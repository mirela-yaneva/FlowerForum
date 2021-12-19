using System;
using System.Collections.Generic;

namespace FlowersForum.Data.Entities
{
    public class RuleSectionEntity : BaseEntity
    {
        public Guid? ParentId { get; set; }

        public RuleSectionEntity Parent { get; set; }

        public ICollection<RuleSectionEntity> Rules { get; set; }
    }
}
