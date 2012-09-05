<%@ Page Title="Data" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="shownotifications.aspx.cs" Inherits="TaxGenieOnline.shownotifications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <div align="left" class="contentboxmiddle1 shdw shd">
                <div align="right">
                      <a class="back" href='javascript:window.history.back();'></a>
                    </div>
                   <%--<div align="left" >
                        <br />--%>
                        <div class="doc">
                            <asp:Literal ID="ltl" runat="server"></asp:Literal>
                            <asp:Label ID="lbldata" runat="server"></asp:Label>
                            <br />
                        </div>
                    
                   </div>
                </div>
            </div>
    
</asp:Content>
