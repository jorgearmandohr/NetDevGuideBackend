using System;
using System.Linq;
using System.Linq.Expressions;

using Domain.Model.Entities;

namespace Domain.Model.Repository
{
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Returns all elements with AsNoTracking
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Returns all elements match the condition with Tracking Reference
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<T> GetByExpression(Expression<Func<T, bool>> predicate);
    }
}