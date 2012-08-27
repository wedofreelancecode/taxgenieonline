using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.CentralExciseTableAdapters;
using TaxGenie_DAL.TariffTableAdapters;
using TaxGenie_DAL.CECNotificationsTableAdapters;
using TaxGenie_DAL.CircularsTableAdapters;
using TaxGenie_DAL.customsTableAdapters;
using TaxGenie_DAL.ServiceTaxTableAdapters;
using TaxGenie_DAL.STCaseLawsTableAdapters;
using TaxGenie_DAL.STNotificationsTableAdapters;
using TaxGenie_DAL.IncomeTaxTableAdapters;
using TaxGenie_DAL.DGFTTableAdapters;
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
                ddlsubcategory.Items.Add("Acts");
                ddlsubcategory.Items.Add("Rules");
                ddlsubcategory.Items.Add("Circulars");
                ddlsubcategory.Items.Add("Notifications");

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
            if (ddlsubcategory.SelectedValue.Equals("Case Laws") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                LoadCEActs(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                LoadCECircularsInstructions(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Acts") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Rules") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Forms") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Case Laws") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Regulations") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                LoadCustomsTariff(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                LoadCENotification(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                LoadCECircularsInstructions(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("SEZ") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Drawback Schedule") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Act 1994") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                LoadST(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("ST Rules") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                LoadST(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Forms and Registers") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                LoadST(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Accounting Codes for new services") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                LoadST(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Case Laws") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                LoadSTCaseLaws(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                LoadSTNotification(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                LoadCECircularsInstructions(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Acts") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                LoadITActs(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Rules") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                LoadITRules(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Circulars") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                LoadITCN(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                LoadITCN(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("FTP") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                LoadDGFT(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("FTDR Notifications") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                LoadDGFT(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("public notices") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                LoadDGFTPN(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {

            }
            if (ddlsubcategory.SelectedValue.Equals("SION") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {

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
                        if (ddlsubcategory.SelectedValue.Equals("Case Laws"))
                        {
                            gvr.Cells[2].Visible = false;
                            gvr.Cells[3].Visible = false;
                        }
                        else
                        {
                            gvr.Cells[2].Visible = false;
                        }
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
        private void LoadCECircularsInstructions(GridView eGrid)
        {
            Circulars_Info_ByyearTableAdapter index = new Circulars_Info_ByyearTableAdapter();
            DataTable dtActsIndexName = index.GetCEcircularsByCat(ddlcatagory.SelectedValue);
            if (dtActsIndexName.Rows.Count > 0)
            {
                editGrid.Visible = true;
                editGrid.DataSource = dtActsIndexName;
                editGrid.DataBind();
                if (editGrid.Columns.Count > 0)
                    editGrid.Columns[0].Visible = false;
                else
                {
                    editGrid.HeaderRow.Cells[4].Visible = false;
                    editGrid.HeaderRow.Cells[5].Visible = false;
                    //editGrid.HeaderRow.Cells[6].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[4].Visible = false;
                        gvr.Cells[5].Visible = false;
                        //gvr.Cells[6].Visible = false;
                    }
                }

                // editGrid.Columns[1].Visible = false;
            }

        }

        private void LoadCustoms(GridView eGrid)
        {
            ActsTableAdapter index = new ActsTableAdapter();
            DataTable dtActsIndexName = index.GetCustomsBySubCat(ddlsubcategory.SelectedValue);
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
                    editGrid.HeaderRow.Cells[3].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        if (ddlsubcategory.SelectedValue.Equals("Case Laws"))
                        {
                            gvr.Cells[2].Visible = false;
                            gvr.Cells[3].Visible = false;
                        }
                        else
                        {
                            gvr.Cells[2].Visible = false;
                            gvr.Cells[3].Visible = false;
                        }
                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }
        private void LoadCustomsTariff(GridView eGrid)
        {
            Custom_Tariff_GetAllTableAdapter index = new Custom_Tariff_GetAllTableAdapter();
            DataTable dtActsIndexName = index.Custom_GetAll();
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
                    editGrid.HeaderRow.Cells[4].Visible = false;
                    editGrid.HeaderRow.Cells[6].Visible = false;
                    editGrid.HeaderRow.Cells[7].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[4].Visible = false;
                        gvr.Cells[6].Visible = false;
                        gvr.Cells[7].Visible = false;
                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }

        private void LoadST(GridView eGrid)
        {
            ServiceTax_GetAllTableAdapter index = new ServiceTax_GetAllTableAdapter();
            DataTable dtActsIndexName = index.SelectSTByCat(ddlsubcategory.SelectedValue);
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
                    editGrid.HeaderRow.Cells[4].Visible = false;
                    editGrid.HeaderRow.Cells[5].Visible = false;
                    editGrid.HeaderRow.Cells[6].Visible = false;
                    editGrid.HeaderRow.Cells[7].Visible = false;
                    editGrid.HeaderRow.Cells[8].Visible = false;
                    editGrid.HeaderRow.Cells[9].Visible = false;
                    editGrid.HeaderRow.Cells[10].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {

                        gvr.Cells[1].Visible = false;
                        gvr.Cells[2].Visible = false;
                        gvr.Cells[4].Visible = false;
                        gvr.Cells[5].Visible = false;
                        gvr.Cells[6].Visible = false;
                        gvr.Cells[7].Visible = false;
                        gvr.Cells[8].Visible = false;
                        gvr.Cells[9].Visible = false;
                        gvr.Cells[10].Visible = false;

                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }
        private void LoadSTCaseLaws(GridView eGrid)
        {
            STCaselaws_GetAllTableAdapter index = new STCaselaws_GetAllTableAdapter();
            DataTable dtActsIndexName = index.GetAll();
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
                    editGrid.HeaderRow.Cells[3].Visible = false;
                    editGrid.HeaderRow.Cells[4].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[3].Visible = false;
                        gvr.Cells[4].Visible = false;

                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }
        private void LoadSTNotification(GridView eGrid)
        {
            STN_GetAllTableAdapter index = new STN_GetAllTableAdapter();
            DataTable dtActsIndexName = index.STN_GetAll();
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
                    editGrid.HeaderRow.Cells[7].Visible = false;
                    editGrid.HeaderRow.Cells[8].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[2].Visible = false;
                        gvr.Cells[7].Visible = false;
                        gvr.Cells[8].Visible = false;
                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }
        private void LoadITActs(GridView eGrid)
        {
            IncomeTaxActs_SelectAllTableAdapter index = new IncomeTaxActs_SelectAllTableAdapter();
            DataTable dtActsIndexName = index.GetAllITActs();
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
                    editGrid.HeaderRow.Cells[6].Visible = false;
                    editGrid.HeaderRow.Cells[7].Visible = false;
                    editGrid.HeaderRow.Cells[8].Visible = false;
                    editGrid.HeaderRow.Cells[9].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[6].Visible = false;
                        gvr.Cells[7].Visible = false;
                        gvr.Cells[8].Visible = false;
                        gvr.Cells[9].Visible = false;
                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }
        private void LoadITRules(GridView eGrid)
        {
            IncomeTaxRules_SelectAllTableAdapter index = new IncomeTaxRules_SelectAllTableAdapter();
            DataTable dtActsIndexName = index.GetAllITRules();
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
                    editGrid.HeaderRow.Cells[7].Visible = false;
                    editGrid.HeaderRow.Cells[8].Visible = false;
                    editGrid.HeaderRow.Cells[9].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[5].Visible = false;
                        gvr.Cells[6].Visible = false;
                        gvr.Cells[7].Visible = false;
                        gvr.Cells[8].Visible = false;
                        gvr.Cells[9].Visible = false;
                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }
        private void LoadITCN(GridView eGrid)
        {
            IncomeTaxCircularsNotification_SelectAllTableAdapter index = new IncomeTaxCircularsNotification_SelectAllTableAdapter();
            DataTable dtActsIndexName = index.GetITCNBySubCat(ddlsubcategory.SelectedValue);
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
                    editGrid.HeaderRow.Cells[4].Visible = false;
                    editGrid.HeaderRow.Cells[5].Visible = false;
                    editGrid.HeaderRow.Cells[7].Visible = false;
                    editGrid.HeaderRow.Cells[8].Visible = false;
                    editGrid.HeaderRow.Cells[9].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[2].Visible = false;
                        gvr.Cells[4].Visible = false;
                        gvr.Cells[5].Visible = false;
                        gvr.Cells[7].Visible = false;
                        gvr.Cells[8].Visible = false;
                        gvr.Cells[9].Visible = false;
                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }
        private void LoadDGFT(GridView eGrid)
        {
            DGFT_GetAllTableAdapter index = new DGFT_GetAllTableAdapter();
            DataTable dtActsIndexName = index.GetDGFTBySubCat(ddlsubcategory.SelectedValue);
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
                    editGrid.HeaderRow.Cells[5].Visible = false;
                    editGrid.HeaderRow.Cells[6].Visible = false;
                    editGrid.HeaderRow.Cells[7].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[2].Visible = false;
                        gvr.Cells[5].Visible = false;
                        gvr.Cells[6].Visible = false;
                        gvr.Cells[7].Visible = false;
                    }
                }

                // editGrid.Columns[1].Visible = false;
            }
        }
        private void LoadDGFTPN(GridView eGrid)
        {
            DGFTpublicnotices_GETALLTableAdapter index = new DGFTpublicnotices_GETALLTableAdapter();
            DataTable dtActsIndexName = index.GetAllDgftPN();
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
                    editGrid.HeaderRow.Cells[7].Visible = false;
                    editGrid.HeaderRow.Cells[8].Visible = false;
                    foreach (GridViewRow gvr in editGrid.Rows)
                    {
                        gvr.Cells[1].Visible = false;
                        gvr.Cells[2].Visible = false;
                        gvr.Cells[7].Visible = false;
                        gvr.Cells[8].Visible = false;
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
            if (ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13") || ddlsubcategory.SelectedValue.Equals("Notifications"))
                {
                    id = row.Cells[1].Text;
                }
                else if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions"))
                {
                    id = row.Cells[5].Text;
                }
                else
                {
                    id = row.Cells[2].Text;
                }
            }
            if (ddlcatagory.SelectedValue.Equals("Customs"))
            {
                if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13") || ddlsubcategory.SelectedValue.Equals("Notifications"))
                {
                    id = row.Cells[1].Text;
                }
                else if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions"))
                {
                    id = row.Cells[5].Text;
                }
                else
                {
                    id = row.Cells[3].Text;
                }
            }
            if (ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions"))
                {
                    id = row.Cells[5].Text;
                }
                else
                {
                    id = row.Cells[1].Text;
                }
            }
            if (ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                if (ddlsubcategory.SelectedValue.Equals("Rules"))
                {
                    id = row.Cells[9].Text;
                }
                else
                {
                    id = row.Cells[1].Text;
                }

            }
            if (ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                id = row.Cells[1].Text;
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
            if (ddlsubcategory.SelectedValue.Equals("Case Laws") && ddlcatagory.SelectedValue.Equals("Central Excise"))
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
                CECNotification_GetAllTableAdapter index = new CECNotification_GetAllTableAdapter();
                index.DeleteCENotificationById(id);
                LoadCENotification(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                Circulars_Info_ByyearTableAdapter index = new Circulars_Info_ByyearTableAdapter();
                index.DeleteCEcircularsById(id);
                LoadCECircularsInstructions(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Acts") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                ActsTableAdapter index = new ActsTableAdapter();
                index.DeleteCustomsById(id);
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Rules") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                ActsTableAdapter index = new ActsTableAdapter();
                index.DeleteCustomsById(id);
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Forms") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                ActsTableAdapter index = new ActsTableAdapter();
                index.DeleteCustomsById(id);
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Case Laws") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                ActsTableAdapter index = new ActsTableAdapter();
                index.DeleteCustomsById(id);
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Regulations") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                ActsTableAdapter index = new ActsTableAdapter();
                index.DeleteCustomsById(id);
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                Custom_Tariff_GetAllTableAdapter index = new Custom_Tariff_GetAllTableAdapter();
                index.DeleteCustomTariffById(id);
                LoadCustomsTariff(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                CECNotification_GetAllTableAdapter index = new CECNotification_GetAllTableAdapter();
                index.DeleteCENotificationById(id);
                LoadCENotification(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                Circulars_Info_ByyearTableAdapter index = new Circulars_Info_ByyearTableAdapter();
                index.DeleteCEcircularsById(id);
                LoadCECircularsInstructions(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("SEZ") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                ActsTableAdapter index = new ActsTableAdapter();
                index.DeleteCustomsById(id);
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Drawback Schedule") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                ActsTableAdapter index = new ActsTableAdapter();
                index.DeleteCustomsById(id);
                LoadCustoms(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Act 1994") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                ServiceTax_GetAllTableAdapter index = new ServiceTax_GetAllTableAdapter();
                index.DeleteSTById(id);
                LoadST(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("ST Rules") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                ServiceTax_GetAllTableAdapter index = new ServiceTax_GetAllTableAdapter();
                index.DeleteSTById(id);
                LoadST(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Forms and Registers") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                ServiceTax_GetAllTableAdapter index = new ServiceTax_GetAllTableAdapter();
                index.DeleteSTById(id);
                LoadST(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Accounting Codes for new services") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                ServiceTax_GetAllTableAdapter index = new ServiceTax_GetAllTableAdapter();
                index.DeleteSTById(id);
                LoadST(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Case Laws") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                STCaselaws_GetAllTableAdapter index = new STCaselaws_GetAllTableAdapter();
                index.DeleteSTCaseLawsById(id);
                LoadSTCaseLaws(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                STN_GetAllTableAdapter index = new STN_GetAllTableAdapter();
                index.DeleteSTNById(id);
                LoadSTNotification(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                Circulars_Info_ByyearTableAdapter index = new Circulars_Info_ByyearTableAdapter();
                index.DeleteCEcircularsById(id);
                LoadCECircularsInstructions(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Acts") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                IncomeTaxActs_SelectAllTableAdapter index = new IncomeTaxActs_SelectAllTableAdapter();
                index.DeleteITActsById(id);
                LoadITActs(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Rules") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                IncomeTaxRules_SelectAllTableAdapter index = new IncomeTaxRules_SelectAllTableAdapter();
                index.DeleteITRulesById(id);
                LoadITRules(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Circulars") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                IncomeTaxCircularsNotification_SelectAllTableAdapter index = new IncomeTaxCircularsNotification_SelectAllTableAdapter();
                index.DeleteITCNById(id);
                LoadITCN(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                IncomeTaxCircularsNotification_SelectAllTableAdapter index = new IncomeTaxCircularsNotification_SelectAllTableAdapter();
                index.DeleteITCNById(id);
                LoadITCN(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("FTP") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                DGFT_GetAllTableAdapter index = new DGFT_GetAllTableAdapter();
                index.DeleteDGFTById(id);
                LoadDGFT(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("FTDR Notifications") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                DGFT_GetAllTableAdapter index = new DGFT_GetAllTableAdapter();
                index.DeleteDGFTById(id);
                LoadDGFT(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("public notices") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                DGFTpublicnotices_GETALLTableAdapter index = new DGFTpublicnotices_GETALLTableAdapter();
                index.DeleteDgftPNById(id);
                LoadDGFTPN(editGrid);
            }
            if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {

            }
            if (ddlsubcategory.SelectedValue.Equals("SION") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {

            }

        }
    }
}
