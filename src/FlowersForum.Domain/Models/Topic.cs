using System;
using System.Collections.Generic;

namespace FlowersForum.Domain.Models
{
    public class Topic : BaseModel
    {
        public Guid? ParentId { get; set; }

        public Topic Parent { get; set; }

        public Section Section { get; set; }

        public Guid SectionId { get; set; }

        public ICollection<Topic> Subtopics { get; set; }
    }
}
