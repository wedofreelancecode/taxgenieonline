<%@ Page Title="Upload Notifications" Language="C#" MasterPageFile="~/TaxGenie.master"
    AutoEventWireup="true" CodeBehind="uploadnotifications.aspx.cs" Inherits="TaxGenieOnline.admin.uploadnotifications" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <div class="contentboxmiddle1 shdw" style="min-height: 300px;">
                <table style="width: 100%; margin-top: 5px;">
                    <tr>
                        <td style="width: 20%; text-align: right">
                            <asp:HiddenField ID="hdnId" runat="server" />
                            <asp:Label ID="lblCategory" runat="server" Text="Category" CssClass="nlsN"></asp:Label>
                        </td>
                        <td style="width: 25%; text-align: left">
                            <asp:DropDownList ID="ddlcatagory" runat="server" CssClass="nls" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlcatagory_SelectedIndexChanged">
                                <asp:ListItem>select one</asp:ListItem>
                                <asp:ListItem>Central Excise</asp:ListItem>
                                <asp:ListItem>Customs</asp:ListItem>
                                <asp:ListItem>Service Tax</asp:ListItem>
                                <asp:ListItem>Income Tax</asp:ListItem>
                                <asp:ListItem>DGFT</asp:ListItem>
                                <asp:ListItem>Library</asp:ListItem>
                                <asp:ListItem>Services</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvddlcat" runat="server" ControlToValidate="ddlcatagory"
                                InitialValue="select one" ErrorMessage="*" ValidationGroup="ddlcat"></asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 20%; text-align: right">
                            <asp:Label ID="lblSubCategory" runat="server" Text="Sub Category" CssClass="nlsN"></asp:Label>
                        </td>
                        <td style="width: 35%; text-align: left">
                            <asp:DropDownList ID="ddlsubcategory" runat="server" CssClass="nls" Width="150" OnSelectedIndexChanged="ddlsubcategory_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="pnlCActs" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblCActsIndex" runat="server" Text="Index" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 25%; text-align: left">
                                <asp:TextBox ID="txtCActsIndex" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblCActsChapterName" runat="server" Text="Chapter Name" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 35%; text-align: left">
                                <asp:TextBox ID="txtCActsChapterName" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblCActsSections" runat="server" Text="Sections" CssClass="nls"></asp:Label>
                                <asp:Editor ID="edtCActsSections" runat="server" Width="100%" Height="400px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCRules" Width="100%" runat="server">
                    <table cellpadding="0" width="100%" cellspacing="0" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCRulesIndexGroup" runat="server" Text="Index Group" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 23%; text-align: left">
                                <asp:DropDownList ID="ddlCRulesIndexGroup" runat="server" CssClass="nls">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCRulesIndex" runat="server" Text="Index" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 23%; text-align: left">
                                <asp:TextBox ID="txtCRulesIndex" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblSubRulesChapterName" runat="server" Text="Chapter Name" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 23%; text-align: left">
                                <asp:TextBox ID="txtSubRulesChapterName" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <asp:Panel ID="pnlSubRules" Width="100%" runat="server">
                                    <table width="100%" style="margin-top: 20px">
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblSubRulesSections" runat="server" Text="Sections" CssClass="nls"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Editor ID="edtSubRulesSections" runat="server" Width="100%" Height="400px" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCRegulations" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCRegulationsIndex" runat="server" Text="Index" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCRegulationsIndex" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCForms" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCformsgroup" runat="server" Text="Group" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:DropDownList ID="ddlCformsgroup" runat="server" CssClass="nls" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlCformsgroup_SelectedIndexChanged">
                                    <asp:ListItem>select one</asp:ListItem>
                                    <asp:ListItem>Application Forms</asp:ListItem>
                                    <asp:ListItem>Shipping Bill Forms</asp:ListItem>
                                    <asp:ListItem>Bill of Entry Forms </asp:ListItem>
                                    <asp:ListItem>Bonds</asp:ListItem>
                                    <asp:ListItem>Appendix</asp:ListItem>
                                    <asp:ListItem>Settlement Commission</asp:ListItem>
                                    <asp:ListItem>Others</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCformssubgroup" runat="server" Text="Sub Group" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:UpdatePanel ID="uplCForms" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCformssubgroups" runat="server" CssClass="nls">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlCformsgroup" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCFormsIndex" runat="server" Text="Index" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCFormsIndex" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblFormsSubject" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtFormsSubject" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCSEZ" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCSEZNotficationNo" runat="server" Text="Notfication No" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCSEZNotficationNo" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCSEZSubject" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCSEZSubject" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCDrawback" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblCDrawbackIndex" runat="server" Text="Index" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 80%; text-align: left">
                                <asp:TextBox ID="txtCDrawbackIndex" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCirculars" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCircularsGroupType" runat="server" Text="GroupType" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:RadioButtonList ID="rdbCircularUploadType" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="true" OnSelectedIndexChanged="rdbCircularUploadType_SelectedIndexChanged">
                                    <asp:ListItem Selected="True">Circulars</asp:ListItem>
                                    <asp:ListItem>Instructions</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCircularYear" runat="server" Text="Year" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCircularYear" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCircularNumber" runat="server" Text="Circular Number" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCircularNumber" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCircularDate" runat="server" Text="Date" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCircularDate" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCircularFileName" runat="server" Text="File Name" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCircularFileNumber" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCircularSubject" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCircularSubject" runat="server" TextMode="MultiLine" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCTariff" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCtariffheading" runat="server" Text="Group" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:DropDownList ID="ddlCtariffheading" runat="server" CssClass="nls" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlCtariffheading_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCtariffsubheading" runat="server" Text="Sub Group" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:UpdatePanel ID="uplCtariffsubheading" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCtariffsubheading" runat="server" CssClass="nls" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlCtariffsubheading_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlCtariffheading" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCtariffSchemes" runat="server" Text="Schemes" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:UpdatePanel ID="uplCtariffSchemes" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlCtariffSchemes" runat="server" CssClass="nls">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlCtariffsubheading" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCtariffchapter" runat="server" Text="Index" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCtariffchapter" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCtariffChaptername" runat="server" Text="Chapter Name" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCtariffChaptername" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCtariffsubj" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCtariffsubj" runat="server" TextMode="MultiLine" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlSTCaselaws" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%;text-align: right">
                                <asp:Label ID="lblCLcitation" runat="server" Text="TGOL Citation" CssClass="nlsN"></asp:Label>
                            </td>
                            <td  style="width: 90%">
                                <asp:TextBox ID="txtCLcitationyear" runat="server" CssClass="nlss" Columns="5"></asp:TextBox>
                                <asp:Label ID="lbltgol" runat="server" Text="-TGOL-" CssClass="nlsN"></asp:Label>
                           
                                <asp:TextBox ID="txtClNumber" runat="server" CssClass="nlss" Columns="5"></asp:TextBox>
                            
                                <asp:Label ID="lblhypen" runat="server" Text="-" CssClass="nlsN"></asp:Label>
                           
                                <asp:TextBox ID="txtCL" runat="server" CssClass="nlss" Columns="6"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Should be 4 digit year" ControlToValidate="txtCLcitationyear" ValidationExpression="\d{4}"></asp:RegularExpressionValidator>
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCLcourt" runat="server" Text="Court" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:DropDownList ID="ddlCLlawscourt" runat="server" CssClass="nls"  AutoPostBack="True" onselectedindexchanged="ddlCLlawscourt_SelectedIndexChanged">
                                    <asp:ListItem Value="">--Select One--</asp:ListItem>
                                    <asp:ListItem Value="Supreme Court of India, New Delhi">Supreme Court of India</asp:ListItem>
                                    <asp:ListItem>High Court</asp:ListItem>
                                    <asp:ListItem>CESTAT</asp:ListItem>
                                    <asp:ListItem>CEGAT</asp:ListItem>
                                    <asp:ListItem>ATFE</asp:ListItem>
                                    <asp:ListItem>TRIBUNAL</asp:ListItem>
                                    <asp:ListItem>Revisionary Authority</asp:ListItem>
                                    <asp:ListItem>Settlement Commossion</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                        <td style="text-align: right">
                            <asp:Label Font-Size="14px" runat="server" ID="lblOther" Visible="False">Other Court</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlOtherCourt" runat="server" CssClass="nls" Visible="False">
                                <asp:ListItem Value="">--Select One--</asp:ListItem>
                                <asp:ListItem>CBEC</asp:ListItem>
                                <asp:ListItem>Authority for Advance Rulings</asp:ListItem>
                                <asp:ListItem>DGFT</asp:ListItem>
                                <asp:ListItem>G.O.I</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label Font-Size="14px" runat="server" ID="lblBench" Visible="False">Bench</asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBench" runat="server" CssClass="nls" Visible="False">
                                <asp:ListItem Value="">--Select One--</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblCLcasenumber" runat="server" Text="Case Number" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 80%; text-align: left">
                                <asp:TextBox ID="txtCLcasenumber" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCLAPPELLANTParty" runat="server" Text="APPELLANT Party" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCLAPPELLANTParty" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCLrespondentparty" runat="server" Text="Respondent Party" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCLrespondentparty" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCTjudgesname" runat="server" Text="Judge's Name" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCLjudgesname" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCLdateofdec" runat="server" Text="Date Of Decision" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCLdateofdec" runat="server" CssClass="nls"></asp:TextBox>
                                <asp:Image ID="imgCal" runat="server" ImageUrl="~/images/c.jpg" style="height:15px;width:15px;"/>
                                <span
                                    style="font-size: smaller; color: Gray;">(MM-DD-YYYY)</span>
                                <asp:CalendarExtender ID="cldate" runat="server" TargetControlID="txtCLdateofdec" PopupButtonID="imgCal" Format="MM-dd-yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCLJinFavour" runat="server" Text="Judgement in Favour Of" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                            <asp:DropDownList ID="txtCLJinFavour" runat="server" CssClass="nls">
                                <asp:ListItem Value="">--Select One--</asp:ListItem>
                                <asp:ListItem>Party</asp:ListItem>
                                <asp:ListItem>Revenue</asp:ListItem>
                                <asp:ListItem>Remand</asp:ListItem>
                                <asp:ListItem>Partially Allowed</asp:ListItem>
                                  <asp:ListItem>Stay Granted</asp:ListItem>
                                <asp:ListItem>Stay Rejected</asp:ListItem>
                                <asp:ListItem>Pre-Deposit Ordered</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align:center">
                                <asp:Label ID="lblheadnotes" runat="server" Text="Head Notes" CssClass="nlsN" Font-Size="Large" Font-Bold="True"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td colspan="2">
                                <asp:Editor ID="edtCLheadnotes" runat="server" CssClass="hidden" BorderWidth="1px" />
                            </td>
                        </tr>
                        <tr><td>&nbsp;</td></tr>
                        <tr>
                            <td style="text-align: center" colspan="2">
                                <asp:Label ID="lblJcontent" runat="server" Text="Judgement" Font-Bold="true" Font-Size="Large" CssClass="nlsN"></asp:Label>
                            </td>
                            </tr>
                            <tr>
                            <td colspan="2">
                                <asp:Editor ID="edtCLcontent" runat="server" CssClass="hidden" BorderWidth="1px" Height="400px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlDGFTFTDR" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTFTDRindex" runat="server" Text="Index" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTFTDRindex" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTFTDR" runat="server" Text="Notification Number" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTFTDRnotificationnum" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTFTDRdate" runat="server" Text="Date" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTFTDRdate" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTFTDRSUB" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTFTDRsub" runat="server" CssClass="nls" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlDGFTFTP" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblpnlDGFTFTPindex" runat="server" Text="Index" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 40%; text-align: left">
                                <asp:TextBox ID="txtpnlDGFTFTPindex" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTFTPsubject" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 40%; text-align: left">
                                <asp:TextBox ID="txtDGFTFTPsubject" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTFTPchaptername" runat="server" Text="ChapterName" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 40%; text-align: left">
                                <asp:TextBox ID="txtDGFTFTPchaptername" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlDGFTpublicnotices" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTpublicnoticeindex" runat="server" Text="Index" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTpublicnoticeindex" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTpublicnoticenum" runat="server" Text="Notice Number" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTpublicnoticenum" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTpublicnoticedate" runat="server" Text="Date" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTpublicnoticedate" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTpublicnoticesubject" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTpublicnoticesubject" runat="server" CssClass="nls" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlStNotifications" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblSTNYear" runat="server" Text="Year" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtSTNYear" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblSTNFNumber" runat="server" Text="File Number" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtSTNFNumber" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblSTNDate" runat="server" Text="Date" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtSTNDate" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblSTNSubject" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtSTNSubject" runat="server" TextMode="MultiLine" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCECnotifications" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCECGroupType" runat="server" Text="Group Type" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:RadioButtonList ID="rdbCECType" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="true">
                                    <asp:ListItem>Tariff</asp:ListItem>
                                    <asp:ListItem>Non-Tariff</asp:ListItem>
                                    <asp:ListItem>Safeguards</asp:ListItem>
                                    <asp:ListItem>Anti Dumping Duty</asp:ListItem>
                                    <asp:ListItem>Others</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCECYear" runat="server" Text="Year" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCECYear" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCECFnumber" runat="server" Text="File Number" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCECFnumber" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCECDate" runat="server" Text="Date" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCECDate" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCECSubject" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCECSubject" runat="server" TextMode="MultiLine" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <%-- Income tax --%>
                <asp:Panel ID="pnlITType" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblITType" runat="server" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 80%; text-align: left">
                                <asp:DropDownList ID="ddlITActType" runat="server" CssClass="nls" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlITActType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <%-- IncomeTax/WealthTax --%>
                <asp:Panel ID="pnlITIncomeWealthAct" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblSectionNo" runat="server" CssClass="nlsN" Text="Section No"></asp:Label>
                            </td>
                            <td style="width: 80%; text-align: left">
                                <asp:TextBox ID="txtSectionNo" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblSectionName" runat="server" CssClass="nlsN" Text="Section Name"></asp:Label>
                            </td>
                            <td style="width: 80%; text-align: left">
                                <asp:TextBox ID="txtSectionName" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <%-- Finance Tax --%>
                <asp:Panel ID="pnpITFinanceAct" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblGroup" runat="server" CssClass="nlsN" Text="Group"></asp:Label>
                            </td>
                            <td style="width: 80%; text-align: left">
                                <asp:DropDownList ID="ddlGroup" runat="server" CssClass="nls">
                                    <asp:ListItem>Select one</asp:ListItem>
                                    <asp:ListItem>Preliminary</asp:ListItem>
                                    <asp:ListItem>Rates Of Income-Tax</asp:ListItem>
                                    <asp:ListItem>Direct Taxes</asp:ListItem>
                                    <asp:ListItem>Miscellaneous</asp:ListItem>
                                    <asp:ListItem>Schedule</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblHeadings" runat="server" CssClass="nlsN" Text="Heading"></asp:Label>
                            </td>
                            <td style="width: 80%; text-align: left">
                                <asp:TextBox ID="txtHeadings" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <%-- IT Circulars/Notifications --%>
                <asp:Panel ID="pnlITCirculars" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblITCircularNo" runat="server" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 80%; text-align: left">
                                <asp:TextBox ID="txtITCircularNo" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblITCircularDate" runat="server" CssClass="nlsN" Text="Date"></asp:Label>
                            </td>
                            <td style="width: 80%; text-align: left">
                                <asp:TextBox ID="txtITCircularDate" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnllibrary" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblindexlibrary" runat="server" Text="Index" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 40%; text-align: left">
                                <asp:TextBox ID="txtindexlibrary" runat="server" CssClass="nls"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="Panel1" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 30px; margin-bottom: 30px">
                        <tr>
                            <td style="width: 30%; text-align: center">
                            </td>
                            <td style="width: 65%; text-align: center">
                                <asp:RadioButtonList ID="rdbUploadType" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="true" OnSelectedIndexChanged="rblUploadType_SelectedIndexChanged">
                                    <asp:ListItem>Paste the Document</asp:ListItem>
                                    <asp:ListItem>Upload the Document</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="width: 5%; text-align: center">
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Label ID="lblPasteHere" runat="server" Text="Paste the documents here" CssClass="nls"></asp:Label>
                <asp:Editor ID="edtData" runat="server" CssClass="hidden" />
                <asp:Label ID="lblUploadDoc" runat="server" Text="Upload the document" CssClass="nls"></asp:Label>
                <asp:FileUpload ID="uploadDocument" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="lbshowDoc" runat="server" Visible="false" Text="Show Existing Document"
                    target="_blank" OnClick="lbshowDoc_Click"></asp:Button>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
