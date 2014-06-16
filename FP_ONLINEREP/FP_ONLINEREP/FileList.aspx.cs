using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FP_ONLINEREP.App_Code;

namespace FP_ONLINEREP
{
    public partial class FileList : System.Web.UI.Page
    {
        public string id;
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
                BindData();
            }

        }

        public void BindData()
        {
            
                int authority = Convert.ToInt16(Session["authority"]);
                if (authority == 1)
                {
                    string uname = Session["uNAme"].ToString();

                    gvFiles.DataSource = FileService.getAllFile();
                    gvFiles.DataBind();

                }
                else
                {
                    string uname = Session["uNAme"].ToString();
                    var result = UserService.getUserByNameOrEmail(uname, uname);
                    
                    var data = FileService.getFileByOwner(result.UserId);
                    gvFiles.DataSource = data.ToList();
                    gvFiles.DataBind();

                }
                
            
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session.Remove("uName");
            Session.Remove("Authority");
            Response.Redirect("LoginAndRegister.aspx", true);
            //Server.Transfer("LoginAndRegister.aspx", true);
        }

        protected void saveToId(string text)
        {
            id = text;
        }

        
    }
}