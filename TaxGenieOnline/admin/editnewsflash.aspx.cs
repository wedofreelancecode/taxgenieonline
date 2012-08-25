using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TaxGenie_DAL.newsflashTableAdapters;

namespace TaxGenieOnline.admin
{
    public partial class editnewsflash : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            newsflash_GetallTableAdapter adptr = new newsflash_GetallTableAdapter();
            newsGrid.DataSource = adptr.GetnewsflashDescription();
            newsGrid.DataBind();
            newsGrid.HeaderRow.Cells[1].Visible = false;
            newsGrid.HeaderRow.Cells[3].Visible = false;
            foreach (GridViewRow gvr in newsGrid.Rows)
            {
                gvr.Cells[1].Visible = false;
                gvr.Cells[3].Visible = false;
            }

        }
        protected void newsGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow row = gv.Rows[e.RowIndex];
            int? id = Int32.Parse(row.Cells[1].Text);
            newsflash_GetallTableAdapter adptr = new newsflash_GetallTableAdapter();
            adptr.newsflash_delete(id);
        }
        public string Id
        {
            get;
            set;
        }

        protected void newsGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow row = gv.Rows[e.NewEditIndex];
            this.Id = row.Cells[1].Text;
            Server.Transfer("uploadnewsflash.aspx");
        }
    }
}