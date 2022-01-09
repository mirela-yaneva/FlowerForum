using System.Collections.Generic;

namespace FlowersForum.Domain.Models
{
    public class PaginationResult<T>
        where T : BaseModel
    {
        public List<T> Result { get; set; }
        public int TotalCount { get; set; }
    }
}
