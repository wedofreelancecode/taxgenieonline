using System;
using TaxGenie_DAL;
using TaxGenie_DAL.TaxUpdateTableAdapters;

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
    }
}