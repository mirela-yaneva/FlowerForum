using System;
using System.Collections.Generic;

namespace FlowersForum.Data.Entities
{
    public class Topic : BaseEntity
    {
        public Guid? ParentId { get; set; }

        public Topic Parent { get; set; }

        public Section Section { get; set; }

        public Guid SectionId { get; set; }

        public ICollection<Topic> Subtopics { get; set; }
    }
}
