namespace Cookbook.Patterns.UnitOfWork
{
    public interface IUnitOfWorkOFT<TContext> : IUnitOfWork where TContext : class
    {
        TContext DbContext { get; }
    }
}
