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
    public class Therapie_ThrancheHoraireController : ControllerBase
    {
        private readonly IBaseInterfaceService<TherapieTrancheHoraire> _baseInterfaceService;
        private readonly IMapper _mapper;

        public Therapie_ThrancheHoraireController(IBaseInterfaceService<TherapieTrancheHoraire> baseInterfaceService, IMapper mapper)
        {
            _baseInterfaceService = baseInterfaceService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllElements()
        {
            var maListe = _mapper.Map<List<TherapieTrancheHoraireDto>>(_baseInterfaceService.GetAllElements());
            return Ok(maListe);
        }

        [HttpPost]
        public  IActionResult CreateElement(TherapieTrancheHoraireDto createElement)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createElementMap = _mapper.Map<TherapieTrancheHoraire>(createElement);

            if (!_baseInterfaceService.CreateElement(createElementMap))
            {
                ModelState.AddModelError(string.Empty, "Something went worng on server !");
                return BadRequest(ModelState);
            }
            return Ok("Successfully Created !");
        }

    }
}
