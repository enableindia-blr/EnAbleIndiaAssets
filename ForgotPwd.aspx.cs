using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace EnAbleIndiaAssets
{
    public partial class ForgotPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendEmail(object sender, EventArgs e)
        {
            //string username = (string)Session["User"];
            string username = "Nynesh";
            string email = string.Empty;
            string password = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["AssetConnectionString1"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //using (SqlCommand cmd = new SqlCommand("SELECT Email, [Password] FROM aspnet_Membership WHERE Email = @Email"))
                using (SqlCommand cmd = new SqlCommand("SELECT UserName, Email, [Password] From aspnet_Users Inner Join aspnet_Membership On aspnet_Users.UserId = aspnet_Membership.UserId Where aspnet_Users.UserName = @UserName;"))
                {
                    
                    cmd.Parameters.AddWithValue("@UserName", username);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            username = sdr["UserName"].ToString();
                            email = sdr["Email"].ToString();
                            password = sdr["Password"].ToString();
                        }
                    }

                    con.Close();
                }
            }
            if (!string.IsNullOrEmpty(password))
            {
                //string to = "nynesh@enableindia.org"; //To address    
                //string from = "fromaddress@gmail.com"; //From address    

                MailMessage mm = new MailMessage("nynesh@enableindia.org", txtEmail.Text.Trim());
                mm.Subject = "Password Recovery";
                mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", username, password);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.mail.yahoo.com";
                //smtp.EnableSsl = false;
                //NetworkCredential NetworkCred = new NetworkCredential();
                //NetworkCred.UserName = "ak_nynesh@yahoo.co.in";
                //NetworkCred.Password = "M12a#1968r";
                //smtp.UseDefaultCredentials = true;
                //smtp.Credentials = NetworkCred;
                //smtp.Port = 465;
                smtp.Send(mm);
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Password has been sent to your email address.";
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "This email address does not match our records.";
            }
        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}