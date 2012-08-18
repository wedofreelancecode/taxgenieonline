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
    public partial class editflashnews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                newsflash_GetYearsTableAdapter dtyears = new newsflash_GetYearsTableAdapter();
                DataTable dtGetYears = dtyears.newsflashgetyears();

                if (dtGetYears.Rows.Count > 0)
                {
                    ddlyear.Items.Add(new ListItem("Select One", "0"));

                    foreach (DataRow i in dtGetYears.Rows)
                    {

                        ddlyear.Items.Add(i["Year"].ToString());
                    }
                }
            }

        }

        protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            newsflash_GetMonthsTableAdapter dtmonths = new newsflash_GetMonthsTableAdapter();
            DataTable dtGetMonths = dtmonths.newsflashgetmonths(ddlyear.SelectedValue);

            if (dtGetMonths.Rows.Count > 0)
            {
                ddlmonth.Items.Add(new ListItem("Select One", "0"));

                foreach (DataRow i in dtGetMonths.Rows)
                {

                    ddlmonth.Items.Add(i["Month"].ToString());
                }
            }


        }

        protected void ddlmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            newsflash_descriptionTableAdapter dtdesc = new newsflash_descriptionTableAdapter();
            DataTable dtGetdesc = dtdesc.newsflashgetdescription(ddlmonth.SelectedValue);

            if (dtGetdesc.Rows.Count > 0)
            {
                dlnewsflash.DataSource = dtGetdesc;
                dlnewsflash.DataBind();
            }

        }
        public static Control FindControlRecursive(Control root, string id)
        {
            if (id == string.Empty)
                return null;

            if (root.ID == id)
                return root;

            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                {
                    return t;
                }
            }
            return null;
        }
        protected void updatenewsflash(object sender, EventArgs e)
        {
            newsflash_GetallTableAdapter dtgetall = new newsflash_GetallTableAdapter();
            dtgetall.Update(ddlyear.SelectedValue, ddlmonth.SelectedValue, Editor1.Content);
            newsflash_GetDescriptionTableAdapter descr = new newsflash_GetDescriptionTableAdapter();
            DataTable dtgetupdate = descr.GetDatanewsflash();
            Label lblnewsflash = (Label)FindControlRecursive(Page, "lblnewsflash");
            if (dtgetupdate.Rows.Count > 0)
            {
                string desc = dtgetupdate.Rows[0]["Newsflash"].ToString();
                lblnewsflash.Text = desc;
            }
        }

        protected void dlnewsflash_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "description")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;

                Editor1.Content = linkButton.Text;



            }
        }
    }
}
