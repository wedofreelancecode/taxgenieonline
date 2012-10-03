using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TaxGenie_DAL.customsTableAdapters;
using TaxGenie_DAL.CentralExciseTableAdapters;
using TaxGenie_DAL.CircularsTableAdapters;
using TaxGenie_DAL.TariffTableAdapters;
using TaxGenie_DAL.LibraryTableAdapters;
using TaxGenie_DAL.DGFTTableAdapters;
using TaxGenie_DAL.CECNotificationsTableAdapters;
using TaxGenie_DAL.STNotificationsTableAdapters;
using TaxGenie_DAL.CaseLawsTableAdapters;

namespace TaxGenieOnline
{
    public partial class displayindex : System.Web.UI.Page
    {
        string category, subcategory, indexName, caselawnum1, caselawnum2;
        string year;
        string tariffIndex;
        string notification;
        protected void Page_Load(object sender, EventArgs e)
        {
            category = Request.QueryString["cat"];
            subcategory = Request.QueryString["subcat"];
            indexName = Request.QueryString["name"];
            year = Request.QueryString["year"];
            notification = Request.QueryString["notification"];
            caselawnum1 = Request.QueryString["CLnum1"];
            caselawnum2 = Request.QueryString["CLnum2"];

            #region Customs Tariff


            if (category == "Customs" & subcategory == "Tariff 2012-13")
            {
                Custom_Tariff_IndexnameTableAdapter index = new Custom_Tariff_IndexnameTableAdapter();
                DataTable dtChapterbyIndex = index.Custom_Tariff_ChapterbyIndex(indexName);
                if (dtChapterbyIndex.Rows.Count > 0)
                {
                    ltlIndex.Text = "<table>";
                    string _Subgroup = string.Empty;
                    string _schemes = string.Empty;
                    foreach (DataRow drChapterbyIndex in dtChapterbyIndex.Rows)
                    {
                        string subgroup = drChapterbyIndex["SubGroup"].ToString();
                        string schemes = drChapterbyIndex["Schemes"].ToString();
                        string chaptername = drChapterbyIndex["chaptername"].ToString();
                        string subject = drChapterbyIndex["subjects"].ToString();

                        if (_Subgroup != subgroup)
                        {
                            ltlIndex.Text += "<tr><td align='center' style='background-color:#D9D9D9;font-size:1.4em;'>" + subgroup + "<br/><br/></td></tr>";
                        }
                        if (_schemes != schemes)
                        {
                            ltlIndex.Text += "<tr><td align='left' style='font-size:10.0pt;font-family:Verdana,sans-serif;mso-bidi-font-family:Times;color:#943634';><br/><br/>" + schemes + "<br/><br/></td></tr>";
                        }
                        ltlIndex.Text += "<tr><td style='font-size:10.0pt;font-family:Verdana,sans-serif;mso-bidi-font-family:Times'><a href='shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&chaptername=" + chaptername + "'>" + chaptername + "</a><br/>" + subject + "<br/><br/><br/></td></tr>";
                        _Subgroup = subgroup;
                        _schemes = schemes;
                    }
                    ltlIndex.Text += "</table>";
                }
            }
            #endregion

            #region Central Excise Tariff


            else if (category == "Central Excise" & subcategory == "Tariff 2012-13")
            {
                CentralExcise_Tariff_GetAllTableAdapter index = new CentralExcise_Tariff_GetAllTableAdapter();
                DataTable dtChapterbyIndex = index.CE_Tariff_ChapterByIndex(indexName);
                if (dtChapterbyIndex.Rows.Count > 0)
                {
                    ltlIndex.Text = "<table>";
                    string _Subgroup = string.Empty;
                    foreach (DataRow drChapterbyIndex in dtChapterbyIndex.Rows)
                    {
                        string subgroup = drChapterbyIndex["SubGroup"].ToString();
                        string chaptername = drChapterbyIndex["chaptername"].ToString();
                        string subject = drChapterbyIndex["subjects"].ToString();

                        if (_Subgroup != subgroup)
                        {
                            ltlIndex.Text += "<tr><td align='center' style='background-color:#D9D9D9;font-size:1.4em;'>" + subgroup + "<br/><br/></td></tr>";
                        }

                        ltlIndex.Text += "<tr><td style='font-size:10.0pt;font-family:Verdana,sans-serif;mso-bidi-font-family:Times'><a href='shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&chaptername=" + chaptername + "'>" + chaptername + "</a><br/>" + subject + "<br/><br/><br/></td></tr>";
                        _Subgroup = subgroup;

                    }
                    ltlIndex.Text += "</table>";
                }
            }

            #endregion

            #region Circulars/Instructions
            else if (subcategory == "Circulars/Instructions")
            {
                if (indexName == "Circulars")
                {
                    gvindexcircularvalues();
                }
                else if (indexName == "Instructions")
                {
                    gvindexinstructionvalues();
                }
            }
            #endregion

            #region CECnotifications
            else if (subcategory == "Notifications" & (category == "Customs" || category == "Central Excise"))
            {
                CECNotifications();
            }
            #endregion

            #region STNotifications
            else if (subcategory == "Notifications" && category == "Service Tax")
            {
                STNotifications();
            }
            #endregion

            #region Caselaws

            else if (subcategory == "Case Laws" || subcategory == "Case")
            {

                lblCL.Text = category+"&nbsp;Case Laws";

                ltlCL.Text += "<table class='citation'><tr><th align='center'>Citation of Year&nbsp;" + year + "</td></tr><tr><td align='center'>";
                ltlCL.Text += caselawnum2 + "-" + caselawnum1 ;
                ltlCL.Text += "</td></tr></table><br/><br/>";


                GetAllCaseLawsTableAdapter getall = new GetAllCaseLawsTableAdapter();
                DataTable dtgetall = getall.GetCitationNum(category, Convert.ToInt32(year), Convert.ToInt32(caselawnum1),Convert.ToInt32(caselawnum2));

                if (dtgetall.Rows.Count > 0)
                {
                    ltlCLheadnotes.Text = string.Empty;
                    foreach (DataRow drcitation in dtgetall.Rows)
                    {
                        string TGOLcitationnum = drcitation["TGOLCitation"].ToString(), APPELLANTParty = drcitation["APPELLANTParty"].ToString(), RESPONDENTParty = drcitation["RESPONDENTParty"].ToString();
                        string HeadNotes = drcitation["HeadNotes"].ToString(), DateofDecision =((System.DateTime)drcitation["DateofDecision"]).ToString("dd-MMMM-yyyy");

                        ltlCLheadnotes.Text += "<table class='citation citCon'>";
                        ltlCLheadnotes.Text += "<tr><td align='center'><a href=shownotifications.aspx?citation=" + TGOLcitationnum + "&cat=" + category + "&subcat=" + subcategory+">" + TGOLcitationnum + "</a></td></tr>";
                        ltlCLheadnotes.Text += "<tr><td align='center'>" + APPELLANTParty + " <span>Vs.</span> " + RESPONDENTParty + "<br/>(Dated:&nbsp;" + DateofDecision + ")</td></tr>";
                        ltlCLheadnotes.Text += "<tr><td style='text-align:justify;font-weight:normal'>" + HeadNotes + "</td></tr></table><br/>";
                    }
                }

            }




            #endregion

            else
            {
                Bindgvindex(subcategory, indexName);
            }
        }

        protected void Bindgvindex(string subcat, string name)
        {
            DataTable dtAChapter = new DataTable();
            if (category == "Customs")
            {
                ActsTableAdapter aChapter = new ActsTableAdapter();
                dtAChapter = aChapter.Data_Select(subcategory, indexName);
            }
            else if (category == "Central Excise")
            {
                CEActsTableAdapter CEActsChapter = new CEActsTableAdapter();
                dtAChapter = CEActsChapter.CEData(subcategory, indexName);
            }
            else if (category == "Library")
            {
                 //Library_RSRules_SelectAllTableAdapter CEActsChapter = new Library_RSRules_SelectAllTableAdapter();
               // dtAChapter = CEActsChapter.Library_Data_Select(subcategory, indexName);
            }
            else if (category == "DGFT" & subcategory == "FTP")
            {

                DGFT_GetAllTableAdapter DGFTFTPChapter = new DGFT_GetAllTableAdapter();
                DataTable dtFTPChapter = DGFTFTPChapter.DGFT_FTP_Data_select(subcategory, indexName);
                gvDGFTFTP.DataSource = dtFTPChapter;
                gvDGFTFTP.DataBind();

            }
            else if (category == "DGFT" & subcategory == "public notices")
            {

                DGFT_GetAllTableAdapter DGFTpublicnotices = new DGFT_GetAllTableAdapter();
                DataTable dtpublicnotices = DGFTpublicnotices.DGFT_NoticenumByindex_select(indexName);
                gvDGFTpublicnotice.DataSource = dtpublicnotices;
                gvDGFTpublicnotice.DataBind();

            }
            else if (category == "DGFT" & subcategory == "FTDR Notifications")
            {

                DGFT_FTDR_Notifications_GetAllTableAdapter DGFTpublicnotices = new DGFT_FTDR_Notifications_GetAllTableAdapter();
                DataTable dtpublicnotices = DGFTpublicnotices.DGFT_FTDR_NotinumByIndex(indexName);
                gvDGFTpublicnotice.DataSource = dtpublicnotices;
                gvDGFTpublicnotice.DataBind();

            }
            if (dtAChapter.Rows.Count > 0)
            {
                gvindex.DataSource = dtAChapter;
                gvindex.DataBind();
            }
        }

        protected void gvindex_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("chapter"))
            {
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                LinkButton lnkDocName = (LinkButton)row.FindControl("lnkChapterName");
                string chapterName = lnkDocName.Text;
                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + indexName + "&chaptername=" + chapterName);
            }
        }

        protected void gvindexcircularvalues()
        {
            Circulars_Info_ByyearTableAdapter cirinfo = new Circulars_Info_ByyearTableAdapter();
            DataTable dtinfo = cirinfo.CircularsInfoByyear(year, category);
            if (dtinfo.Rows.Count > 0)
            {
                gvindexcircular.DataSource = dtinfo;
                gvindexcircular.DataBind();
            }
        }

        protected void gvindexinstructionvalues()
        {
            Instructions_Info_ByyearTableAdapter insinfo = new Instructions_Info_ByyearTableAdapter();
            DataTable dtinsinfo = insinfo.InstructionsInfoByyear(year, category);
            if (dtinsinfo.Rows.Count > 0)
            {
                gvindexinstructions.DataSource = dtinsinfo;
                gvindexinstructions.DataBind();

            }

        }

        protected void CECNotifications()
        {
            DataTable dtinsinfo = null;
            CECNotification_GetAllTableAdapter insinfo = new CECNotification_GetAllTableAdapter();

            switch (notification)
            {
                case "Tariff":
                    dtinsinfo = insinfo.CEC_notificationsinfo_ByTYear(year, category);
                    break;
                case "Non-Tariff":
                    dtinsinfo = insinfo.CEC_notificationinfo_ByNTYear(year, category);
                    break;
                case "Safeguards":
                    dtinsinfo = insinfo.CEC_notificationsinfo_BySYear(year, category);
                    break;
                case "Anti Dumping Duty":
                    dtinsinfo = insinfo.CEC_notificationsinfo_ADDYear(year, category);
                    break;
                case "Others":
                    dtinsinfo = insinfo.CEC_notificationsinfo_ByOthersYear(year, category);
                    break;
            }

            if (dtinsinfo.Rows.Count > 0)
            {
                gvCECNotifications.DataSource = dtinsinfo;
                gvCECNotifications.DataBind();
            }
        }

        protected void STNotifications()
        {
            STN_GetAllTableAdapter stnadp = new STN_GetAllTableAdapter();
            DataTable dtstn = new DataTable();
            dtstn = stnadp.STN_InfoByYear(year, subcategory);

            if(dtstn.Rows.Count>0)
            {
                gvSTNotification.DataSource = dtstn;
                gvSTNotification.DataBind();
            }
        }

        protected void gvindexcircular_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "number")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string cnumber = linkButton.Text;
                Response.Redirect("shownotifications.aspx?cnums=" + cnumber + "&cat=" + category + "&years=" + year + "&subcat=" + subcategory);
            }
        }

        protected void gvindexinstructions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "fnumber")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string fnumber = linkButton.Text;
                Response.Redirect("shownotifications.aspx?fnums=" + fnumber + "&cat=" + category + "&years=" + year + "&subcat=" + subcategory);
            }
        }

        protected void gvDGFTFTP_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "FTPchapter")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string chapter = linkButton.Text;
                Response.Redirect("shownotifications.aspx?chaptername=" + chapter + "&cat=" + category + "&subcat=" + subcategory + "&name=" + indexName);
            }
        }

        protected void gvDGFTpublicnotice_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "number")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string chapter = linkButton.Text;
                Response.Redirect("shownotifications.aspx?chaptername=" + chapter + "&name=" + indexName + "&subcat=" + subcategory + "&cat=" + category);
            }
        }

        protected void gvindexcircular_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                if (category == "DGFT")
                {
                    gvindexcircular.Columns[2].Visible = false;

                }
                else
                {
                    gvindexcircular.Columns[2].Visible = true;
                }

            }
        }

        protected void gvNotifications_RowCommand(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                if (category == "DGFT")
                {
                    gvindexcircular.Columns[2].Visible = false;

                }
                else
                {
                    gvindexcircular.Columns[2].Visible = true;
                }

            }
        }

        protected void gvCECNotifications_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Notificationnum")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string CECNnumber = linkButton.Text;
                Response.Redirect("shownotifications.aspx?CECNnum=" + CECNnumber + "&subcat=" + subcategory + "&cat=" + category + "&years=" + year + "&notificationname=" + notification);

            }
        }

        protected void gvSTNotification_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Notificationnum")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string STNnumber = linkButton.Text;
                Response.Redirect("shownotifications.aspx?STNnum=" + STNnumber + "&subcat=" + subcategory + "&cat=" + category + "&years=" + year + "&notificationname=" + notification);

            }
        }
        
    }
}
