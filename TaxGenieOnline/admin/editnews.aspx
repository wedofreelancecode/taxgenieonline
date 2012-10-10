<%@ Page Title="TaxGenieOnline" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="editnews.aspx.cs" Inherits="TaxGenieOnline.admin.editnews" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
    

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
           <%-- <img src="../images/middle_box_top.png" width="726" height="4" alt="" />--%>
            <div class="contentboxmiddle1 shdw shd">
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="center">
                  <%--  <div align="right">
                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/admin/Adminpage.aspx">Back</asp:HyperLink></div>--%>
                     <table>
                                <tr>
                                    <td>
                                        <span class="nls">Select Year:</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlyear_select" CssClass="nls" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span class="nls">News Title:</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddldoc" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlname_select" CssClass="nls" >
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        <cc1:Editor ID="Editor1" runat="server" Height="500px" Width="100%"/>
                            <%--<cc1:Editor ID="Editor1" runat="server"  />--%>
                            <asp:Button ID="btnupload" runat="server" Text="update" OnClick="btnupload_Click" />
 
                    </div>
                </div>
            </div>
           <%-- <img src="../images/middle_box_bottom.png" width="724" height="6" alt="" />--%>
        </div>
    </div>
</asp:Content>
