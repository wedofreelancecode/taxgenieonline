<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true" CodeBehind="ShowTaxUpdates.aspx.cs" Inherits="TaxGenieOnline.ShowTaxUpdates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
 <div align="right">
        <a class="back" href='javascript:window.history.back();'></a>
    </div>
    <asp:Label ID="lblHeading" runat="server" Width="100%" CssClass="nlsH" BackColor="#D9D9D9"></asp:Label>
    <br />
    <div class="rss-box" style="min-height: 300px">
            <asp:Repeater ID="dlTaxUpdates" runat="server">
                <ItemTemplate>
                    <a class="rss-item" href='/ViewTaxUpdate.aspx?Id=<%# Eval("Id") %>'>
                            <img src='<%# Eval("ImgPath") %>' alt="" width="203" height="148" />
                            </a><br />
                </ItemTemplate>
            </asp:Repeater>
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
