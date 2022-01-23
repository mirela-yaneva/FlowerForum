using System;

namespace FlowersForum.Api.Models
{
    public class SectionVM : BaseVM
    {
        public Guid? ParentId { get; set; }

        public string Name { get; set; }
    }
}
