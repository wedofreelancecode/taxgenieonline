<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true" CodeBehind="Clients.aspx.cs" Inherits="TaxGenieOnline.Clients" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">

 <div class="cl22 fleft">
<div class="contentbox">
            <img src="images/middle_box_top.png" width="501" height="4" />
            <div class="contentboxmiddle">
                <div style="background-image: url(images/blue.png); width: 481px; height: 28px; padding: 10px 0px 0px 10px;
                    color: White; font: normal 1.1em Times New Roman;">
                    Clients
                </div>
                <div class="ab">
                <br /><br />
                     <asp:Repeater ID="dlClients" runat="server">
                            <ItemTemplate>
                               <span style="font-weight:bold"> <%# Eval("Client_Name")%></span>
                                <br />
                               <%# Eval("Address")%>
                               <br />
                               <br />
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
            </div>
            <img src="images/middle_box_bottom.png" width="501" height="6" />
        </div>
   </div>

</asp:Content>

