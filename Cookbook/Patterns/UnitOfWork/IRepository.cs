using System.Collections.Generic;

namespace Cookbook.Patterns.UnitOfWork
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int? id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
        void Save();
    }

}
