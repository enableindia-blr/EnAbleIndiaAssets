using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnAbleIndiaAssets
{
    public partial class AddAssets : System.Web.UI.Page
    {
        private int numOfRows = 0;
        private int numOfColumns = 0;
        //Here’s the code block for the generating the Tables with TextBoxes.

        private void GenerateTable(int colsCount, int rowsCount)
        {


            Table table = new Table();
            table.ID = "Table1";
            Page.Form.Controls.Add(table);


            for (int i = 0; i < rowsCount; i++)
            {
                TableRow row = new TableRow();
                for (int j = 0; j < colsCount; j++)
                {
                    TableCell cell = new TableCell();
                    TextBox tb = new TextBox();

                    tb.ID = "TextBoxRow_" + i + "Col_" + j;

                    cell.Controls.Add(tb);

                    row.Cells.Add(cell);
                }


                table.Rows.Add(row);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            GenerateTable(numOfColumns, numOfRows);
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(TextBox1.Text.Trim(), out numOfColumns) && int.TryParse(TextBox2.Text.Trim(), out numOfRows))
            {

                GenerateTable(numOfColumns, numOfRows);


                ViewState["cols"] = numOfColumns;
                ViewState["rows"] = numOfRows;
            }
            else
            {
                Response.Write("Values are not numeric!");
            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            if (ViewState["cols"] != null && ViewState["rows"] != null)
            {

                Table table = (Table)Page.FindControl("Table1");
                if (table != null)
                {
                    GenerateTable(int.Parse(ViewState["cols"].ToString()), int.Parse(ViewState["rows"].ToString()));


                    for (int i = 0; i < int.Parse(ViewState["rows"].ToString()); i++)
                    {
                        for (int j = 0; j < int.Parse(ViewState["cols"].ToString()); j++)
                        {

                            if (Request.Form["TextBoxRow_" + i + "Col_" + j] != string.Empty)
                            {
                                Response.Write(Request.Form["TextBoxRow_" + i + "Col_" + j] + "<br />");
                            }
                        }
                    }
                }
            }
        }
    }
}