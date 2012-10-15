using System;
using TaxGenie_DAL;
using TaxGenie_DAL.TaxUpdateTableAdapters;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace TaxGenieOnline
{
    public partial class ShowTaxUpdates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TaxUpdateImgTableAdapter TUadptr = new TaxUpdateImgTableAdapter();
            TaxUpdate.TaxUpdateImgDataTable tus = TUadptr.GetFirst(20);
            lblHeading.Text = "Tax Updates";
            dlTaxUpdates.DataSource = tus;
            dlTaxUpdates.DataBind();
        }

        protected void dlTaxUpdates_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {


                HtmlImage img = (HtmlImage)e.Item.FindControl("shownoimg");



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