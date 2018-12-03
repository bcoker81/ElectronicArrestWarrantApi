using System;
using System.Collections.Generic;

namespace ElectronicArrestWarrantApi.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity item);
        void Delete(TEntity item);
        void Dispose();
        IEnumerable<TEntity> FindMany(Func<TEntity, bool> predicate);
        TEntity FindSingle(Func<TEntity, bool> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity Update(int id, TEntity modified);
    }
}