using FullMono.Repository.Entities;

namespace FullMono.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Order> Orders { get; }
        IRepository<Customer> Customers { get; }
        Task<int> CompleteAsync();
    }
}
