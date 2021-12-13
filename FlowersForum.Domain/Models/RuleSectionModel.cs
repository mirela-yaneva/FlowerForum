using System;
using System.Collections.Generic;

namespace FlowersForum.Domain.Models
{
    public class RuleSectionModel : BaseModel
    {
        public Guid? ParentId { get; set; }

        public RuleSectionModel Parent { get; set; }

        public ICollection<RuleSectionModel> Rules { get; set; }
    }
}
