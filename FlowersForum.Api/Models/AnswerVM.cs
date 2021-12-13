using System;

namespace FlowersForum.Api.Models
{
    public class AnswerVM : BaseVM
    {
        public Guid TopicId { get; set; }

        public TopicVM Topic { get; set; }

        public string Text { get; set; }
    }
}
