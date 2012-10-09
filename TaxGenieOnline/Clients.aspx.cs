using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.ClientsTableAdapters;

namespace TaxGenieOnline
{
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientsTableAdapter clients = new ClientsTableAdapter();
            dlClients.DataSource = clients.GetClientsData();
            dlClients.DataBind();

        }
    }
}