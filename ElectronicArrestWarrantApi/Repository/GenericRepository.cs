using ElectronicArrestWarrantApi.Interfaces;
using ElectronicArrestWarrantApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicArrestWarrantApi.Repository
{
    public class GenericRepository<TEntity> : IDisposable, IRepository<TEntity>, IGenericRepository<TEntity> where TEntity : class
    {
        private ArrestWarrantDbContext _context;

        public GenericRepository(ArrestWarrantDbContext context)
        {
            _context = context;
        }

        public GenericRepository()
        {

        }

        public virtual void Add(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
        }

        public void Delete(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
        }

        public virtual TEntity FindSingle(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).SingleOrDefault();
        }

        public virtual IEnumerable<TEntity> FindMany(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity Update(int id, TEntity modified)
        {
            var result = _context.Set<TEntity>().Find(id);
            _context.Entry(result).CurrentValues.SetValues(modified);
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}