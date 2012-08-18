using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

namespace TaxGenieOnline
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltl.Text = "<table>";
            for (int i = 1; i < 20; i++)
            {
                ltl.Text += "<tr><td style='width=500px'>";
                ltl.Text += "Hello" + i;
                ltl.Text += "</td></tr>";
            }
            ltl.Text += "</table>";
        }



    }
}
