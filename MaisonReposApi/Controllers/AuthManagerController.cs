using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Models.Forms;
using Microsoft.AspNetCore.Mvc;



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
            newPerso.IsActive = registerFormPersonnel.IsActive;
            newPerso.FonctionId = registerFormPersonnel.fonctionId;

            //Je génère de façon aléatoire un matricule pour un personel (GuId + nom)
            do
            {
               newPerso.Matricule = (Guid.NewGuid().ToString().Substring(0,5) + registerFormPersonnel.Nom.Substring(0, 3)).ToUpper();

            } while (_authManagerService.MatriculeExistsPersonnel(newPerso.Matricule));

            //J'execute un update et je teste s'il a bien fonctionné
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
