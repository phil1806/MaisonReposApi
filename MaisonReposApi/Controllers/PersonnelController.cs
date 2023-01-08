using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonnelController : ControllerBase
    {
        private readonly IPersonnelService _personnelService;
        private readonly IMapper _mapper;

        public PersonnelController(IPersonnelService personnelService, IMapper mapper)
        {
           _personnelService = personnelService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Personnel>), 200)]
        public IActionResult GetAllPersonnels()
        {
            IEnumerable<PersonnelDto> ListeDuPersonnel = _mapper.Map<List<PersonnelDto>>(_personnelService.GetAllPersonnels());

            if (ListeDuPersonnel.Count() == 0 )
                return BadRequest("Liste vide..");
            return Ok(ListeDuPersonnel);
        }



        [HttpGet("personnel/{persoId}")]
        [ProducesResponseType(typeof(Personnel), 200)]
        public IActionResult GetPersonnelById(int persoId)
        {
            //verifie si la personne existe
            if (!_personnelService.PersonnelExistById(persoId))
                return NotFound();

            PersonnelDto personnel = _mapper.Map<PersonnelDto>(_personnelService.GetPersonnelById(persoId));

            return Ok(personnel);
        }


        [HttpDelete("{persoId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeletePersonnel(int persoId)
        {
            //verifie si la personne existe
            if (!_personnelService.PersonnelExistById(persoId))
                return NotFound();

            //Je recupère la personne à delete
            Personnel personneTolDelete = _personnelService.GetPersonnelById(persoId);

            //Je teste si le personnel est actif si c'est je  désactive 
            if(personneTolDelete.IsActive == true)
            {
                personneTolDelete.IsActive = false;
            }

            if (!_personnelService.DeletePersonnel(personneTolDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Personnel");
            }
            return Ok("Deleted successfully");
        }


        [HttpPut("{persoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdatePersonnel(int persoId , [FromBody] PersonnelDto updatePersonnel)
        {
            //on teste si le formulaire est vide
            if (updatePersonnel is null) return BadRequest("formualaire vide...");

            //on teste si les ids sont identiques
            if (persoId != updatePersonnel.Id) return BadRequest(ModelState);

            //teste si le menbre du personnel en question existe
            if (!_personnelService.PersonnelExistById(persoId)) return NotFound();

            //Je fais un mapping
            Personnel persoMap = _mapper.Map<Personnel>(updatePersonnel);

            if (!_personnelService.UpdatePerrsonnel(persoMap))
            {
                ModelState.AddModelError("", "Something went wrong in Updating!");
                StatusCode(500, ModelState);
            }
            return Ok("Update successfully !");
        }
    }
}
