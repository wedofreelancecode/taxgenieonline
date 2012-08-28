using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using TaxGenie_DAL.UserProfileTableAdapters;
using System.Net.Mail;
using System.Text;

namespace TaxGenieOnline.UserRegistration
{
    public partial class memberreg : System.Web.UI.Page
    {
        MembershipUser u;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUserWizard1_OnCreatingUser(object sender, LoginCancelEventArgs e)
        {
            string username = CreateUserWizard1.UserName;
            if (UserExists(username))
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('This account already exists. Please enter a different Mail ID.');", true);

                e.Cancel = true;
            }

            CreateUserWizard1.UserName = CreateUserWizard1.UserName;
        }

        private bool UserExists(string username)
        {
            if (Membership.GetUser(username) != null) { return true; }
            return false;
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            string _username = CreateUserWizard1.UserName;
            
            try
            {
                //update email into membership table
                Literal lblPWD = (Literal)CompleteWizardStep1.ContentTemplateContainer.FindControl("lblPWD");
                Literal lblUsername = (Literal)CompleteWizardStep1.ContentTemplateContainer.FindControl("lblUsername");
                TextBox UserName = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("UserName");
                TextBox fstName = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtFirstname");

                //Sending Mail
                MailMessage msg = new MailMessage();
                msg.To.Add(UserName.Text);
                msg.Subject = "TaxGenieOnline Login Credentials";
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                StringBuilder msgBody = new StringBuilder( "Dear "+fstName.Text + "<br/>");
                msgBody.Append("<p> Welcome to TaxGenieOnline. Below are credentials to login <br/> User Name : " + UserName.Text + "<br/>");
                msgBody.Append("Password : " + CreateUserWizard1.Password + "</p><br/><br/><br/>");
                msgBody.Append("Thanks,<br/> TaxGenieOnline.com");
                msg.Body = msgBody.ToString();
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
                msg.From = new MailAddress("taxgenieonline@gmail.com", "TaxGenieOnline", System.Text.Encoding.UTF8);
                SmtpClient mailClinet = new SmtpClient();
                mailClinet.EnableSsl = true;
                mailClinet.Send(msg); 
                //lblPWD.Text = CreateUserWizard1.Password;
                lblPWD.Text = UserName.Text;
                lblUsername.Text = UserName.Text;
                u = Membership.GetUser(UserName.Text);
                u.Email = UserName.Text;
                Membership.UpdateUser(u);

                //insert userprofile
                TextBox txtFirstname = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtFirstname");
                TextBox txtLastname = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtLastname");
                RadioButtonList rbtGender = (RadioButtonList)CreateUserWizardStep1.ContentTemplateContainer.FindControl("rbtGender");
                TextBox txtAge = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtAge");
                TextBox txtAdress = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtAdress");
                TextBox txtCity = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtCity");
                TextBox txtState = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtState");
                TextBox txtCountry = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtCountry");
                TextBox txtPincode = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtPincode");
                TextBox txtPhone1 = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtPhone1");
                TextBox txtPhone2 = (TextBox)CreateUserWizardStep1.ContentTemplateContainer.FindControl("txtPhone2");

                u = Membership.GetUser(UserName.Text);
                string userId = u.ProviderUserKey.ToString();
                odsUserProfile.InsertParameters["UserId"].DefaultValue = userId.ToString();
                odsUserProfile.InsertParameters["FirstName"].DefaultValue = txtFirstname.Text;
                odsUserProfile.InsertParameters["LastName"].DefaultValue = txtLastname.Text;
                odsUserProfile.InsertParameters["Gender"].DefaultValue = rbtGender.SelectedValue;
                odsUserProfile.InsertParameters["Age"].DefaultValue = txtAge.Text;
                odsUserProfile.InsertParameters["MailId"].DefaultValue = UserName.Text;
                odsUserProfile.InsertParameters["Address"].DefaultValue = txtAdress.Text;
                odsUserProfile.InsertParameters["City"].DefaultValue = txtCity.Text;
                odsUserProfile.InsertParameters["State"].DefaultValue = txtState.Text;
                odsUserProfile.InsertParameters["Country"].DefaultValue = txtCountry.Text;
                odsUserProfile.InsertParameters["PinCode"].DefaultValue = txtPincode.Text;
                odsUserProfile.InsertParameters["Phone1"].DefaultValue = txtPhone1.Text;
                odsUserProfile.InsertParameters["Phone2"].DefaultValue = txtPhone2.Text;
                odsUserProfile.Insert();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
