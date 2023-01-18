using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;
using MaisonReposApi.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoinsAjout_ResidentSuiviController : ControllerBase
    {
        private readonly IBaseInterfaceService<SoinsAjoutResidantSuivi> _baseInterfaceService;
        private readonly IMapper _mapper;

        public SoinsAjout_ResidentSuiviController(IBaseInterfaceService<SoinsAjoutResidantSuivi> baseInterfaceService ,IMapper mapper)
        {
           _baseInterfaceService = baseInterfaceService;
           _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(ICollection<SoinsAjoutResidantSuivi>),200)]
        public IActionResult GetAllElements()
        {
            var listeElements = _mapper.Map<List<SoinsAjoutResidantSuiviDto>>(_baseInterfaceService.GetAllElements());
            return Ok(listeElements);
        }

        [HttpPost]
        public  IActionResult CreateElement(SoinsAjoutResidantSuiviDto createElement)
        {
            if (createElement is null) return BadRequest("Empty Forms");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var elementToCreate = _mapper.Map<SoinsAjoutResidantSuivi>(createElement);

            if(!_baseInterfaceService.CreateElement(elementToCreate))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on server");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Created !");

        }


        [HttpDelete("{elementId}")]
        public IActionResult DeleteElement(int elementId)
        {
            if(!_baseInterfaceService.ElementExists(elementId)) return BadRequest("Element don't exists");

            var elementToDelete = _baseInterfaceService.GetElementById(elementId);


            if(!_baseInterfaceService.DeleteElement(elementToDelete))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on serve");
                return BadRequest(ModelState);
            }
            return Ok("Successfully Deleted");
        }




    }
}
