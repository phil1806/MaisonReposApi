using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Models.Dtos;
using MaisonReposApi.Models.Forms;
using MaisonReposApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidantController : ControllerBase
    {
        private readonly IResidantService _residantService;
        private readonly IMapper _mapper;

        public ResidantController(IResidantService residantService, IMapper mapper)
        {
            _residantService = residantService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Residant>), 200)]
        public IActionResult GetAllResidants()
        {
            IEnumerable<ResidantDto> residants = _mapper.Map<List<ResidantDto>>(_residantService.GetAllResidants());
            return Ok(residants);
        }

        [HttpGet("{residantId}")]
        [ProducesResponseType(typeof(Residant), 200)]
        [ProducesResponseType(400)]
        public IActionResult  GetResidantById(int residantId)
        {
            //je verifie si le residant existe
            if (!_residantService.ResidantExistById(residantId)) return NotFound("Residant Inexistant");

            //On recupère le residant et on le mappe 
            ResidantDto residantMap = _mapper.Map<ResidantDto>(_residantService.GetResidantById(residantId));

            return Ok(residantMap);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateResidant([FromBody] FormCreateResidant formCreateResidant)
        {
            //Verifie si le formulaire n'est pas vide
            if (formCreateResidant is null) return BadRequest("Formulaire vide...");

            // La validité du formulaire
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //On génere un matricule 
            string? matriculeGenerer = "";
            do
            {
                matriculeGenerer = (Guid.NewGuid().ToString().Substring(0, 5) + formCreateResidant.Nom.Substring(0, 3)).ToUpper();

            } while (_residantService.ResidantExistByMatricule(matriculeGenerer));


            Residant residant = _mapper.Map<Residant>(formCreateResidant);

            //je charge des données
            residant.Nom = formCreateResidant.Nom;
            residant.Prenom = formCreateResidant.Prenom;
            residant.Matricule = matriculeGenerer;
            residant.DateNass = formCreateResidant.DateNass;
            residant.DateEntre = formCreateResidant.DateEntre;
            residant.DateSortie = formCreateResidant.DateSortie;
            residant.IsActive = formCreateResidant.IsActive;

            Console.WriteLine(residant);

            //J'execute un update et je teste s'il a bien fonctionné
            if (!_residantService.CreateResidant(residant))
            {
                ModelState.AddModelError("", "Something went wrong on server");
                return StatusCode(500, ModelState);

            }
            return Ok("succeffuly created");
        }


        [HttpPut("{residantId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateResidant(int residantId, [FromBody] ResidantDto updateResidant)
        { 
            //Verifie si le formulaire est vide
            if (updateResidant is null) return BadRequest("Formulaire vide..");

            //on teste si les ids sont identiques
            if (residantId != updateResidant.Id) return BadRequest(ModelState);

            //je teste si le residant  question existe
            if (!_residantService.ResidantExistById(residantId)) return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var residantMap = _mapper.Map<Residant>(updateResidant);

            if (!_residantService.UpdateResidant(residantMap))
            {
                ModelState.AddModelError("", "Something went wrong on server !");
                return BadRequest(ModelState);
            }

            return Ok("Succefully Updated");
        }

        [HttpDelete("{residantId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public  IActionResult DeleteResidant(int residantId)
        {
            //Verifie si le residant est bien existant
            if (!_residantService.ResidantExistById(residantId)) return BadRequest("Residant inexistant !");

            //je recupère le residant
            var residant = _residantService.GetResidantById(residantId);

            //je passe le residant status inactif
            if (residant.IsActive == true)
            {
                residant.IsActive = false;
            }

            //je teste si le residant a bien été désactivé
            if(!_residantService.DeleteResidant(residant))
            {
                ModelState.AddModelError("", "Something went wrong onserver");
                return BadRequest(ModelState);
            }

            return Ok("Succefully Deleted");
        }

    }
}
