using System;

namespace FlowersForum.Data.Entities
{
    public class AnswerEntity : BaseEntity
    {
        public Guid TopicId { get; set; }

        public virtual TopicEntity Topic { get; set; }

        public string Text { get; set; }

        public virtual UserEntity User { get; set; }

        public Guid UserId { get; set; }
    }
}
