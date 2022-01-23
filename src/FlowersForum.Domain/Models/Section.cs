using System;

namespace FlowersForum.Domain.Models
{
    public class Section : BaseModel
    {
        public Guid? ParentId { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
