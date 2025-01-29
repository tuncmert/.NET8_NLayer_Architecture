using App.Application.Contracts.Persistence;
using FluentValidation;

namespace App.Application.Features.Products.Create
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductRequestValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Product name is required.")
                .NotEmpty().WithMessage("Product name is required.")
                .Length(3, 10).WithMessage("The product name must be between 3 and 10 characters.");
            //.Must(MustUniqueProductName).WithMessage("Product already exists.")

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("The product price must be more than 0.");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("The product must have a category.");

            RuleFor(x => x.Stock)
                .InclusiveBetween(1, 100).WithMessage("The product stock must be between 1 and 100 quantity.");

        }

        //first way sync validation
        //private bool MustUniqueProductName(string name)
        //{
        //    return !_productRepository.Where(x=>x.Name == name).Any();
        //}
    }
}
