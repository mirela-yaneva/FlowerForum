using System;
using System.Collections.Generic;

namespace FlowersForum.Data.Entities
{
    public class SectionEntity : BaseEntity
    {
        public Guid? ParentId { get; set; }

        public virtual SectionEntity Parent { get; set; }

        public ICollection<SectionEntity> Subsections { get; set; }

        public ICollection<TopicEntity> Topics { get; set; }

        public string Name { get; set; }

        public UserEntity User { get; set; }

        public Guid UserId { get; set; }
    }
}
