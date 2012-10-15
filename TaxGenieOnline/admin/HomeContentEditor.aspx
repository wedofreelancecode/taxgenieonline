<%@ Page Title="TaxGenieOnline" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="HomeContentEditor.aspx.cs" Inherits="TaxGenieOnline.admin.HomeContentEditor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <div class="contentboxmiddle1 shdw" style="min-height: 300px;">
            <asp:HiddenField ID="hdnId" runat="server" />
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
                    <tr><asp:panel ID="pnlimg" runat="server">
                        <td align="right">
                            <asp:Label ID="lblImage" runat="server" Text="Image" CssClass="nlsN"></asp:Label>
                        </td>
                        <td align="left">
                            <asp:FileUpload ID="fuImage" runat="server" CssClass="nls"></asp:FileUpload>
                        </td></asp:panel>
                    </tr>
                     <tr>
                  
                    
                    
                        <td align="right">
                            <asp:Label ID="lblimg" Visible="false" runat="server" Text="Actual Image" CssClass="nlsN"></asp:Label>
                        </td>
                        <td align="left" style="padding-left:5px;">
                            <asp:Image ID="actImg" Width="200" Height="200" Visible="false" runat="server"></asp:Image>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" style="padding:10px">
                            <asp:Label ID="lblTitle" runat="server" Text="Title" CssClass="nlsN"
                                Font-Bold="True" Font-Size="12pt" Font-Underline="False" ></asp:Label>
                        </td>
                    </tr>
                      <tr>
                        <td colspan="2" align="center">
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="nls" Rows="4"
                                TextMode="MultiLine" Width="95%"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td colspan="2" align="center" style="padding:10px">
                            <asp:Label ID="Label1" runat="server" Text="Content" CssClass="nlsN"
                                Font-Bold="True" Font-Size="12pt" Font-Underline="False" ></asp:Label>
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
