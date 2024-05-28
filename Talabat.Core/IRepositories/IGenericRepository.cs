using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;
using Talabat.Core.Specification;

namespace Talabat.Core.IRepositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
    
      Task<IEnumerable<T>> GetAllAsync();
      Task <T?> GetByIdAsync(int id);

      Task<IEnumerable<T>> GetAllWithSpecificationAsync(ISpecification<T>spec);
      Task<T?> GetByIdWithSpecificationAsync(ISpecification<T>spec);

      Task<int> GetCountwithspec(ISpecification<T> spec);  

      Task AddAsync (T entity);  

     void Update (T entity);
void Delete (T entity);
    }
}
