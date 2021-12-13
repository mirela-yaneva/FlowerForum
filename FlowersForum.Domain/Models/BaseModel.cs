using System;

namespace FlowersForum.Domain.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
