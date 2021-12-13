using System;
using System.Collections.Generic;

namespace FlowersForum.Data.Entities
{
    public class Section : BaseEntity
    {
        public Guid? ParentId { get; set; }

        public Section Parent { get; set; }

        public ICollection<Section> Subsections { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}
