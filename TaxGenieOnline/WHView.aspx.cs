using System;
using TaxGenie_DAL.WhatsNewTableAdapters;

namespace TaxGenieOnline
{
    public partial class WHView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WhatsNewContentTableAdapter whts = new WhatsNewContentTableAdapter();
            dlWhats.DataSource = whts.GetWhatsNew();
            dlWhats.DataBind();
        }
    }
}