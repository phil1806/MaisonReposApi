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
    public class ResidantSuiviController : ControllerBase
    {
        private readonly IResidantSuiviService _residantSuiviService;
        private readonly IMapper _mapper;
        private readonly IResidantService _residantService;

        public ResidantSuiviController(IResidantSuiviService residantSuiviService, IMapper mapper, IResidantService residantService)
        {
            _residantSuiviService = residantSuiviService;
            _mapper = mapper;
            _residantService = residantService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ResidantSuivi>), 200)]
        public IActionResult GetAllResidantSuivis()
        {
            //Je recupère la liste des residant inscrit dans la liste des résidants suivis
            IEnumerable<ResidantSuiviDto> residantSuiviMap = _mapper.Map<IEnumerable<ResidantSuiviDto>>(_residantSuiviService.GetAllResidantSuivis());
            return Ok(residantSuiviMap);
        }

        [HttpGet("{residantSuiviId}")]
        [ProducesResponseType(typeof(ResidantSuivi), 200)]

        public IActionResult GetResidantSuiviById(int residantSuiviId)
        {
            //Verifie si le residant existe dans la liste des residant suivi
            if (!_residantSuiviService.ResidantSuiviExistById(residantSuiviId)) return NotFound("ResidantSuivi don't exists");
            return Ok(_mapper.Map<ResidantSuiviDto>(_residantSuiviService.GetResidantSuiviById(residantSuiviId)));
        }



        [HttpPost("{residantId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public  IActionResult CreateResidantSuivi(int residantId)
        {
            //Je verifie si le residant est existant et Actif
            if ((!_residantService.ResidantExistById(residantId)) || (!_residantService.GetStatusResidant(residantId))) return NotFound("Residant don't exists !");

            //Je recupère le residant
            Residant residant = _residantService.GetResidantById(residantId);

            //Verifie que il existe dans la liste (residants suivis)
            if(_residantSuiviService.ResidantSuiviExistByMatricule(residant.Matricule))
            {
                ModelState.AddModelError(String.Empty,"Residant existe déjà dans la liste");
                return BadRequest(ModelState);
            }

            //Je charge les données récuperés 
            ResidantSuivi newResidantSuivi = new ResidantSuivi();

            newResidantSuivi.Nom = residant.Nom;
            newResidantSuivi.Prenom = residant.Prenom;
            newResidantSuivi.Matricule = residant.Matricule;    
            newResidantSuivi.residantId = residantId;

            //j'active l'inscription et je vérifie si celà bien fonctionné
            if (!_residantSuiviService.CreateResidantSuivi(newResidantSuivi))
            {
                ModelState.AddModelError("", "Something went wrong on server ");
                return BadRequest(ModelState);
            }

            return Ok("Add residant succefully");
        }


        [HttpDelete("{residantSuiviId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteResidantSuivi(int residantSuiviId)
        {
            //Je verifie s'il existe un residant suivi avec l'id passéen paramètre
            if (!_residantSuiviService.ResidantSuiviExistById(residantSuiviId)) return NotFound("Residant don't exists");

            //Je récupère le résidant Suivi
            ResidantSuivi residantSuiviToDelete = _residantSuiviService.GetResidantSuiviById(residantSuiviId);

            //je fais la suppression et je teste si tt c'est bien passé
            if(!_residantSuiviService.DeleteResidantSuivi(residantSuiviToDelete))
            {
                ModelState.AddModelError("", "Something went wrong on server");
                return BadRequest(ModelState);
            }
            return Ok("Succefully Deleting !");
        }

    }
}
