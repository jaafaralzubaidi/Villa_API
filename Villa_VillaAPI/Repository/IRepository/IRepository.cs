using System.Linq.Expressions;
using Villa_VillaAPI.Models;

namespace Villa_VillaAPI.Repository.IRepository
{   

    // will have common code shared between different Repositoryies
    public interface IRepository<T> where T : class     // means where T is a class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);   // (Expression <function<input, output>> filter = null)
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true); //in AsNoTracking ->  await _db.Villas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
