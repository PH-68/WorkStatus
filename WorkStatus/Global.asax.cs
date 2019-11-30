using System;
using System.Globalization;

namespace WorkStatus
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(System.Web.Routing.RouteTable.Routes);
            Application["V4UnixTimeWeatherbit"] = "0";
            Application["V4UnixTimeDarkSky"] = "0";
            Application["V4UnixTime"] = "0";
            Application["V4UnixTimeUpdate"] = "0";

            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            Application["V2xml"] = webClient.DownloadString("https://alerts.ncdr.nat.gov.tw/RssAtomFeed.ashx?AlertType=33");
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

        protected void Session_Start(object sender, EventArgs e)
        {
            if (Properties.LanguageResource.Nothing == null)
            {
                CultureInfo cultureInfo = new CultureInfo("en-us");
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Session["L"] = "E";
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Threading.Thread.CurrentThread.CurrentCulture;
                if (System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "zh")
                {
                    Session["L"] = "C";
                }
                else
                {
                    Session["L"] = "E";
                }
                Session["V4Verify"] = "false";
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }

        protected void Session_End(object sender, EventArgs e)
        {
        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}