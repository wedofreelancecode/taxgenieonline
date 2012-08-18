using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.CentralExciseTableAdapters;
using TaxGenie_DAL.TariffTableAdapters;
using TaxGenie_DAL.CECNotificationsTableAdapters;
using System.Data;

namespace TaxGenieOnline.admin
{
    public partial class editnotifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            editGrid.Visible = false;
        }

        protected void ddlcatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lblsubcat.Text = ddlcatagory.SelectedValue;

            if (ddlcatagory.SelectedValue.Equals("Customs") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));
                ddlsubcategory.Items.Add("Acts");
                ddlsubcategory.Items.Add("Rules");
                ddlsubcategory.Items.Add("Regulations");
                ddlsubcategory.Items.Add("Tariff 2012-13");
                ddlsubcategory.Items.Add("Forms");
                ddlsubcategory.Items.Add("Notifications");
                ddlsubcategory.Items.Add("Circulars/Instructions");
                ddlsubcategory.Items.Add("Case Laws");
                ddlsubcategory.Items.Add("SEZ");
                ddlsubcategory.Items.Add("Drawback Schedule");
            }
            else if (ddlcatagory.SelectedValue.Equals("Central Excise") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));
                ddlsubcategory.Items.Add("Acts");
                ddlsubcategory.Items.Add("Rules");
                ddlsubcategory.Items.Add("Tariff 2012-13");
                ddlsubcategory.Items.Add("Forms");
                ddlsubcategory.Items.Add("Notifications");
                ddlsubcategory.Items.Add("Circulars/Instructions");
                ddlsubcategory.Items.Add("Case Laws");
                ddlsubcategory.Items.Add("Section 37B Order");
            }
            else if (ddlcatagory.SelectedValue.Equals("Service Tax") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));
                ddlsubcategory.Items.Add("Act 1994");
                ddlsubcategory.Items.Add("ST Rules");
                ddlsubcategory.Items.Add("Services");
                ddlsubcategory.Items.Add("Notifications");
                ddlsubcategory.Items.Add("Circulars/Instructions");
                ddlsubcategory.Items.Add("Case Laws");
                ddlsubcategory.Items.Add("Forms and Registers");
                ddlsubcategory.Items.Add("Accounting Codes for new services");

            }
            else if (ddlcatagory.SelectedValue.Equals("Income Tax") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));

            }
            else if (ddlcatagory.SelectedValue.Equals("Library") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));

            }
            else if (ddlcatagory.SelectedValue.Equals("DGFT") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));
                ddlsubcategory.Items.Add("FTP");
                ddlsubcategory.Items.Add("FTDR Notifications");
                ddlsubcategory.Items.Add("public notices");
                ddlsubcategory.Items.Add("Circulars/Instructions");
                ddlsubcategory.Items.Add("SION");

            }

            else if (ddlcatagory.SelectedValue.Equals("Services") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));
                ddlsubcategory.Items.Add("Consulting");
                ddlsubcategory.Items.Add("Book Keeping");
                ddlsubcategory.Items.Add("Filling Returns");
                ddlsubcategory.Items.Add("Forms and Registers");
                ddlsubcategory.Items.Add("FAQ");

            }
            else
            {
                Response.Write("<script>alert('Please select categeory')</script>");
            }
        }
        protected void ddlsubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsubcategory.SelectedValue.Equals("Acts") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                LoadCEActs(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Rules") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                LoadCEActs(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Forms") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                LoadCEActs(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Section 37B Order") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                LoadCEActs(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                LoadCETariff(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                LoadCENotification(editGrid);
            }
        }
        private void LoadCEActs(GridView eGrid)
        {
            CEActsTableAdapter index = new CEActsTableAdapter();
            DataTable dtActsIndexName = index.GetIndex_ID_BySubCat(ddlsubcategory.SelectedValue);
            if (dtActsIndexName.Rows.Count > 0)
            {
                editGrid.Visible = true;
                editGrid.DataSource = dtActsIndexName;
                editGrid.DataBind();
                if (editGrid.Columns.Count > 0)
                    editGrid.Columns[0].Visible = false;
                else
                {
                    editGrid.HeaderRow.Cells[2].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[2].Visible = false;
                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }

        private void LoadCETariff(GridView eGrid)
        {
            CentralExcise_Tariff_GetAllTableAdapter index = new CentralExcise_Tariff_GetAllTableAdapter();
            DataTable dtActsIndexName = index.CentralExcise_GetAll();
            if (dtActsIndexName.Rows.Count > 0)
            {
                editGrid.Visible = true;
                editGrid.DataSource = dtActsIndexName;
                editGrid.DataBind();
                if (editGrid.Columns.Count > 0)
                    editGrid.Columns[0].Visible = false;
                else
                {
                    editGrid.HeaderRow.Cells[1].Visible = false;
                    editGrid.HeaderRow.Cells[5].Visible = false;
                    editGrid.HeaderRow.Cells[6].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[5].Visible = false;
                        gvr.Cells[6].Visible = false;
                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }
        private void LoadCENotification(GridView eGrid)
        {
            CECNotification_GetAllTableAdapter index = new CECNotification_GetAllTableAdapter();
            DataTable dtActsIndexName = index.SelectCENotificationByCat(ddlcatagory.SelectedValue);
            if (dtActsIndexName.Rows.Count > 0)
            {
                editGrid.Visible = true;
                editGrid.DataSource = dtActsIndexName;
                editGrid.DataBind();
                if (editGrid.Columns.Count > 0)
                    editGrid.Columns[0].Visible = false;
                else
                {
                    editGrid.HeaderRow.Cells[1].Visible = false;
                    editGrid.HeaderRow.Cells[2].Visible = false;
                    editGrid.HeaderRow.Cells[6].Visible = false;
                    editGrid.HeaderRow.Cells[8].Visible = false;
                    editGrid.HeaderRow.Cells[9].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[2].Visible = false;
                        gvr.Cells[6].Visible = false;
                        gvr.Cells[8].Visible = false;
                        gvr.Cells[9].Visible = false;
                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }
        protected void editGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow row = gv.Rows[e.NewEditIndex];
            string id = string.Empty;
            if ((ddlsubcategory.SelectedValue.Equals("Tariff 2012-13") && ddlcatagory.SelectedValue.Equals("Central Excise")) || (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Central Excise")))
            {
                id = row.Cells[1].Text;
            }
            else
            {
                 id = row.Cells[2].Text;
            }
            this.Category = ddlcatagory.SelectedValue;
            this.SubCategory = ddlsubcategory.SelectedValue;
            this.Id = id;
            Server.Transfer("uploadnotifications.aspx");
        }
        public string Id
        {
            get;
            set;
        }
        public string Category
        {
            get;
            set;
        }
        public string SubCategory
        {
            get;
            set;
        }

        protected void editGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = sender as GridView;
            GridViewRow row = gv.Rows[e.RowIndex];
            int? id = Int32.Parse(row.Cells[2].Text);
            if (ddlsubcategory.SelectedValue.Equals("Acts") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                CEActsTableAdapter index = new CEActsTableAdapter();
                index.CEDeleteById(id);
                LoadCEActs(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Rules") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                CEActsTableAdapter index = new CEActsTableAdapter();
                index.CEDeleteById(id);
                LoadCEActs(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Forms") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                CEActsTableAdapter index = new CEActsTableAdapter();
                index.CEDeleteById(id);
                LoadCEActs(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Section 37B Order") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                CEActsTableAdapter index = new CEActsTableAdapter();
                index.CEDeleteById(id);
                LoadCEActs(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                CentralExcise_Tariff_GetAllTableAdapter index = new CentralExcise_Tariff_GetAllTableAdapter();
                index.DeleteTariffById(id);
                LoadCETariff(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                CentralExcise_Tariff_GetAllTableAdapter index = new CentralExcise_Tariff_GetAllTableAdapter();
                index.DeleteTariffById(id);
                LoadCETariff(editGrid);
            }
        }
    }
}
 