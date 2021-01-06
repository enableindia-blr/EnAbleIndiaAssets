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
    public partial class AddEIAssetsDynamic : System.Web.UI.Page
    {
        ArrayList arr_tb = new ArrayList();
        ArrayList arr_lbl = new ArrayList();
        Table table = new Table();
        DropDownList ddl1 = new DropDownList();
        DropDownList ddl2 = new DropDownList();
        DropDownList ddl3 = new DropDownList();
        DropDownList ddl4 = new DropDownList();
        FileUpload AssetPhoto = new FileUpload();
        protected void Page_Load(object sender, EventArgs e)
        {
            arr_tb = GetColumnsTest();
            //Fill all the Drop Down Lists            
            DDL_Fill("SiteName", "Sites", ddl1);
            DDL_Fill("CategoryName", "Categorys", ddl2);
            DDL_Fill("DepartmentName", "Departments", ddl3);
            DDL_Fill("LocationName", "Locations", ddl4);
            categorycheck();
        }

        public ArrayList GetColumns()
        {            
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
                                        arr_lbl.Add(lb);

                                        // Skip Dropdown List and photo
                                        string clmName = (string)row[column.ColumnName];
                                        string clm = clmName.Trim();
                                        if (clm == "Site")
                                        {

                                            ddl1.ID = "Ddl" + i;
                                            ddl1.CssClass = "input-control m-1 p-1";
                                            arr.Add(ddl1);
                                            cell.Controls.Add(ddl1);
                                            row1.Cells.Add(cell);
                                            continue;
                                        }

                                        if (clm == "Category")
                                        {

                                            ddl2.ID = "Ddl" + i;
                                            ddl2.CssClass = "input-control m-1 p-1";
                                            ddl2.AutoPostBack = true;
                                            ddl2.SelectedIndexChanged += Status_SelectedIndexChanged;
                                            arr.Add(ddl2);
                                            cell.Controls.Add(ddl2);
                                            row1.Cells.Add(cell);
                                            continue;
                                        }
                                        if (clm == "Department")
                                        {

                                            ddl3.ID = "Ddl" + i;
                                            ddl3.CssClass = "input-control m-1 p-1";
                                            arr.Add(ddl3);
                                            cell.Controls.Add(ddl3);
                                            row1.Cells.Add(cell);
                                            continue;
                                        }
                                        if (clm == "Locations")
                                        {

                                            ddl4.ID = "Ddl" + i;
                                            ddl4.CssClass = "input-control m-1 p-1";
                                            arr.Add(ddl4);
                                            cell.Controls.Add(ddl4);
                                            row1.Cells.Add(cell);
                                            continue;
                                        }
                                        // Add Asset Photo
                                        if (clm == "Asset Photo")
                                        {
                                            AssetPhoto.ID = "Fld" + i;
                                            AssetPhoto.CssClass = "form-control m-1 p-1";
                                            arr.Add(AssetPhoto);
                                            cell.Controls.Add(AssetPhoto);
                                            row1.Cells.Add(cell);
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

        public void Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            categorycheck();
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
            string site = ddl1.SelectedItem.Value;
            string category = ddl2.SelectedItem.Value;            
            string department = ddl3.SelectedItem.Value;
            string locations = ddl4.SelectedItem.Value;
            int i = 0;
            //GenerateTable(numOfColumns, numOfRows);
            //foreach (TextBox text in arr_tb)
            //{
            //    arr_text.Add(text.Text);
            //}
            // Select Controls
            foreach (Control ctr in arr_tb)
            {
                if (ctr is TextBox)
                {
                    arr_text.Add(((TextBox)ctr).Text);
                }
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
                            if (item.Trim() == "Site")
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
                            if (item.Trim() == "AssetPhoto")
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
                            if ( i <= arr_text.Count)
                            {
                                cmd.Parameters.AddWithValue("@" + item, arr_text[i]);
                                i++;
                            }                       
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
                
                foreach (Control ctr in arr_tb)
                {
                    if (ctr is TextBox)
                    {
                        ((TextBox)ctr).Text = "";
                    }                    
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
        

        //Get Columns Test
        public ArrayList GetColumnsTest()
        {
            int counter = 0;
            Message.Text = "";
            table.ID = "Table1";
            //Page.Form.Controls.Add(table);
            form1div.Controls.Add(table);
            ArrayList arr = new ArrayList();
            ArrayList arrtemp = new ArrayList();
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
                                foreach(DataRow row in dt.Rows)
                                {
                                    arrtemp.Add((string)row[0]);                                    
                                }
                                int k = 0;
                                int m = (dt.Rows.Count / 2) + (dt.Rows.Count % 2);
                                while (k < m )
                                {
                                    if (counter == dt.Rows.Count)
                                    {
                                        break;
                                    }
                                    TableRow row1 = new TableRow();
                                    row1.HorizontalAlign = HorizontalAlign.Justify;
                                    row1.VerticalAlign = VerticalAlign.Middle;
                                    for (int j=0;j<=1;j++)
                                    {

                                        //CheckBoxList1.Items.Add((string)row[column.ColumnName]);
                                        TableCell cell = new TableCell();
                                        // Add label
                                        Label lb = new Label();
                                        lb.ID = "Label" + i;
                                        lb.Text = (string)arrtemp[i] + ": ";
                                        lb.Width = 200;
                                        lb.CssClass = "input-control m-1 p-1 text-right";
                                        cell.Controls.Add(lb);
                                        arr_lbl.Add(lb);
                                        // Skip Dropdown List and photo
                                        //string clmName = (string)row[0];
                                        string clmName = (string) arrtemp[i];
                                        string clm = clmName.Trim();
                                        if (clm == "Site")
                                        {

                                            ddl1.ID = "Ddl" + i;
                                            ddl1.CssClass = "input-control m-1 p-1";
                                            arr.Add(ddl1);
                                            cell.Controls.Add(ddl1);
                                            row1.Cells.Add(cell);
                                            i++;
                                            counter++;
                                            continue;
                                        }

                                        if (clm == "Category")
                                        {

                                            ddl2.ID = "Ddl" + i;
                                            ddl2.CssClass = "input-control m-1 p-1";
                                            ddl2.AutoPostBack = true;
                                            ddl2.SelectedIndexChanged += Status_SelectedIndexChanged;
                                            arr.Add(ddl2);
                                            cell.Controls.Add(ddl2);
                                            row1.Cells.Add(cell);
                                            i++;
                                            counter++;
                                            continue;
                                        }
                                        if (clm == "Department")
                                        {

                                            ddl3.ID = "Ddl" + i;
                                            ddl3.CssClass = "input-control m-1 p-1";
                                            arr.Add(ddl3);
                                            cell.Controls.Add(ddl3);
                                            row1.Cells.Add(cell);
                                            i++;
                                            counter++;
                                            continue;
                                        }
                                        if (clm == "Locations")
                                        {

                                            ddl4.ID = "Ddl" + i;
                                            ddl4.CssClass = "input-control m-1 p-1";
                                            arr.Add(ddl4);
                                            cell.Controls.Add(ddl4);
                                            row1.Cells.Add(cell);
                                            i++;
                                            counter++;
                                            continue;
                                        }
                                        // Add Asset Photo
                                        if (clm == "Asset Photo")
                                        {
                                            AssetPhoto.ID = "Fld" + i;
                                            AssetPhoto.CssClass = "form-control m-1 p-1";
                                            cell.Controls.Add(AssetPhoto);
                                            row1.Cells.Add(cell);
                                            i++;
                                            counter++;
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
                                        i++;
                                        counter++;
                                    }
                                    
                                    k++;
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
        
        public void categorycheck()
        {
            string categorysel = ddl2.SelectedItem.Value;

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {

                    using (SqlCommand cmd = new SqlCommand("SELECT Categories From Fields;"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                int i = 0;
                                foreach (Label lbl in arr_lbl)
                                {
                                    lbl.Visible = false;
                                }
                                foreach (Control ctr in arr_tb)
                                {
                                    ctr.Visible = false;
                                }
                                foreach (DataRow row in dt.Rows)
                                {

                                    foreach (DataColumn column in dt.Columns)
                                    {
                                        string catgsel = (string)row[column.ColumnName];
                                        
                                        if (catgsel.Trim() == "All Categories")
                                        {
                                            if (arr_lbl[i] is Label)
                                            {
                                                ((Label)arr_lbl[i]).Visible = true;
                                            }
                                            if (arr_tb[i] is TextBox)
                                            {
                                                ((TextBox)arr_tb[i]).Visible = true;
                                            }
                                            if (arr_tb[i] is DropDownList)
                                            {
                                                ((DropDownList)arr_tb[i]).Visible = true;
                                            }
                                            if (arr_tb[i] is FileUpload)
                                            {
                                                ((FileUpload)arr_tb[i]).Visible = true;
                                            }
                                            continue;
                                        }

                                        string[] catearr = catgsel.Split(',');
                                        foreach (string ctrst in catearr)
                                        {
                                            if ( ctrst.Trim() == categorysel.Trim())
                                            {
                                                if (arr_lbl[i] is Label)
                                                {
                                                    ((Label)arr_lbl[i]).Visible = true;
                                                }
                                                if (arr_tb[i] is TextBox)
                                                {
                                                    ((TextBox)arr_tb[i]).Visible = true;
                                                }
                                                if (arr_tb[i] is DropDownList)
                                                {
                                                    ((DropDownList)arr_tb[i]).Visible = true;
                                                }
                                                if (arr_tb[i] is FileUpload)
                                                {
                                                    ((FileUpload)arr_tb[i]).Visible = true;
                                                }
                                                continue;
                                            }
                                        }
                                    }
                                    i++;
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
        }
        //Fill All DDL
        protected void DDL_Fill(string colname, string tablename, DropDownList ddl)
        {
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT " + colname + " From " +  tablename +";"))
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
    }
}