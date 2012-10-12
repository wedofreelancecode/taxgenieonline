using System;
using TaxGenie_DAL;
using TaxGenie_DAL.HomeContentsTableAdapters;
using TaxGenie_DAL.TaxUpdateTableAdapters;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

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
            // if (hContents.Columns[5].Equals(" "))
            // {

            // }
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
            
           // HtmlImage delete = (HtmlImage)dlTaxUpdate.Items[0].FindControl("nonimg");
           // delete.Visible = false;
        }

        protected void dlTaxUpdate_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {


                HtmlImage img = (HtmlImage)e.Item.FindControl("nonimg");



                if (img.Src == null || img.Src.ToString() == "")
                {


                    img.Attributes.Add("style", "visibility:hidden");



                }
                else
                {
                    //do nothing

                }



            }
        }

        protected void dlEditorDesk_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {


                HtmlImage img = (HtmlImage)e.Item.FindControl("nonimg2");



                if (img.Src == null || img.Src.ToString() == "")
                {


                    img.Attributes.Add("style", "visibility:hidden");



                }
                else
                {
                    //do nothing

                }



            }
        }

       


      


    }
}
