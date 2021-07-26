using HandsOnTestGoDigital.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace HandsOnTestGoDigital.Infraestructure.Data.APIMovie.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public EntityState Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public EntityState Update(T entity, string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
