using Villa_VillaAPI.Data;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;   // added it to builder.Services.... in Program.cs

        // using dependecny Injection
        public VillaNumberRepository(ApplicationDbContext db) : base(db) // pass db to the base calss to Repository<Villa> constructor. it is expecting an ApplicationDbContext
        {  
            _db = db; 
        }

        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.VillasNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }



    }
}
