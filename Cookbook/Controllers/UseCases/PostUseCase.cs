using Cookbook.Models;
using Cookbook.Patterns.UnitOfWork;

namespace Cookbook.Controllers.UseCases
{
    public class PostUseCase
    {
        public IUnitOfWork unitOfWork;
        public PostUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Recipe Execute(Recipe recipe)
        {
            this.unitOfWork.Create(recipe);
            this.unitOfWork.Save();
            return recipe;
        }
    }
}
