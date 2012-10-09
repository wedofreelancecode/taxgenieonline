﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="EditTaxUpdate.aspx.cs" Inherits="TaxGenieOnline.admin.EditTaxUpdate" %>
    <%@ Register Assembly="TaxGenieOnline" Namespace="TaxGenieOnline.Controls" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <%-- <img src="../images/middle_box_top.png" width="726" height="4" alt="" />--%>
            <div class="contentboxmiddle1 shdw shd" style="min-height: 300px;">
            <br />
            <asp:Label ID="lblHeading" runat="server" Width="100%" CssClass="nlsH" Text="Edit Tax Updates" BackColor="#D9D9D9"></asp:Label>
            <br />
            <br />
                 <asp:PagerControl ID="UPager" runat="server" OnCommand="UPager_Command" PageSize="10"
                    Font-Bold="True" GenerateSmartShortCuts="True" GeneratePagerInfoSection="True" GenerateHiddenHyperlinks="True" GenerateFirstLastSection="True" GenerateToolTips="True" />
                <asp:GridView ID="gvTaxUpdate" Width="100%" runat="server" BorderWidth="2px"
                    AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" 
                    onrowediting="gvTaxUpdate_RowEditing" 
                     onrowdeleting="gvTaxUpdate_RowDeleting">
                     <HeaderStyle BackColor="#D9D9D9" ForeColor="#002700" Height="25px" CssClass="nlsHl" />
                     <AlternatingRowStyle BackColor="#d0d0d0"></AlternatingRowStyle>
                     <RowStyle CssClass="eg" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>