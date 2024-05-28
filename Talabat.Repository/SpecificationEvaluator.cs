using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Models;
using Talabat.Core.Specification;

namespace Talabat.Repository
{
    public class SpecificationEvaluator<TEntitiy> where TEntitiy :BaseEntity
    {
        //   public static IQueryable<TEntitiy> GetQuery(dbset,objectofclass)  //dbset alwayes is IQueryable


        public static IQueryable<TEntitiy> GetQuery(IQueryable<TEntitiy> InputQuery , ISpecification<TEntitiy>spec)
        {

            var query = InputQuery;
            if (spec.Criteria is not null)
            
                query = query.Where(spec.Criteria);

            if(spec.OrderBy!=null) 
                query = query.OrderBy(spec.OrderBy);
           else if(spec.OrderByDesc!=null) query = query.OrderByDescending(spec.OrderByDesc);


            if(spec.IsPaginationEnabled)
            query=query.Skip(spec.Skip).Take(spec.Take);


              query= spec.Includes.Aggregate(query, (currentQuery, IncludeExpression) => currentQuery.Include(IncludeExpression)); //includes
            

            return query;
        }
        

    }
}
