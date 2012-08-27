using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TaxGenie_DAL.customsTableAdapters;
using System.IO;
using TaxGenie_DAL.CentralExciseTableAdapters;
using TaxGenie_DAL.ServiceTaxTableAdapters;
using TaxGenie_DAL.CircularsTableAdapters;
using TaxGenie_DAL.TariffTableAdapters;
using TaxGenie_DAL.STCaseLawsTableAdapters;
using TaxGenie_DAL.DGFTTableAdapters;
using System.Data;
using TaxGenie_DAL.IncomeTaxTableAdapters;
using TaxGenie_DAL.CECNotificationsTableAdapters;
using TaxGenie_DAL.STNotificationsTableAdapters;


namespace TaxGenieOnline.admin
{
    public partial class uploadnotifications : System.Web.UI.Page
    {
        Byte[] bytes;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlCActs.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                pnlSTCaselaws.Visible = false;
                edtData.Visible = false;
                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                btnUpload.Visible = false;
                rdbUploadType.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;

                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;


            }
            editnotifications epage = Context.Handler as editnotifications;
            if (epage != null)
            {
                ddlcatagory.SelectedValue = epage.Category;
                ddlcatagory_SelectedIndexChanged(ddlcatagory, EventArgs.Empty);
                ddlsubcategory.SelectedValue = epage.SubCategory;
                ddlsubcategory_SelectedIndexChanged(ddlsubcategory, EventArgs.Empty);
                ddlcatagory.Enabled = false;
                ddlsubcategory.Enabled = false;
                hdnId.Value = epage.Id;
            }

            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (btnUpload.Text != "Update")
                {
                    btnUpload.Text = "Update";
                    if (ddlcatagory.SelectedValue.Equals("Central Excise"))
                    {
                        CEActsTableAdapter index = new CEActsTableAdapter();
                        DataTable dtActs = index.CEGetAllById(id);
                        if (dtActs.Rows.Count > 0)
                        {
                            if (ddlsubcategory.SelectedValue.Equals("Acts"))
                            {
                                txtCActsIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                txtCActsChapterName.Text = dtActs.Rows[0]["ChapterName"].ToString();
                                edtCActsSections.Content = dtActs.Rows[0]["Sections"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("Rules"))
                            {
                                txtCRulesIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                txtSubRulesChapterName.Text = dtActs.Rows[0]["ChapterName"].ToString();
                                ddlCRulesIndexGroup.SelectedValue = dtActs.Rows[0]["Headings"].ToString();
                                edtSubRulesSections.Content = dtActs.Rows[0]["Sections"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("Forms"))
                            {
                                txtCFormsIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                txtFormsSubject.Text = dtActs.Rows[0]["Subjects"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("Section 37B Order"))
                            {
                                txtCDrawbackIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("Case Laws"))
                            {
                                txtCDrawbackIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            
                        }

                        if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13"))
                        {
                            CentralExcise_Tariff_GetAllTableAdapter indexTariff = new CentralExcise_Tariff_GetAllTableAdapter();
                            DataTable dtTariff = indexTariff.SelectAllById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                ddlCtariffheading.SelectedValue = dtTariff.Rows[0]["Groups"].ToString();
                                ddlCtariffheading_SelectedIndexChanged(ddlCtariffheading, EventArgs.Empty); 
                                ddlCtariffsubheading.SelectedValue = dtTariff.Rows[0]["SubGroup"].ToString();
                                txtCtariffchapter.Text = dtTariff.Rows[0]["IndexName"].ToString();
                                txtCtariffChaptername.Text = dtTariff.Rows[0]["ChapterName"].ToString();
                                txtCtariffsubj.Text = dtTariff.Rows[0]["Subjects"].ToString();
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                        if (ddlsubcategory.SelectedValue.Equals("Notifications"))
                        {
                            CECNotification_GetAllTableAdapter indexTariff = new CECNotification_GetAllTableAdapter();
                            DataTable dtTariff = indexTariff.SelectAllCENotificationById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                rdbCECType.SelectedValue = dtTariff.Rows[0]["GroupType"].ToString();
                                ddlCtariffheading_SelectedIndexChanged(ddlCtariffheading, EventArgs.Empty);
                                txtCECYear.Text = dtTariff.Rows[0]["Year"].ToString();
                                txtCECFnumber.Text = dtTariff.Rows[0]["FileNumber"].ToString();
                                txtCECDate.Text = dtTariff.Rows[0]["Date"].ToString();
                                txtCECSubject.Text = dtTariff.Rows[0]["Subject"].ToString();
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                        if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions"))
                        {
                            Circulars_Info_ByyearTableAdapter indexTariff = new Circulars_Info_ByyearTableAdapter();
                            DataTable dtTariff = indexTariff.GetCEcircularsById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                bool isCircular = dtTariff.Rows[0]["GroupType"] == "Circulars";
                                rdbCircularUploadType.SelectedValue = isCircular ? "Circulars" : "Instructions";
                                txtCircularYear.Text = dtTariff.Rows[0]["Year"].ToString();
                                txtCircularNumber.Text = dtTariff.Rows[0]["CircularNumber"].ToString();
                                txtCircularFileNumber.Text = dtTariff.Rows[0]["FileNumber"].ToString();
                                txtCircularDate.Text = dtTariff.Rows[0]["Date"].ToString();
                                txtCircularSubject.Text = dtTariff.Rows[0]["Subject"].ToString();
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                    }
                    if (ddlcatagory.SelectedValue.Equals("Customs"))
                    {
                        ActsTableAdapter index = new ActsTableAdapter();
                        DataTable dtActs = index.GetAllCustomsById(id);
                        if (dtActs.Rows.Count > 0)
                        {
                            if (ddlsubcategory.SelectedValue.Equals("Acts"))
                            {
                                txtCActsIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                txtCActsChapterName.Text = dtActs.Rows[0]["ChapterName"].ToString();
                                edtCActsSections.Content = dtActs.Rows[0]["Sections"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("Rules"))
                            {
                                txtCRulesIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                txtSubRulesChapterName.Text = dtActs.Rows[0]["ChapterName"].ToString();
                                ddlCRulesIndexGroup.SelectedValue = dtActs.Rows[0]["Headings"].ToString();
                                edtSubRulesSections.Content = dtActs.Rows[0]["Sections"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("Forms"))
                            {
                                ddlCformsgroup.SelectedValue = dtActs.Rows[0]["Headings"].ToString();
                                ddlCformsgroup_SelectedIndexChanged(ddlCformsgroup, EventArgs.Empty);
                                ddlCformssubgroups.SelectedValue = dtActs.Rows[0]["SubHeadings"].ToString();
                                txtCFormsIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                txtFormsSubject.Text = dtActs.Rows[0]["Subjects"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("Regulations"))
                            {
                                txtCRegulationsIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("Case Laws"))
                            {
                                txtCDrawbackIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("Drawback Schedule"))
                            {
                                txtCDrawbackIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("SEZ"))
                            {
                                txtCSEZNotficationNo.Text = dtActs.Rows[0]["IndexName"].ToString();
                                txtCSEZSubject.Text = dtActs.Rows[0]["Subjects"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }

                        }
                        if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13"))
                        {
                            Custom_Tariff_GetAllTableAdapter indexTariff = new Custom_Tariff_GetAllTableAdapter();
                            DataTable dtTariff = indexTariff.SelectCustomTariffById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                ddlCtariffheading.SelectedValue = dtTariff.Rows[0]["Groups"].ToString();
                                ddlCtariffheading_SelectedIndexChanged(ddlCtariffheading, EventArgs.Empty);
                                ddlCtariffsubheading.SelectedValue = dtTariff.Rows[0]["SubGroup"].ToString();
                                txtCtariffchapter.Text = dtTariff.Rows[0]["IndexName"].ToString();
                                txtCtariffChaptername.Text = dtTariff.Rows[0]["ChapterName"].ToString();
                                txtCtariffsubj.Text = dtTariff.Rows[0]["Subjects"].ToString();
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                        if (ddlsubcategory.SelectedValue.Equals("Notifications"))
                        {
                            CECNotification_GetAllTableAdapter indexTariff = new CECNotification_GetAllTableAdapter();
                            DataTable dtTariff = indexTariff.SelectAllCENotificationById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                rdbCECType.SelectedValue = dtTariff.Rows[0]["GroupType"].ToString();
                                ddlCtariffheading_SelectedIndexChanged(ddlCtariffheading, EventArgs.Empty);
                                txtCECYear.Text = dtTariff.Rows[0]["Year"].ToString();
                                txtCECFnumber.Text = dtTariff.Rows[0]["FileNumber"].ToString();
                                txtCECDate.Text = dtTariff.Rows[0]["Date"].ToString();
                                txtCECSubject.Text = dtTariff.Rows[0]["Subject"].ToString();
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                        if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions"))
                        {
                            Circulars_Info_ByyearTableAdapter indexTariff = new Circulars_Info_ByyearTableAdapter();
                            DataTable dtTariff = indexTariff.GetCEcircularsById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                bool isCircular = dtTariff.Rows[0]["GroupType"].ToString().Equals("Circulars");
                                rdbCircularUploadType.SelectedValue = isCircular ? "Circulars" : "Instructions";
                                txtCircularYear.Text = dtTariff.Rows[0]["Year"].ToString();
                                txtCircularNumber.Text = dtTariff.Rows[0]["CircularNumber"].ToString();
                                txtCircularFileNumber.Text = dtTariff.Rows[0]["FileNumber"].ToString();
                                txtCircularDate.Text = dtTariff.Rows[0]["Date"].ToString();
                                txtCircularSubject.Text = dtTariff.Rows[0]["Subject"].ToString();
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                    }
                    if (ddlcatagory.SelectedValue.Equals("Service Tax"))
                    {
                        ServiceTax_GetAllTableAdapter index = new ServiceTax_GetAllTableAdapter();
                        DataTable dtActs = index.SelectAllSTById(id);
                        if (dtActs.Rows.Count > 0)
                        {
                            if (ddlsubcategory.SelectedValue.Equals("Act 1994") || ddlsubcategory.SelectedValue.Equals("ST Rules"))
                            {
                                txtCActsIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                txtCActsChapterName.Text = dtActs.Rows[0]["ChapterName"].ToString();
                                edtCActsSections.Content = dtActs.Rows[0]["Sections"].ToString();
                                edtCActsSections.Visible = false;
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("Forms and Registers"))
                            {
                                ddlCformsgroup.SelectedValue = dtActs.Rows[0]["Headings"].ToString();
                                ddlCformsgroup_SelectedIndexChanged(ddlCformsgroup, EventArgs.Empty);
                                ddlCformssubgroups.SelectedValue = dtActs.Rows[0]["SubHeadings"].ToString();
                                txtCFormsIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                txtFormsSubject.Text = dtActs.Rows[0]["Subjects"].ToString();
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                            if (ddlsubcategory.SelectedValue.Equals("Accounting Codes for new services"))
                            {
                                txtCActsIndex.Text = dtActs.Rows[0]["IndexName"].ToString();
                                txtCActsChapterName.Text = dtActs.Rows[0]["ChapterName"].ToString();
                                edtCActsSections.Content = dtActs.Rows[0]["Sections"].ToString();
                                edtCActsSections.Visible = false;
                                bool isdoc = dtActs.Rows[0]["Data"] != null && dtActs.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtActs.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                           
                           

                        }
                        if (ddlsubcategory.SelectedValue.Equals("Case Laws"))
                        {
                            STCaselaws_GetAllTableAdapter indexTariff = new STCaselaws_GetAllTableAdapter();
                            DataTable dtTariff = indexTariff.SelectSTCaseLawsById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                txtSTCaselaws.Text = dtTariff.Rows[0]["IndexName"].ToString();
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                        if (ddlsubcategory.SelectedValue.Equals("Notifications"))
                        {
                            STN_GetAllTableAdapter indexTariff = new STN_GetAllTableAdapter();
                            DataTable dtTariff = indexTariff.GetAllSTNById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                txtSTNYear.Text = dtTariff.Rows[0]["Year"].ToString();
                                txtSTNFNumber.Text = dtTariff.Rows[0]["FileNumber"].ToString();
                                txtSTNDate.Text = dtTariff.Rows[0]["Date"].ToString();
                                txtSTNSubject.Text = dtTariff.Rows[0]["Subject"].ToString();
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                        if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions"))
                        {
                            Circulars_Info_ByyearTableAdapter indexTariff = new Circulars_Info_ByyearTableAdapter();
                            DataTable dtTariff = indexTariff.GetCEcircularsById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                bool isCircular = dtTariff.Rows[0]["GroupType"].ToString().Equals("Circulars");
                                rdbCircularUploadType.SelectedValue = isCircular ? "Circulars" : "Instructions";
                                txtCircularYear.Text = dtTariff.Rows[0]["Year"].ToString();
                                txtCircularNumber.Text = dtTariff.Rows[0]["CircularNumber"].ToString();
                                txtCircularFileNumber.Text = dtTariff.Rows[0]["FileNumber"].ToString();
                                txtCircularDate.Text = dtTariff.Rows[0]["Date"].ToString();
                                txtCircularSubject.Text = dtTariff.Rows[0]["Subject"].ToString();
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                    }
                    if (ddlcatagory.SelectedValue.Equals("Income Tax"))
                    {
                        if (ddlsubcategory.SelectedValue.Equals("Acts"))
                        {
                            IncomeTaxActs_SelectAllTableAdapter indexTariff = new IncomeTaxActs_SelectAllTableAdapter();
                            DataTable dtTariff = indexTariff.GetITActsById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                ddlITActType.SelectedValue = dtTariff.Rows[0]["SubCategory"].ToString();
                                ddlITActType_SelectedIndexChanged(ddlITActType, EventArgs.Empty);
                                if (ddlITActType.SelectedValue.Equals("Income Tax Act") || ddlITActType.SelectedValue.Equals("Wealth Tax Act") || ddlITActType.SelectedValue.Equals("Expenditure Tax Act"))
                                {
                                    txtSectionNo.Text = dtTariff.Rows[0]["SectionNo"].ToString();
                                    txtSectionName.Text = dtTariff.Rows[0]["IndexName"].ToString();
                                }
                                else
                                {
                                    ddlGroup.SelectedValue = dtTariff.Rows[0]["Groups"].ToString();
                                    txtHeadings.Text = dtTariff.Rows[0]["IndexName"].ToString();
                                    
                                }
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                           
                        }
                        if (ddlsubcategory.SelectedValue.Equals("Rules"))
                        {
                            IncomeTaxRules_SelectAllTableAdapter indexTariff = new IncomeTaxRules_SelectAllTableAdapter();
                            DataTable dtTariff = indexTariff.GetITRulesById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                ddlITActType.SelectedValue = dtTariff.Rows[0]["SubCategory"].ToString();
                                ddlITActType_SelectedIndexChanged(ddlITActType, EventArgs.Empty);
                                if (ddlITActType.SelectedValue.Equals("Income Tax Rules"))
                                {
                                    txtSectionNo.Text = dtTariff.Rows[0]["SectionNo"].ToString();
                                    txtSectionName.Text = dtTariff.Rows[0]["IndexName"].ToString();
                                }
                                else
                                {                                    
                                    txtHeadings.Text = dtTariff.Rows[0]["IndexName"].ToString();
                                }
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                        if (ddlsubcategory.SelectedValue.Equals("Circulars") || ddlsubcategory.SelectedValue.Equals("Notifications"))
                        {
                            IncomeTaxCircularsNotification_SelectAllTableAdapter indexTariff = new IncomeTaxCircularsNotification_SelectAllTableAdapter();
                            DataTable dtTariff = indexTariff.GetITCNById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                txtITCircularNo.Text = dtTariff.Rows[0]["IndexName"].ToString();
                                txtITCircularDate.Text = dtTariff.Rows[0]["datetime1"].ToString();                              
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                        
                    }
                    if (ddlcatagory.SelectedValue.Equals("DGFT"))
                    {
                        if (ddlsubcategory.SelectedValue.Equals("FTP"))
                        {
                            DGFT_GetAllTableAdapter indexTariff = new DGFT_GetAllTableAdapter();
                            DataTable dtTariff = indexTariff.GetDGFTById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                txtDGFTFTPchaptername.Text = dtTariff.Rows[0]["ChapterName"].ToString();
                                txtpnlDGFTFTPindex.Text = dtTariff.Rows[0]["IndexName"].ToString();
                                txtDGFTFTPsubject.Text = dtTariff.Rows[0]["Sections"].ToString();
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }

                        }
                        if (ddlsubcategory.SelectedValue.Equals("FTDR Notifications"))
                        {
                            DGFT_GetAllTableAdapter indexTariff = new DGFT_GetAllTableAdapter();
                            DataTable dtTariff = indexTariff.GetDGFTById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                txtDGFTFTDRindex.Text = dtTariff.Rows[0]["IndexName"].ToString();                               
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }
                        if (ddlsubcategory.SelectedValue.Equals("public notices"))
                        {
                            DGFTpublicnotices_GETALLTableAdapter indexTariff = new DGFTpublicnotices_GETALLTableAdapter();
                            DataTable dtTariff = indexTariff.GetAllDgftPNById(id);
                            if (dtTariff.Rows.Count > 0)
                            {
                                txtDGFTpublicnoticeindex.Text = dtTariff.Rows[0]["IndexName"].ToString();
                                txtDGFTpublicnoticenum.Text = dtTariff.Rows[0]["NoticeNumber"].ToString();
                                txtDGFTpublicnoticedate.Text = dtTariff.Rows[0]["Date"].ToString();
                                txtDGFTpublicnoticesubject.Text = dtTariff.Rows[0]["Subject"].ToString();
                                bool isdoc = dtTariff.Rows[0]["Data"] != null && dtTariff.Rows[0]["Data"].ToString().Length > 0;
                                rdbUploadType.SelectedValue = isdoc ? "Paste the Document" : "Upload the Document";
                                rblUploadType_SelectedIndexChanged(rdbUploadType, EventArgs.Empty);
                                edtData.Content = dtTariff.Rows[0]["Data"].ToString();
                                lbshowDoc.Visible = !isdoc;
                            }
                        }

                    }
                }
            }

        }
        protected void lbshowDoc_Click(object sender, EventArgs e)
        {
            int? id = Int32.Parse(hdnId.Value);
            if (ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13"))
                {
                    CentralExcise_Tariff_GetAllTableAdapter indexTariff = new CentralExcise_Tariff_GetAllTableAdapter();
                    DataTable dataTariff = indexTariff.SelectAllById(id);
                    if (dataTariff.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dataTariff.Rows[0]["Document"]);
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
                else if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions"))
                {
                    Circulars_Info_ByyearTableAdapter index = new Circulars_Info_ByyearTableAdapter();
                    DataTable dtActs = index.GetCEcircularsById(id);
                    if (dtActs.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dtActs.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
                else
                {
                    CEActsTableAdapter index = new CEActsTableAdapter();
                    DataTable dtActs = index.CEGetAllById(id);
                    if (dtActs.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dtActs.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
            }
            if (ddlcatagory.SelectedValue.Equals("Customs"))
            {
                if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13"))
                {
                    Custom_Tariff_GetAllTableAdapter indexTariff = new Custom_Tariff_GetAllTableAdapter();
                    DataTable dataTariff = indexTariff.SelectCustomTariffById(id);
                    if (dataTariff.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dataTariff.Rows[0]["Document"]);
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
                else if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions"))
                {
                    Circulars_Info_ByyearTableAdapter index = new Circulars_Info_ByyearTableAdapter();
                    DataTable dtActs = index.GetCEcircularsById(id);
                    if (dtActs.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dtActs.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
                else
                {
                    ActsTableAdapter index = new ActsTableAdapter();
                    DataTable dtActs = index.GetAllCustomsById(id);
                    if (dtActs.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dtActs.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
            }
            if (ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                if (ddlsubcategory.SelectedValue.Equals("Case Laws"))
                {
                    STCaselaws_GetAllTableAdapter indexTariff = new STCaselaws_GetAllTableAdapter();
                    DataTable dataTariff = indexTariff.SelectSTCaseLawsById(id);
                    if (dataTariff.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dataTariff.Rows[0]["Document"]);
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
                else if (ddlsubcategory.SelectedValue.Equals("Notifications"))
                {
                    STN_GetAllTableAdapter index = new STN_GetAllTableAdapter();
                    DataTable dtActs = index.GetAllSTNById(id);
                    if (dtActs.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dtActs.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
                else if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions"))
                {
                    Circulars_Info_ByyearTableAdapter index = new Circulars_Info_ByyearTableAdapter();
                    DataTable dtActs = index.GetCEcircularsById(id);
                    if (dtActs.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dtActs.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
                else
                {
                    ServiceTax_GetAllTableAdapter index = new ServiceTax_GetAllTableAdapter();
                    DataTable dtActs = index.SelectAllSTById(id);
                    if (dtActs.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dtActs.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
            }
            if (ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                if (ddlsubcategory.SelectedValue.Equals("Acts"))
                {
                    IncomeTaxActs_SelectAllTableAdapter indexTariff = new IncomeTaxActs_SelectAllTableAdapter();
                    DataTable dataTariff = indexTariff.GetITActsById(id);
                    if (dataTariff.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dataTariff.Rows[0]["Document"]);
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
                else if (ddlsubcategory.SelectedValue.Equals("Rules"))
                {
                    IncomeTaxRules_SelectAllTableAdapter index = new IncomeTaxRules_SelectAllTableAdapter();
                    DataTable dtActs = index.GetITRulesById(id);
                    if (dtActs.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dtActs.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
                else 
                {
                    IncomeTaxCircularsNotification_SelectAllTableAdapter index = new IncomeTaxCircularsNotification_SelectAllTableAdapter();
                    DataTable dtActs = index.GetITCNById(id);
                    if (dtActs.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dtActs.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
            }
            if (ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                if (ddlsubcategory.SelectedValue.Equals("public notices"))
                {
                    DGFTpublicnotices_GETALLTableAdapter indexTariff = new DGFTpublicnotices_GETALLTableAdapter();
                    DataTable dataTariff = indexTariff.GetAllDgftPNById(id);
                    if (dataTariff.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dataTariff.Rows[0]["Document"]);
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
                else
                {
                    DGFT_GetAllTableAdapter index = new DGFT_GetAllTableAdapter();
                    DataTable dtActs = index.GetDGFTById(id);
                    if (dtActs.Rows.Count > 0)
                    {
                        byte[] b = ((byte[])dtActs.Rows[0]["Document"]);
                        //Collect Bytes from database and write in Webpage
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(b);
                    }
                }
            }

        }

        protected void ddlcatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lblsubcat.Text = ddlcatagory.SelectedValue;

            if (ddlcatagory.SelectedValue.Equals("Customs") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));
                ddlsubcategory.Items.Add("Acts");
                ddlsubcategory.Items.Add("Rules");
                ddlsubcategory.Items.Add("Regulations");
                ddlsubcategory.Items.Add("Tariff 2012-13");
                ddlsubcategory.Items.Add("Forms");
                ddlsubcategory.Items.Add("Notifications");
                ddlsubcategory.Items.Add("Circulars/Instructions");
                ddlsubcategory.Items.Add("Case Laws");
                ddlsubcategory.Items.Add("SEZ");
                ddlsubcategory.Items.Add("Drawback Schedule");
            }
            else if (ddlcatagory.SelectedValue.Equals("Central Excise") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));
                ddlsubcategory.Items.Add("Acts");
                ddlsubcategory.Items.Add("Rules");
                ddlsubcategory.Items.Add("Tariff 2012-13");
                ddlsubcategory.Items.Add("Forms");
                ddlsubcategory.Items.Add("Notifications");
                ddlsubcategory.Items.Add("Circulars/Instructions");
                ddlsubcategory.Items.Add("Case Laws");
                ddlsubcategory.Items.Add("Section 37B Order");
            }
            else if (ddlcatagory.SelectedValue.Equals("Service Tax") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));
                ddlsubcategory.Items.Add("Act 1994");
                ddlsubcategory.Items.Add("ST Rules");
                ddlsubcategory.Items.Add("Services");
                ddlsubcategory.Items.Add("Notifications");
                ddlsubcategory.Items.Add("Circulars/Instructions");
                ddlsubcategory.Items.Add("Case Laws");
                ddlsubcategory.Items.Add("Forms and Registers");
                ddlsubcategory.Items.Add("Accounting Codes for new services");

            }
            else if (ddlcatagory.SelectedValue.Equals("Income Tax") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));
                ddlsubcategory.Items.Add("Acts");
                ddlsubcategory.Items.Add("Rules");
                ddlsubcategory.Items.Add("Circulars");
                ddlsubcategory.Items.Add("Notifications");
            }
            else if (ddlcatagory.SelectedValue.Equals("Library") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));

            }
            else if (ddlcatagory.SelectedValue.Equals("DGFT") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));
                ddlsubcategory.Items.Add("FTP");
                ddlsubcategory.Items.Add("FTDR Notifications");
                ddlsubcategory.Items.Add("public notices");
                ddlsubcategory.Items.Add("Circulars/Instructions");
                ddlsubcategory.Items.Add("SION");

            }

            else if (ddlcatagory.SelectedValue.Equals("Services") && !ddlcatagory.SelectedValue.Equals("select one"))
            {
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Add(new ListItem("select one", "0"));
                ddlsubcategory.Items.Add("Consulting");
                ddlsubcategory.Items.Add("Book Keeping");
                ddlsubcategory.Items.Add("Filling Returns");
                ddlsubcategory.Items.Add("Forms and Registers");
                ddlsubcategory.Items.Add("FAQ");

            }
            else
            {
                Response.Write("<script>alert('Please select categeory')</script>");
            }
        }

        protected void ddlCformsgroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCformssubgroups.Items.Clear();
            if (ddlCformsgroup.SelectedValue.Equals("Application Forms") && !ddlCformsgroup.SelectedValue.Equals("select one"))
            {
                ddlCformssubgroups.Items.Add(new ListItem("select one", "0"));
                ddlCformssubgroups.Items.Add("Refunds");
                ddlCformssubgroups.Items.Add("Appeals");
                ddlCformssubgroups.Items.Add("Drawback");
                ddlCformssubgroups.Items.Add("Others");
            }
        }

        protected void ddlsubcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Customs
            if (ddlsubcategory.SelectedValue.Equals("Acts") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                pnlCActs.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Rules") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                pnlCRules.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlSubRules.Visible = false;
                pnlCActs.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;

                ddlCRulesIndexGroup.Items.Clear();
                ddlCRulesIndexGroup.Items.Add(new ListItem("select one", "0"));
                ddlCRulesIndexGroup.Items.Add("Agreements between nations");
                ddlCRulesIndexGroup.Items.Add("Baggage Rules, 1998");
                ddlCRulesIndexGroup.Items.Add("Customs Drawback Rules");
                ddlCRulesIndexGroup.Items.Add("Customs Valuation Rules");
                ddlCRulesIndexGroup.Items.Add("Others");
            }
            if (ddlsubcategory.SelectedValue.Equals("Regulations") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                pnlCRegulations.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCActs.Visible = false;
                pnlCRules.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                pnlCTariff.Visible = true;
                rdbUploadType.Visible = true;
                ddlCtariffSchemes.Visible = true;
                lblCtariffSchemes.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCActs.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                pnlDGFTFTDR.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Forms") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                pnlCForms.Visible = true;
                rdbUploadType.Visible = true;
                lblCformsgroup.Visible = true;
                ddlCformsgroup.Visible = true;
                lblCformssubgroup.Visible = true;
                ddlCformssubgroups.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCActs.Visible = false;
                pnlCRules.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                pnlDGFTFTDR.Visible = false;
                rdbUploadType.ClearSelection();
                lblFormsSubject.Visible = false;
                txtFormsSubject.Visible = false;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Case Laws") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                pnlCDrawback.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCActs.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCirculars.Visible = false;
                pnlDGFTFTDR.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("SEZ") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                pnlCSEZ.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCActs.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                pnlDGFTFTDR.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Drawback Schedule") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                pnlCDrawback.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCActs.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
            }
            #endregion

            #region CentralExcise
            if (ddlsubcategory.SelectedValue.Equals("Acts") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                pnlCActs.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Rules") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                pnlCRules.Visible = true;
                rdbUploadType.Visible = true;
                pnlSubRules.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCActs.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
                ddlCRulesIndexGroup.Items.Clear();
                ddlCRulesIndexGroup.Items.Add(new ListItem("select one", "0"));
                ddlCRulesIndexGroup.Items.Add("Central Excise Rules");
                ddlCRulesIndexGroup.Items.Add("Rescinded or Superseded Rules");
            }
            if (ddlsubcategory.SelectedValue.Equals("Tariff 2012-13") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                pnlCTariff.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                ddlCtariffSchemes.Visible = false;
                lblCtariffSchemes.Visible = false;
                pnlCActs.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
                btnUpload.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Forms") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                pnlCForms.Visible = true;
                rdbUploadType.Visible = true;
                lblFormsSubject.Visible = true;
                txtFormsSubject.Visible = true;

                pnlSTCaselaws.Visible = false;
                lblCformsgroup.Visible = false;
                ddlCformsgroup.Visible = false;
                lblCformssubgroup.Visible = false;
                ddlCformssubgroups.Visible = false;
                pnlCActs.Visible = false;
                pnlCRules.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Case Laws") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                pnlCDrawback.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCActs.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Section 37B Order") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                pnlCDrawback.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCActs.Visible = false;
                pnlCRules.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCirculars.Visible = false;
                pnlDGFTFTP.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                lblUploadDoc.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
            }
            #endregion

            #region ServiceTax

            if (ddlsubcategory.SelectedValue.Equals("Act 1994") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                pnlCActs.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;

                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCirculars.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlDGFTFTP.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("ST Rules") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                pnlCActs.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlDGFTFTP.Visible = false;

                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                pnlDGFTFTDR.Visible = false;
                lblUploadDoc.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Forms & Registers") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {

                pnlCForms.Visible = true;
                rdbUploadType.Visible = true;
                lblFormsSubject.Visible = true;
                txtFormsSubject.Visible = true;
                pnlDGFTFTP.Visible = false;
                pnlSTCaselaws.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                lblCformsgroup.Visible = false;
                ddlCformsgroup.Visible = false;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                lblCformssubgroup.Visible = false;
                ddlCformssubgroups.Visible = false;
                pnlCActs.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
                rdbUploadType.ClearSelection();

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Accounting Codes for new services") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                pnlCActs.Visible = true;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCTariff.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;
                rdbUploadType.ClearSelection();

                uploadDocument.Visible = false;
                pnlDGFTFTDR.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
            }
            if (ddlsubcategory.SelectedValue.Equals("Case Laws") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                pnlSTCaselaws.Visible = true;
                rdbUploadType.Visible = true;

                pnlCActs.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                rdbUploadType.ClearSelection();
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

                uploadDocument.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
            }

            #endregion

            #region Circulars/Insructions
            if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions") & !ddlcatagory.SelectedValue.Equals("select one"))
            {
                pnlCirculars.Visible = true;
                if (ddlcatagory.SelectedValue == "DGFT")
                {
                    lblCircularFileName.Visible = false;
                    txtCircularFileNumber.Visible = false;
                }
                else
                {
                    lblCircularFileName.Visible = true;
                    txtCircularFileNumber.Visible = true;
                }
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCActs.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCDrawback.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCSEZ.Visible = false;
                rdbCircularUploadType.ClearSelection();
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
                uploadDocument.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;
            }
            #endregion

            #region Populate DropDownList for Tariffs
            if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "Tariff 2012-13")
            {
                ddlCtariffheading.Items.Clear();
                ddlCtariffheading.Items.Add(new ListItem("select one", "0"));
                ddlCtariffheading.Items.Add("General Notes");
                ddlCtariffheading.Items.Add("Import Tariff");
                ddlCtariffheading.Items.Add("General Exemptions");
                ddlCtariffheading.Items.Add("The Second Schedule Export Tariff");
                ddlCtariffheading.Items.Add("Anti Dumping Duty Notifications");
                ddlCtariffheading.Items.Add("Appendix");
            }
            if (ddlcatagory.SelectedValue == "Central Excise" & ddlsubcategory.SelectedValue == "Tariff 2012-13")
            {
                ddlCtariffheading.Items.Clear();
                ddlCtariffheading.Items.Add(new ListItem("select one", "0"));
                ddlCtariffheading.Items.Add("General Excise Act");
                ddlCtariffheading.Items.Add("Central Excise Tariff Act, 1985 and Exemption Notifications");
                ddlCtariffheading.Items.Add("General Exemptions");
                ddlCtariffheading.Items.Add("Appendix");
            }
            #endregion

            #region DGFT

            if (ddlsubcategory.SelectedValue.Equals("FTP") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                pnlCActs.Visible = false;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();
                pnlDGFTFTDR.Visible = false;
                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTP.Visible = true;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

            }
            if (ddlsubcategory.SelectedValue.Equals("FTDR Notifications") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                pnlCRules.Visible = false;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlSubRules.Visible = false;
                pnlCActs.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                lblUploadDoc.Visible = false;
                pnlDGFTFTP.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTDR.Visible = true;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

            }

            if (ddlsubcategory.SelectedValue.Equals("SION") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                //do
            }



            #endregion

            #region DGFTpublicnotices

            if (ddlsubcategory.SelectedValue.Equals("public notices") && ddlcatagory.SelectedValue.Equals("DGFT"))
            {
                pnlCRegulations.Visible = false;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCActs.Visible = false;
                pnlCRules.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTFTDR.Visible = false;
                rdbUploadType.ClearSelection();

                uploadDocument.Visible = false;
                pnlDGFTpublicnotices.Visible = true;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;
            }

            #endregion

            #region CEandCustomsNotifications
            if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Central Excise"))
            {
                pnlCActs.Visible = false;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCECnotifications.Visible = true;
                pnlStNotifications.Visible = false;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;

            } if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Customs"))
            {
                pnlCActs.Visible = false;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCECnotifications.Visible = true;
                pnlStNotifications.Visible = false;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;
            }
            #endregion

            #region STNotifications
            if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Service Tax"))
            {
                pnlCActs.Visible = false;
                rdbUploadType.Visible = true;

                pnlSTCaselaws.Visible = false;

                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlCirculars.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlDGFTFTP.Visible = false;
                rdbUploadType.ClearSelection();

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = true;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;
            }
            #endregion

            #region Income Tax
            if (ddlsubcategory.SelectedValue.Equals("Acts") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                pnlITType.Visible = true;
                lblITType.Text = "Act Type";

                ddlITActType.Items.Clear();
                ddlITActType.Items.Add(new ListItem("select one", "0"));
                ddlITActType.Items.Add("Income Tax Act");
                ddlITActType.Items.Add("Wealth Tax Act");
                ddlITActType.Items.Add("Expenditure Tax Act");
                ddlITActType.Items.Add("Finance Act");


                pnlCActs.Visible = false;
                rdbUploadType.Visible = false;
                pnlSTCaselaws.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;
            }

            if (ddlsubcategory.SelectedValue.Equals("Rules") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                pnlITType.Visible = true;
                lblITType.Text = "Rule Type";

                ddlITActType.Items.Clear();
                ddlITActType.Items.Add(new ListItem("select one", "0"));
                ddlITActType.Items.Add("Income Tax Rules");
                ddlITActType.Items.Add("Other Direct Tax Rules");


                pnlCActs.Visible = false;
                rdbUploadType.Visible = false;
                pnlSTCaselaws.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;

                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITCirculars.Visible = false;
            }

            if (ddlsubcategory.SelectedValue.Equals("Circulars") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                pnlITCirculars.Visible = true;
                lblITCircularNo.Text = "Circular No";
                rdbUploadType.Visible = true;

                pnlITType.Visible = false;
                pnlCActs.Visible = false;
                pnlSTCaselaws.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;

            }

            if (ddlsubcategory.SelectedValue.Equals("Notifications") && ddlcatagory.SelectedValue.Equals("Income Tax"))
            {
                pnlITCirculars.Visible = true;
                lblITCircularNo.Text = "Notification No";
                rdbUploadType.Visible = true;

                pnlITType.Visible = false;
                pnlCActs.Visible = false;
                pnlSTCaselaws.Visible = false;
                pnlCRules.Visible = false;
                pnlCRegulations.Visible = false;
                pnlCTariff.Visible = false;
                pnlCForms.Visible = false;
                pnlCSEZ.Visible = false;
                pnlCDrawback.Visible = false;
                pnlCirculars.Visible = false;
                rdbUploadType.ClearSelection();

                uploadDocument.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = false;
                edtData.Visible = false;
                btnUpload.Visible = false;
                pnlDGFTFTDR.Visible = false;
                pnlDGFTFTP.Visible = false;
                pnlDGFTpublicnotices.Visible = false;
                pnlCECnotifications.Visible = false;
                pnlStNotifications.Visible = false;
                pnlITType.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = false;

            }
            #endregion
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            #region Customs
            if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "Acts")
            {
                CustomActs();
            }
            if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "Rules")
            {
                CustomRules();
            }
            if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "Regulations")
            {
                CustomRegulations();
            }
            if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "Tariff 2012-13")
            {
                CustomTariff();
            }
            if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "Forms")
            {
                CustomForms();
            }
            if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "Case Laws")
            {
                CustomDrawbackSchedule();
            }
            if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "SEZ")
            {
                CustomSez();
            }
            if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "Drawback Schedule")
            {
                CustomDrawbackSchedule();
            }
             if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "Notifications")
            {
               CustomNotifications();
            }
            #endregion

            #region Central Excise
            if (ddlcatagory.SelectedValue == "Central Excise" & ddlsubcategory.SelectedValue == "Acts")
            {
                CEActs();
            }
            if (ddlcatagory.SelectedValue == "Central Excise" & ddlsubcategory.SelectedValue == "Rules")
            {
                CERules();
            }
            if (ddlcatagory.SelectedValue == "Central Excise" & ddlsubcategory.SelectedValue == "Tariff 2012-13")
            {
                CETariff();
            }
            if (ddlcatagory.SelectedValue == "Central Excise" & ddlsubcategory.SelectedValue == "Forms")
            {
                CEForms();
            }
            if (ddlcatagory.SelectedValue == "Central Excise" & ddlsubcategory.SelectedValue == "Case Laws")
            {
                CESections();
            }
            if (ddlcatagory.SelectedValue == "Central Excise" & ddlsubcategory.SelectedValue == "Section 37B Order")
            {
                CESections();
            } if (ddlcatagory.SelectedValue == "Central Excise" & ddlsubcategory.SelectedValue == "Notifications")
            {
                CENotifications();
            }
            #endregion

            #region ServiceTax
            if (ddlcatagory.SelectedValue == "Service Tax" & ddlsubcategory.SelectedValue == "Act 1994")
            {
                STActs();
            }
            if (ddlcatagory.SelectedValue == "Service Tax" & ddlsubcategory.SelectedValue == "ST Rules")
            {
                STRules();
            }
            if (ddlcatagory.SelectedValue == "Service Tax" & ddlsubcategory.SelectedValue == "Tariff 2012-13")
            {
                //do
            }
            if (ddlcatagory.SelectedValue == "Service Tax" & ddlsubcategory.SelectedValue == "Forms & Registers")
            {
                STForms();
            }
            if (ddlcatagory.SelectedValue == "Service Tax" & ddlsubcategory.SelectedValue == "Accounting Codes for new services")
            {
                STAccountCodes();
            }
            if (ddlcatagory.SelectedValue == "Service Tax" & ddlsubcategory.SelectedValue == "Section 37B Order")
            {
                CESections();
            }
            if (ddlcatagory.SelectedValue == "Service Tax" & ddlsubcategory.SelectedValue == "Case Laws")
            {
                STCaseLaws();
            }
            if (ddlcatagory.SelectedValue == "Service Tax" & ddlsubcategory.SelectedValue == "Notifications")
            {
                STNotifications();
            }
            #endregion

            #region Circulars/Instructions
            if (ddlsubcategory.SelectedValue.Equals("Circulars/Instructions") & !ddlcatagory.SelectedValue.Equals("select one"))
            {
                CircularsInstructions();
            }
            #endregion

            #region DGFT
            if (ddlcatagory.SelectedValue == "DGFT" & ddlsubcategory.SelectedValue == "FTP")
            {
                DGFTFTP();
            }
            if (ddlcatagory.SelectedValue == "DGFT" & ddlsubcategory.SelectedValue == "FTDR Notifications")
            {
                DGFTFTDR();
            }

            if (ddlcatagory.SelectedValue == "DGFT" & ddlsubcategory.SelectedValue == "SION")
            {
                //do
            }

            #endregion

            #region DGFTpublicnotices
            if (ddlcatagory.SelectedValue == "DGFT" & ddlsubcategory.SelectedValue == "public notices")
            {
                DGFTpublicnotices();
            }

            #endregion

            #region Income Tax

            if (ddlcatagory.SelectedValue == "Income Tax" & (ddlITActType.SelectedValue == "Income Tax Act" || ddlITActType.SelectedValue == "Wealth Tax Act" || ddlITActType.SelectedValue == "Expenditure Tax Act"))
            {
                ITIncomeWealthExpenditureActs();
            }
            if (ddlcatagory.SelectedValue == "Income Tax" & ddlITActType.SelectedValue == "Finance Act")
            {
                ITFinanceActs();
            }
            if (ddlcatagory.SelectedValue == "Income Tax" & ddlITActType.SelectedValue == "Income Tax Rules")
            {
                ITIncomeTaxRules();
            }
            if (ddlcatagory.SelectedValue == "Income Tax" & ddlITActType.SelectedValue == "Other Direct Tax Rules")
            {
                ITDirectTaxRules();
            }

            if (ddlcatagory.SelectedValue == "Income Tax" & (ddlsubcategory.SelectedValue == "Circulars" || ddlsubcategory.SelectedValue == "Notifications"))
            {
                ITCircularsNotifications();
            }
            #endregion

            ClearControls();
        }

        #region CustomMethods

        public void CustomActs()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            Custom_GetAllTableAdapter insertActs = new Custom_GetAllTableAdapter();
            ActsTableAdapter UpdateActs = new ActsTableAdapter();
             if (hdnId.Value.Length > 0)
             {
                 int? id = Int32.Parse(hdnId.Value);
                 if (bytes != null && bytes.Length > 1)
                 {
                     UpdateActs.UpdateCustomsById(ddlsubcategory.SelectedValue, txtCActsIndex.Text.Trim(),null,null, txtCActsChapterName.Text,null, edtCActsSections.Content, edtData.Content, bytes,id);
                 }
                 else
                 {
                     UpdateActs.UpdateCustomsByIdNoDoc(ddlsubcategory.SelectedValue, txtCActsIndex.Text.Trim(), null, null, txtCActsChapterName.Text, null, edtCActsSections.Content, edtData.Content,id);
                 }
                 Server.Transfer("editnotifications.aspx");
             }
             else
             {
                 insertActs.Insert(ddlsubcategory.SelectedValue, txtCActsIndex.Text.Trim(), txtCActsChapterName.Text, edtCActsSections.Content, edtData.Content, bytes);
             }
        }

        public void CustomRules()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            Custom_GetAllTableAdapter insertRules = new Custom_GetAllTableAdapter();
             ActsTableAdapter UpdateActs = new ActsTableAdapter();
             if (hdnId.Value.Length > 0)
             {
                 int? id = Int32.Parse(hdnId.Value);
                 if (bytes != null && bytes.Length > 1)
                 {
                     UpdateActs.UpdateCustomsById(ddlsubcategory.SelectedValue, txtCRulesIndex.Text, ddlCRulesIndexGroup.SelectedValue, null, txtSubRulesChapterName.Text, null, null, edtData.Content, bytes, id);
                 }
                 else
                 {
                     UpdateActs.UpdateCustomsByIdNoDoc(ddlsubcategory.SelectedValue, txtCRulesIndex.Text, ddlCRulesIndexGroup.SelectedValue, null, txtSubRulesChapterName.Text, null, null, edtData.Content, id);
                 }
                 Server.Transfer("editnotifications.aspx");
             }
             else
             {
                 insertRules.CustomRules_Insert(ddlsubcategory.SelectedValue, ddlCRulesIndexGroup.SelectedValue, txtCRulesIndex.Text, edtData.Content, bytes);
             }
        }

        public void CustomRegulations()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            Custom_GetAllTableAdapter insertRegulations = new Custom_GetAllTableAdapter();
             ActsTableAdapter UpdateActs = new ActsTableAdapter();
             if (hdnId.Value.Length > 0)
             {
                 int? id = Int32.Parse(hdnId.Value);
                 if (bytes != null && bytes.Length > 1)
                 {
                     UpdateActs.UpdateCustomsById(ddlsubcategory.SelectedValue, txtCRegulationsIndex.Text, null, null, null, null, null, edtData.Content, bytes, id);
                 }
                 else
                 {
                     UpdateActs.UpdateCustomsByIdNoDoc(ddlsubcategory.SelectedValue, txtCRegulationsIndex.Text, null, null, null, null, null, edtData.Content, id);
                 }
                 Server.Transfer("editnotifications.aspx");
             }
             else
             {
                 insertRegulations.CustomRegulations_Insert(ddlsubcategory.SelectedValue, txtCRegulationsIndex.Text, edtData.Content, bytes);
             }
        }

        public void CustomTariff()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            Custom_Tariff_GetAllTableAdapter insertTariff = new Custom_Tariff_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertTariff.UpdateAllCtariffById(ddlCtariffheading.SelectedValue, ddlCtariffsubheading.SelectedValue, ddlCtariffSchemes.Text, txtCtariffchapter.Text, txtCtariffsubj.Text, edtData.Content, bytes, txtCtariffChaptername.Text,id);
                }
                else
                {
                    insertTariff.UpdateAllCtariffByIdNoDoc(ddlCtariffheading.SelectedValue, ddlCtariffsubheading.SelectedValue, ddlCtariffSchemes.Text, txtCtariffsubj.Text, txtCtariffchapter.Text, edtData.Content, txtCtariffChaptername.Text, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertTariff.Insert(ddlCtariffheading.SelectedValue, ddlCtariffsubheading.SelectedValue, ddlCtariffSchemes.Text, txtCtariffchapter.Text, txtCtariffsubj.Text, edtData.Content, bytes, txtCtariffChaptername.Text);
            }
        }

        public void CustomForms()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            Custom_GetAllTableAdapter insertForms = new Custom_GetAllTableAdapter();
            ActsTableAdapter UpdateActs = new ActsTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    UpdateActs.UpdateCustomsById(ddlsubcategory.SelectedValue, txtCFormsIndex.Text, ddlCformsgroup.SelectedValue, ddlCformssubgroups.SelectedValue, null, null, null, edtData.Content, bytes, id);
                }
                else
                {
                    UpdateActs.UpdateCustomsByIdNoDoc(ddlsubcategory.SelectedValue, txtCFormsIndex.Text, ddlCformsgroup.SelectedValue, ddlCformssubgroups.SelectedValue, null, null, null, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertForms.CutomForms_Insert(ddlsubcategory.SelectedValue, ddlCformsgroup.SelectedValue, ddlCformssubgroups.SelectedValue, txtCFormsIndex.Text, edtData.Content, bytes);
            }

        }

        public void CustomSez()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            Custom_GetAllTableAdapter insertSez = new Custom_GetAllTableAdapter();
              ActsTableAdapter UpdateActs = new ActsTableAdapter();
              if (hdnId.Value.Length > 0)
              {
                  int? id = Int32.Parse(hdnId.Value);
                  if (bytes != null && bytes.Length > 1)
                  {
                      UpdateActs.UpdateCustomsById(ddlsubcategory.SelectedValue, txtCSEZNotficationNo.Text, null, null, null, txtCSEZSubject.Text, null, edtData.Content, bytes, id);
                  }
                  else
                  {
                      UpdateActs.UpdateCustomsByIdNoDoc(ddlsubcategory.SelectedValue, txtCSEZNotficationNo.Text, null, null, null, txtCSEZSubject.Text, null, edtData.Content, id);
                  }
                  Server.Transfer("editnotifications.aspx");
              }
              else
              {
                  insertSez.CustomSEZ_Insert(ddlsubcategory.SelectedValue, txtCSEZNotficationNo.Text, txtCSEZSubject.Text, edtData.Content, bytes);
              }

        }

        public void CustomDrawbackSchedule()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            Custom_GetAllTableAdapter insertDrawbackSchedule = new Custom_GetAllTableAdapter();
             ActsTableAdapter UpdateActs = new ActsTableAdapter();
             if (hdnId.Value.Length > 0)
             {
                 int? id = Int32.Parse(hdnId.Value);
                 if (bytes != null && bytes.Length > 1)
                 {
                     UpdateActs.UpdateCustomsById(ddlsubcategory.SelectedValue, txtCDrawbackIndex.Text, null, null, null, null, null, edtData.Content, bytes, id);
                 }
                 else
                 {
                     UpdateActs.UpdateCustomsByIdNoDoc(ddlsubcategory.SelectedValue, txtCDrawbackIndex.Text, null, null, null, null, null, edtData.Content, id);
                 }
                 Server.Transfer("editnotifications.aspx");
             }
             else
             {
                 insertDrawbackSchedule.CustomDrawback_Insert(ddlsubcategory.SelectedValue, txtCDrawbackIndex.Text, edtData.Content, bytes);
             }

        }

        public void CustomNotifications()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            CECNotification_GetAllTableAdapter insertNotifications = new CECNotification_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertNotifications.UpdateAllCENotifications(ddlcatagory.SelectedValue, rdbCECType.SelectedValue, txtCECYear.Text, txtCECFnumber.Text, txtCECDate.Text, txtCECSubject.Text, edtData.Content, bytes, id);
                }
                else
                {
                    insertNotifications.UpdateCENotificationsNoDoc(ddlcatagory.SelectedValue, rdbCECType.SelectedValue, txtCECYear.Text, txtCECFnumber.Text, txtCECDate.Text, txtCECSubject.Text, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertNotifications.CEC_notification_Insert(ddlcatagory.SelectedValue, rdbCECType.SelectedValue, txtCECYear.Text, txtCECFnumber.Text, txtCECDate.Text, txtCECSubject.Text, edtData.Content, bytes);
            }

        }

        #endregion

        #region CentralExciseMethods

        public void CEActs()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            CE_GetAllTableAdapter insertActs = new CE_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertActs.CEUpdateAll(ddlsubcategory.SelectedValue, txtCActsIndex.Text, txtCActsChapterName.Text, edtCActsSections.Content, null, null, edtData.Content, bytes, id);
                }
                else
                {
                    insertActs.CEUpdateNoDoc(ddlsubcategory.SelectedValue, txtCActsIndex.Text, txtCActsChapterName.Text, edtCActsSections.Content, null, null, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertActs.CEActs_Insert(ddlsubcategory.SelectedValue, txtCActsIndex.Text, txtCActsChapterName.Text, edtCActsSections.Content, edtData.Content, bytes);
            }
        }

        public void CERules()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            CE_GetAllTableAdapter insertRules = new CE_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertRules.CEUpdateAll(ddlsubcategory.SelectedValue, txtCRulesIndex.Text, txtSubRulesChapterName.Text, edtSubRulesSections.Content, ddlCRulesIndexGroup.SelectedValue, null, edtData.Content, bytes, id);
                }
                else
                {
                    insertRules.CEUpdateNoDoc(ddlsubcategory.SelectedValue, txtCRulesIndex.Text, txtSubRulesChapterName.Text, edtSubRulesSections.Content, ddlCRulesIndexGroup.SelectedValue, null, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertRules.CERules_Insert(ddlsubcategory.SelectedValue, txtCRulesIndex.Text, txtSubRulesChapterName.Text, edtSubRulesSections.Content, edtData.Content, bytes, ddlCRulesIndexGroup.SelectedValue);
            }
        }

        public void CEForms()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            CE_GetAllTableAdapter insertTariff = new CE_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertTariff.CEUpdateAll(ddlsubcategory.SelectedValue, txtCFormsIndex.Text, null, null, null, txtFormsSubject.Text, edtData.Content, bytes, id);
                }
                else
                {
                    insertTariff.CEUpdateNoDoc(ddlsubcategory.SelectedValue, txtCFormsIndex.Text, null, null, null, txtFormsSubject.Text, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertTariff.CEForms_Insert(ddlsubcategory.SelectedValue, txtCFormsIndex.Text, edtData.Content, bytes, txtFormsSubject.Text);
            }
        }

        public void CESections()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            CE_GetAllTableAdapter insertTariff = new CE_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertTariff.CEUpdateAll(ddlsubcategory.SelectedValue, txtCDrawbackIndex.Text, null, null, null, null, edtData.Content, bytes, id);
                }
                else
                {
                    insertTariff.CEUpdateNoDoc(ddlsubcategory.SelectedValue, txtCDrawbackIndex.Text, null, null, null, null, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertTariff.CESection_Insert(ddlsubcategory.SelectedValue, txtCDrawbackIndex.Text, edtData.Content, bytes);
            }
        }

        public void CETariff()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            CentralExcise_Tariff_GetAllTableAdapter insertTariff = new CentralExcise_Tariff_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertTariff.UpdateAllCEtariffById(ddlCtariffheading.SelectedValue, ddlCtariffsubheading.SelectedValue, txtCtariffchapter.Text, txtCtariffsubj.Text,edtData.Content, bytes,txtCtariffChaptername.Text, id);
                }
                else
                {
                    insertTariff.UpdateAllCEtariffByIdNoDoc(ddlCtariffheading.SelectedValue, ddlCtariffsubheading.SelectedValue, txtCtariffchapter.Text, txtCtariffsubj.Text,edtData.Content,txtCtariffChaptername.Text, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertTariff.Insert(ddlCtariffheading.SelectedValue, ddlCtariffsubheading.SelectedValue, txtCtariffchapter.Text, txtCtariffsubj.Text, edtData.Content, bytes, txtCtariffChaptername.Text);
            }
        }

        public void CENotifications()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            CECNotification_GetAllTableAdapter insertNotifications = new CECNotification_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertNotifications.UpdateAllCENotifications(ddlcatagory.SelectedValue, rdbCECType.SelectedValue, txtCECYear.Text, txtCECFnumber.Text, txtCECDate.Text, txtCECSubject.Text, edtData.Content, bytes, id);
                }
                else
                {
                    insertNotifications.UpdateCENotificationsNoDoc(ddlcatagory.SelectedValue, rdbCECType.SelectedValue, txtCECYear.Text, txtCECFnumber.Text, txtCECDate.Text, txtCECSubject.Text, edtData.Content,id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertNotifications.CEC_notification_Insert(ddlcatagory.SelectedValue, rdbCECType.SelectedValue, txtCECYear.Text, txtCECFnumber.Text, txtCECDate.Text, txtCECSubject.Text, edtData.Content, bytes);
            }
        }


        #endregion

        #region ServiceTaxMethods

        public void STActs()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }

            ServiceTax_GetAllTableAdapter insertActs = new ServiceTax_GetAllTableAdapter();
             if (hdnId.Value.Length > 0)
             {
                 int? id = Int32.Parse(hdnId.Value);
                 if (bytes != null && bytes.Length > 1)
                 {
                     insertActs.UpdateSTById(ddlsubcategory.SelectedValue, txtCActsIndex.Text, null, null, null, null, null, edtData.Content, bytes, id);
                 }
                 else
                 {
                     insertActs.UpdateSTByIdNoDoc(ddlsubcategory.SelectedValue, txtCActsIndex.Text, null, null, null, null, null, edtData.Content, id);
                 }
                 Server.Transfer("editnotifications.aspx");
             }
             else
             {
                 insertActs.STAct_Insert(ddlsubcategory.SelectedValue, txtCActsIndex.Text, edtData.Content, bytes);
             }

        }

        public void STRules()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }

            ServiceTax_GetAllTableAdapter insertRules = new ServiceTax_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertRules.UpdateSTById(ddlsubcategory.SelectedValue, txtCActsIndex.Text, null, null, null, null, null, edtData.Content, bytes, id);
                }
                else
                {
                    insertRules.UpdateSTByIdNoDoc(ddlsubcategory.SelectedValue, txtCActsIndex.Text, null, null, null, null, null, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertRules.STRules_Insert(ddlsubcategory.SelectedValue, txtCActsIndex.Text, edtData.Content, bytes);
            }

        }

        public void STForms()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }

            ServiceTax_GetAllTableAdapter insertForms = new ServiceTax_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertForms.UpdateSTById(ddlsubcategory.SelectedValue, txtCFormsIndex.Text, null, null, null, txtFormsSubject.Text, null, edtData.Content, bytes, id);
                }
                else
                {
                    insertForms.UpdateSTByIdNoDoc(ddlsubcategory.SelectedValue, txtCFormsIndex.Text, null, null, null, txtFormsSubject.Text, null, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertForms.STForms_Insert(ddlsubcategory.SelectedValue, txtCFormsIndex.Text, txtFormsSubject.Text, edtData.Content, bytes);
            }

        }

        public void STAccountCodes()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }

            ServiceTax_GetAllTableAdapter insertAccountCodes = new ServiceTax_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertAccountCodes.UpdateSTById(ddlsubcategory.SelectedValue, txtCActsIndex.Text, null, null, null, null, null, edtData.Content, bytes, id);
                }
                else
                {
                    insertAccountCodes.UpdateSTByIdNoDoc(ddlsubcategory.SelectedValue, txtCActsIndex.Text, null, null, null, null, null, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertAccountCodes.STAccountCodes_Insert(ddlsubcategory.SelectedValue, txtCActsIndex.Text, edtData.Content, bytes);
            }

        }

        public void STNotifications()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }

            STN_GetAllTableAdapter insertSTN = new STN_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertSTN.UpdateSTNById(ddlsubcategory.SelectedValue, txtSTNYear.Text, txtSTNFNumber.Text, txtSTNDate.Text, txtSTNSubject.Text, edtData.Content, bytes,id);
                }
                else
                {
                    insertSTN.UpdateSTNByIdNoDoc(ddlsubcategory.SelectedValue, txtSTNYear.Text, txtSTNFNumber.Text, txtSTNDate.Text, txtSTNSubject.Text, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertSTN.STN_Insert(ddlsubcategory.SelectedValue, txtSTNYear.Text, txtSTNFNumber.Text, txtSTNDate.Text, txtSTNSubject.Text, edtData.Content, bytes);
            }


        }

        #endregion

        #region Circulars/InsructionMethods

        public void CircularsInstructions()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            try
            {
                Circulars_InsertTableAdapter insertCirculars = new Circulars_InsertTableAdapter();
                Circulars_Info_ByyearTableAdapter updateCirculars = new Circulars_Info_ByyearTableAdapter();
                if (hdnId.Value.Length > 0)
                {
                    int? id = Int32.Parse(hdnId.Value);
                    if (bytes != null && bytes.Length > 1)
                    {
                        updateCirculars.UpdateCEcircularById(ddlcatagory.SelectedValue, rdbCircularUploadType.SelectedValue, txtCircularYear.Text, txtCircularNumber.Text, txtCircularDate.Text, txtCircularFileNumber.Text, txtCircularSubject.Text, edtData.Content, bytes,id);
                    }
                    else
                    {
                        updateCirculars.UpdateCEcircularByIdNoDoc(ddlcatagory.SelectedValue, rdbCircularUploadType.SelectedValue, txtCircularYear.Text, txtCircularNumber.Text, txtCircularDate.Text, txtCircularFileNumber.Text, txtCircularSubject.Text, edtData.Content,id);
                    }
                    Server.Transfer("editnotifications.aspx");
                }
                else
                {
                    insertCirculars.Circulars_Insert(ddlcatagory.SelectedValue, rdbCircularUploadType.SelectedValue, txtCircularYear.Text, txtCircularNumber.Text, txtCircularDate.Text, txtCircularFileNumber.Text, txtCircularSubject.Text, edtData.Content, bytes);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region STCaseLawsMethods
        public void STCaseLaws()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            STCaselaws_GetAllTableAdapter insertCaseLaws = new STCaselaws_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertCaseLaws.UpdateSTCaseLawsById(txtSTCaselaws.Text,edtData.Content, bytes, id);
                }
                else
                {
                    insertCaseLaws.UpdateSTCaseLawsByIdNoDoc(txtSTCaselaws.Text, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertCaseLaws.STCaseLaws_Insert(txtSTCaselaws.Text, edtData.Content, bytes);
            }
        }


        #endregion

        #region DGFTMethods

        public void DGFTFTP()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            DGFT_GetAll1TableAdapter insertDGFTFTDR = new DGFT_GetAll1TableAdapter();
            DGFT_GetAllTableAdapter insertActs = new DGFT_GetAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertActs.UpdateDGFTById(ddlsubcategory.SelectedValue, txtpnlDGFTFTPindex.Text, txtDGFTFTPchaptername.Text, txtDGFTFTPsubject.Text, edtData.Content, bytes, id);
                }
                else
                {
                    insertActs.UpdateDGFTByIdNoDoc(ddlsubcategory.SelectedValue, txtpnlDGFTFTPindex.Text, txtDGFTFTPchaptername.Text, txtDGFTFTPsubject.Text, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertDGFTFTDR.Insert(ddlsubcategory.SelectedValue, txtpnlDGFTFTPindex.Text, txtDGFTFTPchaptername.Text, txtDGFTFTPsubject.Text, edtData.Content, bytes);
            }
        }
        public void DGFTFTDR()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
             DGFT_GetAll2TableAdapter insertDGFTFTDR = new DGFT_GetAll2TableAdapter();
              DGFT_GetAllTableAdapter insertActs = new DGFT_GetAllTableAdapter();
              if (hdnId.Value.Length > 0)
              {
                  int? id = Int32.Parse(hdnId.Value);
                  if (bytes != null && bytes.Length > 1)
                  {
                      insertActs.UpdateDGFTById(ddlsubcategory.SelectedValue, txtDGFTFTDRindex.Text,null,null, edtData.Content, bytes, id);
                  }
                  else
                  {
                      insertActs.UpdateDGFTByIdNoDoc(ddlsubcategory.SelectedValue, txtDGFTFTDRindex.Text,null,null, edtData.Content, id);
                  }
                  Server.Transfer("editnotifications.aspx");
              }
              else
              {
                  insertDGFTFTDR.Insert(ddlsubcategory.SelectedValue, txtDGFTFTDRindex.Text, edtData.Content, bytes);
              }


        }

        public void DGFTpublicnotices()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            DGFTpublicnotices_GETALLTableAdapter insertDGFTpublicnotices = new DGFTpublicnotices_GETALLTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertDGFTpublicnotices.UpdateDgftPNById(ddlsubcategory.SelectedValue, txtDGFTpublicnoticeindex.Text, txtDGFTpublicnoticenum.Text, txtDGFTpublicnoticesubject.Text, txtDGFTpublicnoticedate.Text, edtData.Content, bytes, id);
                }
                else
                {
                    insertDGFTpublicnotices.UpdateDgftPNByIdNoDoc(ddlsubcategory.SelectedValue, txtDGFTpublicnoticeindex.Text, txtDGFTpublicnoticenum.Text, txtDGFTpublicnoticesubject.Text, txtDGFTpublicnoticedate.Text, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertDGFTpublicnotices.Insert(ddlsubcategory.SelectedValue, txtDGFTpublicnoticeindex.Text, txtDGFTpublicnoticenum.Text, txtDGFTpublicnoticesubject.Text, txtDGFTpublicnoticedate.Text, edtData.Content, bytes);
            }


        }
        #endregion

        #region Income Tax
        public void ITIncomeWealthExpenditureActs()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            IncomeTaxActs_SelectAllTableAdapter insertActs = new IncomeTaxActs_SelectAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertActs.UpdateITActsById(ddlITActType.SelectedValue, txtSectionName.Text, txtSectionNo.Text, null, bytes, edtData.Content, id);
                }
                else
                {
                    insertActs.UpdateITActsByIdNoDoc(ddlITActType.SelectedValue, txtSectionName.Text, txtSectionNo.Text, null, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertActs.Insert(ddlITActType.SelectedValue, txtSectionName.Text, txtSectionNo.Text, null, edtData.Content, bytes);
            }
        }

        public void ITFinanceActs()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            IncomeTaxActs_SelectAllTableAdapter insertActs = new IncomeTaxActs_SelectAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertActs.UpdateITActsById(ddlITActType.SelectedValue, txtHeadings.Text, null, ddlGroup.SelectedValue, bytes, edtData.Content, id);
                }
                else
                {
                    insertActs.UpdateITActsByIdNoDoc(ddlITActType.SelectedValue, txtHeadings.Text, null, ddlGroup.SelectedValue, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertActs.Insert(ddlITActType.SelectedValue, txtHeadings.Text, null, ddlGroup.SelectedValue, edtData.Content, bytes);
            }
        }

        public void ITIncomeTaxRules()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            IncomeTaxRules_SelectAllTableAdapter insertActs = new IncomeTaxRules_SelectAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertActs.UpdateITRulesById(ddlITActType.SelectedValue, txtSectionName.Text, txtSectionNo.Text, edtData.Content, bytes, id);
                }
                else
                {
                    insertActs.UpdateITRulesByIdNoDoc(ddlITActType.SelectedValue, txtSectionName.Text, txtSectionNo.Text, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertActs.Insert(ddlITActType.SelectedValue, txtSectionName.Text, txtSectionNo.Text, edtData.Content, bytes);
            }
        }

        public void ITDirectTaxRules()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            IncomeTaxRules_SelectAllTableAdapter insertActs = new IncomeTaxRules_SelectAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertActs.UpdateITRulesById(ddlITActType.SelectedValue, txtHeadings.Text, null, edtData.Content, bytes, id);
                }
                else
                {
                    insertActs.UpdateITRulesByIdNoDoc(ddlITActType.SelectedValue, txtHeadings.Text, null, edtData.Content, id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertActs.Insert(ddlITActType.SelectedValue, txtHeadings.Text, null, edtData.Content, bytes);
            }
        }

        public void ITCircularsNotifications()
        {
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                UploadPDF();
            }
            IncomeTaxCircularsNotification_SelectAllTableAdapter insertActs = new IncomeTaxCircularsNotification_SelectAllTableAdapter();
            if (hdnId.Value.Length > 0)
            {
                int? id = Int32.Parse(hdnId.Value);
                if (bytes != null && bytes.Length > 1)
                {
                    insertActs.UpdateITCNById(ddlsubcategory.SelectedValue, txtITCircularNo.Text, edtData.Content, bytes, txtITCircularDate.Text,id);
                }
                else
                {
                    insertActs.UpdateITCNByIdNoDoc(ddlsubcategory.SelectedValue, txtITCircularNo.Text, edtData.Content, txtITCircularDate.Text,id);
                }
                Server.Transfer("editnotifications.aspx");
            }
            else
            {
                insertActs.Insert(ddlsubcategory.SelectedValue, txtITCircularNo.Text, edtData.Content, bytes, txtITCircularDate.Text);
            }
        }

        #endregion

        protected void rblUploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbUploadType.SelectedValue == "Paste the Document")
            {
                edtData.Visible = true;
                uploadDocument.Visible = false;
                lblPasteHere.Visible = true;
                lblUploadDoc.Visible = false;
                btnUpload.Visible = true;
            }
            if (rdbUploadType.SelectedValue == "Upload the Document")
            {
                uploadDocument.Visible = true;
                edtData.Visible = false;
                lblPasteHere.Visible = false;
                lblUploadDoc.Visible = true;
                btnUpload.Visible = true;
            }
        }

        protected void rdbCircularUploadType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbCircularUploadType.SelectedValue == "Circulars")
            {
                lblCircularNumber.Visible = true;
                txtCircularNumber.Visible = true;

            }
            if (rdbCircularUploadType.SelectedValue == "Instructions")
            {
                lblCircularNumber.Visible = false;
                txtCircularNumber.Visible = false;
            }
        }

        public void UploadPDF()
        {

            string filePath = uploadDocument.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;
            //Set the contenttype based on File Extension
            switch (ext.ToLower())
            {
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
            }
            if (contenttype != String.Empty)
            {

                Stream fs = uploadDocument.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                bytes = br.ReadBytes((Int32)fs.Length);
            }
            else
            {
                //   lblMsg.Visible = true;
                // lblMsg.ForeColor = System.Drawing.Color.Red;
                //lblMsg.Text = "File format not recognized." +
                //" Upload Image/Word/PDF formats.";
                rdbUploadType.ClearSelection();
            }
        }

        public void ClearControls()
        {
            txtCActsIndex.Text = string.Empty;
            edtCActsSections.Content = string.Empty;
            txtCActsChapterName.Text = string.Empty;
            ddlCRulesIndexGroup.ClearSelection();
            txtCRulesIndex.Text = string.Empty;
            txtCRegulationsIndex.Text = string.Empty;
            ddlCformsgroup.ClearSelection();
            ddlCformssubgroups.ClearSelection();
            txtCFormsIndex.Text = string.Empty;
            txtCSEZNotficationNo.Text = string.Empty;
            txtCSEZSubject.Text = string.Empty;
            txtCDrawbackIndex.Text = string.Empty;
            txtCircularYear.Text = string.Empty;
            txtCircularNumber.Text = string.Empty;
            txtCircularDate.Text = string.Empty;
            txtCircularFileNumber.Text = string.Empty;
            txtCircularSubject.Text = string.Empty;
            ddlCtariffheading.ClearSelection();
            ddlCtariffsubheading.Items.Clear();
            ddlCtariffSchemes.Items.Clear();
            txtCtariffChaptername.Text = string.Empty;
            txtCtariffchapter.Text = string.Empty;
            txtCtariffsubj.Text = string.Empty;
            edtData.Content = string.Empty;
            txtSTCaselaws.Text = string.Empty;
            txtSTCaselaws.Text = string.Empty;
            ddlITActType.ClearSelection();
            txtSTCaselaws.Text = string.Empty;
            txtSectionName.Text = string.Empty;
            ddlGroup.ClearSelection();
            txtITCircularNo.Text = string.Empty;
            txtITCircularDate.Text = string.Empty;
            txtHeadings.Text = string.Empty;
            txtSectionNo.Text = string.Empty;

        }

        protected void ddlCtariffheading_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "Tariff 2012-13")
            {
                if (ddlCtariffheading.SelectedValue.Equals("General Exemptions"))
                {
                    ddlCtariffsubheading.Items.Clear();
                    ddlCtariffSchemes.Items.Clear();
                    ddlCtariffsubheading.Items.Add(new ListItem("select one", "0"));
                    ddlCtariffsubheading.Items.Add("Import of goods under various export promotion schemes");
                    ddlCtariffsubheading.Items.Add("Imports from preferential and/or developing areas and specified countries");
                    ddlCtariffsubheading.Items.Add("Import of goods at concessional rate of duty for manufacture of excisable goods");
                    ddlCtariffsubheading.Items.Add("Imports by privileged persons, u.n.o. And its agencies");
                    ddlCtariffsubheading.Items.Add("Imports for educational, training, research and for handicapped persons");
                    ddlCtariffsubheading.Items.Add("Donations & gifts");
                    ddlCtariffsubheading.Items.Add("Sports goods, prizes, medals and trophies etc");
                    ddlCtariffsubheading.Items.Add("Exemption notifications relating to re-import");
                    ddlCtariffsubheading.Items.Add("Imports for oil exploration, national programmes, exhibitions, seminars, expeditions");
                    ddlCtariffsubheading.Items.Add("Baggage and personal importation by passengers and tourists ");
                    ddlCtariffsubheading.Items.Add("Durable containers and freight on such containers from port to icds");
                    ddlCtariffsubheading.Items.Add("Miscellaneous");
                }
                else
                {
                    ddlCtariffsubheading.Items.Clear();
                    ddlCtariffSchemes.Items.Clear();
                }
            }
            if (ddlcatagory.SelectedValue == "Central Excise" & ddlsubcategory.SelectedValue == "Tariff 2012-13")
            {
                if (ddlCtariffheading.SelectedValue.Equals("Central Excise Tariff Act, 1985 and Exemption Notifications"))
                {
                    ddlCtariffsubheading.Items.Clear();
                    ddlCtariffSchemes.Items.Clear();
                    ddlCtariffsubheading.Items.Add(new ListItem("select one", "0"));
                    ddlCtariffsubheading.Items.Add("Live animals; animal products");
                    ddlCtariffsubheading.Items.Add("Vegetable products");
                    ddlCtariffsubheading.Items.Add("Animal or vegetable fats and oils ");
                    ddlCtariffsubheading.Items.Add("Foodstuffs; beverages and vinegar; tobacco");
                    ddlCtariffsubheading.Items.Add("Mineral products");
                    ddlCtariffsubheading.Items.Add("Products of the chemical or allied industries");
                    ddlCtariffsubheading.Items.Add("Plastics, rubber and articles");
                    ddlCtariffsubheading.Items.Add("Raw hides, skins, leather, furskins, saddlery etc.");
                    ddlCtariffsubheading.Items.Add("Wood charcoal, cork, basketware and wickerwork");
                    ddlCtariffsubheading.Items.Add("Pulp of wood or of other fibrouscellulosic material etc");
                    ddlCtariffsubheading.Items.Add("Textiles and textile articles");
                    ddlCtariffsubheading.Items.Add("Footwear, headgear, umbrellas, walkingsticks, seat-sticks etc");
                    ddlCtariffsubheading.Items.Add("Articles of stone, plaster and cement etc");
                    ddlCtariffsubheading.Items.Add("Natural or cultured pearls, precious or semi-precious stones etc");
                    ddlCtariffsubheading.Items.Add("Base metals and articles of base metal");
                    ddlCtariffsubheading.Items.Add("Machinery and mechanical appliances, elec-trical equipments etc");
                    ddlCtariffsubheading.Items.Add("Vehicles, aircraft, vessels and associated transport equipment");
                    ddlCtariffsubheading.Items.Add("Optical, photographic, cinematographic, measuring, checking etc");
                    ddlCtariffsubheading.Items.Add("Arms and ammunition, parts and accessories");
                    ddlCtariffsubheading.Items.Add("Miscellaneous manufactured articles");
                    ddlCtariffsubheading.Items.Add("Works of art, collectors’ pieces and antiques");
                }
                else if (ddlCtariffheading.SelectedValue.Equals("General Exemptions"))
                {
                    ddlCtariffsubheading.Items.Clear();
                    ddlCtariffSchemes.Items.Clear();
                    ddlCtariffsubheading.Items.Add(new ListItem("select one", "0"));
                    ddlCtariffsubheading.Items.Add("value based exemption notifications for small scale");
                    ddlCtariffsubheading.Items.Add("Central excise exemption notifications under various export promotion schemes");
                    ddlCtariffsubheading.Items.Add("Exemption notifications relating to goods manufactured in specified areas");
                    ddlCtariffsubheading.Items.Add("Job work notifications");
                    ddlCtariffsubheading.Items.Add("Goods captively consumed");
                    ddlCtariffsubheading.Items.Add("Goods manufactured in govt. Factories and supplied to defence");
                    ddlCtariffsubheading.Items.Add("Technical, educational and research institutes");
                    ddlCtariffsubheading.Items.Add("Goods produced without use of power and for units in rural areas");
                    ddlCtariffsubheading.Items.Add("Certain goods and industries");
                    ddlCtariffsubheading.Items.Add("Notifications prescribing effective rates of duty on the goods of various chapters");
                    ddlCtariffsubheading.Items.Add("Certain goods for rehabilitation work");
                    ddlCtariffsubheading.Items.Add("Certain goods when cleared against a served from india scheme certificate");
                    ddlCtariffsubheading.Items.Add("Miscellaneous");
                }
                else
                {
                    ddlCtariffsubheading.Items.Clear();
                    ddlCtariffSchemes.Items.Clear();
                }
            }
        }

        protected void ddlCtariffsubheading_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcatagory.SelectedValue == "Customs" & ddlsubcategory.SelectedValue == "Tariff 2012-13")
            {
                if (ddlCtariffsubheading.SelectedValue.Equals("Import of goods under various export promotion schemes"))
                {
                    ddlCtariffSchemes.Items.Clear();
                    ddlCtariffSchemes.Items.Add(new ListItem("select one", "0"));
                    ddlCtariffSchemes.Items.Add("Advance licencing scheme/(DEEC) scheme");
                    ddlCtariffSchemes.Items.Add("Advance customs clearance permits");
                    ddlCtariffSchemes.Items.Add("Annual advance licence");
                    ddlCtariffSchemes.Items.Add("Advance licences for deemed exports");
                    ddlCtariffSchemes.Items.Add("Special imprest licence/release orders");
                    ddlCtariffSchemes.Items.Add("DEPB scheme");
                    ddlCtariffSchemes.Items.Add("DFRC scheme");
                    ddlCtariffSchemes.Items.Add("DFIA scheme");
                    ddlCtariffSchemes.Items.Add("Focus Market scheme");
                    ddlCtariffSchemes.Items.Add("Focus Product scheme");
                    ddlCtariffSchemes.Items.Add("Target Plus scheme");
                    ddlCtariffSchemes.Items.Add("EPCG scheme");
                    ddlCtariffSchemes.Items.Add("100% EOU, FTZ, STP AND EHTP Schemes");
                    ddlCtariffSchemes.Items.Add("Special Economic Zones");
                    ddlCtariffSchemes.Items.Add("Duty credit entitlement certificate scheme");
                    ddlCtariffSchemes.Items.Add("Served from India scheme");
                    ddlCtariffSchemes.Items.Add("Replenishment imprest licences");
                    ddlCtariffSchemes.Items.Add("Passbook scheme of EXIM policy 1992-1997");
                    ddlCtariffSchemes.Items.Add("Export order for jobbing");
                    ddlCtariffSchemes.Items.Add("Samples for executing or securing export order");
                    ddlCtariffSchemes.Items.Add("Target Plus scheme");
                }
                else
                {
                    ddlCtariffSchemes.Items.Clear();
                }
            }
            //if (ddlcatagory.SelectedValue == "Central Excise" & ddlsubcategory.SelectedValue == "Tariff 2012-13")
            //{
            //    if (ddlCtariffsubheading.SelectedValue.Equals("General Exemptions"))
            //    {
            //        ddlCtariffSchemes.Items.Clear();
            //        ddlCtariffSchemes.Items.Add(new ListItem("select one", "0"));
            //        ddlCtariffSchemes.Items.Add("value based exemption notifications for small scale");
            //        ddlCtariffSchemes.Items.Add("Central excise exemption notifications under various export promotion schemes");
            //        ddlCtariffSchemes.Items.Add("Exemption notifications relating to goods manufactured in specified areas");
            //        ddlCtariffSchemes.Items.Add("Job work notifications");
            //        ddlCtariffSchemes.Items.Add("Goods captively consumed");
            //        ddlCtariffSchemes.Items.Add("Goods manufactured in govt. Factories and supplied to defence");
            //        ddlCtariffSchemes.Items.Add("Technical, educational and research institutes");
            //        ddlCtariffSchemes.Items.Add("Goods produced without use of power and for units in rural areas");
            //        ddlCtariffSchemes.Items.Add("Certain goods and industries");
            //        ddlCtariffSchemes.Items.Add("Notifications prescribing effective rates of duty on the goods of various chapters");
            //        ddlCtariffSchemes.Items.Add("Certain goods for rehabilitation work");
            //        ddlCtariffSchemes.Items.Add("Certain goods when cleared against a served from india scheme certificate");
            //        ddlCtariffSchemes.Items.Add("Miscellaneous");
            //    }
            //    else
            //    {
            //        ddlCtariffSchemes.Items.Clear();
            //    }
            //}
        }

        protected void ddlITActType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlITActType.SelectedValue.Equals("Income Tax Act") || ddlITActType.SelectedValue.Equals("Wealth Tax Act") || ddlITActType.SelectedValue.Equals("Expenditure Tax Act"))
            {
                pnlITIncomeWealthAct.Visible = true;
                pnpITFinanceAct.Visible = false;
                rdbUploadType.Visible = true;
            }

            if (ddlITActType.SelectedValue.Equals("Finance Act"))
            {
                ddlGroup.Visible = true;
                lblGroup.Visible = true;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = true;
                rdbUploadType.Visible = true;
            }

            if (ddlITActType.SelectedValue.Equals("Income Tax Rules"))
            {
                pnlITIncomeWealthAct.Visible = true;
                pnpITFinanceAct.Visible = false;
                rdbUploadType.Visible = true;
            }

            if (ddlITActType.SelectedValue.Equals("Other Direct Tax Rules"))
            {
                ddlGroup.Visible = false;
                lblGroup.Visible = false;
                pnlITIncomeWealthAct.Visible = false;
                pnpITFinanceAct.Visible = true;
                rdbUploadType.Visible = true;
            }
        }
    }
}
