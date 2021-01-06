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
    public partial class AddEIAssets : System.Web.UI.Page
    {
        ArrayList arr_tb = new ArrayList();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            arr_tb = GetColumns();
            Category_Fill();
            Site_Fill();
            Department_Fill();
            Location_Fill();
        }

        public ArrayList GetColumns()
        {
            Table table = new Table();
            table.ID = "Table1";
            //Page.Form.Controls.Add(table);
            form1div.Controls.Add(table);
            ArrayList arr = new ArrayList();
            try
            { 
                string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    
                    using (SqlCommand cmd = new SqlCommand("SELECT FieldName From Fields;"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                int i = 0;
                                foreach (DataRow row in dt.Rows)
                                {
                                    TableRow row1 = new TableRow();

                                    foreach (DataColumn column in dt.Columns)
                                    {

                                        //CheckBoxList1.Items.Add((string)row[column.ColumnName]);
                                        TableCell cell = new TableCell();
                                        // Add label
                                        Label lb = new Label();
                                        lb.ID = "Label" + i;
                                        lb.Text = (string)row[column.ColumnName] + ": ";
                                        lb.Width = 200;
                                        lb.CssClass = "input-control m-1 p-1 text-right";
                                        cell.Controls.Add(lb);

                                        // Skip Dropdown List and photo
                                        string clmName = (string)row[column.ColumnName];
                                        string clm = clmName.Trim();
                                        if(clm == "Site" || clm== "Category" || clm == "Locations" || clm == "Department" || clm == "Asset Photo")
                                        {
                                            continue;
                                        }
                                        // Add textbox
                                        TextBox tb = new TextBox();
                                        tb.ID = "TextBox" + i;

                                        tb.CssClass = "input-control m-1 p-1";
                                        //tb.Text = "TextBoxRow_" + i + "Col_" + j;
                                        arr.Add(tb);
                                        cell.Controls.Add(tb);
                                        row1.Cells.Add(cell);

                                    }
                                    i++;
                                    table.Rows.Add(row1);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message.Text = ex.Message;  
            }
            return arr;         
        }
        public string generateinsert(string tableName)
        {

            DataTable dataTable = new DataTable();
            string insertst = "";
            string insertval = "";
            string insertstmt = "";
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

                        if (col.ColumnName != "Id")
                        {
                            
                            if (f == 1)
                            {
                                insertst += ", " + col.ColumnName;
                                insertval += ", " + "@" + col.ColumnName;
                            }
                            if (f == 0)
                            {
                                insertst = col.ColumnName;
                                insertval = "@" + col.ColumnName;
                                f = 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message.Text = ex.Message;
            }
            finally
            {
                sqlConn.Close();
            }
            insertstmt = "insert into " + tableName + " (" + insertst + ") Values (" + insertval + ");";

            return insertstmt;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            byte[] assetphoto = new byte[0];
            ArrayList arr_value = new ArrayList();
            ArrayList arr_text = new ArrayList();
            string site = DropDownList1.SelectedItem.Value;
            string category = DropDownList2.SelectedItem.Value;
            string locations = DropDownList3.SelectedItem.Value;
            string department = DropDownList4.SelectedItem.Value;
            int i = 0;
            //GenerateTable(numOfColumns, numOfRows);
            foreach(TextBox text in arr_tb)
            {                
                arr_text.Add(text.Text);                
            }
            
            arr_value = InsertValue("Assets");
            //SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PlanetWrox.mdf;Integrated Security=True");
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            using (conn)
            {
                try
                {
                    //string sql = "insert into AddAssets(AddAssetsId,ApplicationId,AssetTagId,Location,AdditionalPeripherals,ModelNumber,Brand,FundedBy,SerialNumber,WarrantyStatus,AssetValue,Description,FundingSource,AmountDebited,Site,Category,Department,Locations,WindowsLicense,BatteryDetails,MacAddress,SoftwareDetails,AdaptorSerialNumber,AssetPhoto) values (@AddAssetsId,@ApplicationId,@AssetTagId,@Location,@AdditionalPeripherals,@ModelNumber,@Brand,@FundedBy,@SerialNumber,@WarrantyStatus,@AssetValue,@Description,@FundingSource,@AmountDebited,@Site,@Category,@Department,@Locations,@WindowsLicense,@BatteryDetails,@MacAddress,@SoftwareDetails,@AdaptorSerialNumber,@AssetPhoto,@MonitorBrand,@MonitorModelNumber,@MonitorSerialNumber,@OfficeLicense)";
                    string sql = generateinsert("Assets");
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        
                        foreach (string item in arr_value)
                        {                            
                            //Add Values into Assets
                            if (item.Trim()=="Site")
                            {
                                cmd.Parameters.AddWithValue("@Site", site);
                                continue;
                            }
                            if (item.Trim() == "Category")
                            {
                                cmd.Parameters.AddWithValue("@Category", category);
                                continue;
                            }
                            if (item.Trim() == "Department")
                            {
                                cmd.Parameters.AddWithValue("@Department", department);
                                continue;
                            }
                            if (item.Trim() == "Locations")
                            {
                                cmd.Parameters.AddWithValue("@Locations", locations);
                                continue;
                            }
                            if(item.Trim()=="AssetPhoto")
                            {
                                if (AssetPhoto.HasFile)
                                {
                                    using (BinaryReader br = new BinaryReader(AssetPhoto.PostedFile.InputStream))
                                    {
                                        assetphoto = br.ReadBytes(AssetPhoto.PostedFile.ContentLength);
                                        cmd.Parameters.AddWithValue("@AssetPhoto", assetphoto);
                                    }
                                }
                                continue;
                            }
                            cmd.Parameters.AddWithValue("@" + item, arr_text[i]);
                            i++;
                        }

                        // assign value to parameter 
                        cmd.ExecuteNonQuery();
                    }

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    string msg = "Insert Error: ";
                    msg += ex.Message;
                    Message.Text = msg;
                }
                finally
                {
                    conn.Close();
                }
                Message.Text = "Added Assets";
                //form1.Controls.Clear();
                foreach (TextBox text in arr_tb)
                {
                    text.Text = "";
                }
            }
            
        }
        public ArrayList InsertValue(string tableName)
        {
            ArrayList arr = new ArrayList();
            DataTable dataTable = new DataTable();

            string cmdString = String.Format("SELECT TOP 0 * FROM {0}", tableName);
            SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            try
            {
                using (SqlDataAdapter dataContent = new SqlDataAdapter(cmdString, sqlConn))
                {
                    dataContent.Fill(dataTable);
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        if (col.ColumnName != null)
                        {
                            if (col.ColumnName != "Id")
                            {
                                arr.Add(col.ColumnName);
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message.Text = ex.Message;
            }
            finally
            {
                sqlConn.Close();
            }
            return arr;
        }
        protected void Category_Fill()
        {
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT CategoryName From Categorys;"))
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

                                        DropDownList2.Items.Add((string)row[column.ColumnName]);

                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
        protected void Site_Fill()
        {
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT SiteName From Sites;"))
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

                                        DropDownList1.Items.Add((string)row[column.ColumnName]);

                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        protected void Department_Fill()
        {
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT DepartmentName From Departments;"))
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

                                        DropDownList3.Items.Add((string)row[column.ColumnName]);

                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        protected void Location_Fill()
        {
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT LocationName From Locations;"))
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

                                        DropDownList4.Items.Add((string)row[column.ColumnName]);

                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}