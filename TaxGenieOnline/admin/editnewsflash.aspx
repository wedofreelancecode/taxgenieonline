<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true" CodeBehind="editnewsflash.aspx.cs" Inherits="TaxGenieOnline.editnewsflash" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">

<div class="cl2 fleft">
        <div class="contentbox">
            <img src="../images/middle_box_top.png" width="501" height="4" alt="" />
            <div class="contentboxmiddle1 shdw shd">
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="center">
                    <table>
                                <tr>
                                    <td>
                                        <span class="nl">Select Year:</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="ddlyear_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    
                                </tr>
                                
                                <tr>
                                    <td>
                                        <span class="nl">Select Month:</span>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlmonthh" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="ddlmonth_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    </tr>
                                    </table>
                                <asp:DataList ID="dlnewsflash" runat="server" RepeatColumns="5" OnItemCommand="dlnewsflash_ItemCommand">
                                
                    <ItemTemplate>
                                             
                              
                             <span class="nls">
                                    <asp:LinkButton ID="lnkDocName" runat="server" Text='<%# Eval("[Newsflash]") %>' CommandName="description" ForeColor="#AA9898"></asp:LinkButton>&nbsp;&nbsp;&nbsp; </span>
                                                                   
                            </ItemTemplate>
                                                                     
                        </asp:DataList>
                        <br />
                        
                        <br />
                        <br />
                        <cc1:Editor ID="Editor1" runat="server" Height="500px" Width="95%" />
                        
                        <asp:Button ID="btnuploadnewsflash" runat="server" Text="update" OnClick="updatenewsflash"
                           />
 
                    
                    </div>
                </div>
            </div>
            <img src="../images/middle_box_bottom.png" width="501" height="6" alt="" />
        </div>
    </div>
</asp:Content>
