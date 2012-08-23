using System;
using TaxGenie_DAL.WhatsNewTableAdapters;

namespace TaxGenieOnline.admin
{
    public partial class WhatsNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            WhatsNewTableAdapter WNAdapter = new WhatsNewTableAdapter();
            WNAdapter.Insert(ddlcatagory.SelectedValue, txtTitle.Text, edtData.Content, DateTime.Now);
            Server.Transfer("WhatsNew.aspx");
        }
    }
}