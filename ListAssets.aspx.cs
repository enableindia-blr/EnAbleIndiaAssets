using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace EnAbleIndiaAssets
{
    public partial class ListAssets : System.Web.UI.Page
    {
        static string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
        SqlConnection conn = new SqlConnection(constr);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                //{
                //    using (SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM AddAssets", conn))
                //    {
                //        DataTable dt = new DataTable();
                //        sda.Fill(dt);
                //        GridView1.DataSource = dt;
                //        GridView1.DataBind();
                //    }
                //}
                gvbind();
            }
        }
        //Selected columns button click
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;


                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["AssetPhoto"]);
                (e.Row.FindControl("AssetsPhoto") as Image).ImageUrl = imageUrl;

            }
        }
        protected void gvbind()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from AddAssets", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                ds.Tables[0].Rows.Add(ds.Tables[0].NewRow());
                GridView1.DataSource = ds;
                GridView1.DataBind();
                int columncount = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = columncount;
                GridView1.Rows[0].Cells[0].Text = "No Records Found";
            }
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Guid userid = (Guid)GridView1.DataKeys[e.RowIndex].Value;
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("lblID");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete FROM AddAssets where AddAssetsId='" + userid + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            gvbind();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Guid userid = (Guid) GridView1.DataKeys[e.RowIndex].Value;
            GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
            Label lblID = (Label)row.FindControl("lblID");
            //TextBox txtname=(TextBox)gr.cell[].control[];  
            TextBox assettagid = (TextBox)row.Cells[0].Controls[0];
            TextBox location = (TextBox)row.Cells[1].Controls[0];
            TextBox additionalperipherals = (TextBox)row.Cells[2].Controls[0];
            TextBox modelnumber  = (TextBox)row.Cells[3].Controls[0];
            TextBox brand = (TextBox)row.Cells[4].Controls[0];
            TextBox fundedby = (TextBox)row.Cells[5].Controls[0];
            TextBox serialnumber = (TextBox)row.Cells[6].Controls[0];
            TextBox warrantystatus = (TextBox)row.Cells[7].Controls[0];
            TextBox assetvalue = (TextBox)row.Cells[8].Controls[0];
            TextBox description = (TextBox)row.Cells[9].Controls[0];
            TextBox fundingsource = (TextBox)row.Cells[10].Controls[0];
            TextBox amountdebited = (TextBox)row.Cells[11].Controls[0];
            TextBox site = (TextBox)row.Cells[12].Controls[0];
            TextBox category = (TextBox)row.Cells[13].Controls[0];
            TextBox department = (TextBox)row.Cells[14].Controls[0];
            TextBox locations = (TextBox)row.Cells[15].Controls[0];
            TextBox windowslicense = (TextBox)row.Cells[16].Controls[0];
            TextBox batterydetails = (TextBox)row.Cells[17].Controls[0];
            TextBox macaddress = (TextBox)row.Cells[18].Controls[0];
            TextBox softwaredetails = (TextBox)row.Cells[19].Controls[0];
            TextBox adapterserialnumber = (TextBox)row.Cells[20].Controls[0];
            TextBox monitorbrand = (TextBox)row.Cells[21].Controls[0];
            TextBox monitormodelnumber = (TextBox)row.Cells[22].Controls[0];
            TextBox monitorserialnumber = (TextBox)row.Cells[23].Controls[0];
            TextBox officelicense = (TextBox)row.Cells[24].Controls[0];
            

            //TextBox textadd = (TextBox)row.FindControl("txtadd");  
            //TextBox textc = (TextBox)row.FindControl("txtc");  
            GridView1.EditIndex = -1;
            conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM AddAssets", conn);  
            SqlCommand cmd = new SqlCommand("update AddAssets set AssetTagId='" + assettagid.Text + "',Location='" + location.Text + "',AdditionalPeripherals='" + additionalperipherals.Text + "',ModelNumber='" + modelnumber.Text + "',Brand='" + brand.Text + "',FundedBy='" + fundedby.Text + "',SerialNumber='" + serialnumber.Text + "',WarrantyStatus='" + warrantystatus.Text + "',AssetValue='" + assetvalue.Text + "',Description='" + description.Text + "',FundingSource='" + fundingsource.Text + "',AmountDebited='" + amountdebited.Text + "',Site='" + site.Text + "',Category='" + category.Text + "',Department='" + department.Text + "',Locations='" + locations.Text + "',WindowsLicense='" + windowslicense.Text + "',BatteryDetails='" + batterydetails.Text + "',MacAddress='" + macaddress.Text + "',SoftwareDetails='" + softwaredetails.Text + "',AdaptorSerialNumber='" + adapterserialnumber.Text + "',MonitorBrand='" + monitorbrand.Text + "',MonitorModelNumber='" + monitormodelnumber.Text + "',MonitorSerialNumber='" + monitorserialnumber.Text + "',OfficeLicense='" + officelicense.Text + "'where AddAssetsId='" + userid + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            gvbind();
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gvbind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvbind();
        }
    }
}