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

namespace EnAbleIndiaAssets.Admin
{
    public partial class AssignUserRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DDL_Fill("UserName","aspnet_Users", DropDownList1);
            DDL_Fill("RoleName", "aspnet_Roles", DropDownList2);
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = DropDownList1.SelectedValue.Trim();
            string role = DropDownList2.SelectedValue.Trim();
            Guid userid = GetdataUserId("aspnet_Users", username);
            Guid roleid = GetdataRoleId("aspnet_Roles", role);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            string updatestr = "Update aspnet_UsersInRoles Set RoleId=@RoleId Where UserId='" + userid + "'";
            try
            {
                SqlCommand cmd = new SqlCommand(updatestr, conn);
                cmd.Parameters.Add("@RoleId", SqlDbType.UniqueIdentifier).Value = roleid;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                //Label8.Text = msg;
            }
            finally
            {
                conn.Close();
            }
            Label1.Text = username + " Role changed to: " + UpdateUser(userid);
        }
        public Guid GetdataUserId(string tablename,string name)
        {
            //Guid idval = new Guid();
            Guid val = new Guid();
            //var valret = new Object();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            string selectstmt = "Select aspnet_Users.UserId from " + tablename + " Inner Join aspnet_Membership On aspnet_Users.UserId = aspnet_Membership.UserId Where aspnet_Users.UserName=" + "@Name";
            try
            {
                SqlCommand cmd = new SqlCommand(selectstmt, con);
                cmd.Parameters.AddWithValue("@Name", name);
                con.Open();
                val= (Guid)cmd.ExecuteScalar();
                
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                //Label8.Text = msg;
            }
            finally
            {
                con.Close();
            }
            return val;
        }
        public Guid GetdataRoleId(string tablename, string rolename)
        {
            Guid idval = new Guid();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            string selectstmt = "Select RoleId from " + tablename + " Where RoleName=" +"@Name";
            try
            {
                SqlCommand cmd = new SqlCommand(selectstmt, con);
                cmd.Parameters.AddWithValue("@Name", rolename);
                con.Open();
                idval = (Guid)cmd.ExecuteScalar();
                //using (SqlDataReader sdr = cmd.ExecuteReader())
                //{
                //    sdr.Read();
                //    idval = sdr["RoleId"].ToString();
                //    //txtName.Text = sdr["Name"].ToString();
                //    //txtCountry.Text = sdr["Country"].ToString();
                //}
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                //Label8.Text = msg;
            }
            finally
            {
                con.Close();
            }
            return idval;
        }
        public string UpdateUser(Guid userid)
        {
            string rolename = "";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            string selectstmt = "SELECT aspnet_Roles.RoleName From aspnet_Roles Inner Join aspnet_UsersInRoles On aspnet_Roles.RoleId = aspnet_UsersInRoles.RoleId Where aspnet_UsersInRoles.UserId='"+ userid +"'";
            try
            {
                SqlCommand cmd = new SqlCommand(selectstmt, con);
                //cmd.Parameters.AddWithValue("@Name", rolename);
                con.Open();
                rolename = (string)cmd.ExecuteScalar();
                
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                string msg = "Insert Error:";
                msg += ex.Message;
                //Label8.Text = msg;
            }
            finally
            {
                con.Close();
            }
            return rolename;
        }
    }    
}