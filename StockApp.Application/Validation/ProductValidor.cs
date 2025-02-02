

using FluentValidation;
using StockApp.Application.Products.Create;

namespace StockApp.Application.Validation;
public class ProductValidator : AbstractValidator<CreateProductCommand>
{
    public ProductValidator(){
        RuleFor(pr => pr.Name).NotEmpty().WithMessage("{PropertyName} is Required");
        RuleFor(pr => pr.Amount).GreaterThan(0).WithMessage("{PropertyName} Can not be zero");
    }
}