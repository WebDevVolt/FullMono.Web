using FullMono.Repository.Entities;

namespace FullMono.Service.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task CreateCustomerAsync(Customer customer);
    }
}