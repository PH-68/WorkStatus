using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Diagnostics;
using WorkStatus.MVC.Core.Models;

namespace WorkStatus.MVC.Core.Controllers
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
        private IMemoryCache _cache;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _cache = memoryCache;
        }

        [ResponseCache(Duration = 1800, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult Index()
        {
            var timer = new Stopwatch();
            timer.Start();
            if (_cache.TryGetValue("Cache", out StatusModel statusModel))
            {
                ViewBag.StatusModel = statusModel;
            }
            else
            {
                UpdateData();
                if (_cache.TryGetValue("Cache", out statusModel))
                {
                    ViewBag.StatusModel = statusModel;
                }
                else
                {
                    UpdateData();
                }
            }
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            ViewBag.foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
            return View();
        }

        public string UpdateData()
        {
            var timer = new Stopwatch();
            timer.Start();
            var client = new RestClient("https://workstatus.poyi.tk/api/v1/data?cache=bypass")
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            StatusModel statusModel = Newtonsoft.Json.JsonConvert.DeserializeObject<StatusModel>(response.Content);
            _cache.Set("Cache", statusModel);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            return "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}