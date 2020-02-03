using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkStatus.ResponseTimeTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (compatible;Poyibot/WorkStatusAPI; +https://www.poyi.tk/bot)");
            InitializeComponent();
        }
        public static string html = "";
        private void button1_Click(object sender, EventArgs e)
        {
            _HttpServerDemo(textBox1.Text+"?anticache="+Guid.NewGuid(), Convert.ToInt32(textBox2.Text));
        }
        private async void _HttpServerDemo(string url, int t)
        {
            TimeSpan ts = new TimeSpan();
            for (int i = 0; i < t; i++)
            {
                var info4 = _GetHttpWithTimingInfo(url, t);
                await Task.WhenAll(info4);
                ts += info4.Result.Item2;
            }

            Console.WriteLine("Request4 took {0}", ts);
            label1.Text = Convert.ToString((Convert.ToDouble(ts.TotalMilliseconds) / t));
            textBox3.Text = html;
        }
        static readonly HttpClient client = new HttpClient();
        private async Task<Tuple<HttpResponseMessage, TimeSpan>> _GetHttpWithTimingInfo(string url, int t)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            HttpResponseMessage result = await client.GetAsync(url);
            html = await result.Content.ReadAsStringAsync();
            return new Tuple<HttpResponseMessage, TimeSpan>(result, stopWatch.Elapsed);
        }
    }
}
