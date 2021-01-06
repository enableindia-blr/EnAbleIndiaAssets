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
    public partial class Temp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            byte[] assetphoto = new byte[0];
            //Uploading Image Data
            if (FileUpload1.HasFile)
            {
                using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    assetphoto = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
                }
            }

            for(int i=1;i<=177;i++)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString);
                conn.Open();
                string sql = "update ExcelAssets set ASSETPHOTO = '" + assetphoto + "'where SLNO='" + i + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}