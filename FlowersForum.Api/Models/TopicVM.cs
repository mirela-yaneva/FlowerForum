using System;
using System.Collections.Generic;

namespace FlowersForum.Api.Models
{
    public class TopicVM : BaseVM
    {
        public Guid? ParentId { get; set; }

        public TopicVM Parent { get; set; }

        public SectionVM Section { get; set; }

        public Guid SectionId { get; set; }

        public ICollection<TopicVM> Subtopics { get; set; }
    }
}
