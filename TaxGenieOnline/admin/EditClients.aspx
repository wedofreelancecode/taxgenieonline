﻿<%@ Page Title="TaxGenieOnline" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true" CodeBehind="EditClients.aspx.cs" Inherits="TaxGenieOnline.admin.EditClients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
  <div class="cl2 fleft">
        <div class="contentbox" style="min-height: 300px;">
        <asp:Label ID="lblHeading" runat="server" Width="100%" CssClass="nlsH" Text="Edit Clients" BackColor="#D9D9D9"></asp:Label>
             <asp:GridView ID="clientsGrid" Width="100%" runat="server" 
                AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" 
                OnRowDeleting ="clientsGrid_RowDeleting" OnRowEditing="clientsGrid_RowEditing" >
                     <HeaderStyle BackColor="#D9D9D9" ForeColor="#002700" Height="25px" CssClass="nlsHl" />
                     <AlternatingRowStyle BackColor="#d0d0d0"></AlternatingRowStyle>
                     <RowStyle CssClass="eg" />
             </asp:GridView>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
