﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WorkStatus.ASP.NET.MVC.Models
{
    public class WorkStatusExampleDataModal
    {
        public Dictionary<string, string> StatusData { get; set; }
        public List<SelectListItem> Citys { get; set; }

        public WorkStatusExampleDataModal(int language)
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
            //doc.LoadHtml(webClient.DownloadString(URL));

            #region temp

            //doc.LoadHtml("<html lang='en-us'><head></head><body> <title>Directorate-General of Personnel Administration,Executive Yuan - Work and class status during natural disasters</title> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'> <meta content='MSHTML 6.00.2800.1400' name='GENERATOR'> <style> /************************* nds_Style *************************/ body { font-family: arial , '微軟正黑體'; margin: 0; padding: 0; } a{ text-decoration:none;} .Header_Div { background: rgba(23, 169, 123, 0.75); */ /* background-image: linear-gradient(140deg, rgba(206, 251, 209, 0.22) 20%, rgba(74, 197, 135, 0.59) 50%); */ width: 100%; height: 90px; box-shadow: 4px 4px 15px rgba(20%,40%,60%,0.5); font-family: inherit; color: rgba(51, 51, 51, 0.91); text-align: center; /* padding: 3% 0% 0.5% 0%; */ /* font-weight: bold; */ /* margin-top: 20px; */ padding: 35px 0px 0px 0px; background: #81ab00; } .Header_h1 { font-size: 2.5em; /* border: 2px solid #ffffff; */ text-shadow: -1px -1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95); font-weight: bold; } .Header_h2 { font-size: 1.5em; text-shadow: -1px -1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95); font-weight: 600; } .Header_YMD { font-size: 1.2em; /* margin: 1% 0% 0% 0%; */ margin: 10px 0px 0px 0px; /* color: rgba(80, 86, 85, 0.9); */ color: rgba(247, 242, 242, 0.95); } @media screen and (min-width:461px) and (max-width:520px){ .Header_h1 { font-size: 2.2em; } .Header_h2{ font-size: 1.4em; } .Header_YMD { font-size: 1.1em; } } @media screen and (min-width:381px) and (max-width:460px){ .Header_Div { height: 125px; } .Header_h1 { width: 100%; text-align: center; float: left; } .Header_YMD { font-size: 1.1em; margin: 14px 0px 0px 0px; } } @media screen and (max-width:380px){ .Header_Div { height: 110px; } .Header_h1 { font-size: 2.2em; width: 100%; text-align: center; float: left; } .Header_h2{ font-size: 1.4em; } .Header_YMD { font-size: 1em; } } .Version_btn_Div{ width: 100%; height: 30px; position: absolute; /* margin: 10px 0px 0px 0px; */ padding: 10px 0px 0px 0px; background: rgba(255,255,255,.3); height: 26px; } #top-link { position: absolute; top: 3px; right: 5px; } #top-link a.lang { border: 1px solid #555; color: #555; } #top-link a { display: inline-block; border-radius: 5px; font-size: 1.125em; margin: 0 6px; width: 115px; height: 26px; line-height: 26px; text-align: center; transition: all .3s; } #top-link a.lang:before { content: ''; width: 19px; height: 20px; display: inline-block; line-height: 30px; vertical-align: middle; margin: 0 5px 0 0; } .CH_Btn { float: right; font-size: 1.1em; border: 1px solid #9E9E9E; border-radius: 5px; background: #ffffff; margin: -0.4% 0.3% 0% 0%; width: 6%; } .EL_Btn { float: right; font-size: 1.3em; border: 1px solid #9E9E9E; border-radius: 5px; background: #ffffff; margin: -0.4% 0.7% 0% 0%; width: 6%; } #Content { /* background-image: linear-gradient(to right, rgba(253, 245, 129, 0.34) 0%, rgba(206, 255, 237, 0.58) 100%); */ /* background-image: linear-gradient(to right, rgba(253, 246, 142, 0.1) 0%, rgba(201, 251, 81, 0.39) 100%); */ background-image: linear-gradient(to right, rgba(253, 246, 142, 0.1) 0%, rgba(177, 243, 72, 0.35) 100%); } .alert_msg{ font-size: 1em; color: #f52222; font-weight: bold; } @media screen and (max-width:645px){ .alert_msg{ font-size: 0.5em; } } .f_right{ float: right; /* font-size: 0.9em; */ } .f_left{ float: left; } .color_blue{ color:#709dca; } .color_Eggyolk{ background-color: #ffc155; } .Content_Updata{ margin: -15px 0px; } #Table{ width: 100%; border-spacing: 0; border: 1px solid rgba(119, 119, 119, 0.68); border-collapse: inherit; } .Table_Head{ background: #caac76; text-align: center; font-family: inherit; font-weight: 600; letter-spacing: 2px; font-size: 1.2em; border-bottom: 2px solid #caac76; } @media screen and (max-width:645px){ .Table_Head{ font-size: 1.15em; } } @media screen and (max-width:645px){ .contact_link{ font-size: 0.85em; } .Table_Body{ background: #ffffff; } #Description{ display: block; list-style-type: decimal; -webkit-margin-before: 1em; -webkit-margin-after: 1em; -webkit-margin-start: 0px; -webkit-margin-end: 0px; -webkit-padding-start: 40px; } </style> <script type='text/javascript' async='' src='http://www.google-analytics.com/ga.js'></script><script type='text/javascript'> var _gaq = _gaq || []; _gaq.push(['_setAccount', 'UA-6721194-2']); _gaq.push(['_trackPageview']); (function() { var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true; ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js'; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s); })(); </script> <div class='Version_btn_Div'> <div id='top-link'> <a href='#' class='lang'>English</a> <a href='http://www.dgpa.gov.tw' class='lang'>中文</a> </div> </div> <div class='Header_Div'> <font class='Header_h1'> Directorate-General of Personnel Administration,Executive Yuan </font> <font class='Header_h2'> </font> <div class='Header_YMD'> 108/ 8/ 9/ Work and Class Status during Natural Disasters </div> </div> <div id='Content'> <div class='f_right Content_Updata'> <h4 style='font-weight:normal'> Update Time：2019/08/09 23:58:02 </h4> </div> <br> <br> <div> <font class='f_left'> </font> </div> <table id='Table' rules='ALL'> <thead class='Table_Head'> <tr style='height: 28px;'> <td width='18%' class='color_Eggyolk' id='city_Name'>County/City Government</td> <td width='70%' class='color_Eggyolk' id='StopWorkSchool_Info'>Work and Class Status during Natural Disasters</td> </tr> </thead> <tbody class='Table_Body'> <!-- 北部地區 --> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Keelung City'> <font>Keelung City</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Taipei City'> <font>Taipei City</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name New Taipei City'> <font>New Taipei City</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Taoyuan City'> <font>Taoyuan City</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Hsinchu City'> <font>Hsinchu City</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Hsinchu County'> <font>Hsinchu County</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <!-- 中部地區 --> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Miaoli County'> <font>Miaoli County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font><br><font color='#FF0000'>TaianTownship(泰安鄉):Work and Classes Cancelled From 10:00 a.m..  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Taichung City'> <font>Taichung  City</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Changhua County'> <font>Changhua County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Yunlin County'> <font>Yunlin County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Nantou county'> <font>Nantou county</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <!-- 南部地區 --> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Chiayi City'> <font>Chiayi City</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Chiayi County'> <font>Chiayi County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Tainan City'> <font>Tainan City</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Kaohsiung City'> <font>Kaohsiung City</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Pingtung County'> <font>Pingtung County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <!-- 東部地區 --> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Yilan County'> <font>Yilan County</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Hualien County'> <font>Hualien County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(255, 212, 85, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Taitung County'> <font>Taitung County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <!-- 外島地區 --> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Penghu County'> <font>Penghu County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Lienchiang County'> <font>Lienchiang County</font> </td> <td valign='center' align='left' width='70%'> <font color='#FF0000'>Work and Classes Cancelled Today.  </font> </td> </tr> <tr style='background: rgba(139, 241, 138, 0.15);'> <td valign='center' align='middle' width='17%' headers='city_Name Kinmen County'> <font>Kinmen County</font> </td> <td valign='center' align='left' width='70%'> <font color='#000080'>Work and Classes as Usual Today.  </font> </td> </tr> </tbody> </table> <div class='alert_msg'> <br> </div> </div> </body></html>");
            doc.LoadHtml("<html lang='zh-TW'><head></head><body> <title>行政院人事行政總處全球資訊網-天然災害停止上班及上課情形查詢</title> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'> <meta content='MSHTML 6.00.2800.1400' name='GENERATOR'> <meta http-equiv='X-UA-Compatible' content='IE=edge'> <meta name='viewport' content='width=device-width, initial-scale=1.0'> <style> /************************* nds_Style *************************/ body { font-family: arial, '微軟正黑體'; margin: 0; padding: 0; } a { text-decoration: none; } .Header_Div { background: rgba(23, 169, 123, 0.75); */ /* background-image: linear-gradient(140deg, rgba(206, 251, 209, 0.22) 20%, rgba(74, 197, 135, 0.59) 50%); */ width: 100%; height: 90px; box-shadow: 4px 4px 15px rgba(20%,40%,60%,0.5); font-family: inherit; color: rgba(51, 51, 51, 0.91); text-align: center; /* padding: 3% 0% 0.5% 0%; */ /* font-weight: bold; */ /* margin-top: 20px; */ padding: 35px 0px 0px 0px; background: #81ab00; } .Header_h1 { font-size: 2.5em; /* border: 2px solid #ffffff; */ text-shadow: -1px -1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95); font-weight: bold; } .Header_h2 { font-size: 1.5em; text-shadow: -1px -1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95), 1px 1px 1px rgba(255,255,255,.95); font-weight: 600; } .Header_YMD { font-size: 1.2em; /* margin: 1% 0% 0% 0%; */ margin: 10px 0px 0px 0px; /* color: rgba(80, 86, 85, 0.9); */ color: rgba(247, 242, 242, 0.95); } @media screen and (min-width:461px) and (max-width:520px) { .Header_h1 { font-size: 2.2em; } .Header_h2 { font-size: 1.4em; } .Header_YMD { font-size: 1.1em; } } @media screen and (min-width:381px) and (max-width:460px) { .Header_Div { height: 125px; } .Header_h1 { width: 100%; text-align: center; float: left; } .Header_YMD { font-size: 1.1em; margin: 14px 0px 0px 0px; } } @media screen and (max-width:380px) { .Header_Div { height: 110px; } .Header_h1 { font-size: 2.2em; width: 100%; text-align: center; float: left; } .Header_h2 { font-size: 1.4em; } .Header_YMD { font-size: 1em; } } .Version_btn_Div { width: 100%; height: 30px; position: absolute; /* margin: 10px 0px 0px 0px; */ padding: 10px 0px 0px 0px; background: rgba(255,255,255,.3); height: 26px; } #top-link { position: absolute; top: 3px; right: 5px; } #top-link a.lang { border: 1px solid #555; color: #555; } #top-link a { display: inline-block; border-radius: 5px; font-size: 1.125em; margin: 0 6px; width: 115px; height: 26px; line-height: 26px; text-align: center; transition: all .3s; } #top-link a.lang:before { content: ''; width: 19px; height: 20px; display: inline-block; line-height: 30px; vertical-align: middle; margin: 0 5px 0 0; } .CH_Btn { float: right; font-size: 1.1em; border: 1px solid #9E9E9E; border-radius: 5px; background: #ffffff; margin: -0.4% 0.3% 0% 0%; width: 6%; } .EL_Btn { float: right; font-size: 1.3em; border: 1px solid #9E9E9E; border-radius: 5px; background: #ffffff; margin: -0.4% 0.7% 0% 0%; width: 6%; } #Content { /* background-image: linear-gradient(to right, rgba(253, 245, 129, 0.34) 0%, rgba(206, 255, 237, 0.58) 100%); */ /* background-image: linear-gradient(to right, rgba(253, 246, 142, 0.1) 0%, rgba(201, 251, 81, 0.39) 100%); */ background-image: linear-gradient(to right, rgba(253, 246, 142, 0.1) 0%, rgba(177, 243, 72, 0.35) 100%); } .alert_msg { /*//font-size: 1em;*/ color: #f52222; font-weight: bold; } .alert_content { margin-left: 47px; } @media screen and (max-width:645px) { .alert_msg { font-size: 0.5em; } .alert_content { margin-left: 30px; } } .f_right { float: right; /* font-size: 0.9em; */ } .f_left { float: left; } .color_blue { color: #709dca; } .color_Eggyolk { background-color: #ffc155; } .Content_Updata { margin: -23px 0px; } #Table { width: 100%; border-spacing: 0; border: 1px solid rgba(119, 119, 119, 0.68); border-collapse: inherit; } .Table_Head { background: #caac76; text-align: center; font-family: inherit; font-weight: 600; letter-spacing: 2px; font-size: 1.2em; border-bottom: 2px solid #caac76; } @media screen and (max-width:645px) { .Table_Head { font-size: 1.15em; } } @media screen and (max-width:645px) { .contact_link { font-size: 0.85em; } .Table_Body { background: #ffffff; } #Description { display: block; list-style-type: decimal; -webkit-margin-before: 1em; -webkit-margin-after: 1em; -webkit-margin-start: 0px; -webkit-margin-end: 0px; -webkit-padding-start: 40px; } </style> <script type='text/javascript' async='' src='http://www.google-analytics.com/ga.js'></script><script type='text/javascript'> var _gaq = _gaq || []; _gaq.push(['_setAccount', 'UA-6721194-2']); _gaq.push(['_trackPageview']); (function () { var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true; ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js'; var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s); })(); </script> <div class='Version_btn_Div'> <div id='top-link'> <a href='ndse.html' class='lang'>English</a> <a href='#' class='lang'>中文</a> </div> </div> <div class='Header_Div'> <font class='Header_h1'> 行政院人事行政總處 </font> <font class='Header_h2'> 全球資訊網 </font> <div class='Header_YMD'> 108年 8月 8日 天然災害停止上班及上課情形 </div> </div> <div id='Content'> <div class='f_right Content_Updata'> <h4 style='font-weight:normal'> 更新時間：2019/08/08 23:58:05 <br> <a href='https://www.dgpa.gov.tw/informationlist?uid=374' class='f_right color_blue'>歷次天然災害停止上班上課訊息</a> </h4> </div> <br> <br> <div style='clear:both;'> <a href='https://www.dgpa.gov.tw/typh/daily/contact/Contact_Phone.html' class='f_right color_blue'>民眾洽詢天然災害停止上班及上課各地方政府連絡一覽表</a> </div> <div style='clear:both;'> <a href='https://law.moj.gov.tw/LawClass/LawAll.aspx?pcode=S0110022' class='f_right color_blue'>天然災害停止上班及上課作業辦法</a> </div> <div style='clear:both;'> <a href='https://www.dgpa.gov.tw/informations?uid=15#' class='f_right color_blue'>天然災害停止上班及上課作業Q&amp;A</a> <font class='f_left'> 資料來源：各縣市政府 </font> </div> <table id='Table' rules='ALL'> <tbody><tr class='Table_Head' style='height: 28px;'> <th width='18%' class='color_Eggyolk' id='city_Name'>縣市名稱</th> <th width='70%' class='color_Eggyolk' id='StopWorkSchool_Info'>是否停止上班上課情形		 </th> </tr> </tbody><tbody class='Table_Body'> <tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>基隆市</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天晚上照常上班、照常上課。  </font><br><font color='#FF0000'>明天停止上班、停止上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>臺北市</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天晚上照常上班、照常上課。  </font><br><font color='#FF0000'>明天停止上班、停止上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>新北市</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天晚上照常上班、照常上課。  </font><br><font color='#FF0000'>明天停止上班、停止上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>桃園市</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天晚上照常上班、照常上課。  </font><br><font color='#FF0000'>明天停止上班、停止上課。  </font><br><font color='#FF0000'>復興區:今天下午03:30起停止上班、停止上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>新竹市</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#FF0000'>明天停止上班、停止上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>新竹縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#FF0000'>明天停止上班、停止上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>苗栗縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>臺中市</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>彰化縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>雲林縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>南投縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>嘉義市</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>嘉義縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>臺南市</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>高雄市</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>屏東縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>宜蘭縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#FF0000'>明天停止上班、停止上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>花蓮縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>臺東縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>澎湖縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>連江縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#FF0000'>明天停止上班、停止上課。  </font></td></tr><tr><td headers='city_Name' valign='center' align='middle' width='13%'><font>金門縣</font></td><td headers='StopWorkSchool_Info' valign='center' align='left' width='70%'><font color='#000080'>今天照常上班、照常上課。  </font><br><font color='#000080'>明天照常上班、照常上課。  </font></td></tr> <!-- 備註 #a5a1c2--> <tr style='background:rgba(204, 124, 236, 0.39);'> <td colspan='3'> <p style='color:#000040'>備註：</p> <p>1.若欲進入本總處網站首頁版面，請按<a href='https://www.dgpa.gov.tw/index'>人事行政總處全球資訊網</a></p> <p>2.機關、學校中英文名稱係由各通報機關提供。</p> <p>3.適用範圍為各級政府機關及公、私立學校；至交通運輸、警察、消防、海岸巡防、醫療、關務等業務性質特殊機關（構），為全年無休服務民眾，且應實施輪班、輪休制度，如遇天然災害發生時，其尚無停止上班之適用。</p> <p>4.民間事業單位及勞工應依勞動部『天然災害發生事業單位勞工出勤管理及工資給付要點』處理， 如有疑義，請按 <a href='https://laws.mol.gov.tw/FLAW/FLAWDAT01.aspx?id=FL049533'>「勞動部網頁」</a>查詢，或電洽該部免付費電話專線：0800-085-151。 </p> </td> </tr> </tbody> </table> <br> <div class='alert_msg'> 一、偽造、變造本總處網頁發布不實訊息者，可能涉嫌觸犯以下刑責，請勿以身試法：<br> <div style='float: left;'>（一） </div><div class='alert_content'>刑法第211條：偽造、變造公文書，足以生損害於公眾或他人者，處一年以上七年以下有期徒刑。</div> <div style='float: left;'>（二） </div><div class='alert_content'>刑法第360條：無故以電腦程式或其他電磁方式干擾他人電腦或其相關設備，致生損害於公眾或他人者， 處三年以下有期徒刑、拘役或科或併科十萬元以下罰金。</div> <div style='float: left;'>（三） </div><div class='alert_content'>災害防救法第41條：散播有關災害之謠言或不實訊息，足生損害於公眾或他人者，處三年以下有期徒刑、拘役或新臺幣一百萬元以下罰金。犯前項之罪，因而致人於死者，處無期徒刑或七年以上有期徒刑；致重傷者，處三年以上十年以下有期徒刑。 </div> 二、通報權責機關決定停止上班及上課時，應於下列時間前對外發布：<br> <div style='float: left;'>（一）   </div><div class='alert_content'> 全日或上午半日停止上班及上課時：應於前一日晚間7時至10時前發布，並通知傳播媒體於晚間11時前播報之。但前一日未發布當日停止上班及上課，於當日0時後，風雨增強，經參酌交通部中央氣象局提供各地區最新風力級數、陣風級數及雨量預測列表等氣象資料 ，已達第4條第1款、第2款之基準時，通報權責機關應於當日上午4時30分前發布 ，並通知傳播媒體，於上午5時前播報之。 </div> <div style='float: left;'>（二）   </div><div class='alert_content'>下午半日或晚間停止上班及上課時：應於當日上午10時30分前發布，並通知傳播媒體，於上午11時前播報之。</div> <div style='float: left;'>（三） </div><div class='alert_content'>  除上開時間外，各通報權責機關得視實際情形，隨時發布之。</div> </div> </div> </body></html>");
            #endregion temp

            if (doc.DocumentNode.SelectSingleNode("//*[@class='Table_Body']/tr[1]/td[1]").InnerHtml.IndexOf("#000000") != -1)
            {
                IsClosuresWorking.Add(false);
                HtmlNode node = doc.DocumentNode.SelectSingleNode("//*[@class='Table_Body']/tr[1]/td[1]/font/h2");
                StatusData.Add("Every city in Taiwan", node.InnerText);
            }
            else if (doc.DocumentNode.SelectSingleNode("//*[@class='Table_Body']") != null)
            {
                for (int i = 0; i < doc.DocumentNode.SelectNodes("//*[@class='Table_Body']/tr").Count - 1; i++)
                {
                    if (doc.DocumentNode.SelectSingleNode("//*[@class='Table_Body']/tr[" + (i + 1) + "]").InnerHtml.IndexOf("#000080") != -1)
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

        public List<bool> IsClosuresWorking { get; set; }
    }
}