using Cookbook.Models;

namespace Cookbook.Controllers.UseCases
{
    public class HistoryUseCase
    {
        private RecipeHistory newHistory;
        private Recipe modifiedRecipe;

        public HistoryUseCase(Recipe recipe)
        {
            newHistory = new RecipeHistory();
            modifiedRecipe = recipe;
        }

        private void Initialize()
        {
            this.newHistory.name = modifiedRecipe.name;
            this.newHistory.description = modifiedRecipe.description;
            this.newHistory.date = modifiedRecipe.date;
            this.newHistory.child = modifiedRecipe.ChildRecipes.Count;
        }

        private RecipeHistory GetHistory()
        {
            Initialize();
            return this.newHistory;
        }

        public Recipe GetRecipeWithHistory()
        {
            modifiedRecipe.recipeHistory.Add(this.GetHistory());
            return modifiedRecipe;
        }
    }
}
