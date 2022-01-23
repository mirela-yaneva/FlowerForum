using System;

namespace FlowersForum.Domain.Models
{
    public class Topic : BaseModel
    {
        public Guid? ParentId { get; set; }

        public Guid SectionId { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
