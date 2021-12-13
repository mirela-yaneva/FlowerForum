using System;
using System.Collections.Generic;

namespace FlowersForum.Data.Entities
{
    public class RuleSection : BaseEntity
    {
        public Guid? ParentId { get; set; }

        public RuleSection Parent { get; set; }

        public ICollection<RuleSection> Rules { get; set; }
    }
}
