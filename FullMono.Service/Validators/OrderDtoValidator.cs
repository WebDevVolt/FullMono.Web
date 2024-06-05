using FluentValidation;
using FullMono.Shared.Dtos;

namespace FullMono.Service.Validators
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(order => order.OrderDate)
                .NotEmpty().WithMessage("Order date is required.")
                .GreaterThan(DateTime.UtcNow).WithMessage("Order date must be in the future.");

            RuleFor(order => order.Customer)
                .SetValidator(new CustomerDtoValidator());

            RuleForEach(order => order.OrderItems)
                .SetValidator(new OrderItemDtoValidator());
        }
    }
}
