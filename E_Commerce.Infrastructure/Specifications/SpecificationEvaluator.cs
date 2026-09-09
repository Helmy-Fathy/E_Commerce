using E_Commerce.Domain.Common;
using E_Commerce.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Infrastructure.Specifications
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, Tkey>(IQueryable<TEntity> inputQuery, ISpecifications<TEntity, Tkey> spec) where TEntity : BaseEntity<Tkey>
        {
            IQueryable<TEntity> query = inputQuery;
            if (spec != null)
            {
                if (spec.IncludeExpressions.Any())
                {
                    query = spec.IncludeExpressions.Aggregate(query, (current, nextExp) => current.Include(nextExp));
                }
            }

            return query;
        }
    }
}
