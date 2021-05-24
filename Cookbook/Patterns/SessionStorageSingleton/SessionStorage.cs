using Cookbook.Models;
using System.Collections.Generic;
using System.Linq;


namespace Cookbook.Patterns.SessionStorageSingleton
{
    public class SessionStorage
    {
        public List<Recipe> SessionRecipes { get; set; }
        private SessionStorage()
        {
            SessionRecipes = new List<Recipe>();
        }
        private static SessionStorage _instance;
        public static SessionStorage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SessionStorage();
            }
            return _instance;
        }

        public Recipe Get(int? id)
        {
            Recipe toReturn;
            toReturn = this.SessionRecipes.FirstOrDefault(x => x.Id == id);

            if(toReturn == null)
            {
                toReturn = GetInChilds(id, SessionRecipes);
            }

            return toReturn;
        }

        private Recipe GetInChilds(int? id, List<Recipe> childs)
        {
            Recipe toReturn = childs.Find(x => x.Id == id);

            foreach (var child in childs)
            {
                if(toReturn == null)
                {
                    toReturn = GetInChilds(id, child.ChildRecipes);
                }
            }

            return toReturn;
        }

        public void Create(Recipe recipe)
        {
            this.SessionRecipes.Add(recipe);
        }

        public void CreateChild(int id, Recipe recipe)
        {
            Get(id).ChildRecipes.Add(recipe);
        }

        public void Update(Recipe recipe)
        {
            Get(recipe.Id).name = recipe.name;
            Get(recipe.Id).date = recipe.date;
            Get(recipe.Id).description = recipe.description;
            Get(recipe.Id).ChildRecipes = recipe.ChildRecipes;
            Get(recipe.Id).recipeHistory = recipe.recipeHistory;
        }

        public void Delete(int id)
        {
           if(!this.SessionRecipes.Remove(Get(id)))
           {
                foreach(var child in SessionRecipes)
                {
                    DeleteInChild(id, child.ChildRecipes);
                }
           }
        }

        private void DeleteInChild(int id, List<Recipe> childs)
        {
            if (!childs.Remove(Get(id)))
            {
                foreach (var child in childs)
                {
                    DeleteInChild(id, child.ChildRecipes);
                }
            }
        }
    }
}
