using System;
using System.Collections.Generic;

namespace FlowersForum.Api.Models
{
    public class RuleSectionVM : BaseVM
    {
        public Guid? ParentId { get; set; }

        public string Name { get; set; }
    }
}
