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
    public class TherapieController : ControllerBase
    {
        private readonly IBaseInterfaceService<Therapie> _baseInterfaceService;
        private readonly IMapper _mapper;

        public TherapieController(IBaseInterfaceService<Therapie> baseInterfaceService, IMapper mapper)
        {
           _baseInterfaceService = baseInterfaceService;
           _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllTherapies()
        {
            var elementMap = _mapper.Map<List<TherapieDto>>(_baseInterfaceService.GetAllElements());
            return Ok(elementMap);
        }


        [HttpGet("{therapieId}")]
        public  IActionResult  GetTherapieById(int therapieId)
        {
            if (!_baseInterfaceService.ElementExists(therapieId)) return BadRequest("Element don't exists !");
            return Ok(_baseInterfaceService.GetElementById(therapieId));
        }


        [HttpPost]
        public IActionResult CreateTherapie(TherapieDto createTherapie)
        {
            if (createTherapie is null) return BadRequest("Empty Forms!");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createElementMap = _mapper.Map<Therapie>(createTherapie);

            if(!_baseInterfaceService.CreateElement(createElementMap))
            {
                ModelState.AddModelError(string.Empty, "Something went wrong on Server !");
                return BadRequest(ModelState);
            }

            return Ok("Successfully Created !");
        }


        [HttpPut("{therapieId}")]
        public IActionResult UpdateTherapie(int therapieId, TherapieDto updateTherapie)
        {
            if (updateTherapie is null) return BadRequest("Empty forms !");

            if (therapieId != updateTherapie.Id) return BadRequest("error : les id ne sont pas identiques !");

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updateElementMap = _mapper.Map<Therapie>(updateTherapie);


            if (!_baseInterfaceService.UpdateElement(updateElementMap))
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
