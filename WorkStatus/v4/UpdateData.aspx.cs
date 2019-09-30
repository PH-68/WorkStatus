using HtmlAgilityPack;
using System;

namespace WorkStatus.v4
{
    public partial class UpdateData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //WebClient webClient = new WebClient();
            // webClient.Encoding = System.Text.Encoding.UTF8;
            // string Html = webClient.DownloadString("https://www.cwb.gov.tw/V8/C/P/Typhoon/TY_NEWS.html");
            HtmlWeb webClient = new HtmlWeb();
            webClient.OverrideEncoding = System.Text.Encoding.UTF8;
            webClient.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.36 Safari/537.36 Edg/79.0.309.25";
            HtmlDocument doc = webClient.Load("https://www.cwb.gov.tw/V8/C/P/Typhoon/TY_NEWS.html");

            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("/html/body/div[4]/main/div/div[1]/div/div[1]/div[3]/div/div/div/div[2]/div/p");

            foreach (HtmlNode node in nodes)
            {
                Console.WriteLine(node.InnerText.Trim());
            }
            //xmlDocument.GetElementsByTagName()
        }
    }
}