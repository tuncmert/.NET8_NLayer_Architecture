using FluentValidation;

namespace App.Application.Features.Products.Update
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Product name is required.")
                .NotEmpty().WithMessage("Product name is required.")
                .Length(3, 10).WithMessage("The product name must be between 3 and 10 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("The product price must be more than 0.");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("The product must have a category.");

            RuleFor(x => x.Stock)
                .InclusiveBetween(1, 100).WithMessage("The product stock must be between 1 and 100 quantity.");

        }
    }
}
