using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkStatus.ASP.NET.MVC.Controllers
{
    public class HomeController : Controller
    {
        public static readonly string[] CitiesCh = new[]
          {
            "基隆市" ,
            "臺北市" ,
            "新北市" ,
            "桃園市" ,
            "新竹市" ,
            "新竹縣" ,
            "苗栗縣" ,
            "臺中市" ,
            "彰化縣" ,
            "雲林縣" ,
            "南投縣",
            "嘉義市",
            "嘉義縣",
            "臺南市",
            "高雄市",
            "屏東縣",
            "宜蘭縣",
            "花蓮縣",
            "臺東縣",
            "澎湖縣",
            "連江縣",
            "金門縣"
        };
        public static readonly string[] CitiesEn = new[]
         {
            "Keelung City",
            "Taipei City",
            "New Taipei City",
            "Taoyuan City",
            "Hsinchu City",
            "Hsinchu County",
            "Miaoli County",
            "Taichung City",
            "Changhua County",
            "Nantou County",
            "Yunli County",
            "Chiayi City",
            "Chiayi County",
            "Tainan City",
            "Kaohsiung City",
            "Pingtung County",
            "Yilan County",
            "Hualien County",
            "Taitung County",
            "Penghu County",
            "Lienchiang County",
            "Kinmen County"
        };

        [OutputCache(Duration = 1800, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Any, NoStore = true)]
        public ActionResult Index()
        {
            var timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            //B: Run stuff you want timed


            var client = new RestClient("https://workstatus.poyi.tk/api/v1/data")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Models.StatusModel statusModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.StatusModel>(response.Content);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            ViewBag.foo = foo;
            ViewBag.StatusModel = statusModel;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}