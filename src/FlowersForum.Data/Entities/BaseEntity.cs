using System;
using System.ComponentModel.DataAnnotations;

namespace FlowersForum.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
