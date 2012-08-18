using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TaxGenie_DAL.newsTableAdapters;

namespace TaxGenieOnline.admin
{
    public partial class shownewsdocuments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string show = Request.QueryString["text"];

            news_GetdetailsbynewsTableAdapter getdata = new news_GetdetailsbynewsTableAdapter();

            DataTable dtGetData = getdata.Getdatabynews(show);
            if (dtGetData.Rows.Count > 0)
            {
                Literal1.Text = dtGetData.Rows[0]["Data"].ToString();
            }
            else
            {
                Response.Write("<script>alert('No document for selected news')</script>)");
            }

        }
    }
}
