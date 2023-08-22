using System.Threading;
using System.Threading.Tasks;
using ProductsSystem.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ProductsSystem.Application.Products.Commands.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateProductCommandValidator(IApplicationDbContext context)
        {
            _context = context;


            RuleFor(v => v.Brand)
                .MaximumLength(100).WithMessage("Brand must not exceed 100 characters.")
                .NotEmpty().WithMessage("Brand is required.");

            RuleFor(v => v.ProductCode)
                .MaximumLength(50).WithMessage("ProductCode must not exceed 50 characters.")
                .NotEmpty().WithMessage("ProductCode is required.");

            RuleFor(v => v.Value).NotNull().WithMessage("Value must not exceed 10 characters.")
                .NotEmpty().WithMessage("Value is required.");

            RuleFor(v => v.Id).NotNull();
        }
    }
}
