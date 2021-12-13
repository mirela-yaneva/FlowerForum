using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Models
{
    public class AnswerModel : BaseModel
    {
        public Guid TopicId { get; set; }

        public TopicModel Topic { get; set; }

        public string Text { get; set; }
    }
}
