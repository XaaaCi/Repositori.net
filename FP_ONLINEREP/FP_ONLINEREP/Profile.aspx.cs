using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using FP_ONLINEREP.App_Code;


namespace FP_ONLINEREP
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["uName"] == null)
            {
                Response.Redirect("LoginAndRegister.aspx", true);
                //Server.Transfer("LoginAndRegister.aspx", true);
            }
            else
            {
                uName.InnerText = Session["uName"].ToString();
            }

            List<string> error = new List<string>();
            error = (List<string>)Session["error"];

            if (error != null)
            {
                foreach (var text in error)
                {
                    HtmlGenericControl li = new HtmlGenericControl("li");
                    li.InnerText = text;
                    errorlist.Controls.Add(li);
                }
                Session.Remove("error");
            }
        }

        protected void ChangeButton_Click(object sender, EventArgs e)
        {
            string oldPassword = old_password.Value.ToString();
            string newPassword = new_password.Value.ToString();
            string newPasswordConfirm = password_confirm.Value.ToString();

            string uName = Session["uName"].ToString();
            List<string> errorList = new List<string>();

            int wrong = 0;
            if (newPassword != newPasswordConfirm)
            {
                errorList.Add("New password didn't match");
                
                wrong = 1;
            }

            
                
                if (LoginAndRegisterController.tryLogin(uName,oldPassword) && wrong == 0)
                {
                    UserService.changePassword(newPassword, UserService.getUserByName(uName).FirstOrDefault().UserId);
                    Session["message"] = "Password Change Success";
                    Response.Redirect("Home.aspx");

                }
                else
                {
                    errorList.Add("Old Password didn't match");
                }
                Session["error"] = errorList;
                Response.Redirect("Profile.aspx");
             
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session.Remove("uName");
            Session.Remove("Authority");
            Response.Redirect("LoginAndRegister.aspx", true);
            //Server.Transfer("LoginAndRegister.aspx", true);
        }
    }
}