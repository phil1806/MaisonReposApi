using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToilletteController : ControllerBase
    {
        private readonly IBaseInterfaceService<Toillette> _baseInterfaceService;

        public ToilletteController(IBaseInterfaceService<Toillette> baseInterfaceService)
        {
            _baseInterfaceService = baseInterfaceService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Toillette>), 200)]
        public IActionResult GetAllToilletes()
        {
            return Ok(_baseInterfaceService.GetAllElements());
        }

        [HttpGet("{toilletteId}")]
        [ProducesResponseType(typeof(Toillette), 200)]
        public IActionResult GetToilletteById(int toilletteId)
        {
            if (!_baseInterfaceService.ElementExists(toilletteId)) return NotFound("not exists !");
            return Ok(_baseInterfaceService.GetElementById(toilletteId));
        }

        [HttpPost]
        public IActionResult createToillette([FromBody] Toillette createToillette)
        {
            if (createToillette is null) return BadRequest("Forms is Empty !");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_baseInterfaceService.CreateElement(createToillette))
            {
                return BadRequest("Something went wrong on server !");
            }
            return Ok("create successfully !");
        }

        [HttpPut("{toilletteId}")]
        public IActionResult UpdateToillette(int toilletteId, [FromBody] Toillette UpdateToillette)
        {
            //je verifie si la formulaire n'est pas vide
            if (UpdateToillette is null)
                return BadRequest("Formulaire vide ...");

            //je verifie si l'id entrer et le même que celui du formulaire
            if (toilletteId != UpdateToillette.Id)
                return BadRequest(ModelState);

            // je verifie si la fonction existe d'abord dans la Db
            if (!_baseInterfaceService.ElementExists(toilletteId)) return NotFound();

            if (!ModelState.IsValid)   //Je teste la validiter du formulaire
                return BadRequest(ModelState);

            //Je vertifie updating c'est bien dérouler si non je revois une erreur
            if (!_baseInterfaceService.UpdateElement(UpdateToillette))
            {
                ModelState.AddModelError("", "Something went wrong on server !");
                return BadRequest(ModelState);
            }
            return Ok("Successfully Updated ");

        }

        [HttpDelete("{toilletteId}")]
        public IActionResult DeleteToillette(int toilletteId)
        {
            if (_baseInterfaceService.ElementExists(toilletteId)) return BadRequest("not exists !");

            var elementToDelete = _baseInterfaceService.GetElementById(toilletteId);

            if (!_baseInterfaceService.DeleteElement(elementToDelete))
            {
                ModelState.AddModelError("", "something went wrong on server !");
                return BadRequest(ModelState);
            }
            return Ok("Succefully Deleted !");
        }
    }
    }
