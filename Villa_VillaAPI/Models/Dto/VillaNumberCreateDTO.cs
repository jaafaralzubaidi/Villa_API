using System.ComponentModel.DataAnnotations;

namespace Villa_VillaAPI.Models.Dto
{


    // Layer between Villa and ApiController
    public class VillaNumberCreateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }

    }
}
