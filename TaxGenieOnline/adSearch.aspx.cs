using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaxGenieOnline
{
    public partial class adSearch : System.Web.UI.Page
    {
        adResult epage = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            epage = Context.PreviousHandler as adResult;
            if (epage != null)
            {
                txtCaseNo.Text = epage.CaseNo.Value;
                txtKeyword.Text = epage.Keyword.Value;
                txtParty.Text = epage.PartyName.Value;
                txtCLcitationyear.Text = epage.Year.Value;
                txtCL.Text = epage.CPage.Value;
                ddlBench.SelectedValue = epage.Bench.Value;
                txtClNumber.Text = epage.Volume.Value;
                txtJudge.Text = epage.JudgeName.Value;
                if (ddlCourts.Items.Contains(new ListItem(epage.Court.Value)))
                {
                    ddlCourts.SelectedValue = epage.Court.Value;
                }
                else
                {
                    ddlCourts.SelectedValue = "Other";
                    ddlOtherCourt.SelectedValue = epage.Court.Value;
                }
                srcCat.SelectedValue = epage.SearchCat.Value;
                srcType.SelectedValue= epage.SearchType.Value;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtCaseNo.Text = String.Empty;
            txtCL.Text = String.Empty;
            txtCLcitationyear.Text = String.Empty;
            txtClNumber.Text = String.Empty;
            txtKeyword.Text = String.Empty;
            txtParty.Text = String.Empty;
            txtJudge.Text = String.Empty;

            ddlCourts.SelectedIndex = 0;
            ddlOtherCourt.SelectedIndex = 0;
            ddlOtherCourt.Visible = false;
            lblOther.Visible = false;
        }

        protected void ddlCourts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCourts.SelectedValue == "Other")
            {
                ddlOtherCourt.Visible = true;
                lblOther.Visible = true;
            }
            else
            {
                ddlOtherCourt.Visible = false;
                lblOther.Visible = false;
            }
            if (ddlCourts.SelectedValue == "High Court")
            {
                lblBench.Visible = true;
                ddlBench.Visible = true;
                ddlBench.Items.Clear();
                ddlBench.Items.Add(new ListItem("--Select One--", ""));
                ddlBench.Items.Add(new ListItem("Allahabad High Court", "Of Allahabad"));
                ddlBench.Items.Add(new ListItem("Andhra Pradesh High Court", "Of Andhra Pradesh"));
                ddlBench.Items.Add(new ListItem("Bombay High Court", "Of Bombay"));
                ddlBench.Items.Add(new ListItem("Calcutta High Court", "Of Calcutta"));
                ddlBench.Items.Add(new ListItem("Chattishgarh High Court", "Of Chattishgarh"));
                ddlBench.Items.Add(new ListItem("Delhi High Court", "Of Delhi"));
                ddlBench.Items.Add(new ListItem("Gujarat High Court", "Of Gujarat"));
                ddlBench.Items.Add(new ListItem("Guwahati High Court", "Of Guwahati"));
                ddlBench.Items.Add(new ListItem("Himachal Pradesh High Court", "Of Himachal Pradesh"));
                ddlBench.Items.Add(new ListItem("Jammu & Kashmir High Court", "Of Jammu & Kashmir"));
                ddlBench.Items.Add(new ListItem("Jharkhand High Court", "Of Jharkhand"));
                ddlBench.Items.Add(new ListItem("Kerala High Court", "Of Kerala"));
                ddlBench.Items.Add(new ListItem("Karnataka High Court", "Of Karnataka"));
                ddlBench.Items.Add(new ListItem("Lahore High Court", "Of Lahore"));
                ddlBench.Items.Add(new ListItem("Lucknow High Court", "Of Lucknow"));
                ddlBench.Items.Add(new ListItem("Madhya Pradesh High Court", "Of Madhya Pradesh"));
                ddlBench.Items.Add(new ListItem("Madras High Court", "Of Madras"));
                ddlBench.Items.Add(new ListItem("Madurai High Court", "Of Madurai"));
                ddlBench.Items.Add(new ListItem("Mysore High Court", "Of Mysore"));
                ddlBench.Items.Add(new ListItem("Nagpur High Court", "Of Nagpur"));
                ddlBench.Items.Add(new ListItem("Orissa High Court", "Of Orissa"));
                ddlBench.Items.Add(new ListItem("Punjab & Haryana High Court", "Of Punjab & Haryana"));
                ddlBench.Items.Add(new ListItem("Patna High Court", "Of Patna"));
                ddlBench.Items.Add(new ListItem("Rajasthan High Court", "Of Rajasthan"));
                ddlBench.Items.Add(new ListItem("Shillong High Court", "Of Shillong"));
                ddlBench.Items.Add(new ListItem("Sikkim High Court", "Of Sikkim"));
                ddlBench.Items.Add(new ListItem("Uttranchal High Court", "Of Uttranchal"));
            }
            else if (ddlCourts.SelectedValue == "CESTAT")
            {
                lblBench.Visible = true;
                ddlBench.Visible = true;
                ddlBench.Items.Clear();
                ddlBench.Items.Add(new ListItem("--Select One--", ""));
                ddlBench.Items.Add(new ListItem("South Zonal Bench, Bangalore", "South Zonal Bench, Bangalore"));
                ddlBench.Items.Add(new ListItem("South Zonal Bench, Chennai", "South Zonal Bench, Chennai"));
                ddlBench.Items.Add(new ListItem("West Zonal Bench, Mumbai", "West Zonal Bench, Mumbai"));
                ddlBench.Items.Add(new ListItem("West Zonal Bench, Ahmedabad", "West Zonal Bench, Ahmedabad"));
                ddlBench.Items.Add(new ListItem("East Zonal Bench, Kolkata", "East Zonal Bench, Kolkata"));
                ddlBench.Items.Add(new ListItem("North Zonal Bench, New Delhi", "North Zonal Bench, New Delhi"));
                ddlBench.Items.Add(new ListItem("Principle Bench, New Delhi", "Principle Bench, New Delhi"));
                ddlBench.Items.Add(new ListItem("Larger Bench", "Larger Bench"));

            }
            else
            {
                lblBench.Visible = false;
                ddlBench.Visible = false;
                ddlBench.Items.Clear();
                ddlBench.Items.Add(new ListItem("--Select One--", ""));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            KeyWord = txtKeyword.Text;
            SearchCategory = srcCat.SelectedValue;
            SearchType = srcType.SelectedValue;
            Bench = ddlBench.SelectedValue ?? "";
            PartyName = txtParty.Text;
            CaseNo = txtCaseNo.Text;
            JudgeName = txtJudge.Text;
            Year = txtCLcitationyear.Text;
            Court = ddlCourts.SelectedValue;
            CLVol = txtClNumber.Text;
            CLPage = txtCL.Text;
            if (Court == "Other")
                Court = ddlOtherCourt.SelectedValue;

            if (!string.IsNullOrEmpty(txtClNumber.Text.Trim()))
                Citation = "-TGOL-" + txtClNumber.Text + "-" + txtCL.Text;
            else
            {
                Citation = "-" + txtCL.Text;
            }

            Server.Transfer("adResult.aspx");
        }
        public string KeyWord
        {
            get;
            set;
        }
        public string SearchCategory
        {
            get;
            set;
        }
        public string SearchType
        {
            get;
            set;
        }
        public string Bench
        {
            get;
            set;
        }
        public string PartyName
        {
            get;
            set;
        }
        public string JudgeName
        {
            get;
            set;
        }
        public string Court
        {
            get;
            set;
        }
        public string CaseNo
        {
            get;
            set;
        }
        public string Citation
        {
            get;
            set;
        }
        public string Year
        {
            get;
            set;
        }
        public string CLVol
        {
            get;
            set;
        }
        public string CLPage
        {
            get;
            set;
        }
    }

}