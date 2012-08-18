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
    public partial class searchdata : System.Web.UI.Page
    {
        string _id, _tablename;
        protected void Page_Load(object sender, EventArgs e)
        {
            _id = Request.QueryString["id"];
            _tablename = Request.QueryString["name"];

            Data_Search_SelectTableAdapter data = new Data_Search_SelectTableAdapter();
            DataTable dtData = data.GetDataBySearchKeyword(_tablename, _id);
            if (dtData.Rows.Count > 0)
            {

                ltlData.Text = dtData.Rows[0]["data"].ToString();
            }
        }
    }
}
