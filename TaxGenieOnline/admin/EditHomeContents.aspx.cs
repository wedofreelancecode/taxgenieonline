using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.HomeContentsTableAdapters;
using System.Data;

namespace TaxGenieOnline.admin
{
    public partial class EditHomeContents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void UPager_Command(object sender, CommandEventArgs e)
        {
            int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
            UPager.CurrentIndex = currnetPageIndx;
            LoadContents();
        }

        protected void gvContents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow row = gv.Rows[e.RowIndex];
            int? id = Int32.Parse(row.Cells[1].Text);
            HomeContentsTableAdapter index = new HomeContentsTableAdapter();
            if (id != null & id > 0)
            {
                index.Delete(id);
                LoadContents();
            }
        }

        protected void gvContents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow row = gv.Rows[e.NewEditIndex];
            this.Id = row.Cells[1].Text;
            Server.Transfer("HomeContentEditor.aspx");
        }

        private void LoadContents()
        {
            HomeContentsTableAdapter index = new HomeContentsTableAdapter();
            DataTable dtcontents = index.GetContentsByPage(ddlContentType.SelectedValue,UPager.CurrentIndex, UPager.PageSize);
            if (dtcontents.Rows.Count > 0)
            {
                gvContents.DataSource = dtcontents;
                gvContents.DataBind();
                if (gvContents.Columns.Count > 0)
                    gvContents.Columns[0].Visible = false;
                else
                {
                    gvContents.HeaderRow.Cells[1].Visible = false;
                    gvContents.HeaderRow.Cells[2].Visible = false;
                    gvContents.HeaderRow.Cells[4].Visible = false;
                    gvContents.HeaderRow.Cells[6].Visible = false;
                    gvContents.HeaderRow.Cells[7].Visible = false;
                    gvContents.HeaderRow.Cells[8].Visible = false;
                    foreach (GridViewRow gvr in gvContents.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[2].Visible = false;
                        gvr.Cells[4].Visible = false;
                        gvr.Cells[6].Visible = false;
                        gvr.Cells[7].Visible = false;
                        gvr.Cells[8].Visible = false;
                    }
                }
                UPager.ItemCount = Double.Parse(dtcontents.Rows[0]["TotalRows"].ToString());
            }
        }
        public string Id
        {
            get;
            set;
        }
        protected void ddlContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadContents();
        }

        protected void gvContents_RowDataBound(object sender, GridViewRowEventArgs e)
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