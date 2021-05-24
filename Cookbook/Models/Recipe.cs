using System;
using System.Collections.Generic;

namespace Cookbook.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public List<Recipe> ChildRecipes { get; set; }
        public List<RecipeHistory> recipeHistory {get;set;}

        public Recipe()
        {
            date = DateTime.Now;
            ChildRecipes = new List<Recipe>();
            recipeHistory = new List<RecipeHistory>();
        }
    
    }
}
