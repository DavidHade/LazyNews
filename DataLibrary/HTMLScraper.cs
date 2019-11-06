using Core.CoreModels;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Core
{
    public class HTMLScraper //moved to NewsGrab
    {

        public void Parse(WebsiteModel website)
        {

            HtmlWeb web = new HtmlWeb();
            Substring ss = new Substring();
            var htmlDoc = web.Load(website.WebsiteUrl);

            var headline = htmlDoc.DocumentNode.SelectNodes(website.HeadelineXPath);
            var articelURL = htmlDoc.DocumentNode.SelectNodes(website.HeadlineURLXPath);

            System.Diagnostics.Debug.WriteLine("--------h4---------");
            for (int i = 0; i < headline.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(headline[i].InnerText);
                string url = ss.Substringurl(articelURL[i].OuterHtml, website.SearchStringStart, website.SearchStringEnd);
                System.Diagnostics.Debug.WriteLine(url);
            }
            System.Diagnostics.Debug.WriteLine("-------------------");
           
        }

    }
}
