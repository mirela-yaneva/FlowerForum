using FlowersForum.Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FlowersForum.Data.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        public string Password { get; set; }

        [Required]
        public Role Role { get; set; }

        [Required]
        [MaxLength(100)]
        public string Salt { get; set; }

        public List<AnswerEntity> Answers { get; set; }

        public List<TopicEntity> Topics { get; set; }

        public List<SectionEntity> Sections { get; set; }

        public List<RuleSectionEntity> RuleSections { get; set; }
    }
}
