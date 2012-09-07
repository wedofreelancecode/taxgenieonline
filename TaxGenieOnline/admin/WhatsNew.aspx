<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true" CodeBehind="WhatsNew.aspx.cs" Inherits="TaxGenieOnline.admin.WhatsNew" %>
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
                            <asp:DropDownList ID="ddlcatagory" runat="server" CssClass="nls">
                                <asp:ListItem>select one</asp:ListItem>
                                <asp:ListItem Value="EX">Central Excise</asp:ListItem>
                                <asp:ListItem Value="CUS">Customs</asp:ListItem>
                                <asp:ListItem Value="S.TAX">Service Tax</asp:ListItem>
                                <asp:ListItem Value="DGFT">DGFT</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTitle" runat="server" Text="Title" CssClass="nlsN"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="nls" MaxLength="6"></asp:TextBox>
                             <asp:Label ID="lblTip" runat="server" Text="(Maximum 6 characters)" Font-Size="Smaller" ForeColor="Gray"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Editor ID="edtData" runat="server" Width="100%" Height="400px" />
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
