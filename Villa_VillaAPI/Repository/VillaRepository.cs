using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Villa_VillaAPI.Data;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;   // added it to builder.Services.... in Program.cs

        // using dependecny Injection
        public VillaRepository(ApplicationDbContext db) : base(db) // pass db to the base calss to Repository<Villa> constructor. it is expecting an ApplicationDbContext
        {  
            _db = db; 
        }



        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }



    }
}
