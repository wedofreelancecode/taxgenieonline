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

            if (_tablename != "CaseLaws")
            {

                DataTable dtData = data.GetDataBySearchKeyword(_tablename, _id);



                if (dtData.Rows.Count > 0)
                {
                    content = dtData.Rows[0]["data"].ToString();
                }
            }
            else
            {

                DataTable dtCLData = data.DataByCLKeywords(_tablename, _id);

                content += "<table class='citCase' width='100%'  align='center'><tr><th width='100%' align='center'>" + dtCLData.Rows[0]["TGOLCitation"].ToString().ToUpper() + "</th></tr><tr>";
                content += "<td width='100%' align='center'>" + dtCLData.Rows[0]["Court"].ToString().ToUpper() + "</td></tr><tr>";
                content += "<td align='center'>" + dtCLData.Rows[0]["CaseNumber"] + "</td></tr><tr>";
                content += "<td align='center' class='parties'>";
                content += dtCLData.Rows[0]["APPELLANTParty"].ToString().ToUpper() + "<br/>Vs.<br/>";
                content += dtCLData.Rows[0]["RESPONDENTParty"].ToString().ToUpper() + "</td></tr><tr><td  align='left'>";
                content += dtCLData.Rows[0]["JudgesName"] + "</td></tr><tr><td  align='right'>";
                content += "Dated:&nbsp;" + ((DateTime)dtCLData.Rows[0]["DateofDecision"]).ToString("MMMM dd, yyyy") + "</td></tr><tr><td  align='justify'>";
                content += dtCLData.Rows[0]["HeadNotes"] + "</td></tr><tr><td>&nbsp;</td></tr><tr><td  align='center'></td></tr>";

                content += "<tr><td style='font-weight:normal' align='justify'>";

                content += dtCLData.Rows[0]["JUDGEMENTContent"] + "</td></tr>";
                content += "<tr><td style='padding:45px;font-style:italic;font-weight:normal;text-align:justify' align='center'><font face='Verdana, Arial, Helvetica, sans-serif' color='#666666' size='1'>(<b style='font-weight:bold'>DISCLAIMER</b>: Though all efforts have been made to reproduce the order correctly but the access and circulation is subject to the condition that TaxgenieOnline are not responsible/liable for any loss or damage caused to anyone due to any mistake/error/omissions.)</font></td></tr>";
                content += "</table>";











                //  content = dtData.Rows[0]["data"].ToString();

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
                if (sKeyword.ToString() == "ss")
                {

                }
                else
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
            }
            return input;
        }
    }
}
