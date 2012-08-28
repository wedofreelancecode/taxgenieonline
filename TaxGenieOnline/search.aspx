<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="search.aspx.cs" Inherits="TaxGenieOnline.search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <div class="contentboxmiddle1 shdw shd" style="min-height: 300px; padding: 15px 10px 10px 40px">
                <div class="newshldr" style="width: 100%; margin-top: 5px;">
                    <div align="left">
                        <asp:GridView ID="gv_Search" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            OnPageIndexChanging="gv_Search_PageIndexChanging" ForeColor="#333333" GridLines="None">
                            <Columns>
                                <asp:HyperLinkField DataTextField="columnvalue" DataNavigateUrlFields="Id,TABLE_NAME"
                                    DataNavigateUrlFormatString="searchdata.aspx?id={0}&name={1}" ControlStyle-Height="30">
                                    <ControlStyle Height="30px"></ControlStyle>
                                </asp:HyperLinkField>
                            </Columns>
                            <PagerStyle BackColor="#CC3300" HorizontalAlign="Center" />
                            <EmptyDataTemplate>
                                <asp:Label ID="lblNoDataFound" runat="server" Text="No Data Found"></asp:Label>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_right" runat="server">
</asp:Content>
