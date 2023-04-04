using AutoMapper;
using Villa_Web.Models.Dto;

namespace Villa_Web
{   
    public class MappingConfig : Profile    // profile inside Automapper
    {

        public MappingConfig() {
            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();   
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();   

            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();

        }
    }
}


// then add it to program.cs => builder.services
