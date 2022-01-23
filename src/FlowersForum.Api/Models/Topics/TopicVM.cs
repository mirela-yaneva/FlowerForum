using System;

namespace FlowersForum.Api.Models
{
    public class TopicVM : BaseVM
    {
        public Guid? ParentId { get; set; }

        public Guid SectionId { get; set; }

        public string Name { get; set; }
    }
}
