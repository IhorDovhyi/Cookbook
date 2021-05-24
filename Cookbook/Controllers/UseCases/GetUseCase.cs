using Cookbook.Models;
using Cookbook.Patterns.UnitOfWork;
using System.Collections.Generic;

namespace Cookbook.Controllers.UseCases
{
    public class GetUseCase
    {
        public IUnitOfWork unitOfWork;
        public GetUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Recipe> Execute()
        {
            List<Recipe> toReturn = this.unitOfWork.GetAll();
            this.unitOfWork.Save();
            return toReturn;
        }

        public Recipe Execute(int id)
        {
            Recipe toReturn = this.unitOfWork.Get(id);
            this.unitOfWork.Save();
            return toReturn;
        }
    }
}
