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
using System.Web.DynamicData;
using System.Collections;


namespace EnAbleIndiaAssets
{
    public partial class AddCustomFields : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton4.Checked)
            {
                CheckBoxList1.Visible = true;
                CheckBoxList1.Items.Clear();
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

                                            CheckBoxList1.Items.Add((string)row[column.ColumnName]);

                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (RadioButton3.Checked)
            {
                CheckBoxList1.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fieldname = TextBox1.Text;
            string datatype = DropDownList1.SelectedValue;
            string datareq ="NULL";
            //int f = 0;
            //string qrycols = "";
            //ArrayList arr = new ArrayList();

            if (RadioButton1.Checked) {
                datareq = "NOT" + " " + "NULL";
            }
            if (RadioButton2.Checked)
            {
                datareq = "NULL";
            }

            AlterTable(fieldname, datatype, datareq);
            //if (RadioButton4.Checked)
            //{
            //    string flditem;
            //    arr = CheckBoxSelect();
            //    if (arr != null)
            //    {
            //        foreach (string item in arr)
            //        {
            //            flditem = item.Trim();

            //            if (f > 0)
            //            {
            //                qrycols += ", " + flditem;
            //            }
            //            else
            //            {
            //                qrycols = flditem;
            //                f = 1;
            //            }
            //        }
            //    }
            //    //var ddl = "ALTER TABLE Fields ADD " + qrycols + ";";
            //    try
            //    {
            //        var ddl = "Insert into Fields (FieldName,Categories) Values (@FieldName, @Categories);";

            //        string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
            //        SqlConnection con = new SqlConnection(constr);
            //        con.Open();
            //        using (var cmd = new SqlCommand(ddl, con))
            //        {
            //            cmd.Parameters.AddWithValue("@FieldName", fieldname);
            //            cmd.Parameters.AddWithValue("@Categories", qrycols);
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //    catch (Exception err)
            //    {
            //        Console.WriteLine("exception occured while creating table:" + err.Message + "\t" + err.GetType());
            //    }
            //}

        }
        public void AlterTable(string fieldname,string datatype,string datareq)
        {
            try
            {
                //var ddl = "Insert into Fields (FieldName,Categories) Values (@FieldName, @Categories);";
                var ddl = "ALTER TABLE Fields ADD " + fieldname + " " + datatype + " " + datareq + ";";
                //var ddl = "Alter Table Fields Add MEInumber varchar(50);";
                string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                using (var cmd = new SqlCommand(ddl, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("exception occured while creating table:" + err.Message + "\t" + err.GetType());
            }
        }
        public ArrayList CheckBoxSelect()
        {
            //int j = 0;
            ArrayList arr = new ArrayList();
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    arr.Add(CheckBoxList1.Items[i].Text);
                }
            }
            return arr;
        }
    }
}