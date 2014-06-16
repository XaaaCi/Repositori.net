using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FP_ONLINEREP.App_Code;

namespace FP_ONLINEREP
{
    public partial class LoginAndRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uName"] != null)
            {
                Response.Redirect("Home.aspx", true);
                
            }

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string uName = username.Value.ToString();
            string pass = password.Value.ToString();
            
            if (LoginAndRegisterController.tryLogin(uName,pass))
            {
                FP_ONLINEREP.User result = UserService.getUserByNameOrEmail(uName, uName);
                Session["uName"] = uName;
                Session["UId"] = result.UserId;
                Session["Authority"] = result.Authority;
                Response.Redirect("Login.aspx", true);
            }
            else
            {
                errorLabel.Text = "Wrong Username or Password";
            }
            
             
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {

        }
    }
}