<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="ShowContents.aspx.cs" Inherits="TaxGenieOnline.ShowContents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div align="right">
        <a class="back" href='javascript:window.history.back();'></a>
    </div>
    <asp:Label ID="lblHeading" runat="server" Width="100%" CssClass="nlsH" BackColor="#D9D9D9"></asp:Label>
    <br />
    <div class="rss-box" style="min-height: 300px">
        <ul class="rss-items">
            <asp:Repeater ID="dlDeptNews" runat="server">
                <ItemTemplate>
                    <li class="rss-item"><a class="rss-item" href='/ViewContent.aspx?Id=<%# Eval("Id") %>'>
                        <%# Eval("Title") %></a><br />
                        <%# Eval("Data") %>...</li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <br />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
