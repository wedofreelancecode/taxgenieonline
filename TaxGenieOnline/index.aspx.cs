using System;
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
using TaxGenieOnline.Helpers;
using TaxGenie_DAL.IncomeTaxTableAdapters;
using TaxGenie_DAL.CECNotificationsTableAdapters;
using TaxGenie_DAL.STNotificationsTableAdapters;

namespace TaxGenieOnline
{
    public partial class index : System.Web.UI.Page
    {
        string category, subcategory;
        string[] group;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["subcat"] == "Circulars/Instructions")
            {
                category = Request.QueryString["cat"].Replace("/", " ");
                subcategory = Request.QueryString["subcat"];
            }
            else
            {
                category = Request.QueryString["cat"].Replace("/", " ");
                subcategory = Request.QueryString["subcat"].Replace("/", " ");
            }

            #region Circulars/Instructions
            if (subcategory == "Circulars/Instructions" & category != "")
            {
                group = subcategory.Split('/');

                if (group[0].Equals("Circulars"))
                {
                    Circulars_Index_selectTableAdapter circularIndex = new Circulars_Index_selectTableAdapter();
                    DataTable dtcircularsIndex = circularIndex.Circulars_Index(category);
                    if (dtcircularsIndex.Rows.Count > 0)
                    {
                        dlIndexCirculars.DataSource = dtcircularsIndex;
                        dlIndexCirculars.DataBind();
                    }

                    if (group[1].Equals("Instructions"))
                    {
                        Instructors_Index_selectTableAdapter instructorsIndex = new Instructors_Index_selectTableAdapter();
                        DataTable dtinstructorsIndex = instructorsIndex.Instructors_Index(category);
                        if (dtinstructorsIndex.Rows.Count > 0)
                        {
                            dlIndexInstrcutions.DataSource = dtinstructorsIndex;
                            dlIndexInstrcutions.DataBind();
                        }
                    }
                }
                InvisibleRuleLabels();
                InvisibleFormLabels();
                dlIndex.Visible = true;
                //invisible rules
                dlAgreements.Visible = false;
                dlBaggage.Visible = false;
                dlCustomDrawBack.Visible = false;
                dlCustomValuation.Visible = false;
                dlOthers.Visible = false;
                //invisible forms
                dlRefunds.Visible = false;
                dlAppeals.Visible = false;
                dlDrawback.Visible = false;
                dlOthersApplicationForms.Visible = false;
                dlShipping.Visible = false;
                dllBill.Visible = false;
                dlBonds.Visible = false;
                dlSettlementCommission.Visible = false;
                dlSTCaseLaws.Visible = false;
                dlDGFT.Visible = false;

                //invisible SEZ
                gvSEZ.Visible = false;
                //invisible ServiceTax
                gvservicetaxforms.Visible = false;
                gvstacts.Visible = false;
                gvstrules.Visible = false;
                dtstaccodes.Visible = false;
                dlITActs.Visible = false;
                pnlITActsGift.Visible = false;
                pnlITActsInterest.Visible = false;
                dlantidumpingduty.Visible = false;
                pnlSION.Visible = false;
                //visible Circular/Instruction Headings
                if (category == "DGFT")
                {
                    lblInstructionHeading.Visible = false;

                }
                else
                {
                    lblInstructionHeading.Visible = true;
                }

                lblCircularHeading.Visible = true;

                pnlSTlibraries.Visible = false;
                pnlSTTaxation.Visible = false;
                pnlCEManual.Visible = false;
                dltariff.Visible = false;
                dlnontariff.Visible = false;
                dlsafeguards.Visible = false;
                dlCECothers.Visible = false;
                dlSTN.Visible = false;


            }
            #endregion
            else
            {
                if (category == "Customs")
                {
                    #region CustomsIndex

                    if (category == "Customs" & subcategory == "Rules")
                    {
                        VisibleRuleLabels();
                        InvisibleFormLabels();
                        dlIndex.Visible = false;
                        //visible rules
                        dlAgreements.Visible = true;
                        dlBaggage.Visible = true;
                        dlCustomDrawBack.Visible = true;
                        dlCustomValuation.Visible = true;
                        dlOthers.Visible = true;
                        //invisible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlDGFT.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;
                        //invisible ServiceTax
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        pnlSION.Visible = false;
                        lblAgreements.Text = "Agreements between nations";
                        lblBaggage.Text = "Baggage Rules, 1998";


                        ActsTableAdapter indexByHeadings = new ActsTableAdapter();
                        DataTable dtAgreements = indexByHeadings.GetIndexbyRulesHeadings(subcategory, "Agreements between nations");
                        dlAgreements.DataSource = dtAgreements;
                        dlAgreements.DataBind();

                        DataTable dtBaggage = indexByHeadings.GetIndexbyRulesHeadings(subcategory, "Baggage Rules, 1998");
                        dlBaggage.DataSource = dtBaggage;
                        dlBaggage.DataBind();

                        DataTable dtCustomDrawBack = indexByHeadings.GetIndexbyRulesHeadings(subcategory, "Customs Drawback Rules");
                        dlCustomDrawBack.DataSource = dtCustomDrawBack;
                        dlCustomDrawBack.DataBind();

                        DataTable dtCustomValuation = indexByHeadings.GetIndexbyRulesHeadings(subcategory, "Customs Valuation Rules");
                        dlCustomValuation.DataSource = dtCustomValuation;
                        dlCustomValuation.DataBind();

                        DataTable dtOthers = indexByHeadings.GetIndexbyRulesHeadings(subcategory, "Others");
                        dlOthers.DataSource = dtOthers;
                        dlOthers.DataBind();
                    }
                    else if (category == "Customs" & subcategory == "Forms")
                    {
                        InvisibleRuleLabels();
                        VisibleFormLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = true;
                        dlAppeals.Visible = true;
                        dlDrawback.Visible = true;
                        dlOthersApplicationForms.Visible = true;
                        dlShipping.Visible = true;
                        dllBill.Visible = true;
                        dlBonds.Visible = true;
                        dlDGFT.Visible = false;
                        dlSettlementCommission.Visible = true;
                        dlSTCaseLaws.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        pnlSION.Visible = false;
                        ActsTableAdapter indexByHeadings = new ActsTableAdapter();

                        DataTable dtRefunds = indexByHeadings.GetIndexbyFormsHeadings(subcategory, "Application Forms", "Refunds");
                        dlRefunds.DataSource = dtRefunds;
                        dlRefunds.DataBind();

                        DataTable dtAppeals = indexByHeadings.GetIndexbyFormsHeadings(subcategory, "Application Forms", "Appeals");
                        dlAppeals.DataSource = dtAppeals;
                        dlAppeals.DataBind();

                        DataTable dtDrawback = indexByHeadings.GetIndexbyFormsHeadings(subcategory, "Application Forms", "Drawback");
                        dlDrawback.DataSource = dtDrawback;
                        dlDrawback.DataBind();

                        DataTable dtOthersApplicationForms = indexByHeadings.GetIndexbyFormsHeadings(subcategory, "Application Forms", "Others");
                        dlOthersApplicationForms.DataSource = dtOthersApplicationForms;
                        dlOthersApplicationForms.DataBind();

                        DataTable dtShipping = indexByHeadings.GetIndexbyFormsHeadings(subcategory, "Shipping Bill Forms", "");
                        dlShipping.DataSource = dtShipping;
                        dlShipping.DataBind();

                        DataTable dtBill = indexByHeadings.GetIndexbyFormsHeadings(subcategory, "Bill of Entry Forms", "");
                        dllBill.DataSource = dtBill;
                        dllBill.DataBind();

                        DataTable dtBonds = indexByHeadings.GetIndexbyFormsHeadings(subcategory, "Bonds", "");
                        dlBonds.DataSource = dtBonds;
                        dlBonds.DataBind();

                        DataTable dtSettlementCommission = indexByHeadings.GetIndexbyFormsHeadings(subcategory, "Settlement Commission", "");
                        dlSettlementCommission.DataSource = dtSettlementCommission;
                        dlSettlementCommission.DataBind();
                    }
                    else if (category == "Customs" & subcategory == "SEZ")
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        //invisible all
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlDGFT.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //visible SEZ
                        gvSEZ.Visible = true;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        pnlSION.Visible = false;
                        ActsTableAdapter index = new ActsTableAdapter();
                        DataTable dtSEZ = index.SEZ_Index(subcategory);
                        gvSEZ.DataSource = dtSEZ;
                        gvSEZ.DataBind();
                    }
                    else if (category == "Customs" & subcategory == "Tariff 2012-13")
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        //invisible all
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        dlDGFT.Visible = false;
                        //visible SEZ
                        gvSEZ.Visible = true;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlCEManual.Visible = false;
                        pnlSTTaxation.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        pnlSION.Visible = false;
                        DataTable dtGroups = new DataTable();
                        DataRow row = null;

                        DataColumn dcRelationShip = new DataColumn("Group");
                        dcRelationShip.DataType = System.Type.GetType("System.String");
                        dtGroups.Columns.Add(dcRelationShip);
                        row = dtGroups.NewRow();
                        row["Group"] = "General Notes";
                        dtGroups.Rows.Add(row);
                        row = dtGroups.NewRow();
                        row["Group"] = "Import Tariff";
                        dtGroups.Rows.Add(row);
                        row = dtGroups.NewRow();
                        row["Group"] = "General Exemptions";
                        dtGroups.Rows.Add(row);
                        row = dtGroups.NewRow();
                        row["Group"] = "The Second Schedule Export Tariff";
                        dtGroups.Rows.Add(row);
                        row = dtGroups.NewRow();
                        row["Group"] = "Anti Dumping Duty Notifications";
                        dtGroups.Rows.Add(row);
                        row = dtGroups.NewRow();
                        row["Group"] = "Appendix";
                        dtGroups.Rows.Add(row);
                        string redirect = string.Empty;
                        Custom_Tariff_IndexnameTableAdapter index = new Custom_Tariff_IndexnameTableAdapter();

                        ltlIndex.Text = "<table>";
                        foreach (DataRow drGroups in dtGroups.Rows)
                        {
                            string groupName = drGroups[0].ToString();
                            DataTable dtIndex = index.Custom_Tariff_IndexbyGroup(groupName);


                            if (dtIndex.Rows.Count > 0)
                            {
                                string name = string.Empty;
                                string _indexName = string.Empty;
                                foreach (DataRow drIndex in dtIndex.Rows)
                                {
                                    bool isDoc = false;
                                    string indexname = drIndex["indexname"].ToString();
                                    DataTable dtChapterbyIndex = index.GetCustomTariffByIndex(indexname);
                                    if (dtChapterbyIndex.Rows.Count > 0)
                                    {
                                        string aChapter = Convert.ToString(dtChapterbyIndex.Rows[0]["chaptername"]);
                                        if (aChapter.Equals(""))
                                        {
                                            string adata = Convert.ToString(dtChapterbyIndex.Rows[0]["data"]);
                                            isDoc = adata.Equals("");
                                            redirect = "shownotifications.aspx";
                                        }
                                        else
                                        {
                                            redirect = "displayindex.aspx";
                                        }
                                    }


                                    string chapatername = drIndex["chaptername"].ToString();
                                    if (name != groupName)
                                    {
                                        ltlIndex.Text += "<tr><td colspan='2' align='center' style='background-color:#D9D9D9;font-size:1.4em;'>";
                                        ltlIndex.Text += "<b>" + groupName + "</b></td></tr>";
                                    }
                                    ltlIndex.Text += "<tr><td width='200' valign='top'>";
                                    if (_indexName != indexname)
                                    {
                                        ltlIndex.Text += "<br/><a href='" + redirect + "?cat=" + category + "&subcat=" + subcategory + "&name=" + drIndex["indexname"].ToString() + (isDoc ? "' target='_blank'" : string.Empty) + "'>" + drIndex["indexname"].ToString() + "</a>";
                                    }

                                    if (chapatername == "")
                                    {
                                        ltlIndex.Text += "</td><td><br/>" + drIndex["subjects"].ToString() + "<br/></td></tr>";
                                    }
                                    name = groupName;
                                    _indexName = indexname;
                                }
                            }
                        }
                        ltlIndex.Text += "</table>";
                    }

                    else if (category == "Customs" & subcategory == "Notifications")
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        dlIndex.Visible = true;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;
                        dlDGFT.Visible = false;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = true;
                        dlnontariff.Visible = true;
                        dlsafeguards.Visible = true;
                        dlCECothers.Visible = true;
                        dlSTN.Visible = false;
                        pnlSION.Visible = false;
                        CECNotifications();


                    }

                    else
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        dlIndex.Visible = true;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;
                        dlDGFT.Visible = false;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        pnlSION.Visible = false;
                        ActsTableAdapter actsIndexName = new ActsTableAdapter();
                        DataTable dtActsIndexName = actsIndexName.Index_Select(subcategory);
                        if (dtActsIndexName.Rows.Count > 0)
                        {
                            dlIndex.DataSource = dtActsIndexName;
                            dlIndex.DataBind();
                        }
                    }
                    #endregion
                }
                if (category == "Central Excise")
                {
                    #region CentralExciseIndex
                    if (category == "Central Excise" & subcategory == "Rules")
                    {
                        VisibleRuleLabels();
                        InvisibleFormLabels();
                        dlIndex.Visible = false;
                        //visible rules
                        dlAgreements.Visible = true;
                        dlBaggage.Visible = true;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDGFT.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        pnlCEManual.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;

                        lblAgreements.Text = "Central Excise Rules";
                        lblBaggage.Text = string.Empty;
                        lblCustomDrawBack.Visible = false;
                        lblCustomValuation.Visible = false;
                        lblOthers.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;
                        CEActsTableAdapter indexByHeadings = new CEActsTableAdapter();
                        DataTable dtAgreements = indexByHeadings.IndexByHeadings(subcategory, "Central Excise Rules");
                        dlAgreements.DataSource = dtAgreements;
                        dlAgreements.DataBind();

                        DataTable dtBaggage = indexByHeadings.IndexByHeadings(subcategory, "Rescinded or Superseded Rules");
                        dlBaggage.DataSource = dtBaggage;
                        dlBaggage.DataBind();
                    }
                    else if (category == "Central Excise" & subcategory == "Forms")
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        //invisible all
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlDGFT.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //visible SEZ
                        gvSEZ.Visible = true;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        pnlSION.Visible = false;
                        CEActsTableAdapter index = new CEActsTableAdapter();
                        DataTable dtForms = index.CEForms(subcategory);
                        gvSEZ.DataSource = dtForms;
                        gvSEZ.DataBind();
                    }


                    else if (category == "Central Excise" & subcategory == "Tariff 2012-13")
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        //invisible all
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlDGFT.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //visible SEZ
                        gvSEZ.Visible = true;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;
                        DataTable dtGroups = new DataTable();
                        DataRow row = null;

                        DataColumn dcRelationShip = new DataColumn("Group");
                        dcRelationShip.DataType = System.Type.GetType("System.String");
                        dtGroups.Columns.Add(dcRelationShip);
                        row = dtGroups.NewRow();
                        row["Group"] = "General Excise Act";
                        dtGroups.Rows.Add(row);
                        row = dtGroups.NewRow();
                        row["Group"] = "Central Excise Tariff Act, 1985 and Exemption Notifications";
                        dtGroups.Rows.Add(row);
                        row = dtGroups.NewRow();
                        row["Group"] = "General Exemptions";
                        dtGroups.Rows.Add(row);
                        row = dtGroups.NewRow();
                        row["Group"] = "Appendix";
                        dtGroups.Rows.Add(row);
                        string redirect = string.Empty;
                        CentralExcise_Tariff_GetAllTableAdapter index = new CentralExcise_Tariff_GetAllTableAdapter();

                        ltlIndex.Text = "<table>";
                        foreach (DataRow drGroups in dtGroups.Rows)
                        {
                            string groupName = drGroups[0].ToString();
                            DataTable dtIndex = index.CE_Tariff_IndexByGroup(groupName);


                            if (dtIndex.Rows.Count > 0)
                            {
                                string name = string.Empty;
                                string _indexName = string.Empty;

                                foreach (DataRow drIndex in dtIndex.Rows)
                                {
                                    bool isDoc = false;
                                    string indexname = drIndex["indexname"].ToString();
                                    DataTable dtChapterbyIndex = index.CE_Tariff_ChapterByIndex(indexname);
                                    if (dtChapterbyIndex.Rows.Count > 0)
                                    {
                                        string aChapter = Convert.ToString(dtChapterbyIndex.Rows[0]["chaptername"]);
                                        if (aChapter.Equals(""))
                                        {
                                            string adata = Convert.ToString(dtChapterbyIndex.Rows[0]["data"]);
                                            isDoc = adata.Equals("");
                                            redirect = "shownotifications.aspx";
                                        }
                                        else
                                        {
                                            redirect = "displayindex.aspx";
                                        }
                                    }


                                    string chapatername = drIndex["chaptername"].ToString();
                                    if (name != groupName)
                                    {
                                        ltlIndex.Text += "<tr><td colspan='2' align='center' style='background-color:#D9D9D9;font-size:1.4em;'>";
                                        ltlIndex.Text += "<b>" + groupName + "</b></td></tr>";
                                    }
                                    ltlIndex.Text += "<tr><td width='100' valign='top'>";
                                    if (_indexName != indexname)
                                    {
                                        ltlIndex.Text += "<br/><a href='" + redirect + "?cat=" + category + "&subcat=" + subcategory + "&name=" + drIndex["indexname"].ToString() + (isDoc ? "' target='_blank'" : string.Empty) + "'>" + drIndex["indexname"].ToString() + "</a>";
                                    }

                                    if (chapatername == "")
                                    {
                                        ltlIndex.Text += "</td><td><br/>" + drIndex["subjects"].ToString() + "<br/></td></tr>";
                                    }
                                    name = groupName;
                                    _indexName = indexname;
                                }
                            }
                        }
                        ltlIndex.Text += "</table>";
                    }
                    else if (category == "Central Excise" & subcategory == "CBEC Manual")
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        //invisible all
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlDGFT.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //visible SEZ
                        gvSEZ.Visible = false;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = true;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;
                    }
                    else if (category == "Central Excise" & subcategory == "Notifications")
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        dlIndex.Visible = true;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlDGFT.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = true;
                        dlnontariff.Visible = true;
                        dlsafeguards.Visible = true;
                        dlCECothers.Visible = true;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = true;
                        pnlSION.Visible = false;
                        CECNotifications();
                    }
                    else
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        dlIndex.Visible = true;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlDGFT.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false; dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;
                        CEActsTableAdapter index = new CEActsTableAdapter();
                        DataTable dtActsIndexName = index.CEIndex(subcategory);
                        if (dtActsIndexName.Rows.Count > 0)
                        {
                            dlIndex.DataSource = dtActsIndexName;
                            dlIndex.DataBind();
                        }
                    }
                    #endregion
                }
                if (category == "Service Tax")
                {
                    #region ServiceTax
                    if (category == "Service Tax" & subcategory == "Act 1994")
                    {
                        InvisibleFormLabels();
                        dlIndex.Visible = false;
                        //visible rules
                        dlAgreements.Visible = false;
                        gvstacts.Visible = true;
                        //  dlBaggage.Visible = true;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlDGFT.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;
                        pnlCEManual.Visible = false;

                        // lblAgreements.Text = "Central Excise Rules";
                        // lblBaggage.Text = "Rescinded or Superseded Rules";
                        lblCustomDrawBack.Visible = false;
                        lblCustomValuation.Visible = false;
                        lblOthers.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;

                        ServiceTax_GetAll1TableAdapter index = new ServiceTax_GetAll1TableAdapter();

                        DataTable dtIndex = index.STAct_Index_Select(subcategory);
                        dtIndex.Columns.Add("IsDoc");
                        foreach (DataRow dr in dtIndex.Rows)
                        {
                            dr["IsDoc"] = dr["Data"] == null || dr["Data"].ToString() == string.Empty;
                        }
                        gvstacts.DataSource = dtIndex;
                        gvstacts.DataBind();

                    }
                    else if (category == "Service Tax" & subcategory == "ST Rules")
                    {
                        InvisibleRuleLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        gvstrules.Visible = true;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlDGFT.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        lblAppeals.Visible = false;
                        lblApplicationForm.Visible = false;
                        lblBill.Visible = false;
                        lblBonds.Visible = false;

                        lblDrawback.Visible = false;
                        lblOthersApplicationForms.Visible = false;
                        lblRefunds.Visible = false;
                        lblSettlementCommission.Visible = false;
                        lblShipping.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;


                        //invisible SEZ
                        gvSEZ.Visible = false;

                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        pnlSION.Visible = false;
                        ServiceTax_GetAll1TableAdapter indexrules = new ServiceTax_GetAll1TableAdapter();

                        DataTable dtIndex = indexrules.STRules_Index_Select(subcategory);
                        dtIndex.Columns.Add("IsDoc");
                        foreach (DataRow dr in dtIndex.Rows)
                        {
                            dr["IsDoc"] = dr["Data"] == null || dr["Data"].ToString() == string.Empty;
                        }
                        gvstrules.DataSource = dtIndex;
                        gvstrules.DataBind();
                    }
                    else if (category == "Service Tax" & subcategory == "Forms and Registers")
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        //invisible all
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlDGFT.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //visible SEZ
                        gvSEZ.Visible = false;
                        gvservicetaxforms.Visible = true;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;
                        ServiceTax_GetAll1TableAdapter indexforms = new ServiceTax_GetAll1TableAdapter();

                        DataTable dtIndexForms = indexforms.STForms_Index_Select(subcategory);
                        dtIndexForms.Columns.Add("IsDoc");
                        foreach (DataRow dr in dtIndexForms.Rows)
                        {
                            dr["IsDoc"] = dr["Data"] == null || dr["Data"].ToString() == string.Empty;
                        }
                        gvservicetaxforms.DataSource = dtIndexForms;
                        gvservicetaxforms.DataBind();
                    }
                    else if (category == "Service Tax" & subcategory == "Accounting Codes for new services")
                    {
                        InvisibleRuleLabels();
                        // VisibleFormLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dtstaccodes.Visible = true;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlDGFT.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;

                        lblAppeals.Visible = false;
                        lblApplicationForm.Visible = false;
                        lblBill.Visible = false;
                        lblBonds.Visible = false;

                        lblDrawback.Visible = false;
                        lblOthersApplicationForms.Visible = false;
                        lblRefunds.Visible = false;
                        lblSettlementCommission.Visible = false;
                        lblShipping.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;

                        //invisible SEZ
                        gvSEZ.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;

                        ServiceTax_GetAll1TableAdapter indexaccountcodes = new ServiceTax_GetAll1TableAdapter();

                        DataTable dtIndexindexaccountcodes = indexaccountcodes.STAccountcode_Index_Select(subcategory);
                        dtstaccodes.DataSource = dtIndexindexaccountcodes;
                        dtstaccodes.DataBind();
                    }

                    else if (category == "Service Tax" & subcategory == "Case Laws")
                    {
                        InvisibleRuleLabels();
                        // VisibleFormLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dtstaccodes.Visible = false;
                        dlBaggage.Visible = false;
                        dlDGFT.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = true;

                        lblAppeals.Visible = false;
                        lblApplicationForm.Visible = false;
                        lblBill.Visible = false;
                        lblBonds.Visible = false;

                        lblDrawback.Visible = false;
                        lblOthersApplicationForms.Visible = false;
                        lblRefunds.Visible = false;
                        lblSettlementCommission.Visible = false;
                        lblShipping.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;


                        //invisible SEZ
                        gvSEZ.Visible = false;

                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        pnlSION.Visible = false;

                        STCaselaws_GetAllTableAdapter getSTCaslawsindex = new STCaselaws_GetAllTableAdapter();
                        DataTable dtSTCaslawsindex = getSTCaslawsindex.GetSTCaseLawsIndex();
                        if (dtSTCaslawsindex.Rows.Count > 0)
                        {
                            dlSTCaseLaws.DataSource = dtSTCaslawsindex;
                            dlSTCaseLaws.DataBind();
                        }

                    }



                    else if (category == "Service Tax" & subcategory == "Taxation of Services An Educational Guide")
                    {
                        InvisibleRuleLabels();
                        // VisibleFormLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dtstaccodes.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = false;
                        dlDGFT.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;

                        lblAppeals.Visible = false;
                        lblApplicationForm.Visible = false;
                        lblBill.Visible = false;
                        lblBonds.Visible = false;

                        lblDrawback.Visible = false;
                        lblOthersApplicationForms.Visible = false;
                        lblRefunds.Visible = false;
                        lblSettlementCommission.Visible = false;
                        lblShipping.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;



                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;

                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = true;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        pnlSION.Visible = false;
                    }
                    else if (category == "Service Tax" & subcategory == "Notifications")
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        dlIndex.Visible = true;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = true;
                        dlSTN.Visible = true;
                        pnlITActsInterest.Visible = false;
                        dlantidumpingduty.Visible = true;
                        pnlSION.Visible = false;
                        STN_GetAllTableAdapter styear = new STN_GetAllTableAdapter();
                        DataTable dtstnYear = styear.STN_Index();
                        if (dtstnYear.Rows.Count > 0)
                        {
                            dlSTN.DataSource = dtstnYear;
                            dlSTN.DataBind();
                        }

                    }


                    else
                    {
                        InvisibleRuleLabels();
                        InvisibleFormLabels();
                        dlIndex.Visible = true;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible forms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;
                        //CEActsTableAdapter index = new CEActsTableAdapter();
                        //DataTable dtActsIndexName = index.CEIndex(subcategory);
                        //if (dtActsIndexName.Rows.Count > 0)
                        //{
                        //    dlIndex.DataSource = dtActsIndexName;
                        //    dlIndex.DataBind();
                        //}
                    }

                    #endregion
                }
                if (category == "Library")
                {
                    #region ST Libraries

                    if (category == "Library" & subcategory == "ST Libraries")
                    {
                        InvisibleRuleLabels();
                        // VisibleFormLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dtstaccodes.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlDGFT.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;

                        lblAppeals.Visible = false;
                        lblApplicationForm.Visible = false;
                        lblBill.Visible = false;
                        lblBonds.Visible = false;

                        lblDrawback.Visible = false;
                        lblOthersApplicationForms.Visible = false;
                        lblRefunds.Visible = false;
                        lblSettlementCommission.Visible = false;
                        lblShipping.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;


                        //invisible SEZ
                        gvSEZ.Visible = false;

                        pnlSTlibraries.Visible = true;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;


                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;

                    }
                    #endregion

                    #region Resciding Rules
                    if (category == "Library" & subcategory == "Rescinded Rules")
                    {
                        VisibleRuleLabels();
                        InvisibleFormLabels();
                        dlIndex.Visible = false;
                        //visible rules
                        dlAgreements.Visible = true;
                        dlBaggage.Visible = true;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlOthers.Visible = false;
                        //invisible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlDGFT.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;
                        //invisible ServiceTax Data
                        gvservicetaxforms.Visible = false;
                        gvstacts.Visible = false;
                        gvstrules.Visible = false;
                        dtstaccodes.Visible = false;
                        pnlCEManual.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;

                        lblAgreements.Text = string.Empty;
                        lblBaggage.Text = "Rescinded or Superseded Rules";
                        lblCustomDrawBack.Visible = false;
                        lblCustomValuation.Visible = false;
                        lblOthers.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlSTTaxation.Visible = false;
                        dlITActs.Visible = false;

                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;

                        Library_RSRules_SelectAllTableAdapter indexByHeadings = new Library_RSRules_SelectAllTableAdapter();
                        DataTable dtBaggage = indexByHeadings.RSRules_Index(subcategory);
                        dlBaggage.DataSource = dtBaggage;
                        dlBaggage.DataBind();
                    }

                    #endregion
                }
                if (category == "Income Tax")
                {
                    #region Income Tax
                    if (subcategory == "Income Tax Act" || subcategory == "Wealth Tax Act" || subcategory == "Expenditure Tax Act")
                    {
                        dlITActs.Visible = true;

                        InvisibleRuleLabels();
                        // VisibleFormLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dtstaccodes.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlDGFT.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;

                        lblAppeals.Visible = false;
                        lblApplicationForm.Visible = false;
                        lblBill.Visible = false;
                        lblBonds.Visible = false;

                        lblDrawback.Visible = false;
                        lblOthersApplicationForms.Visible = false;
                        lblRefunds.Visible = false;
                        lblSettlementCommission.Visible = false;
                        lblShipping.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;

                        //invisible SEZ
                        gvSEZ.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;
                        IncomeTaxActs_SelectAllTableAdapter getITDetails = new IncomeTaxActs_SelectAllTableAdapter();
                        DataTable dtGetITDetails = getITDetails.GetIndex(subcategory);
                        if (dtGetITDetails.Rows.Count > 0)
                        {
                            dtGetITDetails.Columns.Add("IsDoc");
                            foreach (DataRow dr in dtGetITDetails.Rows)
                            {
                                dr["IsDoc"] = "False";
                            }
                            dlITActs.DataSource = dtGetITDetails;
                            dlITActs.DataBind();
                        }
                    }
                    if (subcategory == "Finance Act")
                    {
                        dlITActs.Visible = false;

                        InvisibleRuleLabels();
                        // VisibleFormLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dtstaccodes.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlDGFT.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;

                        lblAppeals.Visible = false;
                        lblApplicationForm.Visible = false;
                        lblBill.Visible = false;
                        lblBonds.Visible = false;

                        lblDrawback.Visible = false;
                        lblOthersApplicationForms.Visible = false;
                        lblRefunds.Visible = false;
                        lblSettlementCommission.Visible = false;
                        lblShipping.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;

                        pnlSTlibraries.Visible = true;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        pnlSION.Visible = false;
                        IncomeTaxActs_SelectAllTableAdapter getITDetails = new IncomeTaxActs_SelectAllTableAdapter();
                        DataTable dtGetITDetails = getITDetails.GetFinanceActsDetails(subcategory);
                        if (dtGetITDetails.Rows.Count > 0)
                        {
                            ltlIndex.Text = "<table width='100%'>";
                            string _group = string.Empty;
                            string _indexName = string.Empty;
                            foreach (DataRow drGetITDetails in dtGetITDetails.Rows)
                            {
                                string group = drGetITDetails["Groups"].ToString();
                                string indexName = drGetITDetails["IndexName"].ToString();

                                if (_group != group)
                                {
                                    ltlIndex.Text += "<tr height='10px'><td align='center' style='background-color:#D9D9D9;font-size:1.4em;'>" + group + "<br/><br/></td></tr>";
                                }
                                ltlIndex.Text += "<tr><td style='font-size:10.0pt;font-family:Verdana,sans-serif;mso-bidi-font-family:Times'><a href='shownotifications.aspx?name=" + indexName + "+&cat=" + category + "&subcat=" + subcategory + "'>" + indexName + "</a><br/><br/></td></tr>";
                                _group = group;
                            }
                            ltlIndex.Text += "</table>";
                        }
                    }
                    if (subcategory == "Interest Tax Act")
                    {
                        pnlITActsInterest.Visible = true;

                        InvisibleRuleLabels();
                        // VisibleFormLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dtstaccodes.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlDGFT.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;

                        lblAppeals.Visible = false;
                        lblApplicationForm.Visible = false;
                        lblBill.Visible = false;
                        lblBonds.Visible = false;

                        lblDrawback.Visible = false;
                        lblOthersApplicationForms.Visible = false;
                        lblRefunds.Visible = false;
                        lblSettlementCommission.Visible = false;
                        lblShipping.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        //invisible SEZ
                        gvSEZ.Visible = false;

                        pnlSTlibraries.Visible = true;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        pnlSTlibraries.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlSION.Visible = false;
                    }

                    if (subcategory == "Gift Tax Act")
                    {
                        pnlITActsGift.Visible = true;

                        InvisibleRuleLabels();
                        // VisibleFormLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dtstaccodes.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlDGFT.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;

                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        lblAppeals.Visible = false;
                        lblApplicationForm.Visible = false;
                        lblBill.Visible = false;
                        lblBonds.Visible = false;

                        lblDrawback.Visible = false;
                        lblOthersApplicationForms.Visible = false;
                        lblRefunds.Visible = false;
                        lblSettlementCommission.Visible = false;
                        lblShipping.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;

                        //invisible SEZ
                        gvSEZ.Visible = false;

                        pnlSTlibraries.Visible = true;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        pnlSTlibraries.Visible = false;
                        dlITActs.Visible = false;
                        pnlITActsInterest.Visible = false;
                        pnlSION.Visible = false;


                    }
                    if (subcategory == "Income Tax Rules" || subcategory == "Other Direct Tax Rules")
                    {
                        dlITActs.Visible = true;

                        InvisibleRuleLabels();
                        // VisibleFormLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dtstaccodes.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlDGFT.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;

                        lblAppeals.Visible = false;
                        lblApplicationForm.Visible = false;
                        lblBill.Visible = false;
                        lblBonds.Visible = false;

                        lblDrawback.Visible = false;
                        lblOthersApplicationForms.Visible = false;
                        lblRefunds.Visible = false;
                        lblSettlementCommission.Visible = false;
                        lblShipping.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;

                        //invisible SEZ
                        gvSEZ.Visible = false;

                        pnlSTlibraries.Visible = true;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        pnlSTlibraries.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;

                        IncomeTaxRules_SelectAllTableAdapter getITDetails = new IncomeTaxRules_SelectAllTableAdapter();
                        DataTable dtGetITDetails = getITDetails.GetIndex(subcategory);
                        if (dtGetITDetails.Rows.Count > 0)
                        {
                            dtGetITDetails.Columns.Add("IsDoc");
                            foreach (DataRow dr in dtGetITDetails.Rows)
                            {
                                dr["IsDoc"] = "False";
                            }
                            dlITActs.DataSource = dtGetITDetails;
                            dlITActs.DataBind();
                        }
                    }
                    if (subcategory == "Circulars" || subcategory == "Notifications")
                    {
                        dlITActs.Visible = true;

                        InvisibleRuleLabels();
                        // VisibleFormLabels();
                        dlIndex.Visible = false;
                        //invisible rules
                        dlAgreements.Visible = false;
                        dtstaccodes.Visible = false;
                        dlBaggage.Visible = false;
                        dlCustomDrawBack.Visible = false;
                        dlCustomValuation.Visible = false;
                        dlDGFT.Visible = false;
                        dlOthers.Visible = false;
                        //visible froms
                        dlRefunds.Visible = false;
                        dlAppeals.Visible = false;
                        dlDrawback.Visible = false;
                        dlOthersApplicationForms.Visible = false;
                        dlShipping.Visible = false;
                        dllBill.Visible = false;
                        dlBonds.Visible = false;
                        dlSettlementCommission.Visible = false;
                        dlSTCaseLaws.Visible = false;

                        lblAppeals.Visible = false;
                        lblApplicationForm.Visible = false;
                        lblBill.Visible = false;
                        lblBonds.Visible = false;

                        lblDrawback.Visible = false;
                        lblOthersApplicationForms.Visible = false;
                        lblRefunds.Visible = false;
                        lblSettlementCommission.Visible = false;
                        lblShipping.Visible = false;
                        //invisible Circular/Instruction Headings
                        lblCircularHeading.Visible = false;
                        lblInstructionHeading.Visible = false;
                        pnlSTlibraries.Visible = false;

                        //invisible SEZ
                        gvSEZ.Visible = false;
                        pnlSTTaxation.Visible = false;
                        pnlCEManual.Visible = false;
                        pnlITActsGift.Visible = false;
                        pnlITActsInterest.Visible = false;
                        dltariff.Visible = false;
                        dlnontariff.Visible = false;
                        dlsafeguards.Visible = false;
                        dlCECothers.Visible = false;
                        dlSTN.Visible = false;
                        dlantidumpingduty.Visible = false;
                        pnlSION.Visible = false;
                        IncomeTaxCircularsNotification_SelectAllTableAdapter getITDetails = new IncomeTaxCircularsNotification_SelectAllTableAdapter();
                        DataTable dtGetITDetails = getITDetails.GetIndex(subcategory);
                        if (dtGetITDetails.Rows.Count > 0)
                        {
                            dtGetITDetails.Columns.Add("IsDoc");
                            foreach (DataRow dr in dtGetITDetails.Rows)
                            {
                                dr["IsDoc"] = dr["Data"] == null || dr["Data"].ToString() == string.Empty;
                            }
                            dlITActs.DataSource = dtGetITDetails;
                            dlITActs.DataBind();
                        }
                    }
                    #endregion
                }
                if (category == "DGFT" && subcategory == "FTDR Notifications")
                {
                    #region DGFFTDR

                    InvisibleRuleLabels();
                    InvisibleFormLabels();
                    //invisible all
                    dlIndex.Visible = false;
                    //invisible rules
                    dlAgreements.Visible = false;
                    dlBaggage.Visible = false;
                    dlCustomDrawBack.Visible = false;
                    dlCustomValuation.Visible = false;
                    dlOthers.Visible = false;
                    //invisible forms
                    dlRefunds.Visible = false;
                    dlAppeals.Visible = false;
                    dlDrawback.Visible = false;
                    dlOthersApplicationForms.Visible = false;
                    dlShipping.Visible = false;
                    dllBill.Visible = false;
                    dlBonds.Visible = false;
                    dlSettlementCommission.Visible = false;
                    dlSTCaseLaws.Visible = false;
                    //visible SEZ
                    gvSEZ.Visible = false;
                    //invisible ServiceTax Data
                    gvservicetaxforms.Visible = false;
                    gvstacts.Visible = false;
                    gvstrules.Visible = false;
                    dtstaccodes.Visible = false;
                    //invisible Circular/Instruction Headings
                    lblCircularHeading.Visible = false;
                    lblInstructionHeading.Visible = false;
                    pnlSTlibraries.Visible = false;
                    pnlSTTaxation.Visible = false;
                    pnlCEManual.Visible = false;
                    dlDGFT.Visible = true;
                    dlITActs.Visible = false;
                    pnlITActsGift.Visible = false;
                    pnlITActsInterest.Visible = false;
                    dlantidumpingduty.Visible = false;
                    pnlSION.Visible = false;

                    dltariff.Visible = false;
                    dlnontariff.Visible = false;
                    dlsafeguards.Visible = false;
                    dlCECothers.Visible = false;
                    dlSTN.Visible = false;
                    DGFT_FTDR_Notifications_GetAllTableAdapter indexBySubCategeory = new DGFT_FTDR_Notifications_GetAllTableAdapter();
                    DataTable dtDGFTFTDR = indexBySubCategeory.DGFT_FTDRNotification_Index(subcategory);
                    dlDGFT.DataSource = dtDGFTFTDR;
                    dlDGFT.DataBind();


                    #endregion

                } if (category == "DGFT" && subcategory == "FTP")
                {
                    #region DGFFTP

                    InvisibleRuleLabels();
                    InvisibleFormLabels();
                    //invisible all
                    dlIndex.Visible = false;
                    //invisible rules
                    dlAgreements.Visible = false;
                    dlBaggage.Visible = false;
                    dlCustomDrawBack.Visible = false;
                    dlCustomValuation.Visible = false;
                    dlOthers.Visible = false;
                    //invisible forms
                    dlRefunds.Visible = false;
                    dlAppeals.Visible = false;
                    dlDrawback.Visible = false;
                    dlOthersApplicationForms.Visible = false;
                    dlShipping.Visible = false;
                    dllBill.Visible = false;
                    dlBonds.Visible = false;
                    dlSettlementCommission.Visible = false;
                    dlSTCaseLaws.Visible = false;
                    //visible SEZ
                    gvSEZ.Visible = false;
                    //invisible ServiceTax Data
                    gvservicetaxforms.Visible = false;
                    gvstacts.Visible = false;
                    gvstrules.Visible = false;
                    dtstaccodes.Visible = false;
                    //invisible Circular/Instruction Headings
                    lblCircularHeading.Visible = false;
                    lblInstructionHeading.Visible = false; dlantidumpingduty.Visible = false;
                    pnlSTlibraries.Visible = false;
                    pnlSTTaxation.Visible = false;
                    pnlCEManual.Visible = false;
                    dlDGFT.Visible = true;
                    dlITActs.Visible = false;
                    pnlITActsGift.Visible = false;
                    pnlITActsInterest.Visible = false;
                    pnlSION.Visible = false;

                    dltariff.Visible = false;
                    dlnontariff.Visible = false;
                    dlsafeguards.Visible = false;
                    dlCECothers.Visible = false;
                    dlSTN.Visible = false;
                    DGFT_GetAllTableAdapter indexBySubCategeory = new DGFT_GetAllTableAdapter();
                    DataTable dtDGFTFTP = indexBySubCategeory.DGFT_FTP_Inde_select(subcategory);
                    dlDGFT.DataSource = dtDGFTFTP;
                    dlDGFT.DataBind();

                    #endregion
                }

                if (category == "DGFT" && subcategory == "public notices")
                {
                    #region DGFTpublicnotices

                    InvisibleRuleLabels();
                    InvisibleFormLabels();
                    //invisible all
                    dlIndex.Visible = false;
                    //invisible rules
                    dlAgreements.Visible = false;
                    dlBaggage.Visible = false;
                    dlCustomDrawBack.Visible = false;
                    dlCustomValuation.Visible = false;
                    dlOthers.Visible = false;
                    //invisible forms
                    dlRefunds.Visible = false;
                    dlAppeals.Visible = false;
                    dlDrawback.Visible = false;
                    dlOthersApplicationForms.Visible = false;
                    dlShipping.Visible = false;
                    dllBill.Visible = false;
                    dlBonds.Visible = false;
                    dlSettlementCommission.Visible = false;
                    dlSTCaseLaws.Visible = false;
                    //visible SEZ
                    gvSEZ.Visible = false;
                    //invisible ServiceTax Data
                    gvservicetaxforms.Visible = false;
                    gvstacts.Visible = false;
                    gvstrules.Visible = false;
                    dtstaccodes.Visible = false;
                    //invisible Circular/Instruction Headings
                    lblCircularHeading.Visible = false;
                    lblInstructionHeading.Visible = false;
                    pnlSTlibraries.Visible = false;
                    pnlSTTaxation.Visible = false;
                    pnlCEManual.Visible = false;
                    dlDGFT.Visible = true;
                    dlITActs.Visible = false;
                    pnlITActsGift.Visible = false; dlantidumpingduty.Visible = false;
                    pnlITActsInterest.Visible = false;
                    pnlSION.Visible = false;
                    dltariff.Visible = false;
                    dlnontariff.Visible = false;
                    dlsafeguards.Visible = false;
                    dlCECothers.Visible = false;
                    dlSTN.Visible = false;

                    DGFT_GetAllTableAdapter indexBySubCategeory = new DGFT_GetAllTableAdapter();
                    DataTable dtDGFTpublicnotice = indexBySubCategeory.DGFT_publicnotices_Index_select();
                    dlDGFT.DataSource = dtDGFTpublicnotice;
                    dlDGFT.DataBind();
                    #endregion

                }
                if (category == "DGFT" && subcategory == "SION")
                {
                    #region DGFTSION

                    pnlSION.Visible = true;

                    InvisibleRuleLabels();
                    InvisibleFormLabels();
                    //invisible all
                    dlIndex.Visible = false;
                    //invisible rules
                    dlAgreements.Visible = false;
                    dlBaggage.Visible = false;
                    dlCustomDrawBack.Visible = false;
                    dlCustomValuation.Visible = false;
                    dlOthers.Visible = false;
                    //invisible forms
                    dlRefunds.Visible = false;
                    dlAppeals.Visible = false;
                    dlDrawback.Visible = false;
                    dlOthersApplicationForms.Visible = false;
                    dlShipping.Visible = false;
                    dllBill.Visible = false;
                    dlBonds.Visible = false;
                    dlSettlementCommission.Visible = false;
                    dlSTCaseLaws.Visible = false;
                    //visible SEZ
                    gvSEZ.Visible = false;
                    //invisible ServiceTax Data
                    gvservicetaxforms.Visible = false;
                    gvstacts.Visible = false;
                    gvstrules.Visible = false;
                    dtstaccodes.Visible = false;
                    //invisible Circular/Instruction Headings
                    lblCircularHeading.Visible = false;
                    lblInstructionHeading.Visible = false; dlantidumpingduty.Visible = false;
                    pnlSTlibraries.Visible = false;
                    pnlSTTaxation.Visible = false;
                    pnlCEManual.Visible = false;
                    dlDGFT.Visible = false;
                    dlITActs.Visible = false;
                    pnlITActsGift.Visible = false;
                    pnlITActsInterest.Visible = false;

                    dltariff.Visible = false;
                    dlnontariff.Visible = false;
                    dlsafeguards.Visible = false;
                    dlCECothers.Visible = false;
                    dlSTN.Visible = false;

                    #endregion
                }


            }
        }

        public void CECNotifications()
        {
            CECNotification_GetAllTableAdapter getCECYear = new CECNotification_GetAllTableAdapter();
            DataTable dtcectyear = getCECYear.CEC_notificatonindex_ByTYear(category);

            if (dtcectyear.Rows.Count > 0)
            {
                dltariff.DataSource = dtcectyear;
                dltariff.DataBind();
            }

            CECNotification_GetAllTableAdapter cecntyear = new CECNotification_GetAllTableAdapter();
            DataTable dtcecntyear = cecntyear.CEC_notificatonindex_ByNTYear(category);
            if (dtcecntyear.Rows.Count > 0)
            {
                dlnontariff.DataSource = dtcecntyear;
                dlnontariff.DataBind();
            }

            CECNotification_GetAllTableAdapter cecsyear = new CECNotification_GetAllTableAdapter();
            DataTable dtcecsyear = cecsyear.CEC_notificatonindex_BySYear(category);
            if (dtcecsyear.Rows.Count > 0)
            {
                dlsafeguards.DataSource = dtcecsyear;
                dlsafeguards.DataBind();
            }

            CECNotification_GetAllTableAdapter cecaddyear = new CECNotification_GetAllTableAdapter();
            DataTable dtcecaddyear = cecaddyear.CEC_notificatonindex_ByADDYear(category);
            if (dtcecaddyear.Rows.Count > 0)
            {
                dlantidumpingduty.DataSource = dtcecaddyear;
                dlantidumpingduty.DataBind();
            }
            CECNotification_GetAllTableAdapter cecothersyear = new CECNotification_GetAllTableAdapter();
            DataTable dtcecothersyear = cecothersyear.CEC_notificatonindex_ByOthersYear(category);
            if (dtcecothersyear.Rows.Count > 0)
            {
                dlCECothers.DataSource = dtcecothersyear;
                dlCECothers.DataBind();
            }
        }




        protected void dlIndex_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Index")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;
                DataTable dtActsChapter = new DataTable();
                if (category == "Customs")
                {
                    ActsTableAdapter actsChapter = new ActsTableAdapter();
                    dtActsChapter = actsChapter.Data_Select(subcategory, _name);
                }
                else if (category == "Central Excise")
                {
                    CEActsTableAdapter CEActsChapter = new CEActsTableAdapter();
                    dtActsChapter = CEActsChapter.CEData(subcategory, _name);
                }
                if (dtActsChapter.Rows.Count > 0)
                {
                    string aChapter = Convert.ToString(dtActsChapter.Rows[0]["ChapterName"]);
                    if (aChapter.Equals(""))
                    {
                        string aData = Convert.ToString(dtActsChapter.Rows[0]["data"]);
                        if (aData.Equals(""))
                        {
                            Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name, "_blank", string.Empty);
                        }
                        else
                        {
                            Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                        }

                    }
                    else
                    {
                        Response.Redirect("displayindex.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                    }
                }
            }
        }

        #region Customs
        // Rules
        #region rules

        protected void dlAgreements_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Agreements")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);

            }

        }

        protected void dlBaggage_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Baggage")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;
                if (category == "Library" & subcategory == "Rescinded Rules")
                {
                    Library_RSRules_SelectAllTableAdapter CEActsChapter = new Library_RSRules_SelectAllTableAdapter();
                    DataTable dtActsChapter = CEActsChapter.Library_Data_Select(subcategory, _name);
                    if (dtActsChapter.Rows.Count > 0)
                    {
                        string aChapter = Convert.ToString(dtActsChapter.Rows[0]["chaptername"]);
                        if (aChapter.Equals(""))
                        {
                            string aData = Convert.ToString(dtActsChapter.Rows[0]["data"]);
                            if (aData.Equals(""))
                            {
                                Response.Redirect("shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name, "_blank", string.Empty);
                            }
                            else
                            {
                                Response.Redirect("shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                            }
                        }
                        else
                        {
                            Response.Redirect("displayindex.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                        }
                    }
                }
                else if (category == "Central Excise" & subcategory == "Rules")
                {
                    CEActsTableAdapter CEActsChapter = new CEActsTableAdapter();
                    DataTable dtActsChapter = CEActsChapter.ChapterbyIndex(subcategory, _name);
                    if (dtActsChapter.Rows.Count > 0)
                    {
                        string aChapter = Convert.ToString(dtActsChapter.Rows[0]["chaptername"]);
                        if (aChapter.Equals(""))
                        {
                            string aData = Convert.ToString(dtActsChapter.Rows[0]["data"]);
                            if (aData.Equals(""))
                            {
                                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name, "_blank", string.Empty);
                            }
                            else
                            {
                                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                            }
                        }
                        else
                        {
                            Response.Redirect("displayindex.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                        }
                    }
                }
                else if (category == "Customs" & subcategory == "Rules")
                {
                    ActsTableAdapter baggageAdpt = new ActsTableAdapter();
                    DataTable dtActsChapter = baggageAdpt.Data_Select(subcategory, _name);
                    if (dtActsChapter.Rows.Count > 0)
                    {
                        string aData = Convert.ToString(dtActsChapter.Rows[0]["data"]);
                        if (aData.Equals(""))
                        {
                            Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name, "_blank", string.Empty);
                        }
                        else
                        {
                            Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                }
            }
        }

        protected void dlCustomDrawBack_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "CustomDrawBack")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
            }
        }

        protected void dlCustomValuation_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "CustomValuation")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
            }
        }

        protected void dlOthers_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Others")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
            }
        }
        #endregion
        // Forms
        #region Forms

        protected void dlRefunds_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Refunds")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
            }
        }

        protected void dlAppeals_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Appeals")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
            }
        }

        protected void dlDrawback_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Drawback")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
            }
        }

        protected void dlOthersApplicationForms_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "OthersApplicationForms")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
            }
        }

        protected void dlShipping_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Shipping")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
            }
        }

        protected void dllBill_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Bill")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
            }
        }

        protected void dlBonds_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Bonds")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
            }
        }

        protected void dlSettlementCommission_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "SettlementCommission")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
            }
        }

        #endregion
        // visible/invisible controls
        #region Visible/Invisible

        public void InvisibleRuleLabels()
        {
            lblAgreements.Visible = false;
            lblBaggage.Visible = false;
            lblCustomDrawBack.Visible = false;
            lblCustomValuation.Visible = false;
            lblOthers.Visible = false;

        }

        public void VisibleRuleLabels()
        {
            lblAgreements.Visible = true;
            lblBaggage.Visible = true;
            lblCustomDrawBack.Visible = true;
            lblCustomValuation.Visible = true;
            lblOthers.Visible = true;
        }

        public void InvisibleFormLabels()
        {
            lblApplicationForm.Visible = false;
            lblRefunds.Visible = false;
            lblAppeals.Visible = false;
            lblDrawback.Visible = false;
            lblOthersApplicationForms.Visible = false;
            lblShipping.Visible = false;
            lblBill.Visible = false;
            lblBonds.Visible = false;
            lblSettlementCommission.Visible = false;
        }

        public void VisibleFormLabels()
        {
            lblApplicationForm.Visible = true;
            lblRefunds.Visible = true;
            lblAppeals.Visible = true;
            lblDrawback.Visible = true;
            lblOthersApplicationForms.Visible = true;
            lblShipping.Visible = true;
            lblBill.Visible = true;
            lblBonds.Visible = true;
            lblSettlementCommission.Visible = true;
        }

        #endregion
        //SEZ
        #region SEZ

        protected void gvSEZ_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SEZ")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;

                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name, "_blank", string.Empty);
            }
        }

        #endregion

        #endregion

        protected void gvstacts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "STacts")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;
                if (e.CommandArgument.ToString() == "True")
                {
                    Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name, "_blank", string.Empty);
                }
                else
                {
                    Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                }
            }
        }

        protected void gvservicetaxforms_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "STForms")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;
                if (e.CommandArgument.ToString() == "True")
                {
                    Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name, "_blank", string.Empty);
                }
                else
                {
                    Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                }
            }

        }

        protected void gvstrules_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "STrules")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;
                if (e.CommandArgument.ToString() == "True")
                {
                    Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name, "_blank", string.Empty);
                }
                else
                {
                    Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                }
            }
        }

        protected void dtstaccodes_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "accodes")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _name = linkButton.Text;


                Response.Redirect("~/shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);

            }
        }

        protected void dlIndexCirculars_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "CircularIndex")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string year = linkButton.Text;
                Response.Redirect("displayindex.aspx?cat=" + category + "&year=" + year + "&name=" + group[0] + "&subcat=" + subcategory);
            }
        }

        protected void dlIndexInstrcutions_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "InstructionsIndex")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string year = linkButton.Text;
                Response.Redirect("displayindex.aspx?cat=" + category + "&year=" + year + "&name=" + group[1] + "&subcat=" + subcategory);
            }
        }

        protected void dlSTCaseLaws_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "STCaseLaws")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string indexname = linkButton.Text;
                Response.Redirect("shownotifications.aspx?name=" + indexname + "+&cat=" + category + "&subcat=" + subcategory);
            }

        }

        protected void dlDGFT_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DGFT")
            {
                if (category == "DGFT" && subcategory == "FTP")
                {
                    LinkButton linkButton = e.CommandSource as LinkButton;
                    string _name = linkButton.Text;

                    DataTable dtFTPChapter = new DataTable();

                    DGFT_GetAllTableAdapter FTPChapter = new DGFT_GetAllTableAdapter();
                    dtFTPChapter = FTPChapter.DGFT_FTP_Data_select(subcategory, _name);


                    if (dtFTPChapter.Rows.Count > 0)
                    {
                        string _FTPChapter = Convert.ToString(dtFTPChapter.Rows[0]["ChapterName"]);
                        if (_FTPChapter.Equals(""))
                        {
                            Response.Redirect("shownotifications.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                        }
                        else
                        {
                            Response.Redirect("displayindex.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + _name);
                        }
                    }
                }



                else if (category == "DGFT" && subcategory == "FTDR Notifications")
                {
                    LinkButton linkButton = e.CommandSource as LinkButton;
                    string indexname = linkButton.Text;
                    Response.Redirect("shownotifications.aspx?name=" + indexname + "+&cat=" + category + "&subcat=" + subcategory);

                }

                else if (category == "DGFT" && subcategory == "public notices")
                {
                    LinkButton linkButton = e.CommandSource as LinkButton;
                    string indexname = linkButton.Text;
                    Response.Redirect("~/displayindex.aspx?cat=" + category + "&subcat=" + subcategory + "&name=" + indexname);

                }
                else
                {
                    //do

                }

            }

        }

        protected void dlITActs_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ITActs")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string indexname = linkButton.Text;
                if (e.CommandArgument.ToString() == "True")
                {
                    Response.Redirect("shownotifications.aspx?name=" + indexname + "+&cat=" + category + "&subcat=" + subcategory, "_blank", string.Empty);
                }
                else
                {
                    Response.Redirect("shownotifications.aspx?name=" + indexname + "+&cat=" + category + "&subcat=" + subcategory);
                }
            }

        }



        protected void dlSTN_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "STN")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _year2 = linkButton.Text;
                STN_GetAllTableAdapter stnInfo = new STN_GetAllTableAdapter();
                DataTable dtstnInfo = stnInfo.STN_InfoByYear(_year2, subcategory);
                if (dtstnInfo.Rows.Count > 0)
                {
                    Response.Redirect("displayindex.aspx?cat=" + category + "&subcat=" + subcategory + "&year=" + _year2);
                }
            }
        }

        protected void dltariff_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "TariffIndex")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _year3 = linkButton.Text;
                CECNotification_GetAllTableAdapter cectinfo = new CECNotification_GetAllTableAdapter();
                DataTable dtcectinfo = cectinfo.CEC_notificationsinfo_ByTYear(_year3, category);
                if (dtcectinfo.Rows.Count > 0)
                {
                    Response.Redirect("displayindex.aspx?cat=" + category + "&subcat=" + subcategory + "&year=" + _year3 + "&notification=Tariff");
                }
            }

        }

        protected void dlnontariff_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "NonTariffIndex")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _year4 = linkButton.Text;
                CECNotification_GetAllTableAdapter cecntinfo = new CECNotification_GetAllTableAdapter();
                DataTable dtcecntinfo = cecntinfo.CEC_notificationinfo_ByNTYear(_year4, category);
                if (dtcecntinfo.Rows.Count > 0)
                {
                    Response.Redirect("displayindex.aspx?cat=" + category + "&subcat=" + subcategory + "&year=" + _year4 + "&notification=Non-Tariff");
                }
            }
        }

        protected void dlsafeguards_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "SafeguardsIndex")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _year5 = linkButton.Text;
                CECNotification_GetAllTableAdapter cecsinfo = new CECNotification_GetAllTableAdapter();
                DataTable dtcecsinfo = cecsinfo.CEC_notificationsinfo_BySYear(_year5, category);
                if (dtcecsinfo.Rows.Count > 0)
                {
                    Response.Redirect("displayindex.aspx?cat=" + category + "&subcat=" + subcategory + "&year=" + _year5 + "&notification=Safeguards");
                }
            }
        }

        protected void dlantidumpingduty_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AntiDumpingDutyIndex")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _year6 = linkButton.Text;
                CECNotification_GetAllTableAdapter cecaddinfo = new CECNotification_GetAllTableAdapter();
                DataTable dtcecaddinfo = cecaddinfo.CEC_notificationsinfo_ADDYear(_year6, category);
                if (dtcecaddinfo.Rows.Count > 0)
                {
                    Response.Redirect("displayindex.aspx?cat=" + category + "&subcat=" + subcategory + "&year=" + _year6 + "&notification=Anti Dumping Duty");
                }
            }
        }

        protected void dlCECothers_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "others")
            {
                LinkButton linkButton = e.CommandSource as LinkButton;
                string _year7 = linkButton.Text;
                //string ofnumber = Convert.ToString(Request.QueryString["ofnum"]);
                CECNotification_GetAllTableAdapter cecoinfo = new CECNotification_GetAllTableAdapter();
                DataTable dtcecoinfo = cecoinfo.CEC_notificationsinfo_ByOthersYear(_year7, category);
                if (dtcecoinfo.Rows.Count > 0)
                {
                    Response.Redirect("displayindex.aspx?cat=" + category + "&subcat=" + subcategory + "&year=" + _year7 + "&notification=Others");
                }
            }
        }

    }
}

