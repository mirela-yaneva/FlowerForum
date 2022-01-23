using System;

namespace FlowersForum.Domain.Models
{
    public class RuleSection : BaseModel
    {
        public Guid? ParentId { get; set; }

        public string Name { get; set; }

        public Guid UserId { get; set; }
    }
}
