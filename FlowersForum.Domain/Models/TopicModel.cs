using System;
using System.Collections.Generic;

namespace FlowersForum.Domain.Models
{
    public class TopicModel : BaseModel
    {
        public Guid? ParentId { get; set; }

        public TopicModel Parent { get; set; }

        public SectionModel Section { get; set; }

        public Guid SectionId { get; set; }

        public ICollection<TopicModel> Subtopics { get; set; }
    }
}
