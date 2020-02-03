using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

[assembly: PreApplicationStartMethod(typeof(WorkStatus.ASP.NET.MVC.RemoveHeaderModule), "Register")]

namespace WorkStatus.ASP.NET.MVC
{
    public class RemoveHeaderModule : IHttpModule
    {
        private static readonly List<string> _removeHeaders = new List<string>
        {
            "Server",
            "X-AspNet-Version",
            //"X-AspNetMvc-Version",
            "ETag"
        };

        public static void Register()
        {
            DynamicModuleUtility.RegisterModule(typeof(RemoveHeaderModule));
            // HTTP Headers 中的 X-AspNetMvc-Version，一開始就直接 Disable，效率更勝每次都移除。
            MvcHandler.DisableMvcResponseHeader = true;
        }

        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += OnPreSendRequestHeaders;
        }

        public void Dispose()
        {
        }

        private void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            if (HttpContext.Current != null)
            {
                var response = HttpContext.Current.Response;
                _removeHeaders.ForEach(header => { response.Headers.Remove(header); });
            }
        }
    }
}