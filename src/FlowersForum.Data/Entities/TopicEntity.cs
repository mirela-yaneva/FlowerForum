using System;
using System.Collections.Generic;

namespace FlowersForum.Data.Entities
{
    public class TopicEntity : BaseEntity
    {
        public Guid? ParentId { get; set; }

        public TopicEntity Parent { get; set; }

        public SectionEntity Section { get; set; }

        public Guid SectionId { get; set; }

        public ICollection<TopicEntity> Subtopics { get; set; }
    }
}
