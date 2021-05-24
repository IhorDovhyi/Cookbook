using Cookbook.Models;
using Cookbook.Patterns.UnitOfWork;
using System.Collections.Generic;

namespace CookbookTests
{
    class TestRepository : IRepository<Recipe>
    {
        List<Recipe> recipes;
        bool isSave = false;

        public TestRepository(TestDB testContext)
        {
            recipes = testContext.Recipes;
        }
        public IEnumerable<Recipe> GetAll()
        {
            return this.recipes;
        }
        public void Create(Recipe item)
        {
            recipes.Add(item);
        }

        public void Delete(int id)
        {
            var item = recipes.Find(x => x.Id == id);
            if (item != null)
                recipes.Remove(item);
        }

        public Recipe Get(int? id)
        {
            return recipes.Find(x => x.Id == id);
        }

        public void Update(Recipe item)
        {
            recipes.Find(x => x.Id == item.Id).name = item.name;
            recipes.Find(x => x.Id == item.Id).date = item.date;
            recipes.Find(x => x.Id == item.Id).description = item.description;
            recipes.Find(x => x.Id == item.Id).ChildRecipes = item.ChildRecipes;
        }

        public void Save()
        {
            this.isSave = true;
        }
    }
}
