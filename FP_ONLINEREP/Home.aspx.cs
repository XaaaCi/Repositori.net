using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FP_ONLINEREP
{
    public partial class Home : System.Web.UI.Page
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
            string message = (string)Session["message"];
            h1.InnerText = message;
            Session.Remove("message");
        }

        protected void Logout(object sender, EventArgs e)
        {
            Session.Remove("uName");
            Session.Remove("Authority");
            Session.Abandon();
            Response.Redirect("LoginAndRegister.aspx", true);
            //Server.Transfer("LoginAndRegister.aspx", true);
        }

        

       
    }
}