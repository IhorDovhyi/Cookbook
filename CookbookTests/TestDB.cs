using Cookbook.Models;
using System;
using System.Collections.Generic;

namespace CookbookTests
{
    public class TestDB : IDisposable
    {
        public List<Recipe> Recipes { get; set; }

        public TestDB()
        {
            Recipes = new List<Recipe>()
            {
               new Recipe { Id=1, name = "Apple", date = DateTime.Now, description = "Apple description",
                    recipeHistory = new List<RecipeHistory>(),
                    ChildRecipes = new List<Recipe>() { new Recipe{ Id=2, name = "Apple Child 1 1", date = DateTime.Now, description = "Apple Child 1 1 description", recipeHistory = new List<RecipeHistory>(),
                        ChildRecipes = new List<Recipe>() { new Recipe { Id=3, name = "Alpple Child 2 1", date = DateTime.Now, description = "Alpple Child 2 1 description" , recipeHistory = new List<RecipeHistory>(), ChildRecipes = new List<Recipe>()},
                                                            new Recipe { Id=4, name = "Alpple Child 2 2", date = DateTime.Now, description = "Alpple Child 2 2 description" , recipeHistory = new List<RecipeHistory>(), ChildRecipes = new List<Recipe>()}} } }
                },

                new Recipe { Id=5, name = "Banana", date = DateTime.Now, description = "Banana description", recipeHistory = new List<RecipeHistory>(), ChildRecipes = new List<Recipe>() },

                new Recipe { Id=6, name = "Tomato", date = DateTime.Now, description = "Tomato description",
                    recipeHistory = new List<RecipeHistory>(),
                    ChildRecipes = new List<Recipe>() { new Recipe { Id = 7, name = "Tomato Child 1 1", date = DateTime.Now, description = "Tomato Child 1 1 description", recipeHistory = new List<RecipeHistory>(), ChildRecipes = new List<Recipe>() } } },


                new Recipe { Id=8, name = "Kiwi", date = DateTime.Now, description = "Kiwi description", recipeHistory = new List<RecipeHistory>(), ChildRecipes = new List<Recipe>() },

                new Recipe { Id=9, name = "Pineapple", date = DateTime.Now, description = "Pineapple description",
                    recipeHistory = new List<RecipeHistory>() { new RecipeHistory { date = DateTime.Now, name= "Pineapple", description = "Pineapple description" } },
                    ChildRecipes = new List<Recipe>() }
        };
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
