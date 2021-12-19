using System.Collections.Generic;

namespace FlowersForum.Domain.Models
{
    public class Section : BaseModel
    {
        public Section Parent { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}
