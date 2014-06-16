using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FP_ONLINEREP.App_Code;
namespace FP_ONLINEREP
{
    public partial class GetFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.QueryString["ID"]);

            
            List<File> result = FileService.getFileByID(id).ToList();
            if (result.Any())
            {
                File fileToSend = result.FirstOrDefault();
                string name = fileToSend.Name;
                string contentType = fileToSend.ContentType;
                Byte[] data = (Byte[])fileToSend.Data;

                Response.AddHeader("Content-type", contentType);
                Response.AddHeader("Content-Disposition", "attachment; filename=" + name);
                Response.BinaryWrite(data);
                Response.Flush();
                Response.End();
            }
            else
            {
                Response.Redirect("FileNotFound.aspx");
            }

        }
    }
}