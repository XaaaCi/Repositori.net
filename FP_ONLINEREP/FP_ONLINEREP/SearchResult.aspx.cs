using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FP_ONLINEREP.App_Code;

namespace FP_ONLINEREP
{
    public partial class SearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SearchWord"] != null)
            {
                uName.InnerText = Session["uName"].ToString();
                BindData(Session["SearchWord"].ToString());
            }
            else
            {
                header1.InnerText = "no file match the keyword";
            }
        }

        public void BindData(string keyword)
        {
            List<File> data = FileService.getFileByKeyword(keyword).ToList();
            if (data.Any())
            {
                gvFiles.DataSource = data;
                gvFiles.DataBind();
            }
            else
            {
                header1.InnerText = "no file match found";
            }
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session.Remove("uName");
            Session.Remove("Authority");
            Response.Redirect("LoginAndRegister.aspx", true);
            //Server.Transfer("LoginAndRegister.aspx", true);
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string keyword = SearchText.Text.ToString();
            Session["SearchWord"] = keyword;
            Response.Redirect("SearchResult.aspx");
        }
    }
}