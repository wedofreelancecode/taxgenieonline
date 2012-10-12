using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.ClientsTableAdapters;

namespace TaxGenieOnline.admin
{
    public partial class EditClients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientsTableAdapter adptr = new ClientsTableAdapter();
            clientsGrid.DataSource = adptr.GetClientsData();
                clientsGrid.DataBind();
            clientsGrid.HeaderRow.Cells[1].Visible = false;
            foreach (GridViewRow gvr in clientsGrid.Rows)
            {
                gvr.Cells[1].Visible = false;
            }

        }
        protected void clientsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow row = gv.Rows[e.RowIndex];
            int? id = Int32.Parse(row.Cells[1].Text);
            ClientsTableAdapter adptr = new ClientsTableAdapter();
            adptr.DeleteClientsById(id);
            Server.Transfer("EditClients.aspx");
        }
        public string Id
        {
            get;
            set;
        }

        protected void clientsGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow row = gv.Rows[e.NewEditIndex];
            this.Id = row.Cells[1].Text;
            Server.Transfer("AddClients.aspx");
        }

        protected void clientsGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState ==
                                                       DataControlRowState.Alternate)
                {

                   
                    ((LinkButton)e.Row.Cells[0].Controls[2]).Attributes["onclick"] =
                          "if(!confirm('Are you sure to delete this item?'))return   false;";
                }
            }
        }
    }
}