using FlowersForum.Api.Models;
using FluentValidation;

namespace FlowersForum.Api.FluentValidators
{
    public class PaginatorValidator : AbstractValidator<PaginationBaseVM>
    {
        public PaginatorValidator()
        {
            RuleFor(x => x.PageNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter page number!")
                .GreaterThan(0).WithMessage("Page number must be greater than 0");


            RuleFor(x => x.PageSize)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please enter page size!")
                .GreaterThan(0).WithMessage("Page size must be in 1-20 range.")
                .LessThan(21).WithMessage("Page size must be in 1-20 range.");
        }
    }
}
