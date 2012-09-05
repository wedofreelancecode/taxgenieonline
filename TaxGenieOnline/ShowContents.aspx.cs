using System;
using TaxGenie_DAL;
using TaxGenie_DAL.HomeContentsTableAdapters;

namespace TaxGenieOnline
{
    public partial class ShowContents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CType= Request.QueryString["CType"];
            lblHeading.Text = CType;
            HomeContentsTableAdapter hContentsadptr = new HomeContentsTableAdapter();
            HomeContents.HomeContentsDataTable hContents = hContentsadptr.GetContentByType(CType, 20);

            foreach (HomeContents.HomeContentsRow row in hContents)
            {
                //if (CType != "Department News")
                //{
                //    row.Title = row.Data;
                //    row.Data = "";
                //}
                //int len = 200 - row.Title.Length;
                //if (row.Data.Length > len && len > 0)
                //    row.Data = row.Data.Substring(0, len);
                row.Data = "";
                if (row.Title.Length > 200)
                    row.Title = row.Title.Substring(0, 200);
            }

            dlDeptNews.DataSource = hContents;
            dlDeptNews.DataBind();
        }
    }
}