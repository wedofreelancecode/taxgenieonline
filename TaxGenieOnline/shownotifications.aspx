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
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px; margin-left: 40px;
                    margin-right: 40px; min-height: 200px; text-align: justify">
                    <div class="doc1">
                        <asp:Literal ID="ltl" runat="server"></asp:Literal>
                        <asp:Label ID="lbldata" runat="server"></asp:Label>

                        <table>
                        <tr>
                        <td >
                        
                        </td></tr>
                        </table>

                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
