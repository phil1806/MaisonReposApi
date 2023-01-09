using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Models.Dtos;
using MaisonReposApi.Models.Forms;
using MaisonReposApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoinsAjoutController : ControllerBase
    {
        private readonly ISoinsAjoutService _soinsAjoutService;
        private readonly IMapper _mapper;
        private readonly ICategorieDesSoinsService _categorieDesSoinsService;

        public SoinsAjoutController(ISoinsAjoutService soinsAjoutService, IMapper mapper, ICategorieDesSoinsService categorieDesSoinsService)
        {
            _soinsAjoutService = soinsAjoutService;
            _mapper = mapper;
            _categorieDesSoinsService = categorieDesSoinsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SoinsAjout>),200)]
        public IActionResult GetAllSoinsAjout()
        {
            var listeDesSoinAjouter = _mapper.Map<IEnumerable<SoinsAjoutDto>>(_soinsAjoutService.GetAllSoinsAjouter());
            return Ok(listeDesSoinAjouter);
        }

        [HttpGet("soinId")]
        [ProducesResponseType(typeof( SoinsAjout), 200)]
        public IActionResult GetSoinsAjoutById(int soinsId)
        {
            if (!_soinsAjoutService.SoinsExistById(soinsId)) return BadRequest("le soins n'existe pas !");

            SoinsAjoutDto soinsAjout = _mapper.Map<SoinsAjoutDto>(_soinsAjoutService.GetSoinsAjoutById(soinsId));

            return Ok(soinsAjout);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSoins([FromBody] FormAjoutSoins createSoins)
        {
            //verifie si le formulaire et vide
            if (createSoins is null) return BadRequest("Formulaire vide ...");

            //Verifie s'il existe une soins du même titre dans la liste  des soins ajoutés
            SoinsAjout leSoins = _soinsAjoutService.GetAllSoinsAjouter().Where(s => s.Titre.Trim().ToUpper() == createSoins.Titre.Trim().ToUpper()).FirstOrDefault();
            
            //je teste si la variable soins est null 
            if(leSoins != null)
            {
                ModelState.AddModelError(string.Empty, "Soins existant");
                return BadRequest(ModelState);
            }

          
            //Je teste si la categorie de soins existe
            if(!_categorieDesSoinsService.CategorieDesSoinsExits(createSoins.CategorieDesSoinsId))
            {
                ModelState.AddModelError(string.Empty, "la categorie choisie n'existe pas !");
                return BadRequest(ModelState);
            }

            //Validité du formulaire
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

   
            SoinsAjout soinsAjouter = _mapper.Map<SoinsAjout>(createSoins);

            //Je charge les données
            soinsAjouter.Titre = createSoins.Titre;
            soinsAjouter.DescSoins = createSoins.DescSoins;
            soinsAjouter.PersonnelCreatedId = createSoins.PersonnelCreatedId;
            soinsAjouter.CategorieDesSoinsId = createSoins.CategorieDesSoinsId;

            if (!_soinsAjoutService.CreateSoinsAjout(soinsAjouter))
            {
                ModelState.AddModelError(String.Empty, "Something went wrong on server !");
                return BadRequest(ModelState);
            }

            return Ok("Succefully created !");
        }

        [HttpDelete("soinsId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public  IActionResult  DeleteSoinsAjouter(int soinsId)
        {
            if (!_soinsAjoutService.SoinsExistById(soinsId)) return BadRequest("Soins inexistant !");

            //recupère le soins
            var soinsToDelete = _soinsAjoutService.GetSoinsAjoutById(soinsId);

            if (!_soinsAjoutService.DeleteSoinsAjout(soinsToDelete))
            {
                ModelState.AddModelError(String.Empty, "Something went wrong on server");
                return BadRequest(ModelState);
            }
            return Ok("Succefully Deleted !");
        }

        [HttpPut("soinsId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        
        public IActionResult UpdateSoinsAjoouter(int soinsId , [FromBody] SoinsAjoutDto updateSoinsAjouter)
        {
            //verifie si le formulaire est vide ou pas
            if (updateSoinsAjouter is null) return BadRequest("Formilaire vide...");

            //teste si les Ids sont identiques
            if (soinsId != updateSoinsAjouter.Id) return BadRequest(ModelState);

            //verifie si le soins existe dans la Db
            if (!_soinsAjoutService.SoinsExistById(soinsId)) return BadRequest("soins non existant");

            //teste la validité du formulaire
            if (!ModelState.IsValid) return BadRequest(ModelState);

            SoinsAjout soinsAjouterMap = _mapper.Map<SoinsAjout>(updateSoinsAjouter);  // Mapping

            //Je vertifie updating c'est bien dérouler si non je revois une erreur
            if (!_soinsAjoutService.UpdateSoinsAjout(soinsAjouterMap))
            {
                ModelState.AddModelError("", "Something went wrong on server !");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Updated ");

        }
    }
}
