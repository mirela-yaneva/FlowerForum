using FlowersForum.Api.Models.Users;
using FluentValidation;

namespace FlowersForum.Api.FluentValidators
{
    public class RegisterValidator : AbstractValidator<RegisterUserVM>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 100);
            RuleFor(x => x.LastName).Length(2, 100);
            RuleFor(x => x.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")
                .WithMessage("Password must be at least 8 characters with one capital and one lowercase letter, number and a special symbol");
            RuleFor(x => x.Username).EmailAddress().NotEmpty();
        }
    }
}
