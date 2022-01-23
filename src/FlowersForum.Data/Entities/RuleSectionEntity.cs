using System;
using System.Collections.Generic;

namespace FlowersForum.Data.Entities
{
    public class RuleSectionEntity : BaseEntity
    {
        public Guid? ParentId { get; set; }

        public virtual RuleSectionEntity Parent { get; set; }

        public virtual ICollection<RuleSectionEntity> Rules { get; set; }

        public virtual UserEntity User { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }
    }
}
