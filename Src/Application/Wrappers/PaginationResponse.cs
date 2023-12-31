using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class PaginationResponse<T> where T : class
    {
        public PaginationResponse(int pageIndex, int pageSize, int count, IEnumerable<T> result)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Result = result;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IEnumerable<T> Result { get; set; }
    }
}
