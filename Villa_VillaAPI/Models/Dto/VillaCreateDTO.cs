using System.ComponentModel.DataAnnotations;

namespace Villa_VillaAPI.Models.Dto
{


    // Layer between Villa and ApiController
    public class VillaCreateDTO
    {
        // validation
        [Required]          // these will work because of [ApiController] in VillaApiController class
        [MaxLength(30)]     // without [ApiController] call use => if(!ModalState.isValid) inside the AcitonResult function
                            // when using [ApiController] and ModalState the modalState will only execute if it passes valid through the [ApiController]
        public string Name { get; set; }

        public int Occupancy { get; set; }
        public string Details { get; set; } // without the ? it will .NET6 will assume it is a required property. Can change that 

 

        /* Right click on project
        * Edit Project File
        * find   <PropertyGroup>
        *           <TargetFramework>net7.0</TargetFramework>
        *           <Nullable>enable</Nullable>
        *           <ImplicitUsings>enable</ImplicitUsings>
        *         </PropertyGroup>
        * change enable to disable or remove the line
        * 
 
        */
        public int Sqft { get; set; }
        [Required]
        public int Rate { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }

    }
}
