using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataScrapping
{
    public  class DataScrap 
    {
     
       public static void GetWebUrlData()
        {
            string url = "https://www.cse.com.bd/market/current_price";

            HttpClient client = new HttpClient();
            var html = client.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // get spacic data 
            var table = htmlDocument.DocumentNode.SelectSingleNode("//table");
            var tbody = table.SelectSingleNode("//tbody");
            var tr = tbody.SelectNodes("//tr");
            var td = tr.Descendants("td");

            //foreach(var t in td)
            //{
            // var tt =   t.InnerText.Split("\n");
            //    Console.WriteLine(t.InnerHtml);
            //}


            List<string> stringData = new List<string>();

            foreach( var tds in tr)
            {
                //var splitData = tds.InnerText.Split('\n');
                var splitData = tds.InnerText.Replace("\n\t\t\t\t", " ").TrimEnd(new char[] {'\n','\t','\t','\t', '\t'}).Trim().Split(" ");
                var joinSplitingData = splitData.ToString().Trim();
                //var data =    tds.InnerText + ",".Replace('\n', '\r').Trim('\n', '\r');
                //stringData.Add(data);
                //Console.WriteLine(tds.InnerHtml);
               
              

            }



        }

    }
}
