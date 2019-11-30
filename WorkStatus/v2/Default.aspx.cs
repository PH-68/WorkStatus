using System;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace WorkStatus.v2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Request.Cookies["theme"] == null)
            {
                Response.Cookies["theme"].Value = "light";
                Response.Cookies["theme"].Expires = DateTime.UtcNow.AddYears(999);
            }
            if (Request.QueryString["changetheme"] == "true")
            {
                if (Request.Cookies["theme"].Value == "light")
                {
                    Page.Theme = "Dark";
                    html.Attributes.Add("class", "bg-dark");
                    Response.Cookies["theme"].Value = "dark";
                    Response.Cookies["theme"].Expires = DateTime.UtcNow.AddYears(999);
                }
                else
                {
                    Response.Cookies["theme"].Value = "light";
                    Page.Theme = "Light";
                    html.Attributes.Clear();
                    html.Attributes.Add("class", "bg-white");
                    //      html.Attributes.Add("class", "bg-dark");
                }
                //Server.Transfer("Default.aspx?ChangeTheme=false",false);
                Response.Redirect("./");
            }
            else if (Request.Cookies["theme"].Value == "dark")
            {
                Page.Theme = "Dark";
                html.Attributes.Add("class", "bg-dark");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            string xml = Application["V2xml"].ToString();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);
            DateTime dateTime = Convert.ToDateTime(xmlDocument.GetElementsByTagName("updated")[0].InnerText);
            //DateTime.UtcNow.Date
            if (dateTime.ToUniversalTime().Date == DateTime.UtcNow.Date | dateTime.ToUniversalTime().AddDays(1).Ticks >= DateTime.UtcNow.Ticks)
            {
                #region Old

                //for (int i = 0; i < 0; i++)
                //{
                //    TableRow tableRow = new TableRow();
                //    TableCell tableCell = new TableCell();
                //    TableCell tableCell1 = new TableCell();
                //    TableCell tableCell2 = new TableCell();
                //    TableCell tableCell3 = new TableCell();
                //    tableCell3.Text = "<span class=\"spinner-grow spinner-grow-sm text-warning\"></span>";
                //    tableCell1.Text = i.ToString();
                //    tableCell2.Text = xmlDocument.GetElementsByTagName("summary")[i].InnerText.Split(':')[0].Replace("[停班停課通知]", "");
                //    if (xmlDocument.GetElementsByTagName("summary")[i].InnerText.Split(':').Length == 3)
                //    {
                //        tableCell.Text = xmlDocument.GetElementsByTagName("summary")[i].InnerText.Split(':')[1].Replace("。", "+").Split('+')[0] + ":" +
                //            xmlDocument.GetElementsByTagName("summary")[i].InnerText.Split(':')[2].Replace("。", "+").Split('+')[0];
                //        if (xmlDocument.GetElementsByTagName("summary")[i].InnerText.IndexOf("停止") != -1)
                //        {
                //            tableRow.CssClass += "table-warning1 border1 border-warning1";
                //            //tableCell1.Text = i.ToString() + "<img src='https://material.io/resources/icons/static/icons/round-not_interested-24px.svg' alt='Alternate Text' />";
                //            tableRow.Cells.Add(tableCell3);
                //            tableRow.Cells.Add(tableCell1);
                //            tableRow.Cells.Add(tableCell);
                //            tableRow.Cells.Add(tableCell2);
                //            tableRow.Controls.Add(tableCell);
                //            Table.Controls.Add(tableRow);
                //        }
                //        else
                //        {
                //            //tableCell1.Text = i.ToString() + "<img src='https://material.io/resources/icons/static/icons/round-work-24px.svg' alt='Alternate Text' />";
                //            tableRow.Cells.Add(tableCell1);
                //            tableRow.Cells.Add(tableCell);
                //            tableRow.Cells.Add(tableCell2);
                //            tableRow.Controls.Add(tableCell);
                //            Table1.Controls.Add(tableRow);
                //        }
                //    }
                //    else
                //    {
                //        if (xmlDocument.GetElementsByTagName("summary")[i].InnerText.IndexOf("停止") != -1)
                //        {
                //            tableRow.CssClass += "table-warning1 border1 border-warning1";
                //            //tableCell1.Text = i.ToString() + "<img src='https://material.io/resources/icons/static/icons/round-not_interested-24px.svg' alt='Alternate Text' />";
                //            tableRow.Cells.Add(tableCell3);
                //            tableRow.Cells.Add(tableCell1);
                //            tableRow.Cells.Add(tableCell);
                //            tableRow.Cells.Add(tableCell2);
                //            tableRow.Controls.Add(tableCell);
                //            Table.Controls.Add(tableRow);
                //        }
                //        else
                //        {
                //            //tableCell1.Text = i.ToString() + "<img src='https://material.io/resources/icons/static/icons/round-work-24px.svg' alt='Alternate Text' />";
                //            tableRow.Cells.Add(tableCell1);
                //            tableRow.Cells.Add(tableCell);
                //            tableRow.Cells.Add(tableCell2);
                //            tableRow.Controls.Add(tableCell);
                //            Table1.Controls.Add(tableRow);
                //        }
                //        tableCell.Text = xmlDocument.GetElementsByTagName("summary")[i].InnerText.Split(':')[1].Replace("。", "+").Split('+')[0];

                //    }
                //    //   dictionary.Add(xmlDocument.GetElementsByTagName("summary")[i].InnerText.Split(':')[0].Replace("[停班停課通知]", ""), xmlDocument.GetElementsByTagName("summary")[i].InnerText.Split(':')[1].Replace("。", "+").Split('+')[0]);
                //    //Response.Write(xmlDocument.GetElementsByTagName("summary")[i].InnerText + "<br />");
                //}

                #endregion Old

                for (int i = 0; i < xmlDocument.GetElementsByTagName("summary").Count; i++)
                {
                    DateTime currentTime = Convert.ToDateTime(xmlDocument.GetElementsByTagName("updated")[i + 1].InnerText).ToUniversalTime();
                    int v = 0;
                    if (currentTime.ToUniversalTime().Date == DateTime.UtcNow.Date | currentTime.ToUniversalTime().AddDays(1).Ticks >= DateTime.UtcNow.Ticks)
                    // if (currentTime.Date.Ticks >= DateTime.Now.ToUniversalTime().Date.Ticks)
                    {
                        TableRow tableRow = new TableRow();
                        TableCell tableCell = new TableCell();
                        TableCell tableCell1 = new TableCell();
                        TableCell tableCell2 = new TableCell();
                        TableCell tableCell3 = new TableCell();
                        tableCell.Text = i.ToString();
                        tableCell1.Text = xmlDocument.GetElementsByTagName("summary")[i].InnerText.Split(':')[0].Replace("[停班停課通知]", "");
                        string currentText = xmlDocument.GetElementsByTagName("summary")[i].InnerText;
                        if (xmlDocument.GetElementsByTagName("summary")[i].InnerText.Split(':').Length == 3)
                        {
                            tableCell2.Text = currentText.Split(':')[1].Replace("。", "+").Split('+')[0] + ":" + currentText.Split(':')[2].Replace("。", "+").Split('+')[0];
                        }
                        else
                        {
                            tableCell2.Text = xmlDocument.GetElementsByTagName("summary")[i].InnerText.Split(':')[1].Replace("。", "+").Split('+')[0];
                        }
                        if (xmlDocument.GetElementsByTagName("summary")[i].InnerText.IndexOf("停止") != -1)
                        {
                            tableCell3.Text = "<span class=\"spinner-grow spinner-grow-sm text-warning\"></span>";
                            Table.Controls.Add(tableRow);
                        }
                        else
                        {
                            v++;
                            tableCell3.Text = "<span class=\"spinner-grow spinner-grow-sm text-success\"></span>";
                            Table1.Controls.Add(tableRow);
                        }
                        //tableRow.Cells.Add(tableCell);
                        tableRow.Cells.Add(tableCell1);
                        tableRow.Cells.Add(tableCell2);
                        tableRow.Cells.Add(tableCell3);
                    }
                    if (v == 0)
                    {
                        Table1.Visible = false;
                    }
                }
            }
            else
            {
                TableRow tableRow = new TableRow();
                //TableCell tableCell = new TableCell();
                TableCell tableCell1 = new TableCell();
                TableCell tableCell2 = new TableCell();
                TableCell tableCell3 = new TableCell();
                tableCell1.Text = Properties.LanguageResource.WT;
                tableCell2.Text = Properties.LanguageResource.nocancel;
                tableCell3.Text = "<div class='bg-success rounded-circle' style='width:13px;height:13px'></div>";
                Table.Controls.Add(tableRow);
                // tableRow.Controls.Add(tableCell);
                //tableRow.Cells.Add(tableCell);
                tableRow.Cells.Add(tableCell1);
                tableRow.Cells.Add(tableCell2);
                tableRow.Cells.Add(tableCell3);
                Table1.Visible = false;
            }
        }
    }
}