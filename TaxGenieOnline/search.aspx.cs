﻿using System;
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

            Data_Search_SelectTableAdapter getKeywordData = new Data_Search_SelectTableAdapter();
            DataTable dtKeywordData = getKeywordData.Search_Data(_keyword);
            if (dtKeywordData.Rows.Count > 0)
            {
                gv_Search.DataSource = dtKeywordData;
                gv_Search.DataBind();
            }
        }

        protected void gv_Search_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Search.PageIndex = e.NewPageIndex;
        }
    }
}