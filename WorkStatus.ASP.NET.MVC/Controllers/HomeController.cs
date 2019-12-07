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
            return View();
            }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}