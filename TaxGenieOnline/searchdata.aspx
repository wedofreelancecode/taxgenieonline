<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="searchdata.aspx.cs" Inherits="TaxGenieOnline.searchdata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <div class="contentboxmiddle1 shdw shd" style="min-height: 300px; padding: 15px 10px 10px 30px">
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="left" style="width: 100%; margin-top: 5px;">
                        <div align="right">
                        
                            <a class="back" href='javascript:window.history.back();'></a>
                        </div>
                        <asp:Literal ID="ltlData" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
