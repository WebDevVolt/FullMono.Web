using AutoMapper;
using FluentValidation;
using FullMono.Repository.Core;
using FullMono.Repository.Entities;
using FullMono.Service.Validators;
using FullMono.Shared.Dtos;

namespace FullMono.Service.Services
{
    public class OrderService(IUnitOfWork unitOfWork,
        IMapper mapper,
        ICustomerService customerService,
        IValidator<OrderDto> orderValidator) : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly ICustomerService _customerService = customerService;
        private readonly IValidator<OrderDto> _orderValidator = orderValidator;

        public async Task<OrderDto> GetOrderByIdAsync(Guid id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id,
                o => o.Customer,
                o => o.OrderItems
            );

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync(
                o => o.Customer,
                o => o.OrderItems
            );

            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            await ValidationHelper.ValidateDtoAsync(orderDto, _orderValidator);

            var order = _mapper.Map<Order>(orderDto);
            order.Customer = await GetOrInsertCustomer(order.Customer);

            foreach (var item in order.OrderItems)
            {
                item.Order = order;
            }

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<OrderDto>(order);
        }

        private async Task<Customer> GetOrInsertCustomer(Customer customerParam)
        {
            var customer = await _customerService.GetCustomerByIdAsync(customerParam.Id);
            if (customer == null)
            {
                customer = customerParam;
                await _customerService.CreateCustomerAsync(customer);
            }

            return customer;
        }
    }
}
