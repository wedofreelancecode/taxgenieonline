using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using TaxGenie_DAL.searchTableAdapters;

namespace TaxGenieOnline
{
    public partial class searchdata : System.Web.UI.Page
    {
        string _id, _tablename;
        string _keyword;
        protected void Page_Load(object sender, EventArgs e)
        {
            _keyword = Session["keyword"].ToString();
            _id = Request.QueryString["id"];
            _tablename = Request.QueryString["name"];
            string content = string.Empty;
            Data_Search_SelectTableAdapter data = new Data_Search_SelectTableAdapter();
            DataTable dtData = data.GetDataBySearchKeyword(_tablename, _id);
            if (dtData.Rows.Count > 0)
            {
                content = dtData.Rows[0]["data"].ToString();
            }
            ltlData.Text = searchitem.HighlightKeywords(content, _keyword);
        }

    }

    public static class searchitem
    {
        public static string HighlightKeywords(this string input, string keywords)
        {
            if (input == string.Empty || keywords == string.Empty)
            {
                return input;
            }

            string[] sKeywords = keywords.Split(' ');
            foreach (string sKeyword in sKeywords)
            {
                try
                {
                    input = Regex.Replace(input, sKeyword, string.Format("<span style='background-color:Orange'>{0}</span>", "$0"), RegexOptions.IgnoreCase);
                }
                catch
                {
                    //
                }
            }
            return input;
        }
    }
}
