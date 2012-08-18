<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="HomeContentEditor.aspx.cs" Inherits="TaxGenieOnline.admin.HomeContentEditor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <div class="contentboxmiddle1 shdw" style="min-height: 300px;">
                <table style="width: 100%; margin-top: 5px;">
                    <tr>
                        <td style="width: 40%; text-align: right">
                            <asp:Label ID="lblContentType" runat="server" Text="Content Type" CssClass="nlsN"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlContentType" CssClass="nls" AutoPostBack="true" 
                                runat="server" onselectedindexchanged="ddlContentType_SelectedIndexChanged">
                                <asp:ListItem>select one</asp:ListItem>
                                <asp:ListItem>Department News</asp:ListItem>
                                <asp:ListItem>Editor Desk</asp:ListItem>
                                <asp:ListItem>Case Analysis</asp:ListItem>
                                <asp:ListItem>Left Guest</asp:ListItem>
                                <asp:ListItem>Right Guest</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTitle" runat="server" Text="Title" CssClass="nlsN"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="nls"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Editor ID="edtHomeContent" runat="server" Width="100%" Height="400px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" 
                                onclick="btnUpload_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
