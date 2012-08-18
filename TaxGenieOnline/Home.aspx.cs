using System;
using TaxGenie_DAL;
using TaxGenie_DAL.HomeContentsTableAdapters;

namespace TaxGenieOnline
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HomeContentsTableAdapter hContentsadptr = new HomeContentsTableAdapter();
            HomeContents.HomeContentsDataTable hContents = hContentsadptr.GetContentByType("Editor Desk", 2);
            foreach (HomeContents.HomeContentsRow row in hContents)
            {
                int len = 90 - row.Title.Length;
                if (row.Data.Length > len && len > 0)
                    row.Data = row.Data.Substring(0, len);
            }
            dlEditorDesk.DataSource = hContents;
            dlEditorDesk.DataBind();


            HomeContents.HomeContentsDataTable caseContents = hContentsadptr.GetContentByType("Case Analysis", 2);
            foreach (HomeContents.HomeContentsRow row in caseContents)
            {
                int len = 90 - row.Title.Length;
                if (row.Data.Length > len && len > 0)
                    row.Data = row.Data.Substring(0, len);
            }
             dlCaseAnalysis.DataSource = caseContents;
             dlCaseAnalysis.DataBind();
        }
    }
}
