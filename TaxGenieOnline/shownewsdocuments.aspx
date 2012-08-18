<%@ Page Title="News" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="shownewsdocuments.aspx.cs" Inherits="TaxGenieOnline.admin.shownewsdocuments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <%-- <img src="images/middle_box_top.png" width="726" height="4" alt="" />--%>
            <div class="contentboxmiddle1 shdw shd">
                <div style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="center">
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
            <%-- <img src="images/middle_box_bottom.png" width="724" height="6" alt="" />--%>
        </div>
    </div>
</asp:Content>
