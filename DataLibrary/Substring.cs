using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Core
{
    public class Substring //Moved to NewsGrab
    {
        public string Substringurl(string ss, string searchstringstart, string searchstringend)
        {

                String s = ss;
                int startIndex = s.IndexOf(searchstringstart);
                int endIndex = s.IndexOf(searchstringend);
                String substring = s.Substring(startIndex, endIndex - searchstringend.Length + searchstringend.Length - startIndex);
     
            return substring;
        }        
    }
}
