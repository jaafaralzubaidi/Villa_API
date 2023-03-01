using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Villa_VillaAPI.Models
{


   
    public class Villa
    {   //Columns will be created in database. will use EntityFrameWorkCore to create the table

        [Key] //will be the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // will be an identity column. Automatically managering the ID
        public int Id { get; set; } // be default 
        public string Name { get; set; }
        public string Rate { get; set; }
        public int Sqft { get; set; } 
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}
    }
}
