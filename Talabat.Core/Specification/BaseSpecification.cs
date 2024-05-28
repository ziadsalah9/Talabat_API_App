using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.IRepositories;
using Talabat.Core.Models;

namespace Talabat.Core.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {


        public Expression<Func<T, bool>> Criteria { get; set; } 
        public List<Expression<Func<T, object>>> Includes { get; set; }


        public Expression<Func<T, object>> OrderBy { get; set; }

        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public int Skip { get ; set; }
        public int Take { get ; set; }
        public bool IsPaginationEnabled { get; set; } = false;

        public BaseSpecification()
        {
            //creteria = null ( no where ) --> so return all values

            Includes = new List<Expression<Func<T, object>>>();
            
        }

        public BaseSpecification(Expression<Func<T, bool>> Criteria )
        {
            this.Criteria = Criteria; //where(id == id ) return value match id
            Includes = new List<Expression<Func<T, object>>>();

        }
        
        public void AddOrderBy(Expression<Func<T, object>> OrderByexpression)
        {
            OrderBy = OrderByexpression;
        }

        public void AddOrderBydesc(Expression<Func<T, object>> OrderByDescexpression)
        {
            OrderByDesc = OrderByDescexpression;
        }
                 
        
        
        public void ApplyPagination(int skip , int take)
        {
            IsPaginationEnabled =true;
            Skip = skip;
            Take = take;
        }

       
    }
}
