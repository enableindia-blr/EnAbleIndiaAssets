using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Collections;
using System.Web.DynamicData;

namespace EnAbleIndiaAssets
{
    public partial class Assets : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string insertStment = "";
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            TextBox4.Visible = true;
            TextBox5.Visible = true;
            TextBox6.Visible = true;
            TextBox7.Visible = true;
            TextBox8.Visible = true;
            TextBox9.Visible = true;
            TextBox10.Visible = true;
            TextBox13.Visible = true;
            TextBox14.Visible = true;
            TextBox15.Visible = true;
            TextBox16.Visible = true;
            TextBox17.Visible = true;
            TextBox18.Visible = false;
            TextBox19.Visible = false;
            TextBox20.Visible = false;
            TextBox21.Visible = false;
            TextBox11.Visible = true;
            TextBox12.Visible = true;
            AdditionalPeripherals.Visible = true;
            WindowsLicense.Visible = true;
            BatteryDetails.Visible = true;
            MacAddress.Visible = true;
            SoftwareDetails.Visible = true;
            AdaptorSerialNumber.Visible = true;
            MonitorBrand.Visible = false;
            MonitorModelNumber.Visible = false;
            MonitorSerailNumber.Visible = false;
            OfficeLicense.Visible = false;
            Category_Fill();
            Site_Fill();
            Department_Fill();
            Location_Fill();
            //insertStment = generateinsert("AddAssets");
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

                                        Categoryddl.Items.Add((string)row[column.ColumnName]);

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

                                        Siteddl.Items.Add((string)row[column.ColumnName]);

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

                                        Departmentddl.Items.Add((string)row[column.ColumnName]);

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

                                        Locationddl.Items.Add((string)row[column.ColumnName]);

                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //string message = Categoryddl.SelectedItem.Text + " - " + Categoryddl.SelectedItem.Value;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + message + "');", true);

            string category = Categoryddl.SelectedItem.Value;
            category = category.Trim();
            if (category == "Laptop")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = true;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = true;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = true;
                TextBox18.Visible = false;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                AdditionalPeripherals.Visible = true;
                WindowsLicense.Visible = true;
                BatteryDetails.Visible = true;
                MacAddress.Visible = true;
                SoftwareDetails.Visible = true;
                AdaptorSerialNumber.Visible = true;
                MonitorBrand.Visible = false;
                MonitorModelNumber.Visible = false;
                MonitorSerailNumber.Visible = false;
                OfficeLicense.Visible = false;
            }
            else if (category == "Monitor")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = false;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = true;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox13.Visible = false;
                TextBox14.Visible = false;
                TextBox15.Visible = false;
                TextBox16.Visible = false;
                TextBox17.Visible = false;
                TextBox18.Visible = false;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                AdditionalPeripherals.Visible = false;
                WindowsLicense.Visible = false;
                BatteryDetails.Visible = false;
                MacAddress.Visible = false;
                SoftwareDetails.Visible = false;
                AdaptorSerialNumber.Visible = false;
                MonitorBrand.Visible = false;
                MonitorModelNumber.Visible = false;
                MonitorSerailNumber.Visible = false;
                OfficeLicense.Visible = false;
            }
            if (category == "DeskTop")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = true;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = false;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = false;
                TextBox18.Visible = true;
                TextBox19.Visible = true;
                TextBox20.Visible = true;
                TextBox21.Visible = true;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                AdditionalPeripherals.Visible = true;
                WindowsLicense.Visible = true;
                BatteryDetails.Visible = false;
                MacAddress.Visible = true;
                SoftwareDetails.Visible = true;
                AdaptorSerialNumber.Visible = false;
                MonitorBrand.Visible = true;
                MonitorModelNumber.Visible = true;
                MonitorSerailNumber.Visible = true;
                OfficeLicense.Visible = true;
            }
        }
        //protected void Submitbtn_Click(object sender, EventArgs e)
        //{
        //    //ArrayList arr = new ArrayList();
        //    //Guid addassetsid = Guid.NewGuid();
        //    //Guid applicationid = Guid.NewGuid();
        //    string description = TextBox1.Text;
        //    string assettagid = TextBox2.Text;
        //    string location = TextBox3.Text;
        //    string addperipherals = TextBox4.Text;
        //    string modelnumber = TextBox5.Text;
        //    string brand = TextBox6.Text;
        //    string fundedby = TextBox7.Text;
        //    string serialnumber = TextBox8.Text;
        //    string warrantyStatus = TextBox9.Text;
        //    string assetvalue = TextBox10.Text;
        //    string windowslicense = TextBox13.Text;
        //    string batterydetails = TextBox14.Text;
        //    string macaddress = TextBox15.Text;
        //    string softwaredetails = TextBox16.Text;
        //    string adaptorserialnumber = TextBox17.Text;
        //    string monitorbrand = TextBox18.Text;
        //    string monitormodelnumber = TextBox19.Text;
        //    string officelicense = TextBox20.Text;
        //    string monitorserialnumber = TextBox21.Text;
        //    string fundingsource = TextBox11.Text;
        //    string amountdebited = TextBox12.Text;
        //    string site = Siteddl.SelectedItem.Value;
        //    string category = Categoryddl.SelectedItem.Value;
        //    string locations = Locationddl.SelectedItem.Value;
        //    string department = Departmentddl.SelectedItem.Value;
        //    //string assetphoto = AssetPhoto.FileName;
        //    //Label1.Text = "Inside Submit";
        //    byte[] assetphoto = new byte[0];
        //    //Uploading Image Data
        //    if (AssetPhoto.HasFile)
        //    {
        //        using (BinaryReader br = new BinaryReader(AssetPhoto.PostedFile.InputStream))
        //        {
        //            assetphoto = br.ReadBytes(AssetPhoto.PostedFile.ContentLength);
        //        }
        //    }

        //    /*Stream img_strm = AssetPhoto.PostedFile.InputStream;
        //    //Retrieving the length of the file to upload
        //    int img_len = AssetPhoto.PostedFile.ContentLength;
        //    //retrieving the type of the file to upload
        //    string strtype = AssetPhoto.PostedFile.ContentType.ToString();
        //    //string strname = txtimgname.Text.ToString();
        //    byte[] imgdata = new byte[img_len];
        //    int n = img_strm.Read(imgdata, 0, img_len);*/

        //    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PlanetWrox.mdf;Integrated Security=True");
            
        //    using (conn)
        //    {
        //        try
        //        {
        //            //string sql = "insert into AddAssets(AddAssetsId,ApplicationId,AssetTagId,Location,AdditionalPeripherals,ModelNumber,Brand,FundedBy,SerialNumber,WarrantyStatus,AssetValue,Description,FundingSource,AmountDebited,Site,Category,Department,Locations,WindowsLicense,BatteryDetails,MacAddress,SoftwareDetails,AdaptorSerialNumber,AssetPhoto) values (@AddAssetsId,@ApplicationId,@AssetTagId,@Location,@AdditionalPeripherals,@ModelNumber,@Brand,@FundedBy,@SerialNumber,@WarrantyStatus,@AssetValue,@Description,@FundingSource,@AmountDebited,@Site,@Category,@Department,@Locations,@WindowsLicense,@BatteryDetails,@MacAddress,@SoftwareDetails,@AdaptorSerialNumber,@AssetPhoto,@MonitorBrand,@MonitorModelNumber,@MonitorSerialNumber,@OfficeLicense)";
        //            string sql = generateinsert("AddAssets");
        //            conn.Open();
        //            using (SqlCommand cmd = new SqlCommand(sql, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@AddAssetsId", Guid.NewGuid());
        //                cmd.Parameters.AddWithValue("@ApplicationId", Guid.NewGuid());
        //                cmd.Parameters.AddWithValue("@AssetTagId", assettagid);
        //                cmd.Parameters.AddWithValue("@Location", location);
        //                cmd.Parameters.AddWithValue("@AdditionalPeripherals", addperipherals);
        //                cmd.Parameters.AddWithValue("@ModelNumber", modelnumber);
        //                cmd.Parameters.AddWithValue("@Brand", brand);
        //                cmd.Parameters.AddWithValue("@FundedBy", fundedby);
        //                cmd.Parameters.AddWithValue("@SerialNumber", serialnumber);
        //                cmd.Parameters.AddWithValue("@WarrantyStatus", warrantyStatus);
        //                cmd.Parameters.AddWithValue("@AssetValue", assetvalue);
        //                cmd.Parameters.AddWithValue("@Description", description);
        //                cmd.Parameters.AddWithValue("@FundingSource", fundingsource);
        //                cmd.Parameters.AddWithValue("@AmountDebited", amountdebited);
        //                cmd.Parameters.AddWithValue("@Site", site);
        //                cmd.Parameters.AddWithValue("@Category", category);
        //                cmd.Parameters.AddWithValue("@Department", department);
        //                cmd.Parameters.AddWithValue("@Locations", locations);
        //                cmd.Parameters.AddWithValue("@WindowsLicense", windowslicense);
        //                cmd.Parameters.AddWithValue("@BatteryDetails", batterydetails);
        //                cmd.Parameters.AddWithValue("@MacAddress", macaddress);
        //                cmd.Parameters.AddWithValue("@SoftwareDetails", softwaredetails);
        //                cmd.Parameters.AddWithValue("@AdaptorSerialNumber", adaptorserialnumber);
        //                cmd.Parameters.AddWithValue("@AssetPhoto", assetphoto);
        //                cmd.Parameters.AddWithValue("@MonitorBrand", monitorbrand);
        //                cmd.Parameters.AddWithValue("@MonitorModelNumber", monitormodelnumber);
        //                cmd.Parameters.AddWithValue("@MonitorSerialNumber", monitorserialnumber);
        //                cmd.Parameters.AddWithValue("@OfficeLicense", officelicense);
        //                // assign value to parameter 
        //                cmd.ExecuteNonQuery();
        //            }

        //        }
        //        catch (System.Data.SqlClient.SqlException ex)
        //        {
        //            string msg = "Insert Error:";
        //            msg += ex.Message;
        //            Label1.Text = msg;
        //        }
        //        finally
        //        {
        //            conn.Close();
        //        }
        //        //Label1.Text = "Added Assets";
        //    }
        //}

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
                            
                        if (col.ColumnName != null)
                        {
                            if (f==1)
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
                Label1.Text = ex.Message;
            }
            finally
            {
                sqlConn.Close();
            }
            insertstmt = "insert into AddAssets (" + insertst + ") Values (" + insertval + ");";
                               
            return insertstmt;

        }
        
        public ArrayList insertvalue(string tableName)
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
                            arr.Add(col.ColumnName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = ex.Message;
            }
            finally
            {
                sqlConn.Close();
            }          
            return arr;

        }
        protected void Sitebtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Sites.aspx");
            
        }

        protected void Locationbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Locations.aspx");
        }

        protected void Categorybtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Categories.aspx");
        }

        protected void Departmentbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Departments.aspx");
        }
    
        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            //ArrayList arr = new ArrayList();
            //Guid addassetsid = Guid.NewGuid();
            //Guid applicationid = Guid.NewGuid();
            string description = TextBox1.Text;
            string assettagid = TextBox2.Text;
            string location = TextBox3.Text;
            string addperipherals = TextBox4.Text;
            string modelnumber = TextBox5.Text;
            string brand = TextBox6.Text;
            string fundedby = TextBox7.Text;
            string serialnumber = TextBox8.Text;
            string warrantyStatus = TextBox9.Text;
            string assetvalue = TextBox10.Text;
            string windowslicense = TextBox13.Text;
            string batterydetails = TextBox14.Text;
            string macaddress = TextBox15.Text;
            string softwaredetails = TextBox16.Text;
            string adaptorserialnumber = TextBox17.Text;
            string monitorbrand = TextBox18.Text;
            string monitormodelnumber = TextBox19.Text;
            string officelicense = TextBox20.Text;
            string monitorserialnumber = TextBox21.Text;
            string fundingsource = TextBox11.Text;
            string amountdebited = TextBox12.Text;
            string site = Siteddl.SelectedItem.Value;
            string category = Categoryddl.SelectedItem.Value;
            string locations = Locationddl.SelectedItem.Value;
            string department = Departmentddl.SelectedItem.Value;
            //string assetphoto = AssetPhoto.FileName;
            //Label1.Text = "Inside Submit";
            byte[] assetphoto = new byte[0];
            //Uploading Image Data
            if (AssetPhoto.HasFile)
            {
                using (BinaryReader br = new BinaryReader(AssetPhoto.PostedFile.InputStream))
                {
                    assetphoto = br.ReadBytes(AssetPhoto.PostedFile.ContentLength);
                }
            }

            /*Stream img_strm = AssetPhoto.PostedFile.InputStream;
            //Retrieving the length of the file to upload
            int img_len = AssetPhoto.PostedFile.ContentLength;
            //retrieving the type of the file to upload
            string strtype = AssetPhoto.PostedFile.ContentType.ToString();
            //string strname = txtimgname.Text.ToString();
            byte[] imgdata = new byte[img_len];
            int n = img_strm.Read(imgdata, 0, img_len);*/

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PlanetWrox.mdf;Integrated Security=True");

            using (conn)
            {
                try
                {
                    //string sql = "insert into AddAssets(AddAssetsId,ApplicationId,AssetTagId,Location,AdditionalPeripherals,ModelNumber,Brand,FundedBy,SerialNumber,WarrantyStatus,AssetValue,Description,FundingSource,AmountDebited,Site,Category,Department,Locations,WindowsLicense,BatteryDetails,MacAddress,SoftwareDetails,AdaptorSerialNumber,AssetPhoto) values (@AddAssetsId,@ApplicationId,@AssetTagId,@Location,@AdditionalPeripherals,@ModelNumber,@Brand,@FundedBy,@SerialNumber,@WarrantyStatus,@AssetValue,@Description,@FundingSource,@AmountDebited,@Site,@Category,@Department,@Locations,@WindowsLicense,@BatteryDetails,@MacAddress,@SoftwareDetails,@AdaptorSerialNumber,@AssetPhoto,@MonitorBrand,@MonitorModelNumber,@MonitorSerialNumber,@OfficeLicense)";
                    string sql = generateinsert("AddAssets");
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@AddAssetsId", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@ApplicationId", Guid.NewGuid());
                        cmd.Parameters.AddWithValue("@AssetTagId", assettagid);
                        cmd.Parameters.AddWithValue("@Location", location);
                        cmd.Parameters.AddWithValue("@AdditionalPeripherals", addperipherals);
                        cmd.Parameters.AddWithValue("@ModelNumber", modelnumber);
                        cmd.Parameters.AddWithValue("@Brand", brand);
                        cmd.Parameters.AddWithValue("@FundedBy", fundedby);
                        cmd.Parameters.AddWithValue("@SerialNumber", serialnumber);
                        cmd.Parameters.AddWithValue("@WarrantyStatus", warrantyStatus);
                        cmd.Parameters.AddWithValue("@AssetValue", assetvalue);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@FundingSource", fundingsource);
                        cmd.Parameters.AddWithValue("@AmountDebited", amountdebited);
                        cmd.Parameters.AddWithValue("@Site", site);
                        cmd.Parameters.AddWithValue("@Category", category);
                        cmd.Parameters.AddWithValue("@Department", department);
                        cmd.Parameters.AddWithValue("@Locations", locations);
                        cmd.Parameters.AddWithValue("@WindowsLicense", windowslicense);
                        cmd.Parameters.AddWithValue("@BatteryDetails", batterydetails);
                        cmd.Parameters.AddWithValue("@MacAddress", macaddress);
                        cmd.Parameters.AddWithValue("@SoftwareDetails", softwaredetails);
                        cmd.Parameters.AddWithValue("@AdaptorSerialNumber", adaptorserialnumber);
                        cmd.Parameters.AddWithValue("@AssetPhoto", assetphoto);
                        cmd.Parameters.AddWithValue("@MonitorBrand", monitorbrand);
                        cmd.Parameters.AddWithValue("@MonitorModelNumber", monitormodelnumber);
                        cmd.Parameters.AddWithValue("@MonitorSerialNumber", monitorserialnumber);
                        cmd.Parameters.AddWithValue("@OfficeLicense", officelicense);
                        // assign value to parameter 
                        cmd.ExecuteNonQuery();
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
                //Label1.Text = "Added Assets";
            }
        }
    }
}
