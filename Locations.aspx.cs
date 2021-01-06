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
namespace EnAbleIndiaAssets
{
    public partial class Locations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Ok_Click(object sender, EventArgs e)
        {
            string locationname = TextBox1.Text;
            string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    string sql = "INSERT Into Locations (LocationName) Values (@LocationName);";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@LocationName", locationname);
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
                    con.Close();
                    Response.Redirect("~/AssetsAll.aspx");
                }
            }
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            string rdpage = (string)Session["rdpage"];
            Response.Redirect(rdpage);
        }
    }
}