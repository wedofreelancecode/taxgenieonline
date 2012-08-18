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
                                <asp:TextBox ID="txtCRulesIndex" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblSubRulesChapterName" runat="server" Text="Chapter Name" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 23%; text-align: left">
                                <asp:TextBox ID="txtSubRulesChapterName" runat="server" CssClass="nl2"></asp:TextBox>
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
                                <asp:TextBox ID="txtCRegulationsIndex" runat="server" CssClass="nl2"></asp:TextBox>
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
                                <asp:TextBox ID="txtCFormsIndex" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblFormsSubject" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtFormsSubject" runat="server" CssClass="nl2"></asp:TextBox>
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
                                <asp:TextBox ID="txtCSEZNotficationNo" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCSEZSubject" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCSEZSubject" runat="server" CssClass="nl2"></asp:TextBox>
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
                                <asp:TextBox ID="txtCDrawbackIndex" runat="server" CssClass="nl2"></asp:TextBox>
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
                                <asp:TextBox ID="txtCircularYear" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCircularNumber" runat="server" Text="Circular Number" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCircularNumber" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCircularDate" runat="server" Text="Date" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCircularDate" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCircularFileName" runat="server" Text="File Name" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCircularFileNumber" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCircularSubject" runat="server" Text="Subject" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCircularSubject" runat="server" TextMode="MultiLine" CssClass="nl2"></asp:TextBox>
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
                                <asp:TextBox ID="txtCtariffchapter" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCtariffChaptername" runat="server" Text="Chapter Name" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCtariffChaptername" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCtariffsubj" runat="server" Text="Subject" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCtariffsubj" runat="server" TextMode="MultiLine" CssClass="nl2"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlSTCaselaws" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblSTCaselaws" runat="server" Text="Index" CssClass="nlsN"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtSTCaselaws" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlDGFTFTDR" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTFTDRindex" runat="server" Text="Index" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTFTDRindex" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlDGFTFTP" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblpnlDGFTFTPindex" runat="server" Text="Index" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 40%; text-align: left">
                                <asp:TextBox ID="txtpnlDGFTFTPindex" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTFTPsubject" runat="server" Text="Subject" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 40%; text-align: left">
                                <asp:TextBox ID="txtDGFTFTPsubject" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTFTPchaptername" runat="server" Text="ChapterName" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 40%; text-align: left">
                                <asp:TextBox ID="txtDGFTFTPchaptername" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlDGFTpublicnotices" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTpublicnoticeindex" runat="server" Text="Index" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTpublicnoticeindex" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTpublicnoticenum" runat="server" Text="Notice Number" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTpublicnoticenum" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTpublicnoticedate" runat="server" Text="Date" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTpublicnoticedate" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblDGFTpublicnoticesubject" runat="server" Text="Subject" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtDGFTpublicnoticesubject" runat="server" CssClass="nl" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlStNotifications" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblSTNYear" runat="server" Text="Year" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtSTNYear" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblSTNFNumber" runat="server" Text="File Number" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtSTNFNumber" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblSTNDate" runat="server" Text="Date" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtSTNDate" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblSTNSubject" runat="server" Text="Subject" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtSTNSubject" runat="server" TextMode="MultiLine" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnlCECnotifications" Width="100%" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCECGroupType" runat="server" Text="Group Type" CssClass="nls"></asp:Label>
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
                                <asp:Label ID="lblCECYear" runat="server" Text="Year" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCECYear" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCECFnumber" runat="server" Text="File Number" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCECFnumber" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCECDate" runat="server" Text="Date" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCECDate" runat="server" CssClass="nl"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 10%; text-align: right">
                                <asp:Label ID="lblCECSubject" runat="server" Text="Subject" CssClass="nls"></asp:Label>
                            </td>
                            <td style="width: 90%; text-align: left">
                                <asp:TextBox ID="txtCECSubject" runat="server" TextMode="MultiLine" CssClass="nl"></asp:TextBox>
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
                                <asp:TextBox ID="txtSectionNo" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblSectionName" runat="server" CssClass="nlsN" Text="Section Name"></asp:Label>
                            </td>
                            <td style="width: 80%; text-align: left">
                                <asp:TextBox ID="txtSectionName" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <%-- Finance Tax --%>
                <asp:Panel ID="pnpITFinanceAct" runat="server">
                    <table width="100%" style="margin-top: 20px">
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblGroup" runat="server" CssClass="nls" Text="Group"></asp:Label>
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
                                <asp:TextBox ID="txtHeadings" runat="server" CssClass="nl2"></asp:TextBox>
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
                                <asp:TextBox ID="txtITCircularNo" runat="server" CssClass="nl2"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; text-align: right">
                                <asp:Label ID="lblITCircularDate" runat="server" CssClass="nlsN" Text="Date"></asp:Label>
                            </td>
                            <td style="width: 80%; text-align: left">
                                <asp:TextBox ID="txtITCircularDate" runat="server" CssClass="nl2"></asp:TextBox>
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