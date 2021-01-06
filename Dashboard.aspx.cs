using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;
using System.Configuration;
using System.Web.DynamicData;
using System.Collections;
namespace EnAbleIndiaAssets
{
    public partial class Dashboard : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["rdpage"] = "~/Dashboard.aspx";
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from AddAssets", con);

            da.Fill(ds);

            Chart1.DataSource = ds;
            //Chart1.Series[0].ChartType = "Column";
            Chart1.Series[0].XValueMember = "AssetTagId";
            Chart1.Series[0].YValueMembers = "AssetValue";

            con.Close();
        }
       
    }
}