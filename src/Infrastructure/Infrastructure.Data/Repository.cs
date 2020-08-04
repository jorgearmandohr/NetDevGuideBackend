using System;
using System.Linq;
using System.Linq.Expressions;

using Domain.Model.Entities;
using Domain.Model.Repository;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly IServiceProvider _provider;
        private readonly DomainDbContext _dbContext;

        public Repository(IServiceProvider provider, DomainDbContext dbContext)
        {
            _provider = provider;
            _dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public IQueryable<T> GetByExpression(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }
    }
}