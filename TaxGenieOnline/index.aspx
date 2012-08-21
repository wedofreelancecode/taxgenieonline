﻿<%@ Page Title="Index" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="TaxGenieOnline.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <%-- <script type="text/javascript">
        function PostToNewWindow() {
            originalTarget = document.forms[0].target;
            document.forms[0].target = '_blank';
            window.setTimeout("document.forms[0].target=originalTarget;", 300);
            return true;
        } 
</script> --%>
    <div class="cl2 fleft">
        <asp:SiteMapPath ID="sitemap" runat="server" ParentLevelsDisplayed="2" Font-Bold="true"
            Font-Size="Small" ForeColor="Black">
        </asp:SiteMapPath>
        <asp:Label ID="sub" runat="server" />
        <div align="right">
            <a class="back" href='javascript:window.history.back();'></a>
        </div>
        <div class="newshldr" style="padding-top: 5px; padding-bottom: 10px; min-height: 200px">
            <div align="left" style="font: 13px Verdana;">
                <asp:DataList ID="dlIndex" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                    CaptionAlign="Top" OnItemCommand="dlIndex_ItemCommand" Width="100%">
                    <ItemTemplate>
                        <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                        &nbsp;
                        <asp:LinkButton ID="lnknames" runat="server" Text='<%# Eval("IndexName") %>' CommandName="Index"></asp:LinkButton>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <%--Custom Rules --%>
                <div>
                    <asp:Label ID="lblAgreements" runat="server" CssClass="nlsH" Width="100%"></asp:Label>
                    <asp:DataList ID="dlAgreements" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlAgreements_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkAgreements" runat="server" Text='<%# Eval("IndexName") %>'
                                CommandName="Agreements"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblBaggage" runat="server" CssClass="nlsH" Width="100%"></asp:Label>
                    <asp:DataList ID="dlBaggage" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlBaggage_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkBaggage" runat="server" Text='<%# Eval("IndexName") %>' CommandName="Baggage"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblCustomDrawBack" runat="server" Text="Customs Drawback Rules" CssClass="nlsH"
                        Width="100%"></asp:Label>
                    <asp:DataList ID="dlCustomDrawBack" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlCustomDrawBack_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkCustomDrawBack" runat="server" Text='<%# Eval("IndexName") %>'
                                CommandName="CustomDrawBack"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblCustomValuation" runat="server" Text="Customs Valuation Rules"
                        CssClass="nlsH" Width="100%"></asp:Label>
                    <asp:DataList ID="dlCustomValuation" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlCustomValuation_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkCustomValuation" runat="server" Text='<%# Eval("IndexName") %>'
                                CommandName="CustomValuation"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblOthers" runat="server" Text="Others" CssClass="nlsH" Width="100%"></asp:Label>
                    <asp:DataList ID="dlOthers" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlOthers_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkOthers" runat="server" Text='<%# Eval("IndexName") %>' CommandName="Others"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <%--Custom Forms --%>
                <div>
                    <asp:Label ID="lblApplicationForm" runat="server" Text="Application Forms" CssClass="nlsH"
                        BackColor="#D9D9D9" Width="100%"></asp:Label><br />
                    <br />
                    <asp:Label ID="lblRefunds" runat="server" Text="Refunds" CssClass="nlsH" Width="100%"></asp:Label>
                    <asp:DataList ID="dlRefunds" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlRefunds_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkRefunds" runat="server" Text='<%# Eval("IndexName") %>' CommandName="Refunds"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblAppeals" runat="server" Text="Appeals" CssClass="nlsH" Width="100%"></asp:Label>
                    <asp:DataList ID="dlAppeals" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlAppeals_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkAppeals" runat="server" Text='<%# Eval("IndexName") %>' CommandName="Appeals"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblDrawback" runat="server" Text="Drawback" CssClass="nlsH" Width="100%"></asp:Label>
                    <asp:DataList ID="dlDrawback" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlDrawback_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkDrawback" runat="server" Text='<%# Eval("IndexName") %>' CommandName="Drawback"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblOthersApplicationForms" runat="server" Text="Others" CssClass="nlsH"
                        Width="100%"></asp:Label>
                    <asp:DataList ID="dlOthersApplicationForms" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlOthersApplicationForms_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkOthersApplicationForms" runat="server" Text='<%# Eval("IndexName") %>'
                                CommandName="OthersApplicationForms"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblShipping" runat="server" Text="Shipping Bill Forms" CssClass="nlsH"
                        Width="100%"></asp:Label>
                    <asp:DataList ID="dlShipping" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlShipping_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkShipping" runat="server" Text='<%# Eval("IndexName") %>' CommandName="Shipping"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblBill" runat="server" Text="Bill of Entry Forms " CssClass="nlsH"
                        Width="100%"></asp:Label>
                    <asp:DataList ID="dllBill" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dllBill_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkBill" runat="server" Text='<%# Eval("IndexName") %>' CommandName="Bill"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblBonds" runat="server" Text="Bonds" CssClass="nlsH" Width="100%"></asp:Label>
                    <asp:DataList ID="dlBonds" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlBonds_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkBonds" runat="server" Text='<%# Eval("IndexName") %>' CommandName="Bonds"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblSettlementCommission" runat="server" Text="Settlement Commission"
                        CssClass="nlsH" Width="100%"></asp:Label>
                    <asp:DataList ID="dlSettlementCommission" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                        OnItemCommand="dlSettlementCommission_ItemCommand" CaptionAlign="Top">
                        <ItemTemplate>
                            <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                            &nbsp;
                            <asp:LinkButton ID="lnkSettlementCommission" runat="server" Text='<%# Eval("IndexName") %>'
                                CommandName="SettlementCommission"></asp:LinkButton>
                            <br />
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <%--Custom SEZ--%>
                <asp:GridView ID="gvSEZ" runat="server" AutoGenerateColumns="false" OnRowCommand="gvSEZ_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Notification No.">
                            <HeaderStyle BackColor="#D9D9D9" ForeColor="#002700" Height="15px" CssClass="nlsH" />
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSEZ" runat="server" Text='<%# Eval("IndexName") %>' CommandName="SEZ"></asp:LinkButton>
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Subjects" HeaderText="Subject in Brief">
                            <HeaderStyle BackColor="#D9D9D9" ForeColor="#002700" Height="15px" CssClass="nlsH" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle Height="30px"></RowStyle>
                    <AlternatingRowStyle BackColor="#d0d0d0"></AlternatingRowStyle>
                </asp:GridView>
                <%--Servicetax forms--%>
                <asp:GridView ID="gvservicetaxforms" runat="server" AutoGenerateColumns="False" OnRowCommand="gvservicetaxforms_RowCommand"
                    Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Form Type">
                            <HeaderStyle BackColor="#D9D9D9" ForeColor="#002700" Height="15px" CssClass="nlsH" />
                            <ItemTemplate>
                                <br />
                                <asp:LinkButton ID="lnkStforms" runat="server" Text='<%# Eval("IndexName") %>' CommandName="STForms" CommandArgument='<%# Eval("IsDoc") %>' ></asp:LinkButton>
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Subjects" HeaderText="Brief Description">
                            <HeaderStyle BackColor="#D9D9D9" ForeColor="#002700" Height="15px" CssClass="nlsH" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <%--Servicetaxacts--%>
                <asp:GridView ID="gvstacts" runat="server" AutoGenerateColumns="False" OnRowCommand="gvstacts_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                                &nbsp;
                                <asp:LinkButton ID="lnkStacts" runat="server" Text='<%# Eval("IndexName") %>' CommandName="STacts" CommandArgument='<%# Eval("IsDoc") %>'></asp:LinkButton>
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--servicetaxrules--%>
                <asp:GridView ID="gvstrules" runat="server" AutoGenerateColumns="False" BorderColor="#E7E7FF"
                    BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="gvstrules_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                                &nbsp;
                                <asp:LinkButton ID="lnkStrules" runat="server" Text='<%# Eval("IndexName") %>' CommandName="STrules" CommandArgument='<%# Eval("IsDoc") %>'></asp:LinkButton>
                                <br />
                                <br />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--Servicetaxaccodes--%>
                <asp:DataList ID="dtstaccodes" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                    CaptionAlign="Top" OnItemCommand="dtstaccodes_ItemCommand">
                    <ItemTemplate>
                        <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                        &nbsp;
                        <asp:LinkButton ID="lnkstaccodes" runat="server" Text='<%# Eval("IndexName") %>'
                            CommandName="accodes"></asp:LinkButton>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <%--Circulars/Instructions--%>
                <table width="100%">
                    <tr style="background: #D9D9D9">
                        <td style="width: 40%; text-align: center">
                            <asp:Label ID="lblCircularHeading" runat="server" Text="Circulars" CssClass="nlsH"></asp:Label>
                        </td>
                        <td width="20%">
                        </td>
                        <td style="width: 40%; text-align: center">
                            <asp:Label ID="lblInstructionHeading" runat="server" Text="Instructions" CssClass="nlsH"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 40%; text-align: center; vertical-align: top;">
                            <asp:DataList ID="dlIndexCirculars" runat="server" RepeatDirection="Vertical" CaptionAlign="Top"
                                OnItemCommand="dlIndexCirculars_ItemCommand" Width="100%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkcircular" runat="server" Text='<%# Eval("Year") %>' CommandName="CircularIndex"></asp:LinkButton>
                                    <br />
                                    <br />
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                        <td width="20%">
                        </td>
                        <td style="width: 40%; text-align: center; vertical-align: top;">
                            <asp:DataList ID="dlIndexInstrcutions" runat="server" RepeatDirection="Vertical"
                                CaptionAlign="Top" OnItemCommand="dlIndexInstrcutions_ItemCommand" Width="100%">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkinstruction" runat="server" Text='<%# Eval("Year") %>' CommandName="InstructionsIndex"></asp:LinkButton>
                                    <br />
                                    <br />
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </table>
                <%--Tariff--%>
                <asp:Literal ID="ltlIndex" runat="server"></asp:Literal>
                <asp:Label ID="lblnorecords" runat="server" Visible="false" CssClass="nls"></asp:Label>
                <asp:Label ID="Label6" runat="server" Visible="false" CssClass="nls"></asp:Label>
                <%--ServicetaxCaseLaws--%>
                <asp:DataList ID="dlSTCaseLaws" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                    CaptionAlign="Top" OnItemCommand="dlSTCaseLaws_ItemCommand">
                    <%--OnItemCommand="dlSTCaseLaws_ItemCommand"--%>
                    <ItemTemplate>
                        <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                        &nbsp;
                        <asp:LinkButton ID="lnkSTCaseLaws" runat="server" Text='<%# Eval("IndexName") %>'
                            CommandName="STCaseLaws"></asp:LinkButton>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <asp:Panel ID="pnlSTlibraries" runat="server">
                    <a href="/shownotifications.aspx?cat=Library&subcat=Libraries" target="_blank">
                        <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />&nbsp;Service
                        Tax Libraries</a>
                </asp:Panel>
                <asp:Panel ID="pnlSTTaxation" runat="server">
                    <a href="/shownotifications.aspx?cat=Service Tax&subcat=Taxation of Services: An Educational Guide">
                        <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />&nbsp;Service
                        Tax Taxation </a>
                </asp:Panel>
                <asp:Panel ID="pnlCEManual" runat="server" Width="100%" CssClass="nlsH">
                    <asp:Label ID="CBESdesc" runat="server" Visible="True" CssClass="nlsStatic" Text="Please click the below link to View OR Download CBEC Manual"></asp:Label><br />
                    <a href="/shownotifications.aspx?cat=Service Tax&subcat=CBEC Manual" target="_blank">
                        CBEC Manual</a>
                </asp:Panel>
                <asp:DataList ID="dlDGFT" runat="server" ShowHeader="false" RepeatDirection="Vertical"
                    CaptionAlign="Top" OnItemCommand="dlDGFT_ItemCommand">
                    <%--OnItemCommand="dlDGFT_ItemCommand"--%>
                    <ItemTemplate>
                        <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                        &nbsp;
                        <asp:LinkButton ID="lnkDGFT" runat="server" Text='<%# Eval("IndexName") %>' CommandName="DGFT"></asp:LinkButton>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                <%--Income Tax Acts --%>
                <asp:DataList ID="dlITActs" runat="server" RepeatDirection="Vertical" CaptionAlign="Top"
                    Width="100%" OnItemCommand="dlITActs_ItemCommand">
                    <ItemTemplate>
                     <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />
                        &nbsp;
                        <asp:Label ID="lblSectionNo" runat="server" Text='<%# Eval("SectionNo") %>' CssClass="nls"></asp:Label>
                        <asp:LinkButton ID="lnkSectionHeading" runat="server" Text='<%# Eval("IndexName") %>'
                            CommandName="ITActs" CommandArgument='<%# Eval("IsDoc") %>'></asp:LinkButton>
                        <br />
                        <br />
                    </ItemTemplate>
                </asp:DataList>
                 <asp:DataList ID="dltariff" runat="server" RepeatDirection="Vertical" 
                                        CaptionAlign="Top" onitemcommand="dltariff_ItemCommand">
                                        <HeaderTemplate>
                                            Tariff</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnktariff" runat="server" Text='<%# Eval("Year") %>' CommandName="TariffIndex"></asp:LinkButton>
                                            <br />
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>
                                        <asp:DataList ID="dlnontariff" runat="server" RepeatDirection="Vertical"
                                        CaptionAlign="Top" onitemcommand="dlnontariff_ItemCommand">
                                        <HeaderTemplate>
                                            Non-Tariff</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnknontariff" runat="server" Text='<%# Eval("Year") %>' CommandName="NonTariffIndex"></asp:LinkButton>
                                            <br />
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>

                                     <asp:DataList ID="dlsafeguards" runat="server" RepeatDirection="Vertical"
                                        CaptionAlign="Top" onitemcommand="dlsafeguards_ItemCommand">
                                        <HeaderTemplate>
                                            Safeguards</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnksafeguards" runat="server" Text='<%# Eval("Year") %>' CommandName="SafeguardsIndex"></asp:LinkButton>
                                            <br />
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>
                                    <asp:DataList ID="dlantidumpingduty" runat="server" RepeatDirection="Vertical"
                                        CaptionAlign="Top" onitemcommand="dlantidumpingduty_ItemCommand">
                                        <HeaderTemplate>
                                            Anti Dumping Duty</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkantidumpingduty" runat="server" Text='<%# Eval("Year") %>' CommandName="AntiDumpingDutyIndex"></asp:LinkButton>
                                            <br />
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>
                                      <asp:DataList ID="dlCECothers" runat="server" RepeatDirection="Vertical"
                                        CaptionAlign="Top" onitemcommand="dlCECothers_ItemCommand" >
                                        <HeaderTemplate>
                                            Others</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkothers" runat="server" Text='<%# Eval("Year") %>' CommandName="others"></asp:LinkButton>
                                            <br />
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>
                                      <asp:DataList ID="dlSTN" runat="server" RepeatDirection="Vertical" CaptionAlign="Top"
                                        OnItemCommand="dlSTN_ItemCommand">
                                        <HeaderTemplate>
                                            ServiceTax Notifications</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkSTN" runat="server" Text='<%# Eval("Year") %>' CommandName="STN"></asp:LinkButton>
                                            <br />
                                            <br />
                                        </ItemTemplate>
                                    </asp:DataList>
                <asp:Panel ID="pnlITActsGift" runat="server">
                    <a href="/GiftTaxAct.htm" target="_blank">
                        <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />&nbsp;Gift Tax
                        Act</a>
                </asp:Panel>
                 <asp:Panel ID="pnlITActsInterest" runat="server">
                    <a href="/InterestTaxAct.htm" target="_blank">
                        <img src="images/BlueArrow.jpg" alt=">>" width="9px" height="9px" />&nbsp;Interest Tax
                        Act</a>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>