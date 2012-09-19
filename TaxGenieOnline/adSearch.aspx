<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="adSearch.aspx.cs" Inherits="TaxGenieOnline.adSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <div class="contentboxmiddle1 shdw" style="min-height: 300px;">
                  <br />
                  <div style="width:100%;text-align:center">
                <img style="margin-top:5px"; src="images/slogo.png" />&nbsp;<asp:Label ID="lblHeading" runat="server" CssClass="nlsH" style="vertical-align:middle; padding:5px" Text="Case Laws Search"></asp:Label><hr style="width:50%" /><br /></div>
                
                <table style="width: 100%; margin-top: 5px;" cellspacing="7px" border="10px"><tr>
                        <td style="width: 40%; text-align: right; padding-top: 10px" valign="top">
                            <asp:Label ID="lblKeyword" runat="server" Text="Subjet :" CssClass="nlsN"></asp:Label><br />
                            <span style="font-size:9px">(Keywords)</span>&nbsp
                        </td>
                        <td style="padding: 6px;">
                            <asp:TextBox ID="txtKeyword" runat="server" CssClass="nls" Width="270px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvddlcat" runat="server" ControlToValidate="txtKeyword"
                                InitialValue="select one" ErrorMessage="*" ValidationGroup="ddlcat"></asp:RequiredFieldValidator><br />
                            <asp:RadioButtonList runat="server" ID="srcCat" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Headnotes" Value="Headnotes"></asp:ListItem>
                                <asp:ListItem Text="Complete text" Selected="True" Value="Complete text"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RadioButtonList runat="server" ID="srcType" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Phrase" Value="Phrase"></asp:ListItem>
                                <asp:ListItem Text="Any Word" Value="Any Word"></asp:ListItem>
                                <asp:ListItem Text="All words" Selected="True" Value="All words"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="padding: 6px;">
                            <br /></td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Party's Name :
                        </td>
                        <td style="padding: 6px;">
                            <asp:TextBox runat="server" ID="txtParty" class="nls" Width="270px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Court :
                        </td>
                        <td style="padding: 6px;">
                            <asp:DropDownList ID="ddlCourts" runat="server" CssClass="nls" Width="280px" 
                                AutoPostBack="True" onselectedindexchanged="ddlCourts_SelectedIndexChanged">
                                <asp:ListItem>--Select One--</asp:ListItem>
                                <asp:ListItem>Supreme Court of India </asp:ListItem>
                                <asp:ListItem>High Court </asp:ListItem>
                                <asp:ListItem>CESTAT</asp:ListItem>
                                <asp:ListItem>CEGAT</asp:ListItem>
                                <asp:ListItem>ATFE</asp:ListItem>
                                <asp:ListItem>TRIBUNAL</asp:ListItem>
                                <asp:ListItem>Revisionary Authority</asp:ListItem>
                                <asp:ListItem>Settlement Commossion</asp:ListItem>
                                <asp:ListItem>Other</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label runat="server" ID="lblOther" Visible="False"> Other Court :</asp:Label>
                        </td>
                        <td style="padding: 6px;">
                            <asp:DropDownList ID="ddlOtherCourt" runat="server" CssClass="nls"
                                Width="280px" Visible="False">
                                <asp:ListItem>--Select One--</asp:ListItem>
                                <asp:ListItem>CBEC</asp:ListItem>
                                <asp:ListItem>Authority for Advance Rulings</asp:ListItem>
                                <asp:ListItem>DGFT</asp:ListItem>
                                <asp:ListItem>G.O.I</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Case Number :
                        </td>
                        <td style="padding: 6px;">
                            <asp:TextBox runat="server" ID="txtCaseNo" class="nls" Width="270px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            Judge's Name :
                        </td>
                        <td style="padding: 6px;">
                            <asp:TextBox runat="server" ID="txtJudge" class="nls" Width="270px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            CITATION :
                        </td>
                        <td valign="middle" style="padding: 6px;">
                            <table style="text-align:center;border:2px dotted gray" cellspacing="0" cellpadding="0"><tr style="margin:0px;padding:0px;color:gray">
                            <td>year</td><td></td><td>vol</td><td></td><td>page</td></tr>
                            <tr ><td><asp:TextBox ID="txtCLcitationyear" runat="server" CssClass="nls" style="min-width:20px"
                                    Columns="3"></asp:TextBox></td><td>-TGOL-</td>
                            <td><asp:TextBox ID="txtClNumber" runat="server" CssClass="nls" Columns="5" style="min-width:20px"></asp:TextBox></td>
                            <td>-</td><td><asp:TextBox ID="txtCL" runat="server" CssClass="nls" style="min-width:20px" Columns="6"></asp:TextBox>&nbsp;</td></tr></table>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr><td align="right"></td>
                    <td style="padding: 6px;"><asp:Button ID="btnReset" runat="server" Text="Reset" 
                            onclick="btnReset_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" /></td></tr>
                </table>
                <br /><br /><br />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
