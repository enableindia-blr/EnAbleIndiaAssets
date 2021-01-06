using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
namespace EnAbleIndiaAssets
{
    public partial class listvalues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Values"] != null)
            {
                ArrayList arr = (ArrayList)Session["Values"];
                foreach (string item in arr)
                {
                    Response.Write(item + "<BR/>");
                }
            }
        }
    }
}