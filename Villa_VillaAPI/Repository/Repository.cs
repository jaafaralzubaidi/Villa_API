using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Villa_VillaAPI.Data;
using Villa_VillaAPI.Models;
using Villa_VillaAPI.Repository.IRepository;

namespace Villa_VillaAPI.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;   // added it to builder.Services.... in Program.cs
        internal DbSet<T> dbSet;
        // using dependecny Injection
        public Repository(ApplicationDbContext db)
        {  
            _db = db;
            this.dbSet = _db.Set<T>();
        }


        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity); // EntityFrameWork will pupulate the Id. model will have id
            await SaveAsync();
        }



        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (!tracked) // if the query dosen't need to be tracked
            {
                // Error -> The instance of entity type 'Villa' cannot be tracked because another instance with the same key value for {'Id'} is already being tracked
                // this happens because EntityFrameworkCore is tracking the id for villa and then when it tries to update the model it tracks that id but it is the same id as vills
                // AsNoTracking() it tells EntityFrameworkCore when retrive the record don't track that id
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();


        }


        // Get all villas but if needed can apply some filter 
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;   // To apply query on _db.villas

            if (filter != null) // whatever filter will have if not null will apply it
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();

        }


        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }



    }
}
