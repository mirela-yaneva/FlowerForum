using System;

namespace FlowersForum.Data.Entities
{
    public class Answer : BaseEntity
    {
        public Guid TopicId { get; set; }

        public Topic Topic { get; set; }

        public string Text { get; set; }
    }
}
