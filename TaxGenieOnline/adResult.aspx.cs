using System;
using System.Data;
using TaxGenie_DAL.searchTableAdapters;
using System.Web.UI.WebControls;

namespace TaxGenieOnline
{
    public partial class adResult : System.Web.UI.Page
    {
        adSearch epage = null;
        int pageSize = 10;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                epage = Context.PreviousHandler as adSearch;
                if (epage != null)
                {
                    CaseNo.Value = epage.CaseNo;
                    Citation.Value = epage.Citation;
                    Year.Value = epage.Year;
                    JudgeName.Value = epage.JudgeName;
                    Court.Value = epage.Court;
                    SearchCat.Value = epage.SearchCategory;
                    SearchType.Value = epage.SearchType;
                    PartyName.Value = epage.PartyName;
                    Keyword.Value = epage.KeyWord;
                    Volume.Value = epage.CLVol;
                    CPage.Value = epage.CLPage;
                }
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            Data_Search_SelectTableAdapter srcAdapter = new Data_Search_SelectTableAdapter();
            DataTable dt = null;
            if (SearchCat.Value == "Headnotes")
            {
                dt = srcAdapter.GetCLSearch(Keyword.Value, PartyName.Value, Court.Value,Bench.Value, CaseNo.Value, JudgeName.Value, Citation.Value, Year.Value, UPager.CurrentIndex, UPager.PageSize);
            }
            else
            {
                dt = srcAdapter.GetCLKeySearch(Keyword.Value, PartyName.Value, Court.Value,Bench.Value, CaseNo.Value, JudgeName.Value, Citation.Value, Year.Value, UPager.CurrentIndex, UPager.PageSize);
            }
            repSrcResult.DataSource = dt;
            repSrcResult.DataBind();
            if (dt.Rows.Count > 0)
            {
                DPager.ItemCount=UPager.ItemCount = Double.Parse(dt.Rows[0]["TotalRows"].ToString());
            }
            else
            {
                DPager.Visible = UPager.Visible = false;
                nores.Visible = true;
            }

        }

        protected void UPager_Command(object sender, CommandEventArgs e)
        {
            int currnetPageIndx = Convert.ToInt32(e.CommandArgument);
            UPager.CurrentIndex =DPager.CurrentIndex = currnetPageIndx;
            BindRepeater();
        }

        protected void RefSrch_Click(object sender, EventArgs e)
        {
            Server.Transfer("/adSearch.aspx");
        }
    }
}