using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator :AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.ProductName).NotNull();
            RuleFor(x => x.ProductName).MaximumLength(100);
            RuleFor(x => x.Price).NotNull();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(p => p.CreatedUserId).NotNull();
            RuleFor(p => p.CreatedDate).NotNull();
        }
    }
}
