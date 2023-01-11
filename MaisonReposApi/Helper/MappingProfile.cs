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
            CreateMap<Fonction, FonctionDto>().ReverseMap() ;
            CreateMap<Personnel, RegisterFormPersonnel>().ReverseMap();

            CreateMap<Personnel, PersonnelDto>().ReverseMap();

            CreateMap<Residant, ResidantDto>().ReverseMap();

            CreateMap<Residant, FormCreateResidant>().ReverseMap();

            CreateMap<ResidantSuivi, ResidantSuiviDto>().ReverseMap();

            CreateMap<CategorieDesSoin, CategorieDesSoinsDto>().ReverseMap();

            CreateMap< SoinsAjout, SoinsAjoutDto>().ReverseMap();

            CreateMap<FormAjoutSoins,SoinsAjout>().ReverseMap();

            CreateMap<Parametre,ParametreDto>().ReverseMap();

            CreateMap<TrancheHoireDto,TrancheHoraire>().ReverseMap();




        }
    }
}
