using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.ClientsTableAdapters;
using TaxGenieOnline.admin;


namespace TaxGenieOnline
{
    public partial class AddClients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EditClients epage = Context.Handler as EditClients;
            if (epage != null)
            {
                hdnId.Value = epage.Id;
            }
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (btnupload.Text != "Update")
                {
                    ClientsTableAdapter adptr = new ClientsTableAdapter();
                    TaxGenie_DAL.Clients.ClientsDataTable dt = adptr.SelectClientById(id);
                    TaxGenie_DAL.Clients.ClientsRow row = dt.Rows[0] as TaxGenie_DAL.Clients.ClientsRow;
                    txtcmpname.Text = row.Client_Name;
                    taNews.Value = row.Address;
                    btnupload.Text = "Update";
                }
            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                ClientsTableAdapter clients_insert = new ClientsTableAdapter();
                if (hdnId.Value.Length > 0)
                {
                    int? id = Int32.Parse(hdnId.Value);
                    clients_insert.UpdateClientById(txtcmpname.Text, taNews.Value,id);
                    Response.Write("<script>alert('Clients Updated Successfully')</script>");
                    Server.Transfer("EditClients.aspx");
                }
                else
                {
                    clients_insert.Insert(txtcmpname.Text, taNews.Value);
                    Response.Write("<script>alert('News Uploded Successfully')</script>");
                    Server.Transfer("AddClients.aspx");
                } 
                
               
               
            }
            catch (Exception ex)
            {

            }
        }
    }
}