using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using TaxGenie_DAL.UserProfileTableAdapters;
using TaxGenie_DAL;

namespace TaxGenieOnline
{
    public partial class UnauthorizedAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Login Login1 = (Login)LoginView1.FindControl("Login1");
            try
            {
                if (Membership.Provider.ValidateUser(Login1.UserName, Login1.Password))
                {
                    e.Authenticated = true;

                    MembershipUser user = Membership.GetUser(Login1.UserName);
                    Guid? userId = user.ProviderUserKey as Guid?;
                    aspnet_UserProfile_DetailsTableAdapter usrAdptr = new aspnet_UserProfile_DetailsTableAdapter();
                    UserProfile.aspnet_UserProfile_DetailsDataTable dt = usrAdptr.UserProfile(userId);
                    Session["UFName"] = dt[0]["FirstName"].ToString();

                    if (Roles.IsUserInRole(Login1.UserName, "Adminstrator"))
                    {
                        Login1.DestinationPageUrl = "~/admin/Adminpage.aspx";
                    }
                    if (Roles.IsUserInRole(Login1.UserName, "FreeUsers"))
                    {
                        Login1.DestinationPageUrl = "~/Home.aspx";
                    }
                }
                else
                {
                    e.Authenticated = false;
                }

            }
            catch (Exception ex)
            {
                Login1.FailureText = ex.Message;
                //lblErrorMsg.Text = "No user exists with name: " + Login1.UserName;
            }
        }
    }
}
