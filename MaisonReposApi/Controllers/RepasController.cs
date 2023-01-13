using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepasController : ControllerBase
    {
        private readonly IBaseInterfaceService<Repas> _baseInterfaceService;
        private readonly IMapper _mapper;

        public RepasController(IBaseInterfaceService<Repas> baseInterfaceService, IMapper mapper)
        {
            _baseInterfaceService = baseInterfaceService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Repas>), 200)]
        public IActionResult GetAllToillette()
        {     
            return Ok(_baseInterfaceService.GetAllElements());
        }

        [HttpGet("{repasId}")]
        [ProducesResponseType(typeof(Repas), 200)]
        public IActionResult GetToilletteById(int RepasId)
        {
            if (!_baseInterfaceService.ElementExists(RepasId)) return NotFound("Element don't exists !");
            return Ok(_baseInterfaceService.GetElementById(RepasId));
        }

        [HttpPost]
        public IActionResult createToillette([FromBody] Repas createRepas)
        {
            if (createRepas is null) return BadRequest("Forms is Empty !");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_baseInterfaceService.CreateElement(createRepas))
            {
                return BadRequest("Something went wrong on server !");
            }
            return Ok(" successfully  created !");
        }

        [HttpPut("{RepasId}")]
        public IActionResult UpdateToillette(int RepasId, [FromBody] Repas UpdateRepas)
        {
            //je verifie si la formulaire n'est pas vide
            if (UpdateRepas is null)
                return BadRequest("Formulaire vide ...");

            //je verifie si l'id entrer et le même que celui du formulaire
            if (RepasId != UpdateRepas.Id)
                return BadRequest(ModelState);

            // je verifie si la fonction existe d'abord dans la Db
            if (!_baseInterfaceService.ElementExists(RepasId)) return NotFound();

            if (!ModelState.IsValid)   //Je teste la validiter du formulaire
                return BadRequest(ModelState);

            //Je vertifie updating c'est bien dérouler si non je revois une erreur
            if (!_baseInterfaceService.UpdateElement(UpdateRepas))
            {
                ModelState.AddModelError("", "Something went wrong on server !");
                return BadRequest(ModelState);
            }
            return Ok("Successfully Updated ");
      
        }

        [HttpDelete("{RepasId}")]
        public IActionResult DeleteToillette(int RepasId)
        {
            if (_baseInterfaceService.ElementExists(RepasId)) return BadRequest("not exists !");

            var elementToDelete = _baseInterfaceService.GetElementById(RepasId);

            if (!_baseInterfaceService.DeleteElement(elementToDelete))
            {
                ModelState.AddModelError("", "something went wrong on server !");
                return BadRequest(ModelState);
            }
            return Ok("Successfully Deleted !");
        }


    }
}
