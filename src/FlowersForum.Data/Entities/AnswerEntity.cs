using System;

namespace FlowersForum.Data.Entities
{
    public class AnswerEntity : BaseEntity
    {
        public Guid TopicId { get; set; }

        public TopicEntity Topic { get; set; }

        public string Text { get; set; }

        public UserEntity User { get; set; }

        public Guid UserId { get; set; }
    }
}
