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

        public ActionResult Status()
        {
            //ViewBag.Message = "Your application description page.";
            Models.WorkStatusDataModel workStatusData = new Models.WorkStatusDataModel((int)Models.WorkStatusDataModel.Languages.Chinese);
            foreach (var item in workStatusData.StatusData)
            {
                ViewBag.Message = item.Value;
            }
            ViewBag.Dictionary = workStatusData.StatusData;
            ViewBag.IsClosuresWorking = workStatusData.IsClosuresWorking;
            ViewBag.Citys = workStatusData.Citys;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Weather()
        {
            ViewBag.Message = "Your contact page.";
            WebClient webClient = new WebClient { Encoding = System.Text.Encoding.UTF8 };

            Models.CWBDataModel cWBDataModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.CWBDataModel>(webClient.DownloadString(
                "https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-D0047-089?Authorization=rdec-key-123-45678-011121314&elementName=Wx,T,AT,PoP6h"));
            if (Url.RequestContext.RouteData.Values["id"] != null)
            {
                ViewBag.Title = cWBDataModel.records.locations[0].location[0].locationName;
            }
            return View();
        }
    }
}
