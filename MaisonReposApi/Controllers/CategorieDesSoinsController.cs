using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieDesSoinsController : ControllerBase
    {
        private readonly ICategorieDesSoinsService _categorieDesSoinsService;
        private readonly IMapper _mapper;

        public CategorieDesSoinsController(ICategorieDesSoinsService categorieDesSoinsService, IMapper mapper)
        {
            _categorieDesSoinsService = categorieDesSoinsService;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategorieDesSoin>),200)]
        public  IActionResult GetAllCategorieDesSoins()
        {

            return Ok(_mapper.Map<List<CategorieDesSoinsDto>>(_categorieDesSoinsService.GetAllCategorieDesSoins()));
        }


        [HttpGet("categorieId")]
        [ProducesResponseType(typeof(CategorieDesSoin), 200)]
        public  IActionResult GetCategorieDesSoinsById(int categorieId)
        {
            if (!_categorieDesSoinsService.CategorieDesSoinsExits(categorieId))
                return NotFound("Categorie des soins inexistant...");

            var laCategorieMap = _mapper.Map<CategorieDesSoinsDto>(_categorieDesSoinsService.GetCategorieDesSoinsById(categorieId));

            return Ok(laCategorieMap);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategorieDesSoins([FromBody] CategorieDesSoinsDto createCategorie)
        {
            //Verifie que le formulaire n'est pas vide
            if (createCategorie is null) 
                return BadRequest("Formulaire vide...");

            //verifie la validité du formulaire
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Je recupère une categorie si elle existe dans la Db
            var categorie = _categorieDesSoinsService.GetAllCategorieDesSoins().Where(c => c.CategorieSoin.Trim().ToUpper() == createCategorie.CategorieSoin.Trim().ToUpper());

            //Je verifie si la categorie est null
            if (categorie != null) 
                return BadRequest("Categorie existe déjà !");

            CategorieDesSoin categorieDesSoinMap = _mapper.Map<CategorieDesSoin>(createCategorie);

            categorieDesSoinMap.CategorieSoin = createCategorie.CategorieSoin;

            if(!_categorieDesSoinsService.CreateCategorieDesSoins(categorieDesSoinMap))
            {
                ModelState.AddModelError("", "Something went wrong on server");
                return BadRequest(ModelState);
            }

            return Ok("Succefully Created");

        }


        [HttpDelete("categorieId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteCategorieDesSoins(int categorieId)
        {
            //teste si une categorie existe avec cette Id dans la base de donnée
            if (!_categorieDesSoinsService.CategorieDesSoinsExits(categorieId))
                return NotFound("Categorie nom existante...");

            var categorie = _categorieDesSoinsService.GetCategorieDesSoinsById(categorieId);


            //Verifie si l'action de suppresion c'est bien passé
            if(!_categorieDesSoinsService.DeleteCategorieDesSoins(categorie))
            {
                ModelState.AddModelError("", "Something went wrong on server");
                return BadRequest(ModelState);
            }

            return Ok("Succefully Deleted");
        }


        [HttpPut("categorieId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategorieDesSoins(int categorieId,[FromBody] CategorieDesSoinsDto updateCategorie )
        {

            if (updateCategorie is null) return BadRequest("Formulaire vide...");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (categorieId != updateCategorie.Id) return BadRequest(ModelState);

            if (!_categorieDesSoinsService.CategorieDesSoinsExits(categorieId)) return NotFound("Categorie non existante...");

            var categorieMap = _mapper.Map<CategorieDesSoin>(updateCategorie);


            if (!_categorieDesSoinsService.UpdateCategorieDesSoins(categorieMap))
            {
                ModelState.AddModelError("", "Something went wrong on server");
                return BadRequest(ModelState);
            }


            return Ok("Succefully Udpdated");
        }


    }
}
