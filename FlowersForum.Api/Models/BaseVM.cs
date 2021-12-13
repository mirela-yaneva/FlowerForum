using System;

namespace FlowersForum.Api.Models
{
    public class BaseVM
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
