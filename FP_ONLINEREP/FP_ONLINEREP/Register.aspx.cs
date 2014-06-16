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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> error = new List<string>();
            error = (List<string>)Session["error"];

            if (error!=null)
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

        protected void SignUp_Click(object sender, EventArgs e)
        {
            string uName = usernamesignup.Value.ToString();
            string email = emailsignup.Value.ToString();
            string pass = passwordsignup.Value.ToString();
            string pass_confirm = passwordsignup_confirm.Value.ToString();


            User result = UserService.getUserByNameOrEmail(uName, email);
           
            List<string> error = new List<string>();
            int wrong = 0;
            if (passwordsignup.Value != passwordsignup_confirm.Value)
            {
                wrong = 1;
                error.Add("password didnt match");
            }
            if (result != null)
            {
                //error message username/password sudah digunakan
                error.Add("username/email already exist");
                wrong = 1;
            }
            if (wrong < 1)
            {
                //Session["error"] = "register success";
                UserService.addNewUser(uName, email, pass);
                Response.Redirect("RegisterRedirect.aspx", true);
            }
            else
            {
                Session["error"] = error;
                Response.Redirect("Register.aspx", true);
            }

        }
    }
}