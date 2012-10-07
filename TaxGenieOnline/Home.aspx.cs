using System;
using TaxGenie_DAL;
using TaxGenie_DAL.HomeContentsTableAdapters;
using TaxGenie_DAL.TaxUpdateTableAdapters;

namespace TaxGenieOnline
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HomeContentsTableAdapter hContentsadptr = new HomeContentsTableAdapter();
            HomeContents.HomeContentsDataTable hContents = hContentsadptr.GetContentByType("Editor Desk", 1);
            foreach (HomeContents.HomeContentsRow row in hContents)
            {
                //int len = 90 - row.Title.Length;
                //if (row.Data.Length > len && len > 0)
                //    row.Data = row.Data.Substring(0, len);

                if (row.Title.Length > 390)
                    row.Title = row.Title.Substring(0, 390);
            }
            dlEditorDesk.DataSource = hContents;
            dlEditorDesk.DataBind();


            HomeContents.HomeContentsDataTable caseContents = hContentsadptr.GetContentByType("Case Analysis", 2);
            foreach (HomeContents.HomeContentsRow row in caseContents)
            {
                //int len = 90 - row.Title.Length;
                //if (row.Data.Length > len && len > 0)
                //    row.Data = row.Data.Substring(0, len);
                if (row.Title.Length > 250)
                    row.Title = row.Title.Substring(0, 250);
            }
             dlCaseAnalysis.DataSource = caseContents;
             dlCaseAnalysis.DataBind();

             TaxUpdateImgTableAdapter tuAdapter = new TaxUpdateImgTableAdapter();
             dlTaxUpdate.DataSource = tuAdapter.GetFirst(1);
             dlTaxUpdate.DataBind();
        }
    }
}
