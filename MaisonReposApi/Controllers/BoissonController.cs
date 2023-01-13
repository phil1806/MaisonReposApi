using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoissonController : ControllerBase
    {
        private readonly IBaseInterfaceService<Boisson> _baseInterfaceService;

        public BoissonController(IBaseInterfaceService<Boisson> baseInterfaceService)
        {
            _baseInterfaceService = baseInterfaceService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Boisson>), 200)]
        public IActionResult GetAllBoisson()
        {        
            return Ok(_baseInterfaceService.GetAllElements());
        }

        [HttpGet("{boissonId}")]
        [ProducesResponseType(typeof(Boisson), 200)]
        public IActionResult GetBoissonById(int boissonId)
        {
            if (!_baseInterfaceService.ElementExists(boissonId)) return BadRequest("Elements don't exists");
             return Ok(_baseInterfaceService.GetElementById(boissonId));
        }

        [HttpPost]
        public IActionResult CreateBoisson(Boisson createBoisson)
        {
            if (createBoisson == null) return BadRequest(" Empty forms");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_baseInterfaceService.CreateElement(createBoisson))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on  server");
                return BadRequest(ModelState);
            }
            return Ok("Succesfully Created !");

        }


        [HttpPut("{boissonId}")]
        public IActionResult UpdateBoisson(int boissonId, Boisson updateBoisson)
        {
            if (updateBoisson is null) return BadRequest("Formulaire vide");

            if (boissonId != updateBoisson.Id) return BadRequest("Id sont différents");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elementToUpdate = _baseInterfaceService.GetElementById(boissonId);

            if (!_baseInterfaceService.DeleteElement(elementToUpdate))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on  server");
                return BadRequest(ModelState);
            }
            return Ok("Succesfully Updated !");
        }

        
        [HttpDelete("{boissonId}")]
        public IActionResult DeleteBoisson(int boissonId)
        {
            if (!_baseInterfaceService.ElementExists(boissonId)) return NotFound("Elements Dont't exists");

            var elementToDelete =  _baseInterfaceService.GetElementById(boissonId);

            if (!_baseInterfaceService.DeleteElement(elementToDelete))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on  server");
                return BadRequest(ModelState);
            }

            return Ok("Succesfully Deleted");
        }



    }
}
