<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="adResult.aspx.cs" Inherits="TaxGenieOnline.adResult" %>

<%@ Register Assembly="TaxGenieOnline" Namespace="TaxGenieOnline.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <div class="contentboxmiddle1 shdw" style="min-height: 300px;">
                <div style="width: 100%; text-align: center">
                    <asp:LinkButton ID="RefSrch" runat="server" CssClass="srchL srchCL" 
                        onclick="RefSrch_Click">Refine Current Search</asp:LinkButton>
                    <img style="margin-top: 5px" src="images/slogo.png"></img>
                    &nbsp;<asp:Label ID="lblHeading" runat="server" CssClass="nlsH" Style="vertical-align: middle;
                        padding: 5px">Case Laws Search <span style="font-style:italic">Results</span></asp:Label>
                    <asp:LinkButton ID="NewSrch" runat="server" CssClass="srchR srchCL" 
                        PostBackUrl="~/adSearch.aspx">New CaseLaw Search</asp:LinkButton><hr style="width: 50%" />
                    <br />
                </div>
                <asp:PagerControl ID="UPager" runat="server" OnCommand="UPager_Command" PageSize="10"
                    Font-Bold="True" GenerateSmartShortCuts="True" GeneratePagerInfoSection="True" GenerateHiddenHyperlinks="True" GenerateFirstLastSection="True" GenerateToolTips="True" />
                    <hr style="width:100%"/>
                <div class="clres" style="width: 100%">
                <asp:Label runat="server" ID="nores" Visible="false">No Result Found.</asp:Label>
                    <asp:Repeater ID="repSrcResult" runat="server">
                        <ItemTemplate>
                            <img style="margin-top: 5px" src="images/slogo.png" />
                            <a href="/shownotifications.aspx?citation=<%# Eval("TGOLCitation")%>&cat=<%# Eval("Category").ToString().Split(" ".ToCharArray())[0]%>&subcat=Case">
                                <%# Eval("TGOLCitation").ToString().ToUpper()%></a><br />
                            <br />
                            <b style="font-weight: bold">In Favour Of : </b>
                            <%# Eval("JudgementinFavourof")%>
                            <br />
                            <br />
                            <div>
                                <%# Eval("APPELLANTParty")%>
                                vs
                                <%# Eval("RESPONDENTParty")%></div>
                            <br />
                            <div>
                                Date of decision -
                                <%# Eval("DateofDecision")%></div>
                            <br />
                            <p>
                                <%# Eval("HeadNotes")%><br />
                            </p>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                    <br />
                </div>
                <asp:PagerControl ID="DPager" runat="server" OnCommand="UPager_Command" PageSize="10"
                    Font-Bold="True" GenerateSmartShortCuts="True" GeneratePagerInfoSection="True" GenerateHiddenHyperlinks="True" GenerateFirstLastSection="True" GenerateToolTips="True" />
                   
                <asp:HiddenField ID="Keyword" runat="server" Value="0" />
                <asp:HiddenField ID="Court" runat="server" Value="0" />
                <asp:HiddenField ID="Bench" runat="server" Value="0" />
                <asp:HiddenField ID="JudgeName" runat="server" Value="0" />
                <asp:HiddenField ID="SearchType" runat="server" Value="0" />
                <asp:HiddenField ID="SearchCat" runat="server" Value="0" />
                <asp:HiddenField ID="CaseNo" runat="server" Value="0" />
                <asp:HiddenField ID="PartyName" runat="server" Value="0" />
                <asp:HiddenField ID="Citation" runat="server" Value="0" />
                <asp:HiddenField ID="Year" runat="server" Value="0" />
                <asp:HiddenField ID="Volume" runat="server" Value="0" />
                <asp:HiddenField ID="CPage" runat="server" Value="0" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
