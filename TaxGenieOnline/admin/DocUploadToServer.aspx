<%@ Page Title="TaxGenieOnline" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="DocUploadToServer.aspx.cs" Inherits="TaxGenieOnline.admin.DocUploadToServer" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <div class="contentboxmiddle1 shdw" style="min-height: 300px;">
                <asp:Label ID="lblHeading" runat="server" Width="100%" CssClass="nlsH" Text="Document Upload To Server"
                    BackColor="#D9D9D9"></asp:Label>
                <table style="width: 100%; margin-top: 5px;">
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblDoc" runat="server" Text="Please Select a Document or File" CssClass="nlsN"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:FileUpload ID="fuDoc" runat="server" CssClass="nls"></asp:FileUpload>
                        </td>
                    </tr>                    
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btnDocUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                        </td>
                    </tr>
                </table>
                 <asp:Repeater ID="dlDocs" runat="server">
                        <ItemTemplate>
                            <a style="font-size:12px;font-weight:bold;color:#08F" href='<%# Eval("href") %>' target="_blank"><br />
                            <%# Eval("href") %>...</a>
                        </ItemTemplate>
                    </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
