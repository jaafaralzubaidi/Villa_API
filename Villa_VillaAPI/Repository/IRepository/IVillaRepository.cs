using System.Linq.Expressions;
using Villa_VillaAPI.Models;

namespace Villa_VillaAPI.Repository.IRepository
{
    public interface IVillaRepository
    {   
       
        Task<List<Villa>> GetAllAsync(Expression<Func<Villa, bool>> filter = null);   // (Expression <function<input, output>> filter = null)
        Task<Villa> GetAsync(Expression<Func<Villa,bool>> filter = null, bool tracked = true); //in AsNoTracking ->  await _db.Villas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        Task CreateAsync(Villa entity);
        Task RemoveAsync(Villa entity);
        Task UpdateAsync(Villa entity);
        Task SaveAsync();
    }
}
