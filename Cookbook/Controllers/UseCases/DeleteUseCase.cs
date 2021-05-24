using Cookbook.Patterns.UnitOfWork;

namespace Cookbook.Controllers.UseCases
{
    public class DeleteUseCase
    {
        public IUnitOfWork unitOfWork;
        public DeleteUseCase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool Execute(int Id)
        {
            bool key = false;
            this.unitOfWork.Delete(Id);
            key = true;
            this.unitOfWork.Save();
            return key;
        }
    }
}
