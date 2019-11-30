using System;
using System.Globalization;

namespace WorkStatus
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(System.Web.Routing.RouteTable.Routes);
            Application["V4UnixTime"] = "0";
            Application["V4UnixTimeUpdate"] = "0";
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