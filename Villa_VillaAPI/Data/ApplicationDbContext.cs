using Microsoft.EntityFrameworkCore; // allows to use link statments and automatically translated to SQL statments
using Villa_VillaAPI.Models;

namespace Villa_VillaAPI.Data
{
    public class ApplicationDbContext: DbContext
    {

        // in Constructor -> passing the connection string to the base class (DbContext) from program.cs (( builder.Services.AddDbContext ...)
        // this step is needed to configure EntityFrameWorkCore
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //2nd step: is migration
        // Tools -> NuGet Package Manger -> package manager console ->
        // run script -> add-migration meaningfulName  => it will create a new folder called Migrations 
        // then       -> update-database

        public DbSet<Villa> Villas { get; set; } // function name (Villas) will be the table name in the DB
    }
}
