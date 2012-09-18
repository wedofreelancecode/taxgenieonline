using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TaxGenie_DAL.customsTableAdapters;
using TaxGenie_DAL.CentralExciseTableAdapters;
using TaxGenie_DAL.ServiceTaxTableAdapters;
using TaxGenie_DAL.CircularsTableAdapters;
using TaxGenie_DAL.TariffTableAdapters;
using TaxGenie_DAL.STCaseLawsTableAdapters;
using TaxGenie_DAL.LibraryTableAdapters;
using TaxGenie_DAL.DGFTTableAdapters;
using TaxGenie_DAL.IncomeTaxTableAdapters;
using TaxGenie_DAL.CECNotificationsTableAdapters;
using TaxGenie_DAL.STNotificationsTableAdapters;
using TaxGenie_DAL.CaseLawsTableAdapters;

namespace TaxGenieOnline
{
    public partial class shownotifications : System.Web.UI.Page
    {
        string cNumber, fNumber, year,citation;
        string subcategeory;
        protected void Page_Load(object sender, EventArgs e)
        {
            string category = Convert.ToString(Request.QueryString["cat"]);

            if (category == "Central")
            {
                category = "Central Excise";
                 subcategeory = "Case Laws";
            }

            else if (category == "Service")
            {
                category = "Service Tax";
                 subcategeory = "Case Laws";
            }

            else
            {
                 subcategeory = Request.QueryString["subcat"];
            }

           
            string indexName = Request.QueryString["name"];
            string chapter = Request.QueryString["chaptername"];
            string citation = Request.QueryString["citation"];
            cNumber = Convert.ToString(Request.QueryString["cnums"]);
            fNumber = Convert.ToString(Request.QueryString["fnums"]);
            year = Convert.ToString(Request.QueryString["years"]);
            string notification = Request.QueryString["notificationname"];
            string notificationnum = Convert.ToString(Request.QueryString["CECNnum"]);
            string STNnotificationnum = Convert.ToString(Request.QueryString["STNnum"]);

            #region Circulars/Instructions
            if (subcategeory == "Circulars/Instructions")
            {
                if (cNumber != "")
                {
                    Instructions_Data_ByCnumberTableAdapter getDatByCnumber = new Instructions_Data_ByCnumberTableAdapter();
                    DataTable dtDatByCnumber = getDatByCnumber.GetDatabyCnumber(cNumber, category, year);

                    if (dtDatByCnumber.Rows.Count > 0)
                    {
                        ltl.Text = Convert.ToString(dtDatByCnumber.Rows[0]["Data"]);

                    }
                }
                if (fNumber != "")
                {

                    Instructions1_Data_ByCnumberTableAdapter getDataByFnumber = new Instructions1_Data_ByCnumberTableAdapter();
                    DataTable dtDataByFnumber = getDataByFnumber.InstructionsData(fNumber, category, year);

                    if (dtDataByFnumber.Rows.Count > 0)
                    {
                        ltl.Text = Convert.ToString(dtDataByFnumber.Rows[0]["Data"]);


                    }
                }
            }
            #endregion

            #region Customs Tariff

            else if (category == "Customs" && subcategeory == "Tariff 2012-13")
            {
                if (indexName == null && chapter != "")
                {
                    Custom_Tariff_DataByChapteNameTableAdapter getDataByChapteName = new Custom_Tariff_DataByChapteNameTableAdapter();
                    DataTable dtDataByChapteName = getDataByChapteName.GetCTDataByChapterName(chapter);


                    if (dtDataByChapteName.Rows.Count > 0)
                    {

                        string tchaptername = Convert.ToString(dtDataByChapteName.Rows[0]["ChapterName"].ToString());
                        if (tchaptername != "")
                        {
                            string tdata = Convert.ToString(dtDataByChapteName.Rows[0]["Data"].ToString());
                            if (tdata != "")
                            {
                                ltl.Text = Convert.ToString(dtDataByChapteName.Rows[0]["Data"]);
                            }
                            else
                            {
                                byte[] b = ((byte[])dtDataByChapteName.Rows[0]["Document"]);
                                //Collect Bytes from database and write in Webpage
                                Response.ContentType = "application/pdf";
                                Response.BinaryWrite(b);
                                Response.Write("<script>window.open('Page.html','_blank')</script>");
                            }
                        }
                    }

                }

                else
                {


                    Custom_Tariff_DataByIndexNameTableAdapter getDataByIndexName = new Custom_Tariff_DataByIndexNameTableAdapter();
                    DataTable dtDataByIndexName = getDataByIndexName.GetCTDataByIndexName(indexName);
                    string tdata = Convert.ToString(dtDataByIndexName.Rows[0]["Data"].ToString());
                    if (tdata != "")
                    {
                        ltl.Text = Convert.ToString(dtDataByIndexName.Rows[0]["Data"]);

                    }
                    else
                    {

                        byte[] b = ((byte[])dtDataByIndexName.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                        Response.Write("<script>window.open('Page.html','_blank')</script>");

                    }
                }

            }
            #endregion

            #region Central Excise Tariff


            else if (category == "Central Excise" && subcategeory == "Tariff 2012-13")
            {
                if (indexName == null && chapter != "")
                {
                    CE_Tariff_DataByChapteNameTableAdapter getDataByChapteName = new CE_Tariff_DataByChapteNameTableAdapter();
                    DataTable dtDataByChapteName = getDataByChapteName.CE_Tariff_DataByChapter(chapter);
                    if (dtDataByChapteName.Rows.Count > 0)
                    {

                        string tchaptername = Convert.ToString(dtDataByChapteName.Rows[0]["ChapterName"].ToString());
                        if (tchaptername != "")
                        {
                            string tdata = Convert.ToString(dtDataByChapteName.Rows[0]["Data"].ToString());
                            if (tdata != "")
                            {
                                ltl.Text = Convert.ToString(dtDataByChapteName.Rows[0]["Data"]);
                            }
                            else
                            {
                                byte[] b = ((byte[])dtDataByChapteName.Rows[0]["Document"]);
                                //Collect Bytes from database and write in Webpage
                                Response.ContentType = "application/pdf";
                                Response.BinaryWrite(b);
                                Response.Write("<script>window.open('Page.html','_blank')</script>");
                            }
                        }
                    }


                }
                else
                {


                    CentralExcise_Tariff_GetAllTableAdapter getDataByIndexName = new CentralExcise_Tariff_GetAllTableAdapter();
                    DataTable dtDataByIndexName = getDataByIndexName.CE_Tariff_DataByIndex(indexName);
                    string tdata = Convert.ToString(dtDataByIndexName.Rows[0]["Data"].ToString());
                    if (tdata != "")
                    {
                        ltl.Text = Convert.ToString(dtDataByIndexName.Rows[0]["Data"]);

                    }
                    else
                    {

                        byte[] b = ((byte[])dtDataByIndexName.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                        Response.Write("<script>window.open('Page.html','_blank')</script>");

                    }
                }
            }
            #endregion

            #region Service Tax CaseLaws
            //else if (category == "Service Tax" && subcategeory == "Case Laws")
            //{
            //    STCaselaws_GetAllTableAdapter getSTCaselawsDataByindex = new STCaselaws_GetAllTableAdapter();
            //    DataTable dtSTCaselawsDataByindex = getSTCaselawsDataByindex.GetDataByIndexName(indexName);

            //    string stcl = Convert.ToString(dtSTCaselawsDataByindex.Rows[0]["Data"]);

            //    if (stcl != null)
            //    {
            //        ltl.Text = Convert.ToString(dtSTCaselawsDataByindex.Rows[0]["Data"]);
            //    }
            //    else
            //    {
            //        byte[] b = ((byte[])dtSTCaselawsDataByindex.Rows[0]["Document"]);
            //        //Collect Bytes from database and write in Webpage
            //        Response.ContentType = "application/pdf";
            //        Response.BinaryWrite(b);
            //        Response.Write("<script>window.open('Page.html','_blank')</script>");
            //    }


            //}
            #endregion

            #region STLibraries
            else if (category == "Library" && subcategeory == "Libraries")
            {
                string path = HttpContext.Current.Server.MapPath("faq-29sept11.pdf");
                System.Net.WebClient client = new System.Net.WebClient();
                Byte[] buffer = client.DownloadData(path);

                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.TransmitFile(path);

                    //Response.BinaryWrite(buffer);
                }



            }
            #endregion

            #region STTaxation
            else if (category == "Service Tax" && subcategeory == "Taxation of Services: An Educational Guide")
            {
                string path = HttpContext.Current.Server.MapPath("st-edu-guide.pdf");
                System.Net.WebClient client = new System.Net.WebClient();
                Byte[] buffer = client.DownloadData(path);

                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.TransmitFile(path);
                }


            }
            #endregion

            #region CEManual
            else if (category == "Service Tax" && subcategeory == "CBEC Manual")
            {
                string path = HttpContext.Current.Server.MapPath("cx-manual.pdf");
                System.Net.WebClient client = new System.Net.WebClient();
                Byte[] buffer = client.DownloadData(path);

                if (buffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.TransmitFile(path);
                }


            }
            #endregion

            #region CECNotifications
            else if (subcategeory == "Notifications" & (category == "Customs" || category == "Central Excise"))
            {

                DataTable dtcectdata = null;
                CECNotification_GetAllTableAdapter cectdata = new CECNotification_GetAllTableAdapter();
                switch (notification)
                {
                    case "Tariff":

                        dtcectdata = cectdata.CEC_notificatondata_ByTnum(notificationnum, category, year);
                        break;
                    case "Non-Tariff":
                        dtcectdata = cectdata.CEC_notificatondata_ByNTnum(notificationnum, category, year);
                        break;
                    case "Safeguards":
                        dtcectdata = cectdata.CEC_notificatondata_BySnum(notificationnum, category, year);
                        break;
                    case "Anti Dumping Duty":
                        dtcectdata = cectdata.CEC_notificationdata_ByADDNum(notificationnum, category, year);
                        break;
                    case "Others":
                        dtcectdata = cectdata.CEC_notificationdata_ByOthersnum(notificationnum, category, year);
                        break;
                }

                string stcl = Convert.ToString(dtcectdata.Rows[0]["Data"]);

                if (stcl != null)
                {
                    ltl.Text = Convert.ToString(dtcectdata.Rows[0]["Data"]);
                }
                else
                {
                    byte[] b = ((byte[])dtcectdata.Rows[0]["Document"]);
                    //Collect Bytes from database and write in Webpage
                    Response.ContentType = "application/pdf";
                    Response.BinaryWrite(b);
                    Response.Write("<script>window.open('Page.html','_blank')</script>");
                }
            }
            #endregion

            #region  STNotifications

            else if (category == "Service Tax" && subcategeory == "Notifications")
            {
                STN_GetAllTableAdapter stnshow = new STN_GetAllTableAdapter();
                DataTable dtstnshow = stnshow.STN_DataByFnum(STNnotificationnum, subcategeory, year);
                string stcl = Convert.ToString(dtstnshow.Rows[0]["Data"]);

                if (stcl != null)
                {
                    ltl.Text = Convert.ToString(dtstnshow.Rows[0]["Data"]);
                }
                else
                {
                    byte[] b = ((byte[])dtstnshow.Rows[0]["Document"]);
                    //Collect Bytes from database and write in Webpage
                    Response.ContentType = "application/pdf";
                    Response.BinaryWrite(b);
                    Response.Write("<script>window.open('Page.html','_blank')</script>");
                }
            }

            #endregion

            #region DGFT
                        else if (category == "DGFT" & subcategeory == "public notices")
            {
                DGFTpublicnotices_GETALLTableAdapter DGFTNoticenum = new DGFTpublicnotices_GETALLTableAdapter();
               DataTable dtChapterName = DGFTNoticenum.DGFT_publicnoticdata(indexName, chapter);
               string stcl = Convert.ToString(dtChapterName.Rows[0]["Data"]);

               if (stcl != null)
               {
                   ltl.Text = Convert.ToString(dtChapterName.Rows[0]["Data"]);
               }
               else
               {
                   byte[] b = ((byte[])dtChapterName.Rows[0]["Document"]);
                   //Collect Bytes from database and write in Webpage
                   Response.ContentType = "application/pdf";
                   Response.BinaryWrite(b);
                   Response.Write("<script>window.open('Page.html','_blank')</script>");
               }
            }
            else if (category == "DGFT" & subcategeory == "FTDR Notifications")
            {
                DGFT_FTDR_Notifications_GetAllTableAdapter DGFTNoticenum = new DGFT_FTDR_Notifications_GetAllTableAdapter();
               DataTable dtChapterName = DGFTNoticenum.DGFT_FTDRnotic_Data(indexName, chapter);
               string stcl = Convert.ToString(dtChapterName.Rows[0]["Data"]);

               if (stcl != null)
               {
                   ltl.Text = Convert.ToString(dtChapterName.Rows[0]["Data"]);
               }
               else
               {
                   byte[] b = ((byte[])dtChapterName.Rows[0]["Document"]);
                   //Collect Bytes from database and write in Webpage
                   Response.ContentType = "application/pdf";
                   Response.BinaryWrite(b);
                   Response.Write("<script>window.open('Page.html','_blank')</script>");
               }

            }
            #endregion

            #region Library
             else if (category == "Library")
                {
                    Library_SelectAllTableAdapter LibraryData = new Library_SelectAllTableAdapter();
                    //Library_RSRules_SelectAllTableAdapter CEActsChapter = new Library_RSRules_SelectAllTableAdapter();
                   DataTable dtChapterName = LibraryData.Library_Data_Select(subcategeory, indexName);


                    string stcl = Convert.ToString(dtChapterName.Rows[0]["Data"]);

                    if (stcl != null & stcl !="")
                    {
                        ltl.Text = Convert.ToString(dtChapterName.Rows[0]["Data"]);
                    }
                    else
                    {
                        byte[] b = ((byte[])dtChapterName.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                        Response.Write("<script>window.open('Page.html','_blank')</script>");
                    }

                }
            #endregion

            #region Caselaws
            else if (subcategeory == "Case Laws" || subcategeory == "Case")
              {
                  GetAllCaseLawsTableAdapter getdatabycitation = new GetAllCaseLawsTableAdapter();
                  DataTable dtgetdatabycitation = getdatabycitation.GetDataByCitation(category, citation);

                  if (dtgetdatabycitation.Rows.Count > 0)
                  {

                      ltl.Text += "<table>";
                      ltl.Text += "<tr><td style='width:920px' align='center';>" + citation + "</td></tr>";
                      ltl.Text += "<tr>";
                      ltl.Text += "<td style='width:920px'  align='center';>";
                      ltl.Text += "IN THE " + dtgetdatabycitation.Rows[0]["Court"] + "</td></tr>";
                      ltl.Text += "<tr>";
                      ltl.Text += "<td  align='center';>";
                      ltl.Text += "Civil Appeal No. " + dtgetdatabycitation.Rows[0]["CaseNumber"] + "</td></tr>";
                      ltl.Text += "<tr>";
                      ltl.Text += "<td  align='center';>";
                      ltl.Text += dtgetdatabycitation.Rows[0]["APPELLANTParty"] + "</td></tr>";
                      ltl.Text += "<tr>";
                      ltl.Text += "<td  align='center';>";
                      ltl.Text += "V/S</td></tr>";

                      ltl.Text += "<tr>";
                      ltl.Text += "<td  align='center';>";
                      ltl.Text += dtgetdatabycitation.Rows[0]["RESPONDENTParty"] + "</td></tr>";

                      ltl.Text += "<tr>";
                      ltl.Text += "<td  align='left';>";
                      ltl.Text += dtgetdatabycitation.Rows[0]["JudgesName"] + "</td></tr>";


                      ltl.Text += "<tr>";
                      ltl.Text += "<td  align='right';>";
                      ltl.Text +="Dated :" +dtgetdatabycitation.Rows[0]["DateofDecision"] + "</td></tr>";


                      ltl.Text += "<tr>";
                      ltl.Text += "<td  align='justify';>";
                      ltl.Text += dtgetdatabycitation.Rows[0]["HeadNotes"]+"</td></tr>";



                      ltl.Text += "<tr>";
                      ltl.Text += "<td  align='center';>";
                      ltl.Text += "JUDGEMENT</td></tr>";



                      ltl.Text += "<tr>";
                      ltl.Text += "<td  align='left';>";
                      ltl.Text += "Per:" + dtgetdatabycitation.Rows[0]["JudgementinFavourof"] + "</td></tr>";


                      ltl.Text += "<tr>";
                      ltl.Text += "<td  align='justify';>";

                      ltl.Text += dtgetdatabycitation.Rows[0]["JUDGEMENTContent"] + "</td></tr></table>";


                  }

               }

            #endregion


            else
            {
                DataTable dtChapterName = new DataTable();

                if (category == "Customs")
                {
                    ActsTableAdapter chapterName = new ActsTableAdapter();
                    dtChapterName = chapterName.Data_Select(subcategeory, indexName);
                }
                else if (category == "Central Excise")
                {
                    CEActsTableAdapter CEActsChapter = new CEActsTableAdapter();
                    dtChapterName = CEActsChapter.CEData(subcategeory, indexName);
                }
                else if (category == "Service Tax")
                {
                    ServiceTax_GetAll1TableAdapter STchaptername = new ServiceTax_GetAll1TableAdapter();
                    dtChapterName = STchaptername.GetSTData(subcategeory, indexName);
                }
               

                else if (category == "DGFT" & subcategeory == "FTP")
                {
                    DGFT_GetAllTableAdapter FTPchapterName = new DGFT_GetAllTableAdapter();
                    dtChapterName = FTPchapterName.DGFT_FTP_Data_select(subcategeory, indexName);
                }
               
                else if (category == "Income Tax" & (subcategeory == "Income Tax Act" || subcategeory == "Wealth Tax Act" || subcategeory == "Expenditure Tax Act" || subcategeory == "Finance Act"))
                {
                    IncomeTaxActs_SelectAllTableAdapter itActsData = new IncomeTaxActs_SelectAllTableAdapter();
                    dtChapterName = itActsData.GetDataByIndex(subcategeory, indexName);
                }

                else if (category == "Income Tax" & (subcategeory == "Income Tax Rules" || subcategeory == "Other Direct Tax Rules"))
                {
                    IncomeTaxRules_SelectAllTableAdapter itActsData = new IncomeTaxRules_SelectAllTableAdapter();
                    dtChapterName = itActsData.GetDataByIndex(subcategeory, indexName);
                }

                else if (category == "Income Tax" & (subcategeory == "Circulars" || subcategeory == "Notifications"))
                {
                    IncomeTaxCircularsNotification_SelectAllTableAdapter itActsData = new IncomeTaxCircularsNotification_SelectAllTableAdapter();
                    dtChapterName = itActsData.GetDataByIndex(subcategeory, indexName);
                }

                if (dtChapterName.Rows.Count > 0)
                {
                    string aChapterName = Convert.ToString(dtChapterName.Rows[0]["ChapterName"].ToString());
                    string aSections = Convert.ToString(dtChapterName.Rows[0]["Sections"].ToString());
                    string adata = Convert.ToString(dtChapterName.Rows[0]["Data"].ToString());
                    string aDocumenet = Convert.ToString(dtChapterName.Rows[0]["Document"].ToString());


                    if (aChapterName == "" & aSections == "" & aDocumenet == "")
                    {
                        ltl.Text = Convert.ToString(dtChapterName.Rows[0]["Data"]);
                    }
                    else if (aChapterName == "" & aSections == "" & adata == "")
                    {
                        byte[] b = ((byte[])dtChapterName.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                    else
                    {
                        // ltl.Text = "<table><tr><td style='width=500px'>";
                        foreach (DataRow drChapterName in dtChapterName.Rows)
                        {
                            string aChapter = drChapterName["ChapterName"].ToString().Trim();
                            if (chapter.Trim().Equals(aChapter))
                            {
                                ltl.Text = Convert.ToString(drChapterName["Data"]);
                            }
                        }
                    }
                }
            }
        }
    }
}
