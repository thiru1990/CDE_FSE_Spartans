using FluentValidation;
using SellerAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellerAPI.Validator
{
    public class ProductValidator:AbstractValidator<ProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("ProductName should not be null.")
                .MinimumLength(5).WithMessage("Min 5 characters required")
                .MaximumLength(30).WithMessage("Max 30 characters required");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName should not be null.")
                .MinimumLength(5).WithMessage("Min 5 characters required")
                .MaximumLength(30).WithMessage("Max 30 characters required");
        }
    }
}
