using Talabat.Core.Models;
using Talabat.Dtos;

namespace Talabat.Helper
{
    public class Pagination<T>
    {
       

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int Count { get; set; }

        public IEnumerable<T>data {  get; set; }

        public Pagination(int pageIndex, int pageSize,int count, IEnumerable<T> _data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            data = _data;
            Count = count;
        }

    }
}
