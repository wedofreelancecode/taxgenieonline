using System;
using System.Data;
using TaxGenie_DAL;
using TaxGenie_DAL.HomeContentsTableAdapters;

namespace TaxGenieOnline
{
    public partial class ViewContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HomeContentsTableAdapter contAdptr = new HomeContentsTableAdapter();
            int id = int.Parse(Request.QueryString["Id"]);
            HomeContents.HomeContentsDataTable data = contAdptr.GetContent(id);
            HomeContents.HomeContentsRow dr = data.Rows[0] as HomeContents.HomeContentsRow;
            ltl.Text = dr.Title;
            lbldata.Text = dr.Data;
        }
    }
}