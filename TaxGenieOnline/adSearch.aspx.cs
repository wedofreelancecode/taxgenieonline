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
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}