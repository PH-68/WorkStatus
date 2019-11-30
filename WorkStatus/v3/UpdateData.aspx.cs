using System;
using System.Net;

namespace WorkStatus.v3
{
    public partial class UpdateData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            //html的node用大寫
            string html = webClient.DownloadString("https://www.dgpa.gov.tw/typh/daily/nds.html").Replace("<FONT", "<SPAN").Replace("</FONT>", "</SPAN>");
            string table = html.Substring(html.IndexOf("<TABLE"), html.IndexOf("</TABLE>") - html.IndexOf("<TABLE") + 8);
            //xmlDocument.LoadXml(webClient.DownloadString("https://www.dgpa.gov.tw/typh/daily/nds.html"));
            //HtmlWeb webClient = new HtmlWeb();
            Application["V3HtmlTable"] = table;
            html = webClient.DownloadString("https://www.dgpa.gov.tw/typh/daily/ndse.html").Replace("<FONT", "<SPAN").Replace("</FONT>", "</SPAN>");
            table = html.Substring(html.IndexOf("<TABLE"), html.IndexOf("</TABLE>") - html.IndexOf("<TABLE") + 8);
            Application["EV3HtmlTable"] = table;
        }
    }
}