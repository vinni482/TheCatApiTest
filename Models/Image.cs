using System;
using System.Collections.Generic;
using System.Text;

namespace TheCatApiTest.Models
{
    public class Image
    {
        public List<object> breeds { get; set; }
        public List<Category> categories { get; set; }
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
