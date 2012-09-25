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
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            KeyWord = txtKeyword.Text;
            SearchCategory = srcCat.SelectedValue;
            SearchType = srcType.SelectedValue;
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