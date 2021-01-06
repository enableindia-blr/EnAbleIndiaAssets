using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;
using System.Data;
using System.Collections;
using System.Web.DynamicData;

namespace EnAbleIndiaAssets
{
    public partial class Check_Out : System.Web.UI.Page
    {
        //int userid;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //DDL_Fill("SiteName", "Sites", DDL1);
            //DDL_Fill("CategoryName", "Categorys", DDL4);
            //DDL_Fill("DepartmentName", "Departments", DDL3);
            //DDL_Fill("LocationName", "Locations", DDL2);
            if (!Page.IsPostBack)
            {
                string tablename = "Check_In_Out";
                refreshdata(tablename);
                //string stmt = generateupdate(tablename);
                //TextBox1.Text = GridView1.Rows[0].Cells[10].Text;
                TextBox2.Text = (string)Session["User"];
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

        protected void Submit_Click(object sender, EventArgs e)
        {
            //GetSelectedRecords();
            string emailid = TextBox8.Text;
            string assetsstring = "";
            int f = 0;
            //string tablename = "Checked_In_Out";
            foreach (GridViewRow row in GridView2.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        int id = Convert.ToInt32(row.Cells[1].Text);
                        string description = row.Cells[2].Text;
                        string assetname = row.Cells[3].Text;
                        string status = row.Cells[9].Text;
                        string category = row.Cells[10].Text;
                        if (status == "Checked-Out")
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowBox", "alert('The Item Is Already Checked-Out');", true);
                        }
                        if (f==1)
                        {
                            assetsstring = assetsstring + " " + assetname;
                        }
                        else
                        {
                            assetsstring = assetname;
                            f = 1;
                        }                      
                        Update_Database(id, description, assetname, category);
                    }
                }
            }
            Sendemailmessage(assetsstring,emailid);
            //if (GridView1.Rows.Count == 0)
            {
                GridView1.Visible = true;
                AddAssets.Visible = true;
                GridView2.Visible = false;
                Submit.Visible = false;
                TextBox6.Visible = true;
                Button1.Visible = true;
                tablediv.Visible = false;
            }
            // refreshdata(tablename);
            //string rdpage = (string)Session["rdpage"];
            //Response.Redirect(rdpage);
        }
        public void Sendemailmessage(string assetsstring, string emailid)
        {
            string user = (string)Session["User"];
            string mailBody = "(Item Required " + assetsstring + ")";
            MailMessage myMessage = new MailMessage();
            myMessage.Subject = "Request for IT Assets from " + user;
            myMessage.IsBodyHtml = true;
            myMessage.Body = mailBody;
            myMessage.From = new MailAddress("nynesh@enableindia.org", "Asset Management");
            myMessage.To.Add(new MailAddress("nynesh@enableindia.org", emailid));
            SmtpClient mySmtpClient = new SmtpClient();
            mySmtpClient.Send(myMessage);
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int userid = Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text);
            //Session["user_id"] = userid;
            //TextBox1.Text = GridView1.SelectedRow.Cells[2].Text;
            //TextBox2.Text = GridView1.SelectedRow.Cells[3].Text;
            //TextBox3.Text = GridView1.SelectedRow.Cells[4].Text;
            //TextBox4.Text = GridView1.SelectedRow.Cells[5].Text;
            //string status = GridView1.SelectedRow.Cells[8].Text;
            //if (status.Trim() == "Checked-Out")
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowBox", "alert('Item is already Checked-Out!');", true);
            //    TextBox1.Text = "";
            //    TextBox2.Text = "";
            //    TextBox3.Text = "";
            //    TextBox4.Text = "";
            //}
            //else
            //{
            //    TextBox5.Text = "Checked-Out";
            //}
            //if (TextBox1.Text.Trim() == "&nbsp;")
            //{
            //    TextBox1.Text = "";
            //}
            //DDL1.Text = GridView1.SelectedRow.Cells[7].Text;
           // DDL2.Text = GridView1.SelectedRow.Cells[8].Text;
            //DDL3.Text = GridView1.SelectedRow.Cells[9].Text;
           // DDL4.Text = GridView1.SelectedRow.Cells[10].Text;            
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //TextBox1.Text = "Checked Changed";
            //foreach (GridViewRow gvrow in GridView1.Rows)
            //{
            //    CheckBox chk = sender as CheckBox;

            //    if (chk.Checked)
            //    {
            //        GridViewRow row = (GridViewRow)chk.NamingContainer;
            //        TextBox1.Text = row.Cells[2].Text;
            //        TextBox2.Text = row.Cells[3].Text;
            //    }

            //}
        }
        
        protected void Cancel_Click(object sender, EventArgs e)
        {
            string rdpage = (string)Session["rdpage"];
            Response.Redirect(rdpage);
        }

        protected void GetSelectedRecords(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10] { new DataColumn("Id"), new DataColumn("DESCRIPTION"), new DataColumn("ASSET_NAME"), new DataColumn("ASSIGNED_TO"),new DataColumn("ASSIGNED_DATE"),new DataColumn("RETURN_DATE"),new DataColumn("RETURNED_BY"), new DataColumn("RETURNED_DATE"), new DataColumn("STATUS"), new DataColumn("CATEGORY")});
            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        int id = Convert.ToInt32(row.Cells[1].Text);
                        //Session["user_id"] = Convert.ToInt32(id);
                        string description = row.Cells[2].Text;
                        string assetname = row.Cells[3].Text;
                        string assignedto = row.Cells[4].Text;
                        string assigneddate = row.Cells[5].Text;
                        string returndate = row.Cells[6].Text;
                        string returnedby = row.Cells[7].Text;
                        string returneddate= row.Cells[8].Text;
                        string status = row.Cells[9].Text;
                        //string site = row.Cells[10].Text;
                        //string location = row.Cells[11].Text;
                        //string department = row.Cells[9].Text;
                        string category = row.Cells[10].Text;
                        dt.Rows.Add(id,description,assetname,assignedto,assigneddate,returndate,returnedby,returneddate,status,category);
                    }
                }
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
            GridView1.Visible = false;
            GridView2.Visible = true;
            Submit.Visible = true;
            AddAssets.Visible = false;
            tablediv.Visible = true;
            TextBox6.Visible = false;
            Button1.Visible = false;
        }
        public void Update_Database(int id, string description, string assetname, string category)
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            string tablename = "Check_In_Out";
            //string assetname = TextBox1.Text;
            string assignedto = (string)Session["User"]; 

            DateTime assigneddate = Convert.ToDateTime(TextBox3.Text);
            DateTime returndate = Convert.ToDateTime(TextBox4.Text);
            string returnedby = "";
            //DateTime returneddate = Convert.ToDateTime(null);
            string status = TextBox5.Text;
           
            //string site = DDL1.SelectedValue.Trim();
            //string location = DDL2.SelectedValue.Trim();
            //string department = DDL3.SelectedValue.Trim();
            //string category = "";
            //int userid = (int)Session["user_id"];
            
            using (conn)
            {
                try
                {
                    //string sql = "insert into AddAssets(AddAssetsId,ApplicationId,AssetTagId,Location,AdditionalPeripherals,ModelNumber,Brand,FundedBy,SerialNumber,WarrantyStatus,AssetValue,Description,FundingSource,AmountDebited,Site,Category,Department,Locations,WindowsLicense,BatteryDetails,MacAddress,SoftwareDetails,AdaptorSerialNumber,AssetPhoto) values (@AddAssetsId,@ApplicationId,@AssetTagId,@Location,@AdditionalPeripherals,@ModelNumber,@Brand,@FundedBy,@SerialNumber,@WarrantyStatus,@AssetValue,@Description,@FundingSource,@AmountDebited,@Site,@Category,@Department,@Locations,@WindowsLicense,@BatteryDetails,@MacAddress,@SoftwareDetails,@AdaptorSerialNumber,@AssetPhoto,@MonitorBrand,@MonitorModelNumber,@MonitorSerialNumber,@OfficeLicense)";
                    string updatestmt = generateupdate(tablename);
                    //string updatestmt = "Update Check_In_Out Set ASSET_NAME=@ASSET_NAME, ASSIGNED_TO=@ASSIGNED_TO, ASSIGNED_DATE=@ASSIGNED_DATE, RETURN_DATE=@RETURN_DATE, RETURNED_BY=@RETURNED_BY, RETURNED_DATE=@RETURNED_DATE, STATUS=@STATUS, SITE=@SITE, LOCATION=@LOCATION, DEPARTMENT=@DEPARTMENT, CATEGORY=@CATEGORY";
                    SqlCommand cmd = new SqlCommand(updatestmt + " " + " Where Id=" + id + ";", conn);
                    conn.Open();
                    using (cmd)
                    {
                        cmd.Parameters.AddWithValue("@DESCRIPTION", description);
                        cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                        cmd.Parameters.AddWithValue("@ASSIGNED_TO", assignedto);
                        cmd.Parameters.AddWithValue("@ASSIGNED_DATE", assigneddate);
                        cmd.Parameters.AddWithValue("@RETURN_DATE", returndate);
                        cmd.Parameters.AddWithValue("@RETURNED_BY", returnedby);
                        cmd.Parameters.AddWithValue("@RETURNED_DATE", DBNull.Value);
                        cmd.Parameters.AddWithValue("@STATUS", status);
                        //cmd.Parameters.AddWithValue("@SITE", site);
                        //cmd.Parameters.AddWithValue("@LOCATION", location);
                        //cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                        cmd.Parameters.AddWithValue("@CATEGORY", category);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string msg = "Insert Error:";
                    msg += ex.Message;
                    //Label1.Text = msg;
                }
                finally
                {
                    conn.Close();
                }
                //Label1.Text = "Added Assets";
                refreshdata(tablename);
            }
            //return 0;
        }
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
                sqlConn.Open();
                using (SqlDataAdapter dataContent = new SqlDataAdapter(cmdString, sqlConn))
                {
                    dataContent.Fill(dataTable);

                    foreach (DataColumn col in dataTable.Columns)
                    {

                        if (col.ColumnName != "Id" && col.ColumnName != "ASSETPHOTO")
                        {
                            if (f == 1)
                            {
                                updatecol += ", " + col.ColumnName + "= " + "@" + col.ColumnName;
                                //insertval += ", " + "@" + col.ColumnName;
                            }
                            if (f == 0)
                            {
                                updatecol = col.ColumnName + "=" + "@" + col.ColumnName;
                                //insertval = "@" + col.ColumnName;
                                f = 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Label8.Text = ex.Message;
            }
            finally
            {
                sqlConn.Close();
            }
            updatestmt = "Update " + tableName + " set " + updatecol + "";

            return updatestmt;

        }
        public void refreshdata(string tablename)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            string selectstmt = "Select * from " + tablename + " Where STATUS='Checked-In';";
            try
            {
                SqlCommand cmd = new SqlCommand(selectstmt, con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                Label8.Text = msg;
            }
            finally
            {
                con.Close();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string searchtxt = TextBox6.Text;
            string tablename = "Check_In_Out";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            string query = "Select * From " + tablename + " Where STATUS = 'Checked-In' AND (DESCRIPTION Like + @DESCRIPTION + '%' OR ASSET_NAME Like + @ASSET_NAME + '%' OR ASSIGNED_TO like + @ASSIGNED_TO + '%'  OR ASSIGNED_DATE like + @ASSIGNED_DATE + '%' OR RETURN_DATE like + @RETURN_DATE + '%' OR RETURNED_BY like + @RETURNED_BY + '%' OR RETURNED_DATE like + @RETURNED_DATE + '%'  OR CATEGORY like + @CATEGORY + '%')";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@DESCRIPTION", searchtxt);
                    cmd.Parameters.AddWithValue("@ASSET_NAME", searchtxt);
                    cmd.Parameters.AddWithValue("@ASSIGNED_TO", searchtxt);
                    cmd.Parameters.AddWithValue("@ASSIGNED_DATE", searchtxt);
                    cmd.Parameters.AddWithValue("@RETURN_DATE", searchtxt);
                    cmd.Parameters.AddWithValue("@RETURNED_BY", searchtxt);
                    cmd.Parameters.AddWithValue("@RETURNED_DATE", searchtxt);
                    //cmd.Parameters.AddWithValue("@STATUS", searchtxt);
                    //cmd.Parameters.AddWithValue("@SITE", searchtxt);
                    //cmd.Parameters.AddWithValue("@LOCATION", searchtxt);
                    //cmd.Parameters.AddWithValue("@DEPARTMENT", searchtxt);
                    cmd.Parameters.AddWithValue("@CATEGORY", searchtxt);

                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();


                    if (dr.HasRows)
                    {
                        dr.Read();

                        rep_bind(tablename);
                        GridView1.Visible = true;

                        TextBox6.Text = "";
                        Label1.Text = "";
                    }
                    else
                    {
                        GridView1.Visible = false;
                        Label1.Visible = true;
                        Label1.Text = "The search Term " + TextBox6.Text + " &nbsp;Is Not Available in the Records"; ;

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                Label1.Text = msg;
            }
            finally
            {
                conn.Close();
            }
        }
        private void rep_bind(string tablename)
        {
            string searchtxt = TextBox6.Text;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            
            string query = "Select * From " + tablename + " Where STATUS = 'Checked-In' AND (DESCRIPTION Like + @DESCRIPTION + '%' OR ASSET_NAME Like + @ASSET_NAME + '%' OR ASSIGNED_TO like + @ASSIGNED_TO + '%' OR ASSIGNED_DATE like + @ASSIGNED_DATE + '%' OR RETURN_DATE like + @RETURN_DATE + '%' OR RETURNED_BY like + @RETURNED_BY + '%' OR RETURNED_DATE like + @RETURNED_DATE + '%' OR CATEGORY like + @CATEGORY + '%')";
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@DESCRIPTION", searchtxt);
            cmd.Parameters.AddWithValue("@ASSET_NAME", searchtxt);
            cmd.Parameters.AddWithValue("@ASSIGNED_TO", searchtxt);
            cmd.Parameters.AddWithValue("@ASSIGNED_DATE", searchtxt);
            cmd.Parameters.AddWithValue("@RETURN_DATE", searchtxt);
            cmd.Parameters.AddWithValue("@RETURNED_BY", searchtxt);
            cmd.Parameters.AddWithValue("@RETURNED_DATE", searchtxt);
            //cmd.Parameters.AddWithValue("@STATUS", searchtxt);
            //cmd.Parameters.AddWithValue("@SITE", searchtxt);
            //cmd.Parameters.AddWithValue("@LOCATION", searchtxt);
            //cmd.Parameters.AddWithValue("@DEPARTMENT", searchtxt);
            cmd.Parameters.AddWithValue("@CATEGORY", searchtxt);

            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            string tablename = "Check_In_Out";
            GridView1.PageIndex = e.NewPageIndex;
            refreshdata(tablename);
        }
    }
}