using Cookbook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Cookbook.Patterns.UnitOfWork
{
    public class Repository : IRepository<Recipe>
    {
        protected readonly DbContext dbContext;
        protected readonly DbSet<Recipe> dbSet;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.dbSet = this.dbContext.Set<Recipe>();
        }

        public IEnumerable<Recipe> GetAll()
        {
            return this.dbSet;
        }
        public Recipe Get(int? id)
        {
            return this.dbSet.Find(id);
        }
        public void Create(Recipe item)
        {
            var toCreate = this.dbSet.Find(item.Id);
            if (toCreate == null)
            {
                this.dbSet.Add(item);
            }
        }
        public void Delete(int id)
        {
            var item = this.dbSet.Find(id);
            if (item != null)
            {
                this.dbSet.Remove(item);
            }

        }
        public void Update(Recipe entity)
        {
            this.dbSet.Update(entity);
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
