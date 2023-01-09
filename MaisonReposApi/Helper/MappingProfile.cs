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

            CreateMap<Personnel, PersonnelDto>();
            CreateMap<PersonnelDto, Personnel>();

            CreateMap<Residant, ResidantDto>();
            CreateMap<ResidantDto, Residant>();

            CreateMap<Residant, FormCreateResidant>();
            CreateMap< FormCreateResidant, Residant>();

            CreateMap<ResidantSuivi, ResidantSuiviDto>();
            CreateMap<ResidantSuiviDto, ResidantSuivi>();

            CreateMap<CategorieDesSoin, CategorieDesSoinsDto>();
            CreateMap< CategorieDesSoinsDto, CategorieDesSoin>();

            CreateMap< SoinsAjout, SoinsAjoutDto>();
            CreateMap<SoinsAjoutDto,SoinsAjout>();
            CreateMap<FormAjoutSoins,SoinsAjout>();
            CreateMap<SoinsAjout,FormAjoutSoins>();



        }
    }
}
