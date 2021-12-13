using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowersForum.Domain.Models
{
    public class SectionModel : BaseModel
    {
        public Guid? ParentId { get; set; }

        public SectionModel Parent { get; set; }

        public ICollection<SectionModel> Subsections { get; set; }

        public ICollection<TopicModel> Topics { get; set; }
    }
}
