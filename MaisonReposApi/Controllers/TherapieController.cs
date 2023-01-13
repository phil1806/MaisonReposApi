using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TherapieController : ControllerBase
    {
        private readonly IBaseInterfaceService<Therapie> _baseInterfaceService;

        public TherapieController(IBaseInterfaceService<Therapie> baseInterfaceService)
        {
           _baseInterfaceService = baseInterfaceService;
        }

        [HttpGet]
        public IActionResult GetAllTherapies()
        {
            return Ok(_baseInterfaceService.GetAllElements());
        }


        [HttpGet("{therapieId}")]
        public  IActionResult  GetTherapieById(int therapieId)
        {
            if (!_baseInterfaceService.ElementExists(therapieId)) return BadRequest("Element don't exists !");
            return Ok(_baseInterfaceService.GetElementById(therapieId));
        }


        [HttpPost]
        public IActionResult CreateTherapie(Therapie createTherapie)
        {
            if (createTherapie is null) return BadRequest("Empty Forms!");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if(!_baseInterfaceService.CreateElement(createTherapie))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on Server !");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Created !");
        }


        [HttpPut("{therapieId}")]
        public IActionResult UpdateTherapie(int therapieId, Therapie updateTherapie)
        {
            if (updateTherapie is null) return BadRequest("Empty forms !");

            if (therapieId != updateTherapie.Id) return BadRequest("error : les id ne sont pas identiques !");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!_baseInterfaceService.UpdateElement(updateTherapie))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on Server !");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Updated !");
        }


        [HttpDelete("{therapieId}")]
        public IActionResult DeleteTherapie(int therapieId)
        {
            if (!_baseInterfaceService.ElementExists(therapieId)) return BadRequest("Element don't exists !");

            var elementToDelete = _baseInterfaceService.GetElementById(therapieId);

            if (!_baseInterfaceService.DeleteElement(elementToDelete))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on Server !");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Deleted !");
        }

    }

}
