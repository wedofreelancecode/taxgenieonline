<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="AddClients.aspx.cs" Inherits="TaxGenieOnline.AddClients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
<asp:HiddenField ID="hdnId" runat="server" />
    <div class="cl2 fleft" style="margin-bottom: 4px">
        <div class="contentboxmiddle1 shdw shd">
            <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                <a style="float: right" class="back" href='javascript:window.history.back();'></a>
                <br />
                <div align="center">
                    
                    <span class="nlsH"><b><br />Enter the Company Name here</b></span>
                    <br />
                    <asp:TextBox ID="txtcmpname" runat="server" CssClass="nls" Width="357px"></asp:TextBox>
                    
                    <span class="nlsH"><b>
                    <br />
                    Enter the Company Address here</b></span>
                    <br />
                    <textarea id="taNews" rows="5" runat="server" cols="50"></textarea>
                    <br />
                    <div align="center">
                        <asp:Button ID="btnupload" runat="server" Text="Upload" OnClick="btnupload_Click" /></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
