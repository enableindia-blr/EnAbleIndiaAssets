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
    public partial class AssetsLaptop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["rdpage"] = "~/Admin/AssetsAll.aspx";
            DDL_Fill("SiteName", "Sites", Siteddl);
            DDL_Fill("CategoryName", "Categorys", Categoryddl);
            DDL_Fill("DepartmentName", "Departments", Departmentddl);
            DDL_Fill("LocationName", "Locations", Locationddl);
            if(!IsPostBack)
            {
                //Default Category selected is AioPC
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
                TextBox18.Visible = true;
                TextBox19.Visible = false;
                TextBox20.Visible = true;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                //ProductKeyInfo.Visible = true;
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = true;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Visible = true;
                ProductKeyInfo.Text = "Product Key Info: ";
            }
            //insertStment = generateinsert("AddAssets");
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
                TextBox18.Visible = true;
                TextBox19.Visible = true;
                TextBox20.Visible = true;
                TextBox21.Visible = true;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = true;
                PowerAdapterSlNo.Visible = true;
                ProductKeyInfo.Visible = true;
                AccessoriesConnected.Visible = true;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = true;
                BatteryFruNo.Text = "Battery FRU No: ";
                PowerAdapterSlNo.Text = "Power Adapter Serial No: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
            }
            else if (category == "Monitor")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = true;
                TextBox9.Visible = false;
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
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                AccessoriesConnected.Visible = true;
                ProductKeyInfo.Visible = true;
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Text = "Service Code: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = false;
                IPAddress_MacAddress.Visible = false;
                ComputerName.Visible = false;
            }
            if (category == "Desktop")
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
                TextBox18.Visible = true;
                TextBox19.Visible = true;
                TextBox20.Visible = true;
                TextBox21.Visible = true;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = true;
                PowerAdapterSlNo.Visible = true;
                AccessoriesConnected.Visible = true;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = true;
                BatteryFruNo.Text = "Monitor Model Number: ";
                PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Visible = true;
                ProductKeyInfo.Text = "Product Key Info: ";
            }
            if (category == "AioPc")
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
                TextBox18.Visible = true;
                TextBox19.Visible = false;
                TextBox20.Visible = true;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                ProductKeyInfo.Visible = true;
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = true;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Visible = true;
                ProductKeyInfo.Text = "Product Key Info: ";
            }
            if (category == "Audio Visual")
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
                TextBox17.Visible = true;
                TextBox18.Visible = false;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = false;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = false;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = true;
                ProductKeyInfo.Text = "Adapter Model Serial No: ";

            }
            if (category == "Cameras")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = false;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = true;
                TextBox18.Visible = true;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = false;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = false;
            }
            if (category == "Conference IP Phone")
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
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = false;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = true;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = true;
                ProductKeyInfo.Text = "Accessories Serial No: ";
            }
            if (category == "Hard Disk Drives")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
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
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = false;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = true;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = false;
                //ProductKeyInfo.Text = "Adapter Model Serial No: ";
            }
            if (category == "Headsets")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = false;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = false;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = true;
                TextBox18.Visible = false;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = false;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = false;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = false;
                //SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = false;
                //ProductKeyInfo.Text = "Adapter Model Serial No: ";
            }
            if (category == "Hotspots")
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
                TextBox18.Visible = true;
                TextBox19.Visible = true;
                TextBox20.Visible = true;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                ProductKeyInfo.Visible = true;
                BatteryFruNo.Visible = true;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = true;
                BatteryFruNo.Text = "Battery Serial No: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "IMEI Number: ";
                ProductKeyInfo.Visible = true;
                ProductKeyInfo.Text = "SIM Number: ";
                ComputerName.Visible = true;
                ComputerName.Text = "SSID WIFI Key: ";
                IPAddress_MacAddress.Visible = true;
                IPAddress_MacAddress.Text = "Data Plan: ";
                Donated_SupportBy.Visible = true;
                Donated_SupportBy.Text = "Alt Number: ";
                AccessoriesConnected.Visible = true;
                AccessoriesConnected.Text = "Account Number: ";
                WarrantyStatus.Visible = true;
                WarrantyStatus.Text = "Password: ";
            }
            //Keyboards
            if (category == "Keyboards")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
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
                
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = false;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = true;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = false;
                //ProductKeyInfo.Text = "Adapter Model Serial No: ";
            }
            //Mac Pro
            if (category == "Mac Pro")
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
                TextBox18.Visible = true;
                TextBox19.Visible = true;
                TextBox20.Visible = true;
                TextBox21.Visible = true;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                //SoftwareDetails.Text = "Software Details: ";
                //ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = true;
                PowerAdapterSlNo.Visible = true;
                AccessoriesConnected.Visible = true;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = true;
                BatteryFruNo.Text = "Monitor Model Number: ";
                PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Visible = true;
                ProductKeyInfo.Text = "Product Key Info: ";
            }
            //Miscellaneous Accessories
            if (category == "Misc Accessories")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
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
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = false;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = true;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = false;
            }
            //Mouse
            if (category == "Mouse")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = false;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = false;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = true;
                TextBox18.Visible = false;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = false;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = false;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                //SoftwareDetails.Text = "Type: ";
                SoftwareDetails.Visible = false;
                ProductKeyInfo.Visible = false;
                //ProductKeyInfo.Text = "Adapter Model Serial No: ";
            }
            //Networks
            if (category == "Networks")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = false;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = true;
                TextBox18.Visible = true;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = false;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = false;
            }
            //Printers
            if (category == "Printers")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = false;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = true;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = true;
                TextBox18.Visible = true;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = true;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = false;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = false;
                //ProductKeyInfo.Text = "Adapter Model Serial No: ";
            }
            //Projectors
            if (category == "Projectors")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
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
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                IssuedTo.Text = "Issued To: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IPAddress_MacAddress.Visible = false;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = true;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = false;
            }
            //Scrap Items
            if (category == "Scrap Items")
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
                TextBox18.Visible = true;
                TextBox19.Visible = true;
                TextBox20.Visible = true;
                TextBox21.Visible = true;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Gate Pass No: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = true;
                PowerAdapterSlNo.Visible = true;
                ProductKeyInfo.Visible = true;
                AccessoriesConnected.Visible = true;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = true;
                BatteryFruNo.Text = "Battery FRU No: ";
                PowerAdapterSlNo.Text = "Power Adapter Serial No: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
            }
            //Servers and Workstations
            if (category == "Server Workstation")
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
                TextBox18.Visible = true;
                TextBox19.Visible = true;
                TextBox20.Visible = true;
                TextBox21.Visible = true;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = true;
                PowerAdapterSlNo.Visible = true;
                AccessoriesConnected.Visible = true;
                IssuedTo.Visible = true;
                IssuedTo.Text = "USB: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = true;
                BatteryFruNo.Text = "Monitor Model Number: ";
                PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Visible = true;
                ProductKeyInfo.Text = "Product Key Info: ";
            }
            //Speakers
            if (category == "Speakers")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = false;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
                TextBox9.Visible = false;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = false;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = true;
                TextBox18.Visible = false;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = false;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = false;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = false;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                //SoftwareDetails.Text = "Type: ";
                SoftwareDetails.Visible = false;
                ProductKeyInfo.Visible = false;
                //ProductKeyInfo.Text = "Adapter Model Serial No: ";
            }
            //Tabs
            if (category == "Tabs")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = true;
                TextBox9.Visible = false;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = true;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = true;
                TextBox18.Visible = true;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Visible = true;
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                ProductKeyInfo.Visible = true;
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = false;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = false;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Visible = true;
                ProductKeyInfo.Text = "Type: ";
            }
            //Thin Clients
            if (category == "Thin Clients")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = false;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = true;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = true;
                TextBox18.Visible = true;
                TextBox19.Visible = true;
                TextBox20.Visible = true;
                TextBox21.Visible = true;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = true;
                PowerAdapterSlNo.Visible = true;
                AccessoriesConnected.Visible = true;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = true;
                BatteryFruNo.Text = "Monitor Model Number: ";
                PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = false;
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Visible = false;
                ProductKeyInfo.Text = "Product Key Info: ";
            }
            //UPS
            if (category == "Ups")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
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
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = false;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = true;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = false;
            }
            //USB WIFI DONGLE
            if (category == "Usb Wifi Dongle")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = true;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = true;
                TextBox18.Visible = true;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = true;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = false;
            }
            //Video conference
            if (category == "Video Conference")
            {
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                TextBox4.Visible = true;
                TextBox5.Visible = true;
                TextBox6.Visible = true;
                TextBox7.Visible = true;
                TextBox8.Visible = false;
                TextBox9.Visible = true;
                TextBox10.Visible = true;
                TextBox13.Visible = true;
                TextBox14.Visible = true;
                TextBox15.Visible = true;
                TextBox16.Visible = true;
                TextBox17.Visible = true;
                TextBox18.Visible = true;
                TextBox19.Visible = false;
                TextBox20.Visible = false;
                TextBox21.Visible = false;
                TextBox11.Visible = true;
                TextBox12.Visible = true;
                //Label Re-Assign
                SoftwareDetails.Text = "Software Details: ";
                ProductKeyInfo.Text = "Product Key Info: ";
                ComputerName.Text = "Computer Name: ";
                IPAddress_MacAddress.Text = "IP Address/Mac Address: ";
                Donated_SupportBy.Text = "Donated/Supported By: ";
                AccessoriesConnected.Text = "Accessories Connected: ";
                WarrantyStatus.Text = "Warranty Status: ";
                BatteryFruNo.Visible = false;
                PowerAdapterSlNo.Visible = false;
                IssuedTo.Visible = true;
                IssuedTo.Text = "Issued To: ";
                IPAddress_MacAddress.Visible = true;
                ComputerName.Visible = false;
                AccessoriesConnected.Visible = true;
                //BatteryFruNo.Text = "Monitor Model Number: ";
                //PowerAdapterSlNo.Text = "Monitor Serial Number: ";
                SoftwareDetails.Visible = true;
                SoftwareDetails.Text = "Type: ";
                ProductKeyInfo.Visible = false;
            }
        }
        //Submit Add Assets
        protected void Submitbtn_Click(object sender, EventArgs e)
        {
            //ArrayList arr = new ArrayList();
            //Guid addassetsid = Guid.NewGuid();
            //Guid applicationid = Guid.NewGuid();
            string description = TextBox1.Text;
            string assetname = TextBox2.Text;
            string placedat = TextBox3.Text;
            string modelno = TextBox4.Text;
            string productslno = TextBox5.Text;
            string softwaredetails = TextBox6.Text;
            string fundedby = TextBox7.Text;
            string productkeyinfo = TextBox8.Text;
            string issuedto = TextBox9.Text;
            string donatedby = TextBox10.Text;
            string warrantystatus = TextBox13.Text;
            string accessories = TextBox14.Text;
            string remarks = TextBox15.Text;
            //string purchasedate = TextBox16.Text;
            //string price = TextBox17.Text;
            string ipaddress = TextBox18.Text;
            string batteryfruno = TextBox19.Text;
            string computername = TextBox20.Text;
            string poweradapter = TextBox21.Text;
            string fundingsource = TextBox11.Text;
            //string amountdebited = TextBox12.Text;
            string site = Siteddl.SelectedItem.Value;
            string category = Categoryddl.SelectedItem.Value.Trim();
            string locations = Locationddl.SelectedItem.Value;
            string department = Departmentddl.SelectedItem.Value;
            string tablename = "ExcelAioPc";
            string type = TextBox6.Text;
            string servicecode = TextBox8.Text;
            string monitormodelno = TextBox19.Text;
            string monitorserialno = TextBox21.Text;
            string adaptermodelsn = TextBox8.Text;
            //Convert String to Date
            //DateTime purchasedate = DateTime.ParseExact(TextBox16.Text, "dd/MM/yyyy", null);
            DateTime purchasedate = Convert.ToDateTime(TextBox16.Text);
            double price = Convert.ToDouble(TextBox17.Text);
            double amountdebited = Convert.ToDouble(TextBox12.Text);
            //Server & Workstation
            string usb = TextBox9.Text;
            //For Hotspots
            string imeinumber = TextBox6.Text;
            string simnumber = TextBox8.Text;
            string ssidwifikey = TextBox20.Text;
            string dataplan = TextBox18.Text;
            string altnumber = TextBox10.Text;
            string accountnumber = TextBox14.Text;
            string password = TextBox13.Text;
            string batterysn = TextBox19.Text;
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
            /*Stream img_strm = AssetPhoto.PostedFile.InputStream;
            //Retrieving the length of the file to upload
            int img_len = AssetPhoto.PostedFile.ContentLength;
            //retrieving the type of the file to upload
            string strtype = AssetPhoto.PostedFile.ContentType.ToString();
            //string strname = txtimgname.Text.ToString();
            byte[] imgdata = new byte[img_len];
            int n = img_strm.Read(imgdata, 0, img_len);*/

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);

            using (conn)
            {
                try
                {
                    //string sql = "insert into AddAssets(AddAssetsId,ApplicationId,AssetTagId,Location,AdditionalPeripherals,ModelNumber,Brand,FundedBy,SerialNumber,WarrantyStatus,AssetValue,Description,FundingSource,AmountDebited,Site,Category,Department,Locations,WindowsLicense,BatteryDetails,MacAddress,SoftwareDetails,AdaptorSerialNumber,AssetPhoto) values (@AddAssetsId,@ApplicationId,@AssetTagId,@Location,@AdditionalPeripherals,@ModelNumber,@Brand,@FundedBy,@SerialNumber,@WARRANTY_STATUS,@AssetValue,@Description,@FUNDING_SOURCE,@AMOUNT_DEBITED,@Site,@Category,@Department,@Locations,@WindowsLicense,@BatteryDetails,@MacAddress,@SOFTWARE_DETAILS,@AdaptorSerialNumber,@AssetPhoto,@MonitorBrand,@MonitorModelNumber,@MonitorSerialNumber,@OfficeLicense)";
                    string sql = generateinsert(tablename);
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //Add values based on category                        
                        if (category == "Laptop")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@PRODUCT_SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@SOFTWARE_DETAILS", softwaredetails);
                            cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            cmd.Parameters.AddWithValue("@POWERADAPTER_SL_NO", poweradapter);
                            cmd.Parameters.AddWithValue("@BATTERY_FRU_NO", batteryfruno);
                            cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        if (category == "Desktop")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@PRODUCT_SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@SOFTWARE_DETAILS", softwaredetails);
                            cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        if (category == "Monitor")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@PRODUCT_SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            cmd.Parameters.AddWithValue("@SERVICE_CODE", servicecode);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        if (category == "AioPc")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@SOFTWARE_DETAILS", softwaredetails);
                            cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            //cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        if (category == "Audio Visual")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            cmd.Parameters.AddWithValue("@ADAPTER_MODEL_SN", adaptermodelsn);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            //cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            //cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            //cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            //cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_GIVEN", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        if (category == "Cameras")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@ADAPTER_MODEL_SN", adaptermodelsn);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@MACADDRESS_IPADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            //cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        if (category == "Conference IP Phone")
                        {
                            cmd.Parameters.AddWithValue("@PARTNO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_SERIAL_NO", adaptermodelsn);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            //cmd.Parameters.AddWithValue("@MACADDRESS_IPADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORTED_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        if (category == "Hard Disk Drives")
                        {
                            cmd.Parameters.AddWithValue("@PRODUCTNO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            //cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            //cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            //cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            //cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        if (category == "Headsets")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            //cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            //cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            //cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATEDBY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            //cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_GIVEN", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        if (category == "Hotspots")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", description);
                            cmd.Parameters.AddWithValue("@IMEI_NUMBER", imeinumber);
                            cmd.Parameters.AddWithValue("@SIM_NUMBER", simnumber);
                            cmd.Parameters.AddWithValue("@BATTERY_S_N", batterysn);
                            cmd.Parameters.AddWithValue("@SSID_WIFI_KEY", ssidwifikey);
                            cmd.Parameters.AddWithValue("@DATAPLAN", dataplan);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@ALT_NUMBER", altnumber);
                            cmd.Parameters.AddWithValue("@PASSWORD", password);
                            cmd.Parameters.AddWithValue("@ACCOUNT_NUMBER", accountnumber);                            
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            //cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        if (category == "Keyboards")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            //cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            //cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            //cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            //cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_GIVEN", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Mac Pro
                        if (category == "Mac Pro")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@SOFTWARE_DETAILS", softwaredetails);
                            cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            //cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Miscellaneous Accessories
                        if (category == "Misc Accessories")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@ADAPTER_MODEL_SN", adaptermodelsn);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            //cmd.Parameters.AddWithValue("@MACADDRESS_IPADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORTED_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_GIVEN", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Mouse
                        if (category == "Mouse")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            //cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            //cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            cmd.Parameters.AddWithValue("@ASSIGNEDTO", issuedto);
                            //cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            //cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            //cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            //cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Networks
                        if (category == "Networks")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@ADAPTER_MODEL_SN", adaptermodelsn);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@MACADDRESS_IPADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            //cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Printers
                        if (category == "Printers")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            //cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@MACADDRESS_IPADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            //cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Projectors
                        if (category == "Projectors")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@ADAPTER_MODEL_SN", adaptermodelsn);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            //cmd.Parameters.AddWithValue("@MACADDRESS_IPADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORTED_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Scrap Items
                        if (category == "Scrap Items")
                        {
                            cmd.Parameters.AddWithValue("@LAPTOPMODELNO", modelno);
                            cmd.Parameters.AddWithValue("@LAPTOPPRODUCT_SERIALNO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@SOFTWARE_DETAILS", softwaredetails);
                            cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            cmd.Parameters.AddWithValue("@POWERADAPTER_SL_NO", poweradapter);
                            cmd.Parameters.AddWithValue("@BATTERY_FRU_NO", batteryfruno);
                            cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORTED_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@GATEPASSNO", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            //cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            //cmd.Parameters.AddWithValue("@PRICE", price);
                            //cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Servers & Workstations
                        if (category == "Server Workstation")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@PRODUCT_SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@SOFTWARE_DETAILS", softwaredetails);
                            cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            cmd.Parameters.AddWithValue("@USB", usb);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Speakers
                        if (category == "Speakers")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            //cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            //cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            //cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ASSIGNEDTO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATEDBY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            //cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            //cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_GIVEN", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Tabs
                        if (category == "Tabs")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", description);
                            cmd.Parameters.AddWithValue("@SOFTWARE_DETAILS", softwaredetails);
                            cmd.Parameters.AddWithValue("@TYPE", productkeyinfo);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@MAC_IPADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORTED_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_GIVEN", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Thin Clients
                        if (category == "Thin Clients")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@ADAPTERDETAILS", description);
                            //cmd.Parameters.AddWithValue("@SOFTWARE_DETAILS", softwaredetails);
                            //cmd.Parameters.AddWithValue("@PRODUCT_KEY_INFO", productkeyinfo);
                            cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@IPADDRESS_MACADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            cmd.Parameters.AddWithValue("@MONITORSERAILNO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //UPS
                        if (category == "Ups")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@CONFIGURATION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@ADAPTER_MODEL_SN", adaptermodelsn);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            //cmd.Parameters.AddWithValue("@MACADDRESS_IPADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_AT", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //USB WIFI DONGLE
                        if (category == "Usb Wifi Dongle")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@ADAPTER_MODEL_SN", adaptermodelsn);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@MAC_ID", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            //cmd.Parameters.AddWithValue("@DONATED_SUPPORT_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            //cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_GIVEN", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
                        //Video Conference
                        if (category == "Video Conference")
                        {
                            cmd.Parameters.AddWithValue("@MODEL_NO", modelno);
                            cmd.Parameters.AddWithValue("@SERIAL_NO", productslno);
                            cmd.Parameters.AddWithValue("@PRODUCT_DESCRIPTION", description);
                            cmd.Parameters.AddWithValue("@TYPE", type);
                            //cmd.Parameters.AddWithValue("@ADAPTER_MODEL_SN", adaptermodelsn);
                            //cmd.Parameters.AddWithValue("@COMPUTER_NAME", computername);
                            cmd.Parameters.AddWithValue("@MAC_IPADDRESS", ipaddress);
                            cmd.Parameters.AddWithValue("@ASSET_NAME", assetname);
                            cmd.Parameters.AddWithValue("@DEPARTMENT", department);
                            //cmd.Parameters.AddWithValue("@MONITOR_SERIAL_NO", monitorserialno);
                            //cmd.Parameters.AddWithValue("@MONITOR_MODEL_NO", monitormodelno);
                            //cmd.Parameters.AddWithValue("@ISSUED_TO", issuedto);
                            cmd.Parameters.AddWithValue("@DONATED_SUPPORTED_BY", donatedby);
                            cmd.Parameters.AddWithValue("@WARRANTY_STATUS", warrantystatus);
                            cmd.Parameters.AddWithValue("@ACCESSORIES_CONNECTED", accessories);
                            cmd.Parameters.AddWithValue("@REMARKS", remarks);
                            cmd.Parameters.AddWithValue("@PURCHASED_DATE", purchasedate);
                            cmd.Parameters.AddWithValue("@PRICE", price);
                            cmd.Parameters.AddWithValue("@PLACED_GIVEN", placedat);
                            cmd.Parameters.AddWithValue("@SITE", site);
                            cmd.Parameters.AddWithValue("@CATEGORY", category);
                            cmd.Parameters.AddWithValue("@FUNDING_SOURCE", fundingsource);
                            cmd.Parameters.AddWithValue("@AMOUNT_DEBITED", amountdebited);
                            cmd.Parameters.AddWithValue("@LOCATION", locations);
                            cmd.Parameters.AddWithValue("@ASSETPHOTO", assetphoto);
                        }
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
                            if (f == 1)
                            {
                                insertst += ", " + col.ColumnName;
                                insertval += ", " + "@" + col.ColumnName;
                            }
                            if (f == 0)
                            {
                                if(col.ColumnName != "SL_NO") { 
                                    insertst = col.ColumnName;
                                    insertval = "@" + col.ColumnName;
                                    f = 1;
                                }
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
            insertstmt = "insert into " + tableName + " (" + insertst + ") Values (" + insertval + ");";

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

        protected void Cancelbtn_Click(object sender, EventArgs e)
        {
            string rdpage = (string) Session["rdpage"];
            Response.Redirect(rdpage);
        }
    }
}