using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Data.Common;

namespace EnAbleIndiaAssets
{
    public partial class ExcelToSQL : System.Web.UI.Page
    {
        string tablename = "Check_In_Out";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Table_Name();
                //tablename = DropDownList1.SelectedValue.ToString();
                //BindGridview(tablename);
            }
        }

        private void BindGridview(string tablename)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                string sqlstr = "select * from " + tablename + ";";
                SqlCommand cmd = new SqlCommand(sqlstr, con);
                //cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/UploadFile/" + FileUpload1.FileName));
                    FileUpload1.SaveAs(path);
                    // Connection String to Excel Workbook  
                    //string excelCS = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1;\"", path);
                    string excelCS = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";
                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", con);
                        con.Open();
                        // Create DbDataReader to Data Worksheet  
                        DbDataReader dr = cmd.ExecuteReader();
                        
                        // SQL Server Connection String  
                        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                        // Bulk Copy to SQL Server   
                        SqlBulkCopy bulkInsert = new SqlBulkCopy(CS);
                        bulkInsert.DestinationTableName = tablename;
                        bulkInsert.WriteToServer(dr);
                        BindGridview(tablename);
                        lblMessage.Text = "Your file uploaded successfully";
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            
        }
        //public void Table_Name()
        //{
        //    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(CS))
        //    {
        //        string sqlstr = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='PlanetWrox'";
        //        SqlCommand cmd = new SqlCommand(sqlstr, con);
        //        //cmd.CommandType = CommandType.StoredProcedure;
        //        con.Open();
        //        DropDownList1.DataSource = cmd.ExecuteReader();
        //        DropDownList1.DataBind();
        //        con.Close();
        //    }
        //}

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            tablename = DropDownList1.SelectedValue.ToString();
            BindGridview(tablename);
        }
    }

}