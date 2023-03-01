using System.ComponentModel.DataAnnotations;

namespace Villa_VillaAPI.Models.Dto
{


    // Layer between Villa and ApiController
    public class VillaDTO
    {
        public int Id { get; set; }
        // validation
        [Required]          // these will work because of [ApiController] in VillaApiController class
        [MaxLength(30)]     // without [ApiController] call use => if(!ModalState.isValid) inside the AcitonResult function
                            // when using [ApiController] and ModalState the modalState will only execute if it passes valid through the [ApiController]
        public string Name { get; set; }

        public int Occupancy { get; set; }
        public int Sqft { get; set; }
        [Required]
        public string Rate { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }

    }
}
