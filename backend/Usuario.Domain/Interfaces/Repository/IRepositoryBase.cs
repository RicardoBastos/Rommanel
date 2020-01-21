using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Usuario.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        TEntity GetById(Guid? id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}

