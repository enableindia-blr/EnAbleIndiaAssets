using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnAbleIndiaAssets
{
    public partial class Modaltest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie cookieUserName = Request.Cookies["UserName"];
                //HttpCookie cookiepassword = Request.Cookies["Password"];
                if (cookieUserName != null)
                {
                    //if (Login1.RememberMeSet == true)
                    {
                        Login1.UserName = cookieUserName.Value;
                        //Login1.Password = cookiepassword.Value;

                    }

                }
            }

            if (User.Identity.IsAuthenticated == true)
            {
                Response.Redirect("~/Dashboard.aspx");
            }
        }
        public void OnLoggedIn(object sender, EventArgs e)
        {

            Response.Cookies.Add(new HttpCookie("UserName", Login1.UserName));
            //Response.Cookies.Add(new HttpCookie("Password", Login1.Password));
            Response.Redirect("~/Dashboard.aspx");
        }
    }
}