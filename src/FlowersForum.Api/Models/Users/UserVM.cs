using FlowersForum.Domain.Enums;

namespace FlowersForum.Api.Models.Users
{
    public class UserVM : BaseVM
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
