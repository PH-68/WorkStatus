﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorkStatus.v2
{
    public partial class UpdateData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            Application["V2xml"] = webClient.DownloadString("https://alerts.ncdr.nat.gov.tw/RssAtomFeed.ashx?AlertType=33");
        }
    }
}