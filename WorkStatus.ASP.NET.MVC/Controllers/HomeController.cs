using HtmlAgilityPack;
using System;
using System.Net;
using System.Web.Mvc;

namespace WorkStatus.ASP.NET.MVC.Controllers
{
    public class HomeController : Controller
    {
        public static int UnixTime = 0;
        public static string HtmlTable = "";
        public static string EHtmlTable = "";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";
            WebClient webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };

            if (UnixTime < (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds || false == true)
            {
                UnixTime = (int)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds + 1800;
                //html的node用大寫
                string html = webClient.DownloadString("https://www.dgpa.gov.tw/typh/daily/nds.html").Replace("<FONT", "<SPAN").Replace("</FONT>", "</SPAN>");
                string table = html.Substring(html.IndexOf("<TABLE"), html.IndexOf("</TABLE>") - html.IndexOf("<TABLE") + 8);
                //xmlDocument.LoadXml(webClient.DownloadString("https://www.dgpa.gov.tw/typh/daily/nds.html"));
                //HtmlWeb webClient = new HtmlWeb();
                HtmlTable = table;
                html = webClient.DownloadString("https://www.dgpa.gov.tw/typh/daily/ndse.html").Replace("<FONT", "<SPAN").Replace("</FONT>", "</SPAN>");
                table = html.Substring(html.IndexOf("<TABLE"), html.IndexOf("</TABLE>") - html.IndexOf("<TABLE") + 8);
                EHtmlTable = table;
            }
            ViewBag.Message = EHtmlTable;
            HtmlDocument doc = new HtmlDocument();
            webClient.Headers["User-Agent"] = "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)";
            doc.LoadHtml(webClient.DownloadString("https://www.dgpa.gov.tw/typh/daily/ndse.html"));
            HtmlNode node = doc.DocumentNode.SelectSingleNode("//*[@id='Table']/tbody[1]/tr[1]/td/font/h2");
            if (node != null)
            {
                ViewBag.Message = node.InnerText;

            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}