using FluentValidation;
using FullMono.Shared.Dtos;

public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
{
    public OrderItemDtoValidator()
    {
        RuleFor(item => item.ProductId)
           .NotEmpty().WithMessage("Product ID is required.");

        RuleFor(item => item.OrderId)
            .NotEmpty().WithMessage("Order ID is required.");

        RuleFor(item => item.Quantity)
            .NotEmpty().WithMessage("Quantity is required.")
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
    }
}
