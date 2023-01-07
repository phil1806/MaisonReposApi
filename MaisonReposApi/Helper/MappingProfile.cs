using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Models.Dtos;
using MaisonReposApi.Models.Forms;

namespace MaisonReposApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fonction , FonctionDto>();
            CreateMap<FonctionDto, Fonction>();

            CreateMap<Personnel, RegisterFormPersonnel>();
            CreateMap<RegisterFormPersonnel, Personnel>();

        }
    }
}
