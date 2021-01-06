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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            Profile_Fill();
        }

        protected void Profile_Fill()
        {
            string username = (string) Session["User"];
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT aspnet_Users.UserName, aspnet_Membership.Email From aspnet_Users Inner Join aspnet_Membership On aspnet_Users.UserId = aspnet_Membership.UserId; "))
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

                                    if(row[0].ToString().Trim() == username.Trim())
                                    {

                                        TextBox1.Text = (string)row[0];
                                        TextBox2.Text = (string)row[1];

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