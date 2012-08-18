<%@ Page Title="Unauthorized Access" Language="C#" MasterPageFile="~/TaxGenie.Master" AutoEventWireup="true"
    CodeBehind="UnauthorizedAccess.aspx.cs" Inherits="TaxGenieOnline.UnauthorizedAccess" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <img src="images/middle_box_top.png" width="501" height="4" alt="" />
            <div class="contentboxmiddle">
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="center">
                        <h2>
                            Unauthorized Access</h2>
                        <p>
                            You have attempted to access a page that you are not authorized to view.
                        </p>
                        <p>
                            If you have any questions, please contact the site administrator.
                        </p>
                    </div>
                </div>
            </div>
            <img src="images/middle_box_bottom.png" width="501" height="6" alt="" />
        </div>
    </div>
</asp:Content>
