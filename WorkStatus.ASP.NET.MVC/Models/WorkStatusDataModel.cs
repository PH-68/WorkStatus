using HtmlAgilityPack;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace WorkStatus.ASP.NET.MVC.Models
{
    public class WorkStatusDataModel
    {
        public Dictionary<string, string> StatusData { get; set; }
        public static List<SelectListItem> Citys { get; set; }

        public WorkStatusDataModel(int language)
        {
            WebClient webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            StatusData = new Dictionary<string, string>();
            Citys = new List<SelectListItem>();
            IsClosuresWorking = new List<bool>();
            string URL;
            if (language == (int)Languages.English)
            {
                URL = "https://www.dgpa.gov.tw/typh/daily/nds.html";
            }
            else
            {
                URL = "https://www.dgpa.gov.tw/typh/daily/ndse.html";
            }
            HtmlDocument doc = new HtmlDocument();
            webClient.Headers["User-Agent"] = "Mozilla/5.0 (compatible;Poyibot/WorkStatusMVC; +https://www.poyi.tk/bot)";
            doc.LoadHtml(webClient.DownloadString(URL));

            #region temp

        //    doc.LoadHtml("<html lang='en-us'><head></head><body> <title>Directorate-General of Personnel Administration,Executive Yuan - Work and class status during natural disasters</title> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'> <meta content='MSHTML 6.00.2800.1400' name='GENERATOR'> <style> /************************* nds_Style *************************/ body { font-family: arial , '微軟正黑體'; margin: 0; padding: 0; } a{ text-decoration:none;} .Header_Div { background: rgba(23, 169, 123, 0.75); */ /* background-image: linear-gradient(140deg, rgba(206, 251, 209, 0.22) 20%, rgba(74, 197, 135, 0.59) 50%); */ width: 100%; height: 90px; box-shadow: 4px 4px 15px rgba(20%,40%,60%,0.5); font-family: inherit; color: rgba(51, 51, 51, 0.91); text-align: center; /* padding: 3% 0% 0.5% 0%; */ /* font-weight: bold; */ /* margin-top: 20px; */ padding: 35px 0px 0px 0px; background: #81ab00; } .Header_h1 { font-size: 2.5em; /* border: 2px solid #ffffff; */ text-shadow: -1px -1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95); font-weight: bold; } .Header_h2 { font-size: 1.5em; text-shadow: -1px -1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95); font-weight: 600; } .Header_YMD { font-size: 1.2em; /* margin: 1% 0% 0% 0%; */ margin: 10px 0px 0px 0px; /* color: rgba(80, 86, 85, 0.9); */ color: rgba(247, 242, 242, 0.95); } @media screen and (min-width:461px) and (max-width:520px){ .Header_h1 { font-size: 2.2em; } .Header_h2{ font-size: 1.4em; } .Header_YMD { font-size: 1.1em; } } @media screen and (min-width:381px) and (max-width:460px){ .Header_Div { height: 125px; } .Header_h1 { width: 100%; text-align: center; float: left; } .Header_YMD { font-size: 1.1em; margin: 14px 0px 0px 0px; } } @media screen and (max-width:380px){ .Header_Div { height: 110px; } .Header_h1 { font-size: 2.2em; width: 100%; text-align: center; float: left; } .Header_h2{ font-size: 1.4em; } .Header_YMD { font-size: 1em; } } .Version_btn_Div{ width: 100%; height: 30px; position: absolute; /* margin: 10px 0px 0px 0px; */ padding: 10px 0px 0px 0px; background: rgba(255,255,255,.3); height: 26px; } #top-link { position: absolute; top: 3px; right: 5px; } #top-link a.lang { border: 1px solid #555; color: #555; } #top-link a { display: inline-block; border-radius: 5px; font-size: 1.125em; margin: 0 6px; width: 115px; height: 26px; line-height: 26px; text-align: center; transition: all .3s; } #top-link a.lang:before { content: ''; width: 19px; height: 20px; display: inline-block; line-height: 30px; vertical-align: middle; margin: 0 5px 0 0; } .CH_Btn { float: right; font-size: 1.1em; border: 1px solid #9E9E9E; border-radius: 5px; background: #ffffff; margin: -0.4% 0.3% 0% 0%; width: 6%; } .EL_Btn { float: right; font-size: 1.3em; border: 1px solid #9E9E9E; border-radius: 5px; background: #ffffff; margin: -0.4% 0.7% 0% 0%; width: 6%; } #Content { /* background-image: linear-gradient(to right, rgba(253, 245, 129, 0.34) 0%, rgba(206, 255, 237, 0.58) 100%); */ /* background-image: linear-gradient(to right, rgba(253, 246, 142, 0.1) 0%, rgba(201, 251, 81, 0.39) 100%); */ background-image: linear-gradient(to right, rgba(253, 246, 142, 0.1) 0%, rgba(177, 243, 72, 0.35) 100%); } .alert_msg{ font-size: 1em; color: #f52222; font-weight: bold; } @media screen and (max-width:645px){ .alert_msg{ font-size: 0.5em; } } .f_right{ float: right; /* font-size: 0.9em; */ } .f_left{ float: left; } .color_blue{ color:#709dca; } .color_Eggyolk{ background-color: #ffc155; } .Content_Updata{ margin: -15px 0px; } #Table{ width: 100%; border-spacing: 0; border: 1px solid rgba(119, 119, 119, 0.68); border-collapse: inherit; } .Table_Head{ background: #caac76; text-align: center; font-family: inherit; font-weight: 600; letter-spacing: 2px; font-size: 1.2em; border-bottom: 2px solid #caac76; } @media screen and (max-width:645px){ .Table_Head{ font-size: 1.15em; } } @media screen and (max-width:645px){ .contact_link{ font-size: 0.85em; } .Table_Body{ background: #ffffff; } #Description{ display: block; list-style-type: decimal; -webkit-margin-before: 1em; -webkit-margin-after: 1em; -webkit-margin-start: 0px; -webkit-margin-end: 0px; -webkit-padding-start: 40px; } </style> <script type='text/javascript' async='' src='http://www.google-analytics.com/ga.js'></script><script type='text/javascript'> var _gaq = _gaq || []; _gaq.push(['_setAccount', 'UA-6721194-2']); _gaq.push(['_trackPageview']); (function() { var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true; ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js'; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s); })(); </script> <div class='Version_btn_Div'> <div id='top-link'> <a href='#' class='lang'>English</a> <a href='http://www.dgpa.gov.tw' class='lang'>中文</a> </div> </div> <div class='Header_Div'> <font class='Header_h1'> Directorate-General of Personnel Administration,Executive Yuan </font> <font class='Header_h2'> </font> <div class='Header_YMD'> 108/ 8/ 9/ Work and Class Status during Natural Disasters </div> </div> <div id='Content'> <div class='f_right Content_Updata'> <h4 style='font-weight:normal'> Update Time：2019/08/09 23:58:02 </h4> </div> <br> <br> <div> <font class='f_left'> </font> </div> <table id='Table' rules='ALL'> <thead class='Table_Head'> <tr style='height: 28px;'> <td width='18%' class='color_Eggyolk' id='city_Name'>County/City Government</td> <td width='70%' class='color_Eggyolk' id='StopWorkSchool_Info'>Work and Class Status during Natural Disasters</td> </tr> </thead> <tbody class='Table_Body'> <!-- 北部地區 --> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Keelung City'> <font>Keelung City</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Taipei City'> <font>Taipei City</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name New Taipei City'> <font>New Taipei City</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Taoyuan City'> <font>Taoyuan City</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Hsinchu City'> <font>Hsinchu City</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Hsinchu County'> <font>Hsinchu County</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <!-- 中部地區 --> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Miaoli County'> <font>Miaoli County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font><br><font color='#FF0000'>TaianTownship(泰安鄉):Work and Classes Cancelled From 10:00 a.m..  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Taichung City'> <font>Taichung  City</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Changhua County'> <font>Changhua County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Yunlin County'> <font>Yunlin County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Nantou county'> <font>Nantou county</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <!-- 南部地區 --> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Chiayi City'> <font>Chiayi City</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Chiayi County'> <font>Chiayi County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Tainan City'> <font>Tainan City</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Kaohsiung City'> <font>Kaohsiung City</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Pingtung County'> <font>Pingtung County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <!-- 東部地區 --> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Yilan County'> <font>Yilan County</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Hualien County'> <font>Hualien County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Taitung County'> <font>Taitung County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <!-- 外島地區 --> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Penghu County'> <font>Penghu County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Lienchiang County'> <font>Lienchiang County</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Kinmen County'> <font>Kinmen County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> </tbody> </table> <div class='alert_msg'> <br> </div> </div> </body></html>");
            
            #endregion temp

            if (doc.DocumentNode.SelectSingleNode("//*[@class='Table_Body']/tr[1]/td[1]").InnerHtml.IndexOf("#000000") !=-1)
            {
                IsClosuresWorking.Add(false);
                HtmlNode node = doc.DocumentNode.SelectSingleNode("//*[@class='Table_Body']/tr[1]/td[1]/font/h2");
                StatusData.Add("Every city in Taiwan", node.InnerText);
            }
            else if (doc.DocumentNode.SelectSingleNode("//*[@class='Table_Body']") != null)
            {
                for (int i = 0; i < doc.DocumentNode.SelectNodes("//*[@class='Table_Body']/tr").Count - 1; i++)
                {
                    if (doc.DocumentNode.SelectSingleNode("//*[@class='Table_Body']/tr[" + (i + 1)+"]").InnerHtml.IndexOf("#000080") != -1)
                    {
                        IsClosuresWorking.Add(false);
                    }
                    else
                    {
                        IsClosuresWorking.Add(true);
                    }
                    SelectListItem selectListItem = new SelectListItem()
                    {
                        Value = i.ToString(),
                        Text = doc.DocumentNode.SelectSingleNode("//*[@class='Table_Body']/tr[" + (i + 1) + "]/td[1]/font").InnerText
                    };
                    Citys.Add(selectListItem);
                    StatusData.Add(doc.DocumentNode.SelectSingleNode("//*[@class='Table_Body']/tr[" + (i + 1) + "]/td[1]/font").InnerText,
                        doc.DocumentNode.SelectSingleNode("//*[@class='Table_Body']/tr[" + (i + 1) + "]/td[2]/font").InnerText);
                }
            }
            webClient.Dispose();
        }

        public enum Languages : int
        {
            English,
            Chinese
        }

        public string GetStatusData()
        {
            return "";
        }

        public List<bool> IsClosuresWorking { get; set; }
    }
}