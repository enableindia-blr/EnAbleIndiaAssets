using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace EnAbleIndiaAssets.Master_Pages
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user_name = (string) Session["User"];
            if (Roles.IsUserInRole(user_name, "Administrator")) {

                //Session["Values"] = null;
                cardwidth.Visible = true;
                cardwidth2.Style.Add("width", "75%");
                cardwidth2.Style.Add("padding", "2%");
                //cardwidth2.Style.Add("margin", "5px");
            }
            else
            {
                //Session["Values"] = null;
                cardwidth.Visible = true;
                cardwidth2.Style.Add("width", "75%");
                cardwidth2.Style.Add("padding", "2%");
                //cardwidth2.Style.Add("margin", "1%");
            }

        }
        
    }
}