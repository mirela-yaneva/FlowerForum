using FlowersForum.Domain.Enums;

namespace FlowersForum.Domain.Models
{
    public class User : BaseModel
    {
        public string Email { get; set; }

        public Role Role { get; set; }

        public string Salt { get; set; }
    }
}
