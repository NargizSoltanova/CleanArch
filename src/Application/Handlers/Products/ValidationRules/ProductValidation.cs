using FluentValidation;
using practice.Domain.Entities;

namespace practice.Application.Handlers.Products.ValidationRules;

public class ProductValidation : AbstractValidator<Product>
{
    public ProductValidation()
    {
        RuleFor(p => p.Name).NotEmpty().NotNull().MaximumLength(200);
        RuleFor(p => p.Price).NotEmpty().NotNull();
        RuleFor(p => p.Count).NotEmpty().NotNull();
    }
}
