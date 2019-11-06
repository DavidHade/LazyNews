using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CoreModels
{
    public class WebsiteModel //Moved to NewsGrab
    {
        public int Id { get; set; }
        //[DataType(DataType.Url, ErrorMessage = "Please enter a valid url")]
        public string WebsiteUrl { get; set; }
        public string HeadelineXPath { get; set; }
        public string HeadlineURLXPath { get; set; }
        public string Headline { get; set; }
        public string ArticleURL { get; set; }
        public string SearchStringStart { get; set; }
        public string SearchStringEnd { get; set; }
    }
}
