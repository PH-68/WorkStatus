using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WorkStatus.ASP.NET.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // 定時排程
            Timer t = new Timer(10000); //設計時間間隔，如果一個小時執行一次就改為3600000 
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.AutoReset = true;
            t.Enabled = true;
        }

        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            //排程內容
        }
    }
}
