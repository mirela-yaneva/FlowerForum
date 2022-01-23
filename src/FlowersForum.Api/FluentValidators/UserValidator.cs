using FlowersForum.Api.Models.Users;
using FluentValidation;

namespace FlowersForum.Api.FluentValidators
{
    public class UserValidator : AbstractValidator<UserVM>
    {
        public UserValidator()
        {
        }
    }
}
