<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="TaxUpdateEditor.aspx.cs" Inherits="TaxGenieOnline.admin.TaxUpdateEditor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <div class="contentboxmiddle1 shdw" style="min-height: 300px;">
                <asp:Label ID="lblHeading" runat="server" Width="100%" CssClass="nlsH" Text="Tax Update"
                    BackColor="#D9D9D9"></asp:Label>
                <table style="width: 100%; margin-top: 5px;">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblImage" runat="server" Text="Image" CssClass="nlsN"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:FileUpload ID="fuImage" runat="server" CssClass="nls"></asp:FileUpload>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Editor ID="edtTaxUpdate" runat="server" Width="100%" Height="400px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
