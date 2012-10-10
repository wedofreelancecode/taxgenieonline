<%@ Page Title="TaxGenieOnline" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="uploadnews.aspx.cs" Inherits="TaxGenieOnline.uploadnews" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <%--<img src="../images/middle_box_top.png" width="726" height="4" alt="" />--%>
            <div class="contentboxmiddle1 shdw shd">
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="center">
                       <%-- <div align="right">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/admin/Adminpage.aspx">Back</asp:HyperLink></div>--%>
                        <div align="left">
                            <asp:Label ID="lblstatus" runat="server"></asp:Label>
                            <br />
                            <div class="nlsCentre"><b>Write content in below box OR Paste the document</b></div>
                            <br />
                            <br />
                            <cc1:Editor ID="Editor1" runat="server" Height="500px" Width="100%" />
                            <br />
                        </div>
                        <div align="center">
                            <table>
                                <tr>
                                    <td>
                                        <span class="nls">News Title:</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdocname" runat="server" CssClass="nl" Width="238px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="nls" style="float: right">Year:</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtyear" runat="server" CssClass="nl" Width="239px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="nls" style="float: right">Description:</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtdesc" runat="server" CssClass="nl" TextMode="MultiLine" Height="101px"
                                            Width="241px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnupload" runat="server" Text="Upload" OnClick="btnupload_Click" />
                                    </td>
                            
                                </tr>
                            </table>
                          
                        </div>
                    </div>
                </div>
            </div>
            <%--<img src="../images/middle_box_bottom.png" width="724" height="6" alt="" />--%>
        </div>
    </div>
</asp:Content>
