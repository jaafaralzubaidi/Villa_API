using System.ComponentModel.DataAnnotations;

namespace Villa_Web.Models.Dto
{


    // Layer between Villa and ApiController
    public class VillaNumberUpdateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaID { get; set; }        //referring to the foreign key
        public string SpecialDetails { get; set; }

    }
}
