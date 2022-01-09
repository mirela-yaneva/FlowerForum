using FlowersForum.Domain.Enums;

namespace FlowersForum.Domain.Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public string Salt { get; set; }
    }
}
