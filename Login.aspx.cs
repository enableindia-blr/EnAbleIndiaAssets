using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace EnAbleIndiaAssets
{
    public partial class About : Page
    {
        //public event EventHandler LoggedIn;
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
            Session["User"] = Login1.UserName;
            Session["Password"] = Login1.Password;
            Response.Redirect("~/Dashboard.aspx");
        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //Response.Cookies.Add(new HttpCookie("UserName", Login1.UserName));
            //Response.Redirect("~/Dashboard.aspx");
            
        }

        protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
        {

            //MembershipUser u = Membership.GetUser(PasswordRecovery1.UserName, false);
            //string password= u.GetPassword();
            //string username = u.UserName; 
            
            //string fileName = Server.MapPath("~/App_Data/SignUpConfirmation.txt");
            //string mailBody = File.ReadAllText(fileName);
            //string mailBody = ("Your Username is:" + <%username%> + "<br/><br/>" + "Your Password is:" + password);
            //MailMessage myMessage = new MailMessage();
            //myMessage.Subject = "Password Change Mail";
            //myMessage.IsBodyHtml = true;
            //myMessage.Body = "Your Username is:" + username + "<br/><br/>" + "Your Password is:" + password + ")";
            //myMessage.From = new MailAddress("nynesh@enableindia.org", "Asset Management");
            //myMessage.To.Add(new MailAddress("nynesh@enableindia.org", "Nynesh AK"));
            //SmtpClient mySmtpClient = new SmtpClient();
            //mySmtpClient.Send(myMessage);
            //Response.Redirect("MyProfile.aspx");
        }

        
    }
}