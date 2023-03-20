using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Villa_VillaAPI.Data;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Repository
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _db;   // added it to builder.Services.... in Program.cs

        public VillaRepository(ApplicationDbContext db) {  // using dependecny Injection
            _db = db; 
        }


        public async Task CreateAsync(Villa entity)
        {
           await _db.Villas.AddAsync(entity); // EntityFrameWork will pupulate the Id. model will have id
            await SaveAsync();
        }



        public async Task<Villa> GetAsync(Expression<Func<Villa, bool>> filter = null, bool tracked = true)   
        {
            IQueryable<Villa> query = _db.Villas;

            if(!tracked) // if the query dosen't need to be tracked
            {
                // Error -> The instance of entity type 'Villa' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked
                // this happens because EntityFrameworkCore is tracking the id for villa and then when it tries to update the model it tracks that id but it is the same id as vills
                // AsNoTracking() it tells EntityFrameworkCore when retrive the record don't track that id
                query = query.AsNoTracking();
            }
            if(filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();


        }


        // Get all villas but if needed can apply some filter 
        public async Task<List<Villa>> GetAllAsync(Expression<Func<Villa, bool>> filter = null)
        {
            IQueryable<Villa> query = _db.Villas;   // To apply query on _db.villas

            if(filter != null) // whatever filter will have if not null will apply it
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
           
        }


        public async Task RemoveAsync(Villa entity)
        {
           _db.Villas.Remove(entity);
            await SaveAsync();
        }

        public async Task UpdateAsync(Villa entity)
        {
            _db.Villas.Update(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }


    }
}
