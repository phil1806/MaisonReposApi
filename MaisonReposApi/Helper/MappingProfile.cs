using AutoMapper;
using MaisonReposApi.Entities;
using MaisonReposApi.Models.Dtos;

namespace MaisonReposApi.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Fonction , FonctionDto>();
            CreateMap<FonctionDto, Fonction>();

        }
    }
}
