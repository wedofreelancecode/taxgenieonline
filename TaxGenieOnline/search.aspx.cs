using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TaxGenie_DAL.searchTableAdapters;

namespace TaxGenieOnline
{
    public partial class search : System.Web.UI.Page
    {
        string _keyword;
        protected void Page_Load(object sender, EventArgs e)
        {
            _keyword = Request.QueryString["keyword"].ToString();
            Session["keyword"] = _keyword;
            if (!IsPostBack)
            {

                bindgv();
            }
        }

        protected void gv_Search_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Search.PageIndex = e.NewPageIndex;
            bindgv();
        }

        public void bindgv()
        {
            Data_Search_SelectTableAdapter getKeywordData = new Data_Search_SelectTableAdapter();
            DataTable dtKeywordData = getKeywordData.Search_Data(_keyword);
            if (dtKeywordData.Rows.Count > 0)
            {
                gv_Search.DataSource = dtKeywordData;
                gv_Search.DataBind();
                lblseachword.Text = "see results about <span style='font-weight:bold;'>" + _keyword + "</span>";
            }
            else
            {
                lblseachword.Text = "No records found for <span style='font-weight:bold;'>" + _keyword + "</span>";
            }
         
        }
    }
}
