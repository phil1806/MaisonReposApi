using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FonctionController : ControllerBase
    {
        private readonly IFonctionService _fonctionService;
        private readonly IMapper _mapper;

        public FonctionController(IFonctionService fonctionService, IMapper mapper)
        {
            _fonctionService = fonctionService;
           _mapper = mapper;
        }



        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Fonction>), 200)]
        public IActionResult GetAllFonctions()
        {
            var lesFocntions = _mapper.Map<List<FonctionDto>>(_fonctionService.GetAllFonction());
            return Ok(lesFocntions);
        }


        [HttpGet("{fonctionId}")]
        [ProducesResponseType(typeof(Fonction), 200)]
        public IActionResult GetFonctionById(int fonctionId)
        {
            //Je verifit si la fonction existe dans la Db
            if (!_fonctionService.FonctionExitsById(fonctionId))
                return NotFound();

            //Je recupère la fonction si elle existe vrmaiment et je mappe la Data
            var laFonction = _mapper.Map<FonctionDto>(_fonctionService.GetFonctionById(fonctionId));

            return Ok(laFonction); 
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateFonction([FromBody] FonctionDto createFonction)
        {

            //Je teste si le formulaire est vide...

            if (createFonction == null)
                return BadRequest("Fomulaire vide...");

            //Je vérifie si la focntion existe déjà dans la table
            var laFonction = _fonctionService.GetAllFonction().Where(f => f.fonction.Trim().ToLower() == createFonction.fonction.Trim().ToLower()).FirstOrDefault();

            if(laFonction != null)
            {
                ModelState.AddModelError("", "This fonction already exists.. ");
                return StatusCode(422, ModelState);
            }

            //Je vérifie l'etat du formulaire
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Je mappe les données du formulaire
            var fonctionMap = _mapper.Map<Fonction>(createFonction);


            //Je verifie si la requête est ok ?  si pas de soucis  :  si non j'envoie une erreur
            if (!_fonctionService.CreateFonction(fonctionMap))
            {
                ModelState.AddModelError("", "Something wrong on server!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created ");

        }

        [HttpDelete("{fonctionId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteFonction(int fonctionId)
        {

            // je verifie si la fonction existe d'abord dans la Db
            if (!_fonctionService.FonctionExitsById(fonctionId))
                return NotFound();

            //Je recupère la focntion à supprimer
            var fonctionDelete = _fonctionService.GetFonctionById(fonctionId);

            // si tt est ok je delete
            if (!_fonctionService.DeleteFonction(fonctionDelete))
            {
                ModelState.AddModelError("", "Sommething went wrong on server");
                return StatusCode(422, ModelState);
            }
            return Ok("Successfully Deleted ");
        }


        [HttpPut("{fonctionId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public IActionResult UpdateFonction(int fonctionId, [FromBody] FonctionDto updateFonction)
        {
            //je verifie si la formulaire n'est pas vide
            if (updateFonction == null)
                return BadRequest("Formulaire vide ...");

            //je verifie si l'id entrer et le même que celui du formulaire
            if(fonctionId != updateFonction.Id)
                return BadRequest(ModelState);

            // je verifie si la fonction existe d'abord dans la Db
            if (!_fonctionService.FonctionExitsById(updateFonction.Id))
                return NotFound();

            if(!ModelState.IsValid)   //Je teste la validiter du formulaire
                return BadRequest(ModelState);

            var fonctionMap = _mapper.Map<Fonction>(updateFonction);

            //Je vertifie updating c'est bien dérouler si non je revois une erreur
            if (!_fonctionService.UpdateFonction(fonctionMap))
            {
                ModelState.AddModelError("", "Something went wrong on server !");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Updated ");

        }
    }
}
