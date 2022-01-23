using System;
using System.Collections.Generic;

namespace FlowersForum.Data.Entities
{
    public class TopicEntity : BaseEntity
    {
        public Guid? ParentId { get; set; }

        public virtual TopicEntity Parent { get; set; }

        public virtual SectionEntity Section { get; set; }

        public Guid SectionId { get; set; }

        public virtual ICollection<TopicEntity> Subtopics { get; set; }

        public virtual UserEntity User { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
