using FlowersForum.Api.Models;
using FluentValidation;

namespace FlowersForum.Api.FluentValidators
{
    public class AnswerValidator : AbstractValidator<AnswerVM>
    {
        public AnswerValidator()
        {
            RuleFor(x => x.Text).NotNull().MaximumLength(2000);
            RuleFor(x => x.TopicId).NotNull();
        }
    }
}
