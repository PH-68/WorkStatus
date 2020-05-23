﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
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
            "Keelung",
            "Taipei",
            "New Taipei",
            "Taoyuan",
            "Hsinchu",
            "Hsinchu",
            "Miaoli",
            "Taichung",
            "Changhua",
            "Nantou",
            "Yunli",
            "Chiayi",
            "Chiayi",
            "Tainan",
            "Kaohsiung",
            "Pingtung",
            "Yilan",
            "Hualien",
            "Taitung",
            "Penghu",
            "Lienchiang",
            "Kinmen"
        };

        private IMemoryCache _cache;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _cache = memoryCache;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            if (_cache.TryGetValue("WeatherCache", out List<OWMModel> oWMModels))
            {
                ViewBag.OWMs = oWMModels;
            }
            else
            {
                UpdateData();
                if (_cache.TryGetValue("WeatherCache", out oWMModels))
                {
                    ViewBag.OWMs = oWMModels;
                }
                else
                {
                    UpdateData();
                }
            }
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
            List<OWMModel> oWMModels = new List<OWMModel>();
            foreach (var item in CitiesEn)
            {
                client = new RestClient("https://api.openweathermap.org/data/2.5/weather?q=" + item + ",TW&units=metric&appid=44d31a1e35fb9166af8c0af891f9cf10&lang=zh_tw")
                {
                    Timeout = -1
                };
                request = new RestRequest(Method.GET);
                request.AddHeader("Accept", "*/*");
                request.AddHeader("User-Agent", "Mozilla/5.0 (compatible; PoyiCorporationBot/2.1; +http://www.poyi.tk/bot.html)");
                request.AddHeader("Accept-Encoding", "gzip, deflate, br");
                request.AddHeader("Connection", "keep-alive");
                request.AddHeader("Cache-Control", "no-cache");
                response = client.Execute(request);
                OWMModel oWMModel = Newtonsoft.Json.JsonConvert.DeserializeObject<OWMModel>(response.Content);
                oWMModels.Add(oWMModel);
            }
            _cache.Set("WeatherCache", oWMModels);
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            return "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Detail(string id)
        {
            if (id != null)
            {
                RestClient client = new RestClient("http://api.openweathermap.org/data/2.5/weather?q=" + CitiesCh[Convert.ToInt16(id)] + "&appid=44d31a1e35fb9166af8c0af891f9cf10&lang=zh_tw")
                {
                    Timeout = -1
                };
                var request = new RestRequest(Method.GET);
                request.AddHeader("Accept", "*/*");
                request.AddHeader("User-Agent", "Mozilla/5.0 (compatible; PoyiCorporationBot/2.1; +http://www.poyi.tk/bot.html)");
                request.AddHeader("Accept-Encoding", "gzip, deflate, br");
                request.AddHeader("Connection", "keep-alive");
                request.AddHeader("Cache-Control", "no-cache");
                IRestResponse response = client.Execute(request);
                OWMModel oWMModel = Newtonsoft.Json.JsonConvert.DeserializeObject<OWMModel>(response.Content);
                ViewBag.OWM = oWMModel;
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
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}