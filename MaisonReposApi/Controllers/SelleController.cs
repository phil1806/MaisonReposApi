using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelleController : ControllerBase
    {
        private readonly IBaseInterfaceService<Selle> _baseInterfaceService;
        private readonly IMapper _mapper;

        public SelleController(IBaseInterfaceService<Selle> baseInterfaceService, IMapper mapper)
        {
            _baseInterfaceService = baseInterfaceService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Selle>), 200)]
        public IActionResult GetAllSelles()
        {
            return Ok(_baseInterfaceService.GetAllElements());
        }

        [HttpGet("{selleId}")]
        [ProducesResponseType(typeof(Selle), 200)]
        public IActionResult GetSelleById(int selleId)
        {
            if (!_baseInterfaceService.ElementExists(selleId)) return BadRequest("Elements don't exists");
            return Ok(_baseInterfaceService.GetElementById(selleId));
        }

        [HttpPost]
        public IActionResult CreateSelle(Selle createSelle)
        {
            if (createSelle is null) return BadRequest("Empty form !");
             
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_baseInterfaceService.CreateElement(createSelle))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on  serve");
                return BadRequest(ModelState);
            }
            return Ok("Succesfully updated");

        }

        [HttpPut("{selleId}")]
        public IActionResult UpdateSelle(int selleId, Selle updateSelle )
        {
            if (!_baseInterfaceService.ElementExists(selleId)) return BadRequest("element don't exits");

            if (selleId != updateSelle.Id) return BadRequest("Id ne sont pas identiques");

            if (updateSelle is null) return BadRequest("Formulaire vide !");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_baseInterfaceService.UpdateElement(updateSelle))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on  server");
                return BadRequest(ModelState);
            }

            return Ok("Successfully updated");

        }

        [HttpDelete("{selleId}")]
        public IActionResult DeleteSelle(int selleId)
        {
            if (!_baseInterfaceService.ElementExists(selleId)) return BadRequest("Element don't exits");

            var elementToDelte = _baseInterfaceService.GetElementById(selleId);

            if (!_baseInterfaceService.DeleteElement(elementToDelte))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on  server");
                return BadRequest(ModelState);
            }

            return Ok("Succesfully Deleted");
        }
    }
}
