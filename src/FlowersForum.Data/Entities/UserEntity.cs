using FlowersForum.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowersForum.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public Role Role { get; set; }

        [Required]
        [MaxLength(100)]
        public string Salt { get; set; }

        public virtual List<AnswerEntity> Answers { get; set; }

        public virtual List<TopicEntity> Topics { get; set; }

        public virtual List<SectionEntity> Sections { get; set; }

        public virtual List<RuleSectionEntity> RuleSections { get; set; }
    }
}
