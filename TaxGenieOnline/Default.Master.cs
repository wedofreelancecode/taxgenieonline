using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TaxGenie_DAL.newsflashTableAdapters;
using System.Web.Security;

using System.Diagnostics;

namespace TaxGenieOnline
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Page.User.Identity.Name;
            if (Roles.IsUserInRole(username, "Adminstrator"))
            {
                adminpanel.Visible = true;
            }
            if (Roles.IsUserInRole(username, "FreeUsers"))
            {
                adminpanel.Visible = false;
            }

            newsflash_GetDescriptionTableAdapter news = new newsflash_GetDescriptionTableAdapter();
            dlNewsFlash.DataSource= news.GetDatanewsflash();
            dlNewsFlash.DataBind();
        }

        protected void imgSearch_Click1(object sender, ImageClickEventArgs e)
        {
            if (txtSearch.Value != "Search" && txtSearch.Value != "")
            {
                Response.Redirect("~/search.aspx?keyword=" + txtSearch.Value);
            }
            //else
            //{

            //    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "alert", "alert('please enter keywords to perform search')", true);
            //}
        }


    }

}
