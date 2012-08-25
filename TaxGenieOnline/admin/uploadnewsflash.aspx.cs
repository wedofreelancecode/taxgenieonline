using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TaxGenie_DAL;
using TaxGenie_DAL.newsflashTableAdapters;


namespace TaxGenieOnline.admin
{
    public partial class uploadnewsflash : System.Web.UI.Page
    {
        int k = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            editnewsflash epage = Context.Handler as editnewsflash;
            if (epage != null)
            {
                hdnId.Value = epage.Id;
            }
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (btnupload.Text != "Update")
                {
                    newsflash_GetallTableAdapter adptr = new newsflash_GetallTableAdapter();
                    newsflash.newsflash_GetallRow news = adptr.GetNewFlash(id).Rows[0] as newsflash.newsflash_GetallRow;
                    taNews.Value = news.Newsflash;
                    btnupload.Text = "Update";
                }
            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                newsflash_GetallTableAdapter newsflash_insert = new newsflash_GetallTableAdapter();
                string content = taNews.Value.Replace("'", "''");
                if (hdnId.Value.Length > 0)
                {
                    int? id = Int32.Parse(hdnId.Value);
                    newsflash_insert.Update_NewsFlash(content, DateTime.Now, id);
                    Server.Transfer("editnewsflash.aspx");
                }
                else
                {
                    k = newsflash_insert.Insert(DateTime.Now, content);

                    if (k > 0)
                    {
                        Response.Write("<script>alert('Newsflash Uploded Successfully')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                lblstatus.Text = ex.Message;
            }
        }
    }
}
