using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FP_ONLINEREP.App_Code;

namespace FP_ONLINEREP
{
    public partial class Upload : System.Web.UI.Page
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

        }

        protected void Logout(object sender, EventArgs e)
        {
            Session.Remove("uName");
            Session.Remove("Authority");
            Response.Redirect("LoginAndRegister.aspx", true);
            //Server.Transfer("LoginAndRegister.aspx", true);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            /*
           
                int id = (from f in context.Files
                          select f.FileId).Max();
                         
                int size = fileInput.PostedFile.ContentLength;
                string name = fileInput.PostedFile.FileName;
                int position = name.LastIndexOf("\\");
                name = name.Substring(position + 1);
                string contentType = fileInput.PostedFile.ContentType;
                byte[] fileData = new byte[size];
                fileInput.PostedFile.InputStream.Read(fileData, 0, size);
                File newFile = new File();
                newFile.Name = name;
                newFile.ContentType = contentType;
                newFile.Size = size;
                newFile.Data = fileData;
                newFile.UserId = Convert.ToInt32(Session["UId"]);
                newFile.FileId = id + 1;

                context.Files.Add(newFile);
                context.SaveChanges();
                Session["message"] = "Upload Success";
                Response.Redirect("Home.aspx", true);                
            */
            /*
            
            name = name.Substring(position + 1);
            string contentType = fileInput.PostedFile.ContentType;
            */
            string name = fileInput.PostedFile.FileName;
            int position = name.LastIndexOf("\\");
            int size = fileInput.PostedFile.ContentLength;
            byte[] fileData = new byte[size];
            fileInput.PostedFile.InputStream.Read(fileData, 0, size);
            
            FileService.addNewFile(FileService.makeNewFile(name.Substring(position + 1), fileInput.PostedFile.ContentType, size, fileData, Convert.ToInt32(Session["UId"])));
            Session["message"] = "Upload Success";
            Response.Redirect("Home.aspx", true);
            /*
            foreach(string filetagname in files)
            {
                HttpPostedFile file = Request.Files[filetagname];
                if (file.ContentLength > 0)
                {
                    int size = file.ContentLength;
                    string name = file.FileName;
                    int position = name.LastIndexOf("\\");
                    name = name.Substring(position + 1);
                    string contentType = file.ContentType;
                    byte[] fileData = new byte[size];
                    file.InputStream.Read(fileData, 0, size);
                    
                    //TODO : save to the dadtabase
                    using (Online_RepositoryEntities context = new Online_RepositoryEntities())
                    {
                        
                        File newFile = new File();
                        newFile.Name = name;
                        newFile.ContentType = contentType;
                        newFile.Size = size;
                        newFile.Data = fileData;
                        //try
                        //{
                            context.Files.Add(newFile);
                            context.SaveChanges();
                        //}
                        //catch 
                        //{ 
                        
                        //}
                    }
                }
            }
            */
        }
    }
}