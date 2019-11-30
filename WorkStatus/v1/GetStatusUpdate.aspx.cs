using System;

namespace WorkStatus.v1
{
    public partial class GetStatusUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["data"] != null)
            {
                Application["rawdata"] = Request.Form["data"];
                Application["Stop"] = "0";
            }
            else if (Request.Form["NoChange"] != null)
            {
                Application["NoChange"] = Request.Form["NoChange"];
                Application["Stop"] = " 1";
            }
            if (Request.Form["Edata"] != null)
            {
                Application["Erawdata"] = Request.Form["Edata"];
                Application["Stop"] = "0";
            }
            else if (Request.Form["ENoChange"] != null)
            {
                Application["ENoChange"] = Request.Form["ENoChange"];
                Application["Stop"] = "1";
            }
        }
    }
}