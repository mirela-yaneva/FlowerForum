using System;
using System.Collections.Generic;

namespace FlowersForum.Api.Models
{
    public class SectionVM : BaseVM
    {
        public Guid? ParentId { get; set; }

        public SectionVM Parent { get; set; }

        public ICollection<SectionVM> Subsections { get; set; }

        public ICollection<TopicVM> Topics { get; set; }
    }
}
