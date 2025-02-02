

using FluentValidation;

namespace StockApp.Application.Products.Create;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(4);
        RuleFor(p => p.Amount).GreaterThan(0);
    }
}