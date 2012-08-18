<%@ Page Title="" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="search.aspx.cs" Inherits="TaxGenieOnline.search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl22 fleft">
        <div class="contentbox">
            <img src="images/middle_box_top.png" width="501" height="4" alt="" />
            <div class="contentboxmiddle">
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="left">
                        <asp:GridView ID="gv_Search" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            PageSize="15" OnPageIndexChanging="gv_Search_PageIndexChanging" 
                            CellPadding="4" ForeColor="#333333" GridLines="None">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle Height="50" BackColor="#999999" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:HyperLinkField DataTextField="columnvalue" DataNavigateUrlFields="Id,TABLE_NAME"
                                    DataNavigateUrlFormatString="searchdata.aspx?id={0}&name={1}" />
                            </Columns>
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <img src="images/middle_box_bottom.png" width="501" height="6" alt="" />
        </div>
    </div>
</asp:Content>
