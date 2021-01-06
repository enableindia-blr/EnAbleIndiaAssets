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
    public partial class Fields : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            int f = 0;
            string fieldname = TextBox1.Text;
            string qrycols = "";
            ArrayList arr = new ArrayList();
            if (RadioButton1.Checked)
            {
                //if (!IsPostBack)
                //allcategory = true;
                //CheckBoxList1.Items.Add();
                //Response.Write("<script>alert('inside');</script>");

            }

            if (RadioButton1.Checked)
            {
                
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Insert into Fields (FieldName,Categories) Values(@FieldName,@Categories);", con);
                    cmd.Parameters.AddWithValue("@FieldName", fieldname);
                    cmd.Parameters.AddWithValue("@Categories", "All Categories");
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table Altered Successfully...");
                    con.Close();
                }
                catch (Exception err)
                {
                    Console.WriteLine("exception occured while creating table:" + err.Message + "\t" + err.GetType());
                }
            }

            if (RadioButton2.Checked)
            {
                string flditem;
                arr = CheckBoxSelect();
                if (arr != null)
                {
                    foreach (string item in arr)
                    {
                        flditem = item.Trim();
                        
                        if (f > 0)
                        {
                            qrycols += ", " + flditem;
                        }
                        else
                        {                            
                                qrycols = flditem;                                
                                f = 1;                            
                        }
                    }
                }
                //var ddl = "ALTER TABLE Fields ADD " + qrycols + ";";
                try
                {
                    var ddl = "Insert into Fields (FieldName,Categories) Values (@FieldName, @Categories);";
                    string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    using (var cmd = new SqlCommand(ddl, con))
                    {
                        cmd.Parameters.AddWithValue("@FieldName", fieldname);
                        cmd.Parameters.AddWithValue("@Categories", qrycols);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("exception occured while creating table:" + err.Message + "\t" + err.GetType());
                }
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
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('inside radio button');</script>");
            if (RadioButton2.Checked)
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

            if (RadioButton1.Checked)
            {
                CheckBoxList1.Visible = false;
            }
        }
    }
}