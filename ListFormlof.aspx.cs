using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.DynamicData;
using System.Collections;

namespace EnAbleIndiaAssets
{
    public partial class ListFormlof : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string tablename = "ExcelLaptop";
            //string category = "Desktop";
            string category = (string)Session["category"];
            if (!IsPostBack)
            {
                if (Session["category"] != null)
                {

                    if (category == "AioPc")
                    {
                        tablename = "ExcelAioPc";
                    }
                    if (category == "Audio Visual")
                    {
                        tablename = "ExcelAudioVisual";
                    }
                    if (category == "Cameras")
                    {
                        tablename = "ExcelCameras";
                    }
                    if (category == "Conference IP Phone")
                    {
                        tablename = "ExcelConfIpPhone";
                    }
                    if (category == "Desktop")
                    {
                        tablename = "ExcelDesktop";
                    }
                    if (category == "Hard Disk Drives")
                    {
                        tablename = "ExcelHdd";
                    }
                    if (category == "Headsets")
                    {
                        tablename = "ExcelHeadsets";
                    }
                    if (category == "Hotspots")
                    {
                        tablename = "ExcelHotspots";
                    }
                    if (category == "Keyboards")
                    {
                        tablename = "ExcelKeyboards";
                    }
                    if (category == "Laptop")
                    {
                        tablename = "ExcelLaptop";
                    }
                    if (category == "Mac Pro")
                    {
                        tablename = "ExcelMacPro";
                    }
                    if (category == "Misc Accessories")
                    {
                        tablename = "ExcelMiscAccess";
                    }
                    if (category == "Monitor")
                    {
                        tablename = "ExcelMonitor";
                    }
                    if (category == "Mouse")
                    {
                        tablename = "ExcelMouse";
                    }
                    if (category == "Networks")
                    {
                        tablename = "ExcelNetworks";
                    }
                    if (category == "Printers")
                    {
                        tablename = "ExcelPrinters";
                    }
                    if (category == "Projectors")
                    {
                        tablename = "ExcelProjectors";
                    }
                    if (category == "Scrap Items")
                    {
                        tablename = "ExcelScrapItems";
                    }
                    if (category == "Server Workstation")
                    {
                        tablename = "ExcelServerWorkStation";
                    }
                    if (category == "Speakers")
                    {
                        tablename = "ExcelSpeakers";
                    }
                    if (category == "Tabs")
                    {
                        tablename = "ExcelTabs";
                    }
                    if (category == "Thin Clients")
                    {
                        tablename = "ExcelThinClients";
                    }
                    if (category == "Ups")
                    {
                        tablename = "ExcelUps";
                    }
                    if (category == "Usb Wifi Dongle")
                    {
                        tablename = "ExcelUsbWifiDongle";
                    }
                    if (category == "Video Conference")
                    {
                        tablename = "ExcelVideoConf";
                    }
                }
                GetColumns(tablename);
                if (Session["Valueslof"] == null)
                {
                    for (int i = 0; i < checkboxlist1.Items.Count; i++)
                        checkboxlist1.Items[i].Selected = true;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["Valueslof"] != null)
                {
                    //string[] arr;
                    ArrayList arr = (ArrayList)Session["Valueslof"];

                    if (arr != null)
                    {
                        foreach (string val in arr)
                        {
                            ListItem chk = checkboxlist1.Items.FindByValue(val);

                            if (chk != null)
                                chk.Selected = true;
                        }
                    }
                }

            }
        }

        public List<string> GetColumns(string tableName)
        {
            List<string> colList = new List<string>();
            DataTable dataTable = new DataTable();


            string cmdString = String.Format("SELECT TOP 0 * FROM {0}", tableName);

            //if (ConnectionManager != null)
            {
                try
                {
                    SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
                    //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    using (SqlDataAdapter dataContent = new SqlDataAdapter(cmdString, sqlConn))
                    {
                        dataContent.Fill(dataTable);

                        foreach (DataColumn col in dataTable.Columns)
                        {
                            colList.Add(col.ColumnName);
                            //if (col.ColumnName != "AssetPhoto" && col.ColumnName != "AddAssetsId" && col.ColumnName != "ApplicationId")
                            if (col.ColumnName != "ASSETPHOTO")
                            {
                                checkboxlist1.Items.Add(col.ColumnName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Message.Text = ex.Message;
                }
            }


            //checkboxlist1.Items[i].Selected = true;
            return colList;
        }

        public string[] getColumnsName()
        {
            List<string> listacolumnas = new List<string>();
            SqlDataReader reader;
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            using (SqlCommand command = sqlConn.CreateCommand())
            {
                command.CommandText = "select column_name from information_schema.columns where table_name = 'AddAssets'";
                sqlConn.Open();
                using (reader = command.ExecuteReader(CommandBehavior.KeyInfo))
                {
                    reader.Read();
                    reader.FieldCount.ToString();
                    var table = reader.GetSchemaTable();
                    foreach (DataColumn column in table.Columns)
                    {
                        listacolumnas.Add(column.ColumnName);
                        checkboxlist1.Items.Add(column.ColumnName);
                    }
                }
            }
            return listacolumnas.ToArray();
        }
        public void PassValues()
        {
            int counter = 0;
            ArrayList arr = new ArrayList();
            for (int i = 0; i < checkboxlist1.Items.Count; i++)
            {
                if (checkboxlist1.Items[i].Selected)
                {
                    if (ViewState["CountLimit"] != null)
                    {
                        counter++;
                        ViewState["CountLimit"] = counter;
                    }
                    else
                    {
                        counter++;
                        ViewState["CountLimit"] = counter;
                    }
                    counter = (int)ViewState["CountLimit"];
                    if (counter < 2)
                    {
                        //Display message if user selects only 1 item
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowBox", "alert('You should select at least 2 items!');", true);
                        //Save the selected items in the Array
                        arr.Add(checkboxlist1.Items[i].Text);
                        checkboxlist1.Items[i].Selected = true;
                    }
                    else
                    {
                        //Save the selected items in the Array
                        arr.Add(checkboxlist1.Items[i].Text);
                        checkboxlist1.Items[i].Selected = true;

                    }
                }

            }
            if (counter == 0)
            {
                //Display message if user selects only 1 item
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowBox", "alert('You should select at least 1 item!');", true);
                //Response.Write("<script>alert('Atleast one item to be selected');</script>");
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                //string script = "<script language=\"javascript\" type=\"text/javascript\">alert('Select atleast one value');</script>";
                //Response.Write(script);

            }
            //Store the values in Session so that we can get the values on the page
            Session["Valueslof"] = arr;
            Session["Count"] = counter;
            //Response.Redirect("GridView.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string rdpage = (string)Session["rdpage"];
            PassValues();
            if ((int)Session["Count"] == 0)
            {
                //string script = "<script language=\"javascript\" type=\"text/javascript\">alert('Select atleast one value');</script>";
                //Response.Write(script);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowBox", "alert('You should select at least 1 item!');", true);
            }
            else
            {
                Response.Redirect("ListofAssets.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            PassValues();
            Response.Redirect("ListofAssets.aspx");
        }
    }
}