using Cookbook.Models;
using Cookbook.Patterns.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Cookbook.Controllers.UseCases
{
    public class PutUseCase
    {
        public IUnitOfWork unitOfWork;
        private HistoryUseCase historyUseCase;
        public PutUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Recipe Execute(Recipe recipe)
        {
            historyUseCase = new HistoryUseCase(recipe);
            this.unitOfWork.Update(historyUseCase.GetRecipeWithHistory());
            this.unitOfWork.Save();
            return recipe;
        }
    }
}
