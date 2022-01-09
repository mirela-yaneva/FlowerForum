using System.Collections.Generic;

namespace FlowersForum.Api.Models.Paginations
{
    public class PaginationResultVM<T>
        where T : BaseVM
    {
        public List<T> Result { get; set; }
        public int TotalCount { get; set; }
    }
}
