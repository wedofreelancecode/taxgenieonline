using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL;
using TaxGenie_DAL.HomeContentsTableAdapters;


namespace TaxGenieOnline
{
    public partial class TaxGenie : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.AppRelativeVirtualPath != "~/Home.aspx" && Page.AppRelativeVirtualPath != "~/memberreg.aspx" && Page.AppRelativeVirtualPath != "~/pwdrecovery.aspx" && Page.AppRelativeVirtualPath != "~/about-us.aspx" && Page.AppRelativeVirtualPath != "~/Contactus.aspx" && Page.AppRelativeVirtualPath != "~/changepwd.aspx" && Page.AppRelativeVirtualPath != "~/editprofile.aspx")
            {
                cph_right.Visible = false;
            }
            else
            {
                HomeContentsTableAdapter hContentsadptr = new HomeContentsTableAdapter();
                HomeContents.HomeContentsDataTable hContents = hContentsadptr.GetContentByType("Department News",2);
                foreach (HomeContents.HomeContentsRow row in hContents)
                {
                    int len = 90 - row.Title.Length;
                    if (row.Data.Length > len && len > 0)
                        row.Data = row.Data.Substring(0, len);
                }
                dlDeptNews.DataSource = hContents;
                dlDeptNews.DataBind();

                HomeContents.HomeContentsDataTable rGst = hContentsadptr.GetContentByType("Right Guest", 1);
                foreach (HomeContents.HomeContentsRow row in rGst)
                {
                    int len = 190 - row.Title.Length;
                    if (row.Data.Length > len && len > 0)
                        row.Data = row.Data.Substring(0, len);
                }
                dlRGuest.DataSource = rGst;
                dlRGuest.DataBind();

                HomeContents.HomeContentsDataTable lGst = hContentsadptr.GetContentByType("Right Guest", 1);
                foreach (HomeContents.HomeContentsRow row in lGst)
                {
                    int len = 190 - row.Title.Length;
                    if (row.Data.Length > len && len > 0)
                        row.Data = row.Data.Substring(0, len);
                }
                dlLGuest.DataSource = lGst;
                dlLGuest.DataBind();
            }
            if (!Page.IsPostBack)
            {
              
                if (Request.IsAuthenticated)
                {

                    if (!string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
                    {
                        // This is an unauthorized, authenticated request...
                        Response.Redirect("~/UnauthorizedAccess.aspx");
                    }
                }
            }
            if (Page.User.Identity.Name != "")
            {
                Label lblWlcmName = (Label)LoginView1.FindControl("lblWlcmName");
                lblWlcmName.Text = Page.User.Identity.Name;

            }
            //news_GetDescriptionTableAdapter desc = new news_GetDescriptionTableAdapter();
            //DataTable dtDesc = desc.GetDescription();
            //if (gdvNews != null && gdvNews.Visible && dtDesc.Rows.Count > 0)
            //{
            //    gdvNews.DataSource = dtDesc;
            //    gdvNews.DataBind();
            //}
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            Login Login1 = (Login)LoginView1.FindControl("Login1");
            try
            {
                if (Membership.Provider.ValidateUser(Login1.UserName, Login1.Password))
                {
                    e.Authenticated = true;

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



        protected void gdvNews_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "newslink")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string commandText = linkButton.Text;
                Response.Redirect("/shownewsdocuments.aspx?text=" + commandText);
            }

        }
    }
}
