<%@ Page Title="Upload Flash News" Language="C#" MasterPageFile="~/TaxGenie.master"
    AutoEventWireup="true" CodeBehind="uploadnewsflash.aspx.cs" Inherits="TaxGenieOnline.admin.uploadnewsflash" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
<asp:HiddenField ID="hdnId" runat="server" />
    <div class="cl2 fleft" style="margin-bottom:4px">
            <div class="contentboxmiddle1 shdw shd">
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                    <a style="float: right" class="back" href='javascript:window.history.back();'></a>
                    <div align="center">
                        <asp:Label ID="lblstatus" runat="server"></asp:Label>
                        <br />
                        <span class="nlsH"><b>Enter the News here</b></span>
                        <br />
                        <textarea id="taNews" rows="15" runat="server" cols="100"></textarea>
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
