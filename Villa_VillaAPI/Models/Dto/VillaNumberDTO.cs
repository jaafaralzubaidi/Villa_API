using System.ComponentModel.DataAnnotations;

namespace Villa_VillaAPI.Models.Dto
{


    // Layer between Villa and ApiController
    public class VillaNumberDTO
    {
        [Required]
        public int VillaNo { get; set; }
        public string SpecialDetails { get; set; }

    }
}
