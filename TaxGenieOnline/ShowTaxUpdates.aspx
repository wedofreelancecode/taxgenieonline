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
                <dir>
                    <a href='/ViewTaxUpdate.aspx?Id=<%# Eval("Id") %>'><%# Eval("Title") %>
                            <img src='<%# Eval("ImgPath") %>' alt="" width="50" height="40" class="txtwrap" />
                            </a><br />
                            <label> Published:<%# Eval("DateTime") %></label>
                            </dir><br />
                </ItemTemplate>
            </asp:Repeater>
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
