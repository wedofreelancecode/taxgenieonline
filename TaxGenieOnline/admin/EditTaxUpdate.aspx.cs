using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.TaxUpdateTableAdapters;
using System.Data;

namespace TaxGenieOnline.admin
{
    public partial class EditTaxUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadTaxUpdate();
            }
        }

        protected void UPager_Command(object sender, CommandEventArgs e)
        {
            int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
            UPager.CurrentIndex = currnetPageIndx;
            LoadTaxUpdate();
        }

        protected void gvTaxUpdate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow row = gv.Rows[e.RowIndex];
            int? id = Int32.Parse(row.Cells[1].Text);
            TaxUpdateImgTableAdapter index = new TaxUpdateImgTableAdapter();
            if (id != null & id > 0)
            {
                index.Delete(id);
                LoadTaxUpdate();
            }
        }

        protected void gvTaxUpdate_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow row = gv.Rows[e.NewEditIndex];
            this.Id = row.Cells[1].Text;
            Server.Transfer("TaxUpdateEditor.aspx");
        }
        private void LoadTaxUpdate()
        {
            TaxUpdateImgTableAdapter index = new TaxUpdateImgTableAdapter();
            DataTable dtTUpdates = index.GetTaxUpdateByPage(UPager.CurrentIndex, UPager.PageSize);
            if (dtTUpdates.Rows.Count > 0)
            {
                gvTaxUpdate.DataSource = dtTUpdates;
                gvTaxUpdate.DataBind();
                if (gvTaxUpdate.Columns.Count > 0)
                    gvTaxUpdate.Columns[0].Visible = false;
                else
                {
                    gvTaxUpdate.HeaderRow.Cells[1].Visible = false;
                    gvTaxUpdate.HeaderRow.Cells[2].Visible = false;
                    gvTaxUpdate.HeaderRow.Cells[3].Visible = false;
                    gvTaxUpdate.HeaderRow.Cells[6].Visible = false;
                    gvTaxUpdate.HeaderRow.Cells[7].Visible = false;
                    foreach (GridViewRow gvr in gvTaxUpdate.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[2].Visible = false;
                        gvr.Cells[3].Visible = false;
                        gvr.Cells[6].Visible = false;
                        gvr.Cells[7].Visible = false;
                    }
                }
                UPager.ItemCount = Double.Parse(dtTUpdates.Rows[0]["TotalRows"].ToString());
            }
        }

        public string Id { get; set; }
    }
}