using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
using TaxGenie_DAL.UserProfileTableAdapters;

namespace TaxGenieOnline
{
    public partial class editprofile : System.Web.UI.Page
    {
        MembershipUser user;
        Guid userId;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Membership.GetUser(User.Identity.Name);
            userId = (Guid)user.ProviderUserKey;


            if (!IsPostBack)
            {
                ods_PersonalProfile.SelectParameters["userId"].DefaultValue = userId.ToString();
            }
        }
        protected void EditProfile()
        {
            TextBox txtFirstname = (TextBox)frmv_PersonalProfile.FindControl("txtFirstname");
            TextBox txtLastname = (TextBox)frmv_PersonalProfile.FindControl("txtLastname");
            RadioButtonList rbtGender = (RadioButtonList)frmv_PersonalProfile.FindControl("rbtGender");
            TextBox txtAge = (TextBox)frmv_PersonalProfile.FindControl("txtAge");
            //TextBox txtEmail = (TextBox)frmv_PersonalProfile.FindControl("txtEmail");
            TextBox txtAdress = (TextBox)frmv_PersonalProfile.FindControl("txtAdress");
            TextBox txtCity = (TextBox)frmv_PersonalProfile.FindControl("txtCity");
            TextBox txtState = (TextBox)frmv_PersonalProfile.FindControl("txtState");
            TextBox txtCountry = (TextBox)frmv_PersonalProfile.FindControl("txtCountry");
            TextBox txtPincode = (TextBox)frmv_PersonalProfile.FindControl("txtPincode");
            TextBox txtPhone1 = (TextBox)frmv_PersonalProfile.FindControl("txtPhone1");
            TextBox txtPhone2 = (TextBox)frmv_PersonalProfile.FindControl("txtPhone2");

            try
            {
                ods_PersonalProfile.UpdateParameters["UserId"].DefaultValue = userId.ToString();
                ods_PersonalProfile.UpdateParameters["FirstName"].DefaultValue = txtFirstname.Text;
                ods_PersonalProfile.UpdateParameters["LastName"].DefaultValue = txtLastname.Text;
                ods_PersonalProfile.UpdateParameters["Gender"].DefaultValue = rbtGender.SelectedValue;
                ods_PersonalProfile.UpdateParameters["Age"].DefaultValue = txtAge.Text;
                ods_PersonalProfile.UpdateParameters["MailId"].DefaultValue = null;
                ods_PersonalProfile.UpdateParameters["Address"].DefaultValue = txtAdress.Text;
                ods_PersonalProfile.UpdateParameters["City"].DefaultValue = txtCity.Text;
                ods_PersonalProfile.UpdateParameters["State"].DefaultValue = txtState.Text;
                ods_PersonalProfile.UpdateParameters["Country"].DefaultValue = txtCountry.Text;
                ods_PersonalProfile.UpdateParameters["PinCode"].DefaultValue = txtPincode.Text;
                ods_PersonalProfile.UpdateParameters["Phone1"].DefaultValue = txtPhone1.Text;
                ods_PersonalProfile.UpdateParameters["Phone2"].DefaultValue = txtPhone2.Text;
                ods_PersonalProfile.Update();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Your profile saved successfully.');", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void ods_PersonalProfile_Updated(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Your profile saved successfully.');", true);
            }
        }

        protected void frmv_PersonalProfile_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Update"))
            {
                EditProfile();
            }
        }
    }
}
