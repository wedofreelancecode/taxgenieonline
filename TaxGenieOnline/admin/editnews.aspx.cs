using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TaxGenie_DAL.newsTableAdapters;
namespace TaxGenieOnline.admin
{
    public partial class editnews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                news_GetYearsTableAdapter dtyears = new news_GetYearsTableAdapter();
                DataTable dtGetYears = dtyears.GetYears();

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
        protected void ddlyear_select(object sender, EventArgs e)
        {

            news_GetDocbyyearTableAdapter dtdoc = new news_GetDocbyyearTableAdapter();
            DataTable dtGetDoc = dtdoc.Getnewsdocbyyear(ddlyear.SelectedValue);
            if (dtGetDoc.Rows.Count > 0 && ddlyear.SelectedValue != "Select One")
            {
                ddldoc.Items.Clear();

                ddldoc.Items.Add(new ListItem("Select One", "0"));

                foreach (DataRow i in dtGetDoc.Rows)
                {

                    ddldoc.Items.Add(i["Name"].ToString());
                }
            }
            else
            {
                ddldoc.Items.Clear();

            }
        }

        protected void ddlname_select(object sender, EventArgs e)
        {
            news_getdescriptionbydocyearandnameTableAdapter description = new news_getdescriptionbydocyearandnameTableAdapter();
            DataTable dtdescription = description.GetDescByNameandYear(ddldoc.SelectedValue, ddlyear.SelectedValue);
            if (dtdescription.Rows.Count > 0)
            {
                string desc = dtdescription.Rows[0]["Description"].ToString();
                Editor1.Content = desc;
            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            news_GetallDataTableAdapter updatenewsdesc = new news_GetallDataTableAdapter();
            updatenewsdesc.Update(ddldoc.SelectedValue, ddlyear.SelectedValue, Editor1.Content).ToString();
            news_GetDescriptionTableAdapter desc = new news_GetDescriptionTableAdapter();
            DataTable dtDesc = desc.GetDescription();
            GridView gdvNews = (GridView)FindControlRecursive(Page, "gdvNews");
            gdvNews.DataSource = dtDesc;
            gdvNews.DataBind();
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
    }
}

