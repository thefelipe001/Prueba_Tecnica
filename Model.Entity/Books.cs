using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Entity
{
    public class Books
    {
        public int id { get; set; } = 0;
        public string title { get; set; } = "";
        public string description { get; set; } = "";
        public int pageCount { get; set; } = 0;
        public string excerpt { get; set; } = "";
        public DateTime publishDate { get; set; }
    }
}
