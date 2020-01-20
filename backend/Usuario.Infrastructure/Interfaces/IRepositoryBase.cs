using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using Usuario.Domain.Entities;

namespace Usuario.Infrastructure.Interfaces
{
    public interface IRepositoryBase<TKey,TEntity>
        where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
        where TEntity : BaseEntity<TKey>, IEntity<TKey>
    {
        EntityEntry<TEntity> Insert(TEntity entity);
        EntityEntry<TEntity> Update(TEntity entity);
        IList<TEntity> GetAll();
        TEntity GetById(int Id);
        EntityEntry<TEntity> Delete(TEntity entity);

    }
}

