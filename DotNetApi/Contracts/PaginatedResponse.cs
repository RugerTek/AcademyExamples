using System.Collections.Generic;

namespace DotNetApi.Contracts
{
    public class PaginatedResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Count { get; set; }
    }
}