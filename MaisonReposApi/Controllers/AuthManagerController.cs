using AutoMapper;
using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Models.Dtos;
using MaisonReposApi.Models.Forms;
using MaisonReposApi.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MaisonReposApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagerController : ControllerBase
    {
        private readonly IAuthManagerService _authManagerService;
        private readonly IPersonnelService _personnelService;
        private readonly IMapper _mapper;

        public AuthManagerController( IAuthManagerService authManagerService, IPersonnelService personnelService, IMapper mapper)
        {
            _authManagerService = authManagerService;
             _personnelService = personnelService;
            _mapper = mapper;
          
        }


        [HttpPost("register")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult RegisterPersonnel([FromBody] RegisterFormPersonnel registerFormPersonnel)
        {
            //Verifie si le formulaire est null (vide)
            if (registerFormPersonnel is null) return BadRequest("Error : Formulaire vide...");

            //Je verifie si le membre du personnel existe à travers son adresse Email
            var personnel = _personnelService.GetAllPersonnels().Where(p => p.Email.Trim().ToUpper() == registerFormPersonnel.Email.ToUpper().Trim()).FirstOrDefault();

            if (personnel != null)
            {
                ModelState.AddModelError("", "Personnel already exists !");
                return StatusCode(422, ModelState);
            }

            //je teste la validition du formulaire
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Personnel newPerso = _mapper.Map<Personnel>(registerFormPersonnel);

            _authManagerService.CreatePasswordHash(registerFormPersonnel.password, out byte[] passwordHash, out byte[] passwordSalt); //Hashage Mdp

            ////Charge les données dans le new Personnel
            newPerso.Nom = registerFormPersonnel.Nom;
            newPerso.Prenom = registerFormPersonnel.Prenom;
            newPerso.Email = registerFormPersonnel.Email;
            newPerso.PasswordHash = passwordHash;
            newPerso.PasswordSalt = passwordSalt;
            newPerso.Matricule = registerFormPersonnel.Matricule;
            newPerso.IsActive = registerFormPersonnel.IsActive;
            newPerso.FonctionId = registerFormPersonnel.fonctionId;

            if (!_authManagerService.RegisterPersonnel(newPerso))
            {
                ModelState.AddModelError("", "Something went wrong on server");
                return StatusCode(500, ModelState);

            }
            return Ok("Successfully created ");

        }

        [HttpPost("Login")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public  IActionResult Login([FromBody] LoginPersonnel loginFormPersonnel)
        {
            // Je vérifie si le formulaire est vide ou pas
            if (loginFormPersonnel is null) return BadRequest("Formulaire vide ....");

            //Validiter du formulaire
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Je verifie si le menbre du personnel existe dans la base de données
            if (!_personnelService.PersonnelExistByEmail(loginFormPersonnel.Email)) return NotFound("Personnel Inexistant !");

            var token = _authManagerService.LoginPersonnel(loginFormPersonnel);
           
            return Ok(token);
        }
    }
}
