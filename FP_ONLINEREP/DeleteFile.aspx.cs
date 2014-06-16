using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FP_ONLINEREP.App_Code;

namespace FP_ONLINEREP
{
    public partial class DeleteFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.QueryString["ID"]);


            /*IEnumerable<File> result = from f in context.Files
                                       where f.FileId == id
                                       select f;
            */
            IEnumerable<File> result = FileService.getFileByID(id);
            if (result.Any())
            {
                File fileToDelete = result.FirstOrDefault();
                name.Text = fileToDelete.Name;
                type.Text = fileToDelete.ContentType;
                size.Text = Convert.ToString(fileToDelete.Size);

            }
            else
            {
                Response.Redirect("FileNotFound.aspx");
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.QueryString["ID"]);
            if (Session["uName"] == null)
            {
                Response.Redirect("LoginAndRegister.aspx", true);
                //Server.Transfer("LoginAndRegister.aspx", true);
            }
            else
            {
            }
        

            using (Online_RepositoryEntities context = new Online_RepositoryEntities())
            {
                /*
                IEnumerable<File> result = from f in context.Files
                                           where f.FileId == id
                                           select f;
                */
                IEnumerable<File> result = FileService.getFileByID(id);
                
                if (result.Any())
                {
                    FileService.deleteFile(id);
                    Response.Redirect("FileList.aspx");
                }
                else
                {
                    error.Text = "FILE NOT FOUND";

                }
            }
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