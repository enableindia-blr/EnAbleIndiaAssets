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
    public partial class GridView : System.Web.UI.Page
    {
        string category = "";
        string tablename = "";
        public SqlConnection con;
        public string constr;

        public void connection()
        {
            constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ToString();
            con = new SqlConnection(constr);
            con.Open();

        }
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack) {                

                DDL_Fill("CategoryName", "Categorys", DropDownList1);
            }
        }

        protected void DDL_Fill(string colname, string tablename, DropDownList ddl)
        {
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT " + colname + " From " + tablename + ";"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                foreach (DataRow row in dt.Rows)
                                {
                                    foreach (DataColumn column in dt.Columns)
                                    {
                                        ddl.Items.Add((string)row[column.ColumnName]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void LoadData(string tablename)
        {
            int f = 0;
            
            string qrycols = "";
            
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dt = new DataTable();
            if (Session["Values"] != null)
            {
                ArrayList arr = (ArrayList)Session["Values"];
                if (arr != null) { 
                    foreach (string item in arr)
                    {
                        if (f > 0)
                        {
                            if (item != "ASSETPHOTO") { 
                                qrycols += ", " + item;
                                dt.Columns.Add(item);
                            }
                        }
                        else
                        {   
                            qrycols = item;
                            dt.Columns.Add(item);
                            f = 1;                                                        
                        }       
                    }
                }
                
            }
            else
            {
                qrycols = "*";
            }
            sqlConn.Open();
            try
            {
                string qrystr = "Select " + qrycols + " From "+ tablename +";";
                sqlDataAdapter.SelectCommand = new SqlCommand(qrystr, sqlConn);
                sqlDataAdapter.Fill(dt);
            }
            finally
            {
                sqlConn.Close();
            }
            GridView1.DataSource = dt;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["rdpage"] = "~/GridView.aspx";
            if (Session["category"] == null)
            {                
                category = DropDownList1.SelectedValue.Trim();
                Session["category"] = category;
                DropDownList1.SelectedValue = category;
            }
            //DropDownList1.Items.Clear();
            category = (string)Session["category"];
            //category = "Desktop";
            //DropDownList1.DataTextField = category;
            //DropDownList1.DataValueField = category;
            //DropDownList1.DataBind();
            tablename = category_check(category);
            
            if (!IsPostBack) 
            {
                //DropDownList1.Items.Clear();
                //DropDownList1.Items.Add("Desktop");
                //DropDownList1.Items.Add("Laptop");
                //DropDownList1.Items.Add("Monitor");
                DropDownList1.SelectedValue = category;
                Session["tblname"] = tablename;
                if (Session["Values"] == null)
                {
                    GetColumns(tablename);
                }
                LoadData(tablename);
                //GridView1.Columns[0].HeaderText="Sl No";
                GridView1.Width = Unit.Pixel(300);
                GridView1.DataBind();           
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            category = DropDownList1.SelectedValue.Trim();
            Session["category"] = category;
            //Session["rdpage"] = "GridView.aspx";
            Response.Redirect("ListForm.aspx");            
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DataRowView dr = (DataRowView)e.Row.DataItem;

            //    if ((string)dr["AssetPhoto"]!= "NULL")
            //    {
            //        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["AssetPhoto"]);
            //        (e.Row.FindControl("AssetsPhoto") as Image).ImageUrl = imageUrl;
            //    }
            //}
            ArrayList arr = new ArrayList();
            string strreplace = "";
            arr = (ArrayList) Session["Values"];
            if (e.Row.RowType == DataControlRowType.Header)
            {
                // int j = 0;
                //for (int i = 0; i < e.Row.Cells.Count; i++)
                if (arr != null)
                {
                    foreach (string item in arr)
                    {
                        //e.Row.Cells[i].Text = "Sl No";
                        for (int i = 0; i < e.Row.Cells.Count; i++)
                        {
                            if (string.Compare(e.Row.Cells[i].Text, item.Trim(), true) == 0)
                            {
                                strreplace = item.Trim();
                                e.Row.Cells[i].Text = strreplace.Replace('_', ' ');
                                continue;
                            }
                        }
                    }
                }
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            category = DropDownList1.SelectedValue.Trim();
            Session["category"] = category;
            //Response.Redirect("ListForm.aspx");

            tablename = category_check(category);
            Session["tblname"] = tablename;
            GetColumns(tablename);
            LoadData(tablename);
            GridView1.Width = Unit.Pixel(300);
            GridView1.DataBind();
        }
        public void GetColumns(string tableName)
        {
            
            DataTable dataTable = new DataTable();
            ArrayList arr = new ArrayList();

            string cmdString = String.Format("SELECT TOP 0 * FROM {0}", tableName);
         
            try
            {
                SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                using (SqlDataAdapter dataContent = new SqlDataAdapter(cmdString, sqlConn))
                {
                    dataContent.Fill(dataTable);

                    foreach (DataColumn col in dataTable.Columns)
                    {                           
                        arr.Add(col.ColumnName);                            
                    }
                }
            }
            catch (Exception ex)
            {
                //Message.Text = ex.Message;
            }             
            Session["Values"] = arr;            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string tablename = (string)Session["tblname"];
            string search = TextBox1.Text;
            connection();
            string query = SelectData(tablename);
            //string query = "Select * From " + tablename + " Where (MODELNO Like + @MODELNO + '%' OR ASSETNAME like + @ASSETNAME + '%')";
            SqlCommand com = new SqlCommand(query, con);
            //com.Parameters.AddWithValue("@MODELNO", TextBox1.Text);
            //com.Parameters.AddWithValue("@ASSETNAME", TextBox1.Text);
            if (Session["Values"] != null)
            {
                ArrayList arr = (ArrayList)Session["Values"];
                if (arr != null)
                {
                    foreach (string item in arr)
                    {
                        if (item.Trim() != "ASSETPHOTO" && item.Trim() != "SL_NO")
                        {
                            com.Parameters.AddWithValue("@" + item, search);
                        }

                    }
                }
            }

            SqlDataReader dr;
            dr = com.ExecuteReader();


            if (dr.HasRows)
            {
                dr.Read();

                rep_bind(tablename);
                GridView1.Visible = true;

                TextBox1.Text = "";
                Label1.Text = "";
            }
            else
            {
                GridView1.Visible = false;
                Label1.Visible = true;
                Label1.Text = "The search Term " + TextBox1.Text + " &nbsp;Is Not Available in the Records"; ;

            }

        }
        private void rep_bind(string tablename)
        {
            string search = TextBox1.Text;
            connection();
            string query = SelectData(tablename);
            //string query = "Select * From " + tablename + " Where (MODELNO Like + @MODELNO + '%' OR ASSETNAME like + @ASSETNAME + '%')";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand com = new SqlCommand(query, con);
            //com.Parameters.AddWithValue("@MODELNO", TextBox1.Text);
            //com.Parameters.AddWithValue("@ASSETNAME", TextBox1.Text);
            if (Session["Values"] != null)
            {
                ArrayList arr = (ArrayList)Session["Values"];
                if (arr != null)
                {
                    foreach (string item in arr)
                    {
                        if (item.Trim() != "ASSETPHOTO" && item.Trim() != "SL_NO")
                        {
                            com.Parameters.AddWithValue("@" + item, search);
                        }
                    }
                }
            }

            da.SelectCommand = com;
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        private string SelectData(string tablename)
        {
            int f = 0;
            string qryselect = "";
            string qrycols = "";
            string qrycolssl = "";
            
            if (Session["Values"] != null)
            {
                ArrayList arr = (ArrayList)Session["Values"];
                if (arr != null) 
                { 
                    foreach (string item in arr)
                    {
                        if (f > 0)
                        {
                            if (item.Trim() != "ASSETPHOTO" && item.Trim() != "SL_NO")
                            { 
                                qrycols += " OR " + item.Trim() + " like + " + "@" + item.Trim() + "+'%'";
                                qrycolssl += ", " + item.Trim();
                            }
                        }
                        else
                        {
                            if (item.Trim() != "ASSETPHOTO" && item.Trim() != "SL_NO")
                            {
                                qrycols = item.Trim() + " like + " + "@" +item.Trim() + "+'%'";
                                qrycolssl = "SL_NO, " + item.Trim();
                                f = 1;
                            }
                        }       
                    }
                }
                
            }
            else
            {
                qrycols = "MODELNO LIKE @MODELNO%";
            }
            qryselect = "Select " + qrycolssl + " From " + tablename + " Where (" + qrycols +")";
            return qryselect;            
        }
        public string category_check(string category)
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
            return tablename;
        }
    }
}