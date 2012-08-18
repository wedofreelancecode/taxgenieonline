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
            // newsflash_GetDescriptionTableAdapter fetchdata = new newsflash_GetDescriptionTableAdapter();
            // DataTable dtDesc = fetchdata.GetDatanewsflash();
            //// if (dtDesc.Rows.Count > 0)
            ////// {
            //   //  string news = string.Empty;
            //   ////  for (int i = 0; i < dtDesc.Rows.Count; i++)
            //    // {
            //       //  string desc = dtDesc.Rows[i]["Newsflash"].ToString() + "&nbsp;&nbsp;&nbsp;";
            //       //  news = news + desc;
            //    // }
            //   //  lblnewsflash.Text = news;
            // }
        }

        protected void imgSearch_Click1(object sender, ImageClickEventArgs e)
        {
            if (txtSearch.Value != "Search" && txtSearch.Value != "")
            {
                Response.Redirect("~/search.aspx?keyword=" + txtSearch.Value);
            }
        }


    }

}
