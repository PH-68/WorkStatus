using System;
using System.Net;

namespace WorkStatus.v4
{
    public partial class cwbdataviewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            TextBox2.Text = webClient.DownloadString(TextBox1.Text);
        }
    }
}