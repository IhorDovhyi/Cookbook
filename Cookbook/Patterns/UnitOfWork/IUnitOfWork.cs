using Cookbook.Models;
using System;
using System.Collections.Generic;

namespace Cookbook.Patterns.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        List<Recipe> GetAll();
        Recipe Get(int? id);
        void Create(Recipe item);
        void Update(Recipe item);
        void Delete(int id);
        void RegisterNew(Recipe entity);
        void RegisterDirty(Recipe entity);
        void RegisterClean(Recipe entity);
        void RegisterDeleted(Recipe entity);
        public void Commit();
        public void Save();
    }
}
