using System;
using System.Collections.Generic;

namespace FlowersForum.Domain.Models
{
    public class RuleSection : BaseModel
    {
        public Guid? ParentId { get; set; }

        public RuleSection Parent { get; set; }

        public ICollection<RuleSection> Rules { get; set; }
    }
}
