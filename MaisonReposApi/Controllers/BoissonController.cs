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
            return Ok(_baseInterfaceService.GetElementById(boissonId));
        }

        [HttpPost]
        public IActionResult CreateBoisson(Boisson createBoisson)
        {
            return Ok();
        }

        [HttpPut("{boissonId}")]
        public IActionResult UpdateBoisson(int boissonId, Boisson updateBoisson)
        {
            return Ok();
        }


        [HttpDelete("{boissonId}")]
        public IActionResult DeleteBoisson(int boisonId)
        {
            if (!_baseInterfaceService.ElementExists(boisonId)) return NotFound("Dont't exists");

          
            return Ok();
        }



    }
}
