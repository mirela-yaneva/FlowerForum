using System;

namespace FlowersForum.Domain.Models
{
    public class Answer : BaseModel
    {
        public Guid TopicId { get; set; }

        public string Text { get; set; }

        public Guid UserId { get; set; }
    }
}
