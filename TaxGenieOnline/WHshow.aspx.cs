using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.WhatsNewTableAdapters;
using TaxGenie_DAL;

namespace TaxGenieOnline
{
    public partial class WHshow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WhatsNewTableAdapter contAdptr = new WhatsNewTableAdapter();
            int id = int.Parse(Request.QueryString["Id"]);
            WhatsNew.WhatsNewDataTable data = contAdptr.GetData(id);
            WhatsNew.WhatsNewRow dr = data.Rows[0] as WhatsNew.WhatsNewRow;
            lbldata.Text = dr.Data;
        }
    }
}