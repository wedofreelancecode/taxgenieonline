<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="searchdata.aspx.cs" Inherits="TaxGenieOnline.searchdata" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl22 fleft">
        <div class="contentbox">
            <img src="images/middle_box_top.png" width="501" height="4" alt="" />
            <div class="contentboxmiddle1 shdw shd">
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="left">
                        <asp:Literal ID="ltlData" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <img src="images/middle_box_bottom.png" width="501" height="6" alt="" />
        </div>
    </div>
</asp:Content>
