using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Models.Dtos;
using MaisonReposApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametreController : ControllerBase
    {
        private readonly IParametreService _parametreService;
        private readonly IMapper _mapper;

        public ParametreController(IParametreService parametreService, IMapper mapper)
        {
            _parametreService = parametreService;
        _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Parametre>), 200)]

        public IActionResult GetAllParametres()
        {
          return Ok(_mapper.Map<ICollection<ParametreDto>>(_parametreService.GetAllParametres()));
        }


        [HttpGet("{paramId}")]
        [ProducesResponseType(typeof(Parametre), 200)]
        public IActionResult GetFonctionById(int paramId)
        {
            //Je verifit si la fonction existe dans la Db
            if (!_parametreService.ParametreExist(paramId)) 
                return NotFound();

            //Je recupère la fonction si elle existe vrmaiment et je mappe la Data
            var leParametre = _mapper.Map<ParametreDto>(_parametreService.GetParametreById(paramId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(leParametre);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult AddParametre([FromBody] ParametreDto createParam)
        {
            if (createParam is null) return BadRequest("Fromulaire vide !");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paramToAdd = _mapper.Map<Parametre>(createParam);

            //Je verifie si la requête est ok ?  si pas de soucis  :  si non j'envoie une erreur
            if (!_parametreService.AddParametre(paramToAdd))
            {
                ModelState.AddModelError("", "Something wrong on server!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created ");

        }

        [HttpPut("{paramId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]

        public IActionResult UpdateParametre(int paramId, ParametreDto updateParam)
        {
            //je verifie si la formulaire n'est pas vide
            if (updateParam is null)
                return BadRequest("Formulaire vide ...");

            //je verifie si l'id entrer et le même que celui du formulaire
            if (paramId != updateParam.Id)
                return BadRequest(ModelState);

            // je verifie si la fonction existe d'abord dans la Db
            if (!_parametreService.ParametreExist(paramId)) return NotFound();

            if (!ModelState.IsValid)   //Je teste la validiter du formulaire
                return BadRequest(ModelState);

            var paramToUpdate = _mapper.Map<Parametre>(updateParam);

            //Je vertifie updating c'est bien dérouler si non je revois une erreur
            if (!_parametreService.UpdateParametre(paramToUpdate))
            {
                ModelState.AddModelError("", "Something went wrong on server !");
                return BadRequest(ModelState);
            }
            return Ok("Successfully Updated ");

        }


        [HttpDelete("{paramId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteParametre(int paramId)
        {
            if (!_parametreService.ParametreExist(paramId)) return NotFound("Parametre inexistant !");

            var paramToDelete = _parametreService.GetParametreById(paramId);

            // si tt est ok je delete
            if (!_parametreService.DeleteParametre(paramToDelete))
            {
                ModelState.AddModelError("", "Sommething went wrong on server");
                return StatusCode(422, ModelState);
            }
            return Ok("Successfully Deleted ");

        }

    }
}
