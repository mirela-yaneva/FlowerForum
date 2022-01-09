using FlowersForum.Api.Models.Users;
using FluentValidation;

namespace FlowersForum.Api.FluentValidators
{
    public class UserValidator : AbstractValidator<UserVM>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 100);
            RuleFor(x => x.LastName).Length(2, 100);
            RuleFor(x => x.UserName).Length(2, 100);
        }
    }
}
