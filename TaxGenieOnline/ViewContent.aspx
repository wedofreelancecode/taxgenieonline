<%@ Page Title="TaxGenieOnline" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="ViewContent.aspx.cs" Inherits="TaxGenieOnline.ViewContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="contentbox">
        <div align="left" class="contentboxmiddle1 shdw shd" style="min-height: 300px;">
            <div align="right">
                <a class="back" href='javascript:window.history.back();'></a>
            </div>
            <div class="doc">
                <asp:Label ID="ltl" runat="server" Width="100%" CssClass="adminbtn"></asp:Label>
                <br /><br />
                <asp:Label ID="lbldata" runat="server" Width="100%"></asp:Label>
                <br /><br />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
