using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.WhatsNewTableAdapters;
using System.Data;

namespace TaxGenieOnline.admin
{
    public partial class EditWhatsNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadContents();
            }
        }

        protected void gvContents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow row = gv.Rows[e.RowIndex];
            int? id = Int32.Parse(row.Cells[1].Text);
            WhatsNewTableAdapter index = new WhatsNewTableAdapter();
            if (id != null & id > 0)
            {
                index.Delete(id);
                LoadContents();
            }
        }

        protected void UPager_Command(object sender, CommandEventArgs e)
        {
            int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
            UPager.CurrentIndex = currnetPageIndx;
            LoadContents();
        }
        private void LoadContents()
        {
            WhatsNewTableAdapter index = new WhatsNewTableAdapter();
            DataTable whats = index.GetWhatsNewByPage(UPager.CurrentIndex, UPager.PageSize);
            if (whats.Rows.Count > 0)
            {
                gvWhatsNew.DataSource = whats;
                gvWhatsNew.DataBind();
                if (gvWhatsNew.Columns.Count > 0)
                    gvWhatsNew.Columns[0].Visible = false;
                else
                {
                    gvWhatsNew.HeaderRow.Cells[1].Visible = false;
                    gvWhatsNew.HeaderRow.Cells[4].Visible = false;
                    gvWhatsNew.HeaderRow.Cells[6].Visible = false;
                    gvWhatsNew.HeaderRow.Cells[7].Visible = false;
                    foreach (GridViewRow gvr in gvWhatsNew.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[4].Visible = false;
                        gvr.Cells[6].Visible = false;
                        gvr.Cells[7].Visible = false;
                    }
                }
                UPager.ItemCount = Double.Parse(whats.Rows[0]["TotalRows"].ToString());
            }
        }

        protected void gvWhatsNew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState ==
                                                       DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[0].Controls[0]).Attributes["onclick"] =
                          "if(!confirm('Are you sure to delete this item?'))return   false;";
                }
            }
        }
    }
}