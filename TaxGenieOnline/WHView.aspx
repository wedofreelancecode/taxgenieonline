<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="WHView.aspx.cs" Inherits="TaxGenieOnline.WHView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="contentbox">
        <div align="left" class="contentboxmiddle1 shdw shd" style="min-height: 300px;">
            <div align="right">
                <a class="back" href='javascript:window.history.back();'></a>
            </div>
            <div align="center">
            <asp:Label ID="lblHeading" runat="server" Width="100%" CssClass="nlsH" BackColor="#D9D9D9" Text="What's New"></asp:Label>
                <br />
                <table width="300px">
                <asp:Repeater ID="dlWhats" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="whnew">
                                <%# Eval("Category")%>
                            </td>
                            <td width="10px" class="whnew">
                                :
                            </td>
                            <td class="whnew">
                                <a href='WHShow.aspx?Id=<%# Eval("Id1") %>'>
                                    <%# Eval("Title1") %></a>
                            </td>
                            <td class="whnew">
                                <a href='WHShow.aspx?Id=<%# Eval("Id2") %>'>
                                    <%# Eval("Title2") %></a>
                            </td>
                            <td class="whnew">
                                <a href='WHShow.aspx?Id=<%# Eval("Id3") %>'>
                                    <%# Eval("Title3") %></a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
