using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.IRepositories;
using Talabat.Core.Models;
using Talabat.Core.Specification;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly StoreContext context;
        public GenericRepository(StoreContext context)
        {
            this.context = context;
            
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {

         

            return await context.Set<T>().ToListAsync();
        }


        public async Task<IEnumerable<T>> GetAllWithSpecificationAsync(ISpecification<T> spec)
        {

            return await ApplySpecification(spec) .ToListAsync();
        }


        public async Task<T?> GetByIdAsync(int id)
        {
            //if (typeof(T) == typeof(Product)) {
            //         return await context.Set<Product>().Where(p => p.Id == id).Include(p => p.Brand).Include(p=>p.Category)
            //        .FirstOrDefaultAsync() as T; 
            //        }

          return await context.Set<T>().FindAsync(id);
        }


        public async Task<int> GetCountwithspec(ISpecification<T> spec)
        {
            return await SpecificationEvaluator<T>.GetQuery(context.Set<T>(), spec).CountAsync();
        }


        public async Task<T?> GetByIdWithSpecificationAsync(ISpecification<T> spec)
        {
           return await SpecificationEvaluator<T>.GetQuery(context.Set<T>(),spec).FirstOrDefaultAsync();
        }

      
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>(), spec);
        }

        public async Task AddAsync(T entity) =>await context.Set<T>().AddAsync(entity);
        

        public void Update(T entity)=> context.Set<T>().Update(entity);

        public void Delete(T entity) =>context.Set<T>().Remove(entity);
     
    }
  
}
