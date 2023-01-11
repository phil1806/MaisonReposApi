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
    public class TrancheHoraireController : ControllerBase
    {
        private readonly IBaseInterfaceService<TrancheHoraire> _baseInterfaceService;
        private readonly IMapper _mapper;

        public TrancheHoraireController(IBaseInterfaceService<TrancheHoraire> baseInterfaceService, IMapper mapper)
        {
            _baseInterfaceService = baseInterfaceService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TrancheHoraire>), 200)]
        public IActionResult GetAllTrancheHoraire()
        {
            var listedesTrancheHoiraires = _mapper.Map<IEnumerable<TrancheHoireDto>>(_baseInterfaceService.GetAllElements());
            return Ok(listedesTrancheHoiraires);
        }

        [HttpGet("{trancheId}")]
        [ProducesResponseType(typeof(TrancheHoraire), 200)] 
        public IActionResult GetTrancheHoraireById(int trancheId)
        {
           //teste si le tranche existe
            if(!_baseInterfaceService.ElementExists(trancheId)) return BadRequest("NOT EXISTS !");

            var laTranche = _mapper.Map<TrancheHoireDto>(_baseInterfaceService.GetElementById(trancheId));
           
            return Ok(laTranche);
       
        }

        [HttpDelete("{trancheId}")]
        public IActionResult DeleteTrancheHoiraire(int trancheId)
        {
            if (_baseInterfaceService.ElementExists(trancheId)) return BadRequest("not exists !");

            var elementToDelete = _baseInterfaceService.GetElementById(trancheId);

            if(!_baseInterfaceService.DeleteElement(elementToDelete))
            {
                ModelState.AddModelError("", "something went wrong on server !");
                return BadRequest(ModelState);
            }
            return Ok("Succefully Deleting !");

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTrancheHoiraire([FromBody] TrancheHoireDto createTrancheHoraire)
        {
            if (createTrancheHoraire is null) return BadRequest("Formulaire vide !");

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var trancheHoraireMap = _mapper.Map<TrancheHoraire>(createTrancheHoraire);


            if (!_baseInterfaceService.CreateElement(trancheHoraireMap))
            {
                ModelState.AddModelError(string.Empty, "something went wrong on server !");
                return BadRequest(ModelState);
            }        
           return Ok("sucessfully creating!");
        }


        [HttpPut("{trancheId}")]
        public IActionResult UpdateTrancheHoiraire( int trancheId , TrancheHoireDto updateTrancheHoraire)
        {
            if (updateTrancheHoraire is null) return BadRequest("Forms is empty !");

            if (!_baseInterfaceService.ElementExists(trancheId)) return NotFound("Element don't exists");

            if (trancheId != updateTrancheHoraire.Id) return BadRequest("id is not same !");

            var elementToUpdate = _mapper.Map<TrancheHoraire>(updateTrancheHoraire);

            if (!_baseInterfaceService.UpdateElement(elementToUpdate))
            {
                ModelState.AddModelError(string.Empty, "something went wrong on server !");
                return BadRequest(ModelState);

            }
            return Ok("sucessfully Updating!");

        }
    }
}
