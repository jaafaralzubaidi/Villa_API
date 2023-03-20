using AutoMapper;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Models.Dto;

namespace Villa_VillaAPI
{   
    public class MappingConfig : Profile    // profile inside automapper
    {
        //Automapper works when id, name, Amenity ,....         {
        //Villa model = new()
        //{
        //    Amenity = villaDTO.Amenity,
        //    Details = villaDTO.Details,
        //    Id = villaDTO.Id,
        //    ImageUrl = villaDTO.ImageUrl,
        //    Name = villaDTO.Name,
        //    Occupancy = villaDTO.Occupancy,
        //    Rate = villaDTO.Rate,
        //    Sqft = villaDTO.Sqft,
        //};
        public MappingConfig() {
            CreateMap<Villa, VillaDTO>();   // map from villa to villaDTO
            CreateMap<VillaDTO, Villa>();   // map the reverse 

            CreateMap<Villa, VillaCreateDTO>().ReverseMap(); // shortcut
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap(); // shortcut

            // VillaNumber
            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();

        }
    }
}


// then add it to program.cs => builder.services
