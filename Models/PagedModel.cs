using System.Collections.Generic;

namespace TheCatApiTest.Models
{
    public class PagedModel<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
