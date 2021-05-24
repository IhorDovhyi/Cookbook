using Cookbook.Models;
using Cookbook.Patterns.SessionStorageSingleton;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Cookbook.Patterns.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWorkOFT<TContext> where TContext : DbContext
    {
        private readonly TContext _context;
        private bool disposed = false;

        SessionStorage sessionStorage;
        IRepository<Recipe> recipeWorkRepo;
        List<Recipe> isNew;
        List<Recipe> isDirty;
        List<Recipe> isDeleted;

        public UnitOfWork(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            sessionStorage = SessionStorage.GetInstance();
            recipeWorkRepo = new Repository(_context);
            isNew = new List<Recipe>();
            isDirty = new List<Recipe>();
            isDeleted = new List<Recipe>();
        }
        public TContext DbContext => _context;
        public List<Recipe> GetAll()
        {
            if (!this.sessionStorage.SessionRecipes.Any())
            {
                this.sessionStorage.SessionRecipes = recipeWorkRepo.GetAll().ToList();
                foreach (var item in recipeWorkRepo.GetAll())
                {
                    this.RegisterNew(item);
                }
            }
            return this.sessionStorage.SessionRecipes;
        }
        public Recipe Get(int? id)
        {
            return this.sessionStorage.Get(id);
        }
        public void Create(Recipe item)
        {
            this.RegisterNew(item);
        }
        public void Update(Recipe item)
        {
            if (this.isDirty.Any(x => x.Id == item.Id))
            {
                this.isDirty.Remove(this.isDirty.Find(x=> item.Id == x.Id)); 
                this.RegisterDirty(item);
            }
            else
            {
                this.RegisterDirty(item);
            }
        }
        public void Delete(int id)
        {
             this.RegisterDeleted(this.sessionStorage.Get(id));
        }
        public void RegisterNew(Recipe entity)
        {
            this.isNew.Add(entity);
        }
        public void RegisterDirty(Recipe entity)
        {
            this.isDirty.Add(entity);
        }
        public void RegisterClean(Recipe entity)
        {
            sessionStorage.SessionRecipes.Add(entity);
        }
        public void RegisterDeleted(Recipe entity)
        {
            this.isDeleted.Add(entity);
        }
        public void Commit()
        {
            CommitNew();
            CommitDirty();
            CommitDeleted();
        }
        internal void CommitNew()
        {
            if (this.isNew.Any())
            {
                foreach (var isnew in this.isNew)
                {
                    if (! this.sessionStorage.SessionRecipes.Any(x=> x.Id==isnew.Id))
                    {
                        this.recipeWorkRepo.Create(isnew);
                        this.sessionStorage.SessionRecipes.Add(isnew);
                    }
                }
                this.isNew.Clear();
            }
        }
        internal void CommitDirty()
        {
            foreach (var isdirty in this.isDirty)
            {
                recipeWorkRepo.Update(isdirty);
                this.sessionStorage.Update(isdirty);
            }

            this.isDirty.Clear();
        }
        internal void CommitDeleted()
        {
            if (this.isDeleted.Any())
            {
                foreach (var isdeleted in this.isDeleted)
                {
                    this.recipeWorkRepo.Delete(isdeleted.Id);
                    this.sessionStorage.Delete(isdeleted.Id);
                }
                this.isDeleted.Clear();
            }
        }
        public void Save()
        {
            Commit();
            recipeWorkRepo.Save();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (recipeWorkRepo != null)
                    {
                        this.isDeleted.Clear();
                        this.isDirty.Clear();
                        this.isNew.Clear();
                    }
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
