using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CoreModels
{
    public class TheGuardianModel //moved to NewsGrab
    {
        public string WebsiteUrl = "https://www.theguardian.com/international";
        public string HeadelineXPath = "//body/div/div/section/div/div/div/ul/li/div/div/div/div/h3";
        public string HeadlineURLXPath = "//body/div/div/section/div/div/div/ul/li/div/div/div/div/h3/a"; //"+/a"
        public string SearchStringStart = "http"; //12            
        public string SearchStringEnd = "\" class"; //42
    }
}
