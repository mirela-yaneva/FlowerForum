using System;
using System.Collections.Generic;

namespace FlowersForum.Api.Models
{
    public class RuleSectionVM : BaseVM
    {
        public Guid? ParentId { get; set; }

        public RuleSectionVM Parent { get; set; }

        public ICollection<RuleSectionVM> Rules { get; set; }
    }
}
