using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.DynamicData;
using System.Collections;
using System.Globalization;
namespace EnAbleIndiaAssets
{
    public partial class GridViewSLCOL : System.Web.UI.Page
    {
        static string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);
        string qrycols = "*";

        string category = "";
        string tablename = "";
        
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DDL_Fill("CategoryName", "Categorys", DropDownList1);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["rdpage"] = "~/Admin/GridViewSLCOL.aspx";
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

            tablename = Category_check(category);
            
            if (!IsPostBack)
            {
                //DropDownList1.Items.Clear();
                //DropDownList1.Items.Add("Desktop");
                //DropDownList1.Items.Add("Laptop");
                //DropDownList1.Items.Add("Monitor");
                DropDownList1.SelectedValue = category;
                GetColumns(tablename);
                //gvbind(tablename);
                LoadData(tablename);
                //GridView1.Width = Unit.Pixel(300);
                
            }
        }

        public void loaddata()
        {
            int f = 0;            

            //SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            //DataTable dt = new DataTable();
            if (Session["Values"] != null)
            {
                ArrayList arr = (ArrayList)Session["Values"];
                if (arr != null)
                {
                    foreach (string item in arr)
                    {
                        if (f > 0)
                        {
                            qrycols += ", " + item;
                            //dt.Columns.Add(item);

                        }
                        else
                        {
                            if (item != "AssetPhoto")
                            {
                                //qrycols = "AssetPhoto" + ", " + item;
                                qrycols = item;
                                //dt.Columns.Add(item);
                                f = 1;
                            }
                        }
                    }
                }

            }
            else
            {
                qrycols = "*";
            }

        }
        //Selected columns button click
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DataRowView dr = (DataRowView)e.Row.DataItem;

            //    if (dr["AssetPhoto"].ToString() != "NULL") { 
            //        string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["AssetPhoto"]);
            //        (e.Row.FindControl("AssetsPhoto") as Image).ImageUrl = imageUrl;
            //    }
            //}

            ArrayList arr = new ArrayList();
            string strreplace = "";
            arr = (ArrayList)Session["Values"];
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
                if (arr != null)
                {
                    foreach (string item in arr)
                    {
                        if (f > 0)
                        {
                            if (item != "ASSETPHOTO")
                            {
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
                string qrystr = "Select " + qrycols + " From " + tablename + ";";
                sqlDataAdapter.SelectCommand = new SqlCommand(qrystr, sqlConn);
                sqlDataAdapter.Fill(dt);
            }
            finally
            {
                sqlConn.Close();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListForm.aspx");
        }
        protected void gvbind(string tablename)
        {
            conn.Open();
            string sqlstr = "Select " + qrycols + " from " + tablename +";";
            //string sqlstr = "Select * From ExcelAssets";
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(dt);

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();
            //}
            //else
            //{
            //    ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
            //    GridView1.DataSource = ds;
            //    GridView1.DataBind();
            //    int columncount = GridView1.Rows[0].Cells.Count;
            //    GridView1.Rows[0].Cells.Clear();
            //    GridView1.Rows[0].Cells.Add(new TableCell());
            //    GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
            //    GridView1.Rows[0].Cells[0].Text = "No Records Found";
            //}
            GridView1.DataSource = dt;
            GridView1.DataBind();
            conn.Close();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Guid userid = (Guid)GridView1.DataKeys[e.RowIndex].Value;
            string category = DropDownList1.SelectedValue.Trim();
            Session["category"] = category;
            //Get tablename from dropdown list            
            tablename = Category_check(category);
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("lblID");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete FROM " + tablename + " where SL_NO='" + userid + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            gvbind(tablename);
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind(tablename);
        }

        //Sorting
        protected void GridView1_Sorting(object sender,GridViewSortEventArgs e)
        {
            
            string oldExpression = GridView1.SortExpression;
            string newExpression = e.SortExpression;
            if (oldExpression.IndexOf(newExpression) < 0)
            {
                if (oldExpression.Length > 0)
                    e.SortExpression = newExpression + "," + oldExpression;
                else
                    e.SortExpression = newExpression;
            }
            else
            {
                e.SortExpression = oldExpression;
            }
            
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Guid userid = (Guid)GridView1.DataKeys[e.RowIndex].Value;
            int userid = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("lblID");
            
            int rows = GridView1.Rows.Count;
            ArrayList arr = new ArrayList();
            ArrayList txtbx = new ArrayList();
            string category = DropDownList1.SelectedValue.Trim();
            Session["category"] = category;
            int i = 1;

            //Get tablename from category
            tablename = Category_check(category);
           
            arr = GetColumns(tablename);
            foreach (string item in arr)
            {
                if (item.Trim() != "SL_NO" && item.Trim() != "ASSETPHOTO")
                {
                    TextBox tb = new TextBox();
                    tb.ID = "TextBox" + i.ToString();
                    tb = (TextBox)row.Cells[i + 3].Controls[0];
                    txtbx.Add(tb);
                    i++;
                }

            }
            
            //CultureInfo provider = CultureInfo.InvariantCulture;
            //Boolean datevalid = DateTime.TryParseExact(purchasedate.Text, "dd-MM-yyyy hh:mm:ss", null, DateTimeStyles.None, out DateTime reslt);
            //if (!datevalid)
            //{
            //    purchasedate.Text += " 00:00:00";
            //}
            i = 0;
            //DateTime purchaseddate = DateTime.ParseExact(purchasedate.Text, "dd-MM-yyyy hh:mm:ss", null);
            //double pricedb = Convert.ToDouble(price.Text);
            //double amountdebiteddb = Convert.ToDouble(amountdebited.Text);
            GridView1.EditIndex = -1;
            conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM AddAssets", conn);
            string updatestmt = generateupdate(tablename);
            SqlCommand cmd = new SqlCommand(updatestmt + " " +" Where SL_NO=" + userid + ";", conn);
            //cmd.ExecuteNonQuery();
            //cmd = new SqlCommand("update ExcelLaptop set PURCHASEDDATE=@Purchaseddate" +", "+ "PRICE=@Price" +", " + "AMOUNTDEBITED=@Amountdebited" + " Where SLNO=" + userid + ";", conn);
            //cmd.Parameters.AddWithValue("@Purchaseddate", purchaseddate);
            //cmd.Parameters.AddWithValue("@Price", pricedb);
            foreach (string item in arr) {
                if(item.Trim() != "SL_NO" && item.Trim() != "ASSETPHOTO") { 
                    if (i <= txtbx.Count)
                    {
                        if (item.Trim() == "PURCHASED_DATE")
                        {
                            if (((TextBox)txtbx[i]).Text.Length != 0) 
                            {
                                //Boolean datevalid = DateTime.TryParseExact(((TextBox)txtbx[i]).Text, "dd-MM-yyyy hh:mm:ss", null, DateTimeStyles.None, out DateTime reslt);
                                //if (!datevalid)
                                //{
                                //   ((TextBox) txtbx[i]).Text += " 00:00:00";
                                //}
                                //DateTime purchaseddate = DateTime.ParseExact(((TextBox)txtbx[i]).Text, "dd-MM-yyyy hh:mm:ss", null);
                                DateTime purchaseddate = Convert.ToDateTime(((TextBox)txtbx[i]).Text);
                                cmd.Parameters.AddWithValue("@" + item, purchaseddate);
                                i++;
                                continue;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@" + item, String.Empty);
                                i++;
                                continue;
                            }
                        }
                        if (item.Trim() == "PRICE")
                        {
                            if (((TextBox)txtbx[i]).Text.Length != 0) { 
                                double pricedb = Convert.ToDouble(((TextBox)txtbx[i]).Text);
                                cmd.Parameters.AddWithValue("@" + item, pricedb);
                                i++;
                                continue;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@" + item, 0.00);
                                i++;
                                continue;
                            }
                        }
                        if (item.Trim() == "AMOUNT_DEBITED")
                        {
                            if (((TextBox)txtbx[i]).Text.Length != 0) { 
                                double amountdebiteddb = Convert.ToDouble(((TextBox)txtbx[i]).Text);
                                cmd.Parameters.AddWithValue("@" + item, amountdebiteddb);
                                i++;
                                continue;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@" + item, 0.00);
                                i++;
                                continue;
                            }
                        }
                        cmd.Parameters.AddWithValue("@" + item, ((TextBox)txtbx[i]).Text);
                        i++;

                    }
                }

            }
            
            cmd.ExecuteNonQuery();
            conn.Close();
            gvbind(tablename);
            //GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbind(tablename);
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvbind(tablename);
        }

        //Generate Update Statement
        public string generateupdate(string tableName)
        {

            DataTable dataTable = new DataTable();
            string updatecol = "";
            //string insertval = "";
            string updatestmt = "";
            int f = 0;
            string cmdString = String.Format("SELECT TOP 0 * FROM {0}", tableName);
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            try
            {
                using (SqlDataAdapter dataContent = new SqlDataAdapter(cmdString, sqlConn))
                {
                    dataContent.Fill(dataTable);

                    foreach (DataColumn col in dataTable.Columns)
                    {

                        if (col.ColumnName != "SL_NO" && col.ColumnName != "ASSETPHOTO")
                        {
                            if (f == 1)
                            {
                                updatecol += ", " + col.ColumnName + "= " + "@" + col.ColumnName;
                                //insertval += ", " + "@" + col.ColumnName;
                            }
                            if (f == 0)
                            {
                                updatecol = col.ColumnName + "=" + "@" +col.ColumnName;
                                //insertval = "@" + col.ColumnName;
                                f = 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Message.Text = ex.Message;
            }
            finally
            {
                sqlConn.Close();
            }
            updatestmt = "Update " + tableName + " set "+ updatecol + "";

            return updatestmt;

        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            category = DropDownList1.SelectedValue.Trim();
            Session["category"] = category;
            //Response.Redirect("ListForm.aspx");

            //Get tablename from category
            tablename = Category_check(category);
            
            GetColumns(tablename);
            //LoadData(tablename);
            gvbind(tablename);
            //GridView1.Width = Unit.Pixel(300);
            //GridView1.DataBind();
        }
        public ArrayList GetColumns(string tableName)
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
            return arr;
        }

        public string Category_check(string category)
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