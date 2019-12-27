using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyNews.Core.Models
{
    public class NewsEntry : BaseEntity //Model for EF data
    {
        public int id { get; set; }
        public DateTime TimeAdded { get; set; }
        public string Headline { get; set; }
        public string HeadlineUrl { get; set; }
        public string NewsSource { get; set; }
        public string Article { get; set; }
        public string Imagepath { get; set; }
        public string Category { get; set; }
    }
}
