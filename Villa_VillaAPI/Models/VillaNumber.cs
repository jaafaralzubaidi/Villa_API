using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Villa_VillaAPI.Models
{
    public class VillaNumber
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] //primary key, but not identity. don't want the database to generate it. it will be provided by the user
        public int VillaNo { get; set; }

        //foreign key to reference the Villa ID in Villa Table
        [ForeignKey("Villa")] // name of function
        public int VillaID { get; set; }
        //navigation property. Foreign key mapper

        //Entity Framework core can populate the Villa property when get the Villa number in Repository
        public Villa Villa { get; set; } // Navigation property 
        // after running add-migration name...of... it will create index and foreign key in migrations
        // error message: The ALTER TABLE statement conflicted with the FOREIGN KEY constraint "FK_VillasNumbers_Villas_VillaID". The conflict occurred in database "Villa_API", table "dbo.Villas", column 'Id'
        // need to delete the records from the villaNumber table before update-database


        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
