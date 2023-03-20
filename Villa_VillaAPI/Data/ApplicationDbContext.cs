using Microsoft.EntityFrameworkCore; // allows to use link statments and automatically translated to SQL statments
using Villa_VillaAPI.Models;

namespace Villa_VillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        // in Constructor -> passing the connection string to the base class (DbContext) from program.cs (( builder.Services.AddDbContext ...)
        // this step is needed to configure EntityFrameWorkCore
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //2nd step: is migration
        // Tools -> NuGet Package Manger -> package manager console ->
        // run script -> add-migration meaningfulName  => it will create a new folder called Migrations 
        // then       -> update-database

        public DbSet<Villa> Villas { get; set; } // function name (Villas) will be the table name in the DB


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Details = "some random text. some random text some random text",
                    ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa3.jpg",
                    Occupancy = 5,
                    Rate = 200,
                    Sqft = 400,
                    Amenity = "",
                    CreatedDate = DateTime.Now,

                },
                 new Villa
                 {
                     Id = 2,
                     Name = "Premium Pool Villa",
                     Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                     ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa1.jpg",
                     Occupancy = 4,
                     Rate = 300,
                     Sqft = 550,
                     Amenity = "",
                     CreatedDate = DateTime.Now
                 },
              new Villa
              {
                  Id = 3,
                  Name = "Luxury Pool Villa",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa4.jpg",
                  Occupancy = 4,
                  Rate = 400,
                  Sqft = 750,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              },
              new Villa
              {
                  Id = 4,
                  Name = "Diamond Villa",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa5.jpg",
                  Occupancy = 4,
                  Rate = 550,
                  Sqft = 900,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              },
              new Villa
              {
                  Id = 5,
                  Name = "Diamond Pool Villa",
                  Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageUrl = "https://dotnetmastery.com/bluevillaimages/villa2.jpg",
                  Occupancy = 4,
                  Rate = 600,
                  Sqft = 1100,
                  Amenity = "",
                  CreatedDate = DateTime.Now
              }
                );
        }
    }
}
