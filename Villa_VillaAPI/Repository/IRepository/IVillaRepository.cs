using System.Linq.Expressions;
using Villa_VillaAPI.Models;

namespace Villa_VillaAPI.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {   
       
         Task<Villa> UpdateAsync(Villa entity);

    }
}
