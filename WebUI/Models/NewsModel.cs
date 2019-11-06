using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class NewsModel //not in use, DB model used directly
    {
        public string DateAdded { get; set; }
        public string TimeAdded { get; set; }
        public string Headline { get; set; }
        public string HeadlineUrl { get; set; }
    }
}