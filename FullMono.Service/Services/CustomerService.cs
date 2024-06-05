using FullMono.Repository.Core;
using FullMono.Repository.Entities;

namespace FullMono.Service.Services
{
    public class CustomerService(IUnitOfWork unitOfWork) : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _unitOfWork.Customers.AddAsync(customer);
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {
            return await _unitOfWork.Customers.GetByIdAsync(id);
        }
    }
}
