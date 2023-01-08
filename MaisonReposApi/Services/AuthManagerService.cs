using AutoMapper;
using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Models.Forms;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MaisonReposApi.Services
{
    public class AuthManagerService : IAuthManagerService
    {
        private readonly MyDbContext _context;
        private readonly IPersonnelService _personnelService;
        private readonly string _secretKey;


        //Contructor
        public AuthManagerService(MyDbContext context, IPersonnelService personnelService, IConfiguration configuration)
        {
            _context = context;
            _personnelService = personnelService;
            _secretKey = configuration.GetSection("TokenInfo").GetSection("secret").Value;
        }



        /// <summary>
        /// Permet s'identifier sur l'application
        /// </summary>
        /// <param name="loginPersonnel"></param>
        /// <returns>String (token)</returns>
        public string LoginPersonnel(LoginPersonnel loginPersonnel)
        {
            //Je recupère menbre du Personnel avec le  Email correspondant
           Personnel personnel = _personnelService.GetPersonnelByEmail( loginPersonnel.Email );
           
            //je verifie si le password est ok
            if(!VerifyPasswordHash(loginPersonnel.Password, personnel.PasswordHash, personnel.PasswordSalt))
            {
                return "Error: wrong Password !";
            }

            return GenerateToken(personnel);
        }


        /// <summary>
        /// Permet d'enregister un menbre du Personel
        /// </summary>
        /// <param name="registerFormPersonnel"></param>
        /// <returns>Booleean</returns>
        public bool RegisterPersonnel(Personnel personnel)
        {
            _context.Add(personnel);
            return Save();
        }

        /// <summary>
        /// Permet d'enregistrer une Data dans la base de données,
        /// </summary>
        /// <returns>Boolean</returns>
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }


        /// <summary>
        /// Permet le hashage du mot de passe
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }


        /// <summary>
        /// Permet la vérification du mot de passe
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns>Boolean</returns>
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var compteHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return compteHash.SequenceEqual(passwordHash);

            }
        }


        /// <summary>
        /// Permet de génerer le token 
        /// </summary>
        /// <param name="personnel"></param>
        /// <returns>String (token)</returns> 
        public string GenerateToken(Personnel personnel)
        {
            //Creation de la signiature du token
            SymmetricSecurityKey SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            SigningCredentials credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //Création des Payloads - claims
            List<Claim> myClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, personnel.Nom),
                new Claim(ClaimTypes.Email, personnel.Email),
                new Claim("PersonelId", personnel.Id.ToString())
            };

            //configuration token
            JwtSecurityToken token = new JwtSecurityToken(
                claims: myClaims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials

             );

            //je crée un gestionnaire de Token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// Permet s'il existe déjà un matricule identique dans la Base de données 
        /// </summary>
        /// <param name="matricule"></param>
        /// <returns>Boolean</returns>
        public bool MatriculeExistsPersonnel(string matricule)
        {
            return _context.Personnels.Any(m => m.Matricule.ToUpper() == matricule.ToUpper());
        }
   
    }
}
