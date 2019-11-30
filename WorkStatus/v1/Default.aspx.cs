using System;
using System.Web.UI.WebControls;

namespace WorkStatus.v1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //CL1.Text = WorkStatus.Properties.LanguageResource.CL;
            string data = "";
            if (Application["Stop"].ToString() == "0")
            {
                if (Session["L"].ToString() == "C")
                {
                    data = Application["rawdata"].ToString();
                }
                else if (Session["L"].ToString() == "E")
                {
                    data = Application["Erawdata"].ToString();
                }
                //for (int i = 0; i < data.Split(',').Length; i++)
                //{
                //    System.Web.UI.HtmlControls.HtmlGenericControl tr = new System.Web.UI.HtmlControls.HtmlGenericControl("tr");
                //    System.Web.UI.HtmlControls.HtmlGenericControl td = new System.Web.UI.HtmlControls.HtmlGenericControl("td");
                //    System.Web.UI.HtmlControls.HtmlGenericControl td1 = new System.Web.UI.HtmlControls.HtmlGenericControl("td");
                //    System.Web.UI.HtmlControls.HtmlGenericControl td2 = new System.Web.UI.HtmlControls.HtmlGenericControl("td");
                //    td.InnerText = i.ToString();
                //    td1.InnerText = data.Split(',')[i].Split('+')[0];
                //    td2.InnerText = data.Split(',')[i].Split('+')[1];
                //    tr.Controls.Add(td);
                //    tr.Controls.Add(td1);
                //    tr.Controls.Add(td2);
                //}
                for (int i = 0; i < data.Split(',').Length; i++)
                {
                    TableRow tableRow = new TableRow();
                    TableCell tableCell = new TableCell();
                    TableCell tableCell1 = new TableCell();
                    TableCell tableCell2 = new TableCell();

                    tableCell1.Text = i.ToString();
                    tableCell2.Text = data.Split(',')[i].Split('+')[0];
                    tableCell.Text = data.Split(',')[i].Split('+')[1];
                    tableRow.Cells.Add(tableCell1);
                    tableRow.Cells.Add(tableCell);
                    tableRow.Cells.Add(tableCell2);
                    tableRow.Controls.Add(tableCell);
                    Table.Controls.Add(tableRow);
                }
            }
            else
            {
                TableRow tableRow = new TableRow();
                TableCell tableCell = new TableCell();
                TableCell tableCell1 = new TableCell();
                TableCell tableCell2 = new TableCell();
                if (Session["L"].ToString() == "C")
                {
                    tableCell1.Text = "1";
                    tableCell2.Text = "全臺";
                    tableCell.Text = Application["NoChange"].ToString();
                    tableRow.Cells.Add(tableCell1);
                    tableRow.Cells.Add(tableCell);
                    tableRow.Cells.Add(tableCell2);
                    tableRow.Controls.Add(tableCell);
                    Table.Controls.Add(tableRow);
                }
                else if (Session["L"].ToString() == "E")
                {
                    tableCell1.Text = "1";
                    tableCell2.Text = "Whole Taiwan";
                    tableCell.Text = Application["ENoChange"].ToString().Replace("。", ".");
                    tableRow.Cells.Add(tableCell1);
                    tableRow.Cells.Add(tableCell);
                    tableRow.Cells.Add(tableCell2);
                    tableRow.Controls.Add(tableCell);
                    Table.Controls.Add(tableRow);
                }

                //table.Rows.Add(tableRow);
            }
        }

        protected void CL1_Click(object sender, EventArgs e)
        {
        }
    }
}