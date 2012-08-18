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

using System.Drawing;

namespace TaxGenieOnline
{
    public partial class uploadnews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {

                string content = Editor1.Content;
                string actcontent1 = content.Replace("'", "");


                news_GetallDataTableAdapter news_insert = new news_GetallDataTableAdapter();
                news_insert.Insert(txtdocname.Text, actcontent1, txtyear.Text, DateTime.Now, txtdesc.Text);

                news_GetDescriptionTableAdapter desc = new news_GetDescriptionTableAdapter();
                DataTable dtDesc = desc.GetDescription();
                if (dtDesc.Rows.Count > 0)
                {
                    GridView gdvNews = (GridView)FindControlRecursive(Page, "gdvNews");
                    gdvNews.DataSource = dtDesc;
                    gdvNews.DataBind();
                    Response.Write("<script>alert('News Uploded Successfully')</script>");
                }
            }
            catch (Exception ex)
            {

                lblstatus.Text = ex.Message;
            }
        }


      
    }
}
