using FlowersForum.Api.Models.Users;
using FluentValidation;

namespace FlowersForum.Api.FluentValidators
{
    public class LoginValidator : AbstractValidator<LoginVM>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).EmailAddress().NotEmpty();
            RuleFor(x => x.Password).MinimumLength(8);
        }
    }
}
