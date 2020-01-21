using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Usuario.Domain.Interfaces.Repository;

namespace Usuario.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly UsuarioContext db;

        public RepositoryBase(UsuarioContext context) =>
            db = context;

        public virtual void Add(TEntity obj)
        {
            db.Add(obj);
            db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll() =>
            db.Set<TEntity>().ToList();

        public virtual TEntity GetById(Guid? id) =>
            db.Set<TEntity>().Find(id);

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return db.Set<TEntity>().FirstOrDefault(where);
        }

        public virtual void Remove(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            db.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        private bool _disposed = false;

        ~RepositoryBase() =>
            Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                db.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}
