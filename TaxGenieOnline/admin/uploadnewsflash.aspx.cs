using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TaxGenie_DAL.newsflashTableAdapters;


namespace TaxGenieOnline.admin
{
    public partial class uploadnewsflash : System.Web.UI.Page
    {
        int k = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {

                string content = Editor1.Content;
                string actcontent1 = content.Replace("'", "");


                newsflash_GetallTableAdapter newsflash_insert = new newsflash_GetallTableAdapter();
              k =newsflash_insert.Insert(DateTime.Now, actcontent1);

              if (k > 0)
              {
                  Response.Write("<script>alert('Newsflash Uploded Successfully')</script>");
              }
            }
            catch (Exception ex)
            {

                lblstatus.Text = ex.Message;
            }
        }
    }
}
