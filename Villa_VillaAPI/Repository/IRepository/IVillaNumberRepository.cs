using System.Linq.Expressions;
using Villa_VillaAPI.Models;

namespace Villa_VillaAPI.Repository.IRepository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {   
       
         Task<VillaNumber> UpdateAsync(VillaNumber entity);

    }
}
