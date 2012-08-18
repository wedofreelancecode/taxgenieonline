<%@ Page Title="Index" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="displayindex.aspx.cs" Inherits="TaxGenieOnline.displayindex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl2 fleft">
        <div class="contentbox">
            <div class="contentboxmiddle1 shdw shd">
                <div>
                    <asp:SiteMapPath ID="sitemap" runat="server" ParentLevelsDisplayed="2" Font-Bold="true"
                        Font-Size="Small" ForeColor="Black">
                    </asp:SiteMapPath>
                </div>
                <div align="right">
                    <a class="back" href='javascript:window.history.back();'></a>
                </div>
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px; margin-left: 30px;">
                    <div class="doc1" align="left" style="margin-left: 30px;">
                        <asp:Label ID="lblHeader" runat="server" ForeColor="Blue" Font-Size="1.4em"></asp:Label>
                        <asp:GridView ID="gvindex" runat="server" ShowHeader="False" AutoGenerateColumns="False"
                            OnRowCommand="gvindex_RowCommand" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                            CellPadding="4" ForeColor="Black">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="vertical-align: top; padding-top: 30px">
                                                    <asp:LinkButton ID="lnkChapterName" runat="server" Text='<%#Eval("ChapterName") %>'
                                                        CommandName="chapter" CssClass="nls"></asp:LinkButton>
                                                    <br />
                                                    <br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblsection" runat="server" Text='<%#Eval("Sections") %>' CssClass="nls"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        <asp:GridView ID="gvindexcircular" runat="server" BorderColor="#CCCCCC" AutoGenerateColumns="false"
                            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" OnRowCommand="gvindexcircular_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="CircularNumber">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkCircularNumber" runat="server" Text='<%#Eval("CircularNumber") %>'
                                            CommandName="number" CssClass="nls"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcirculardate" runat="server" Text='<%#Eval("Date") %>' CssClass="nls"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FileNumber">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcircularfileno" runat="server" Text='<%#Eval("FileNumber") %>'
                                            CssClass="nls"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%#Eval("Subject") %>' CssClass="nls"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvindexinstructions" runat="server" BorderColor="#CCCCCC" AutoGenerateColumns="false"
                            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" OnRowCommand="gvindexinstructions_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="FileNumber">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkFileNumber" runat="server" Text='<%#Eval("FileNumber") %>'
                                            CommandName="fnumber" CssClass="nls"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblinstructionsdate" runat="server" Text='<%#Eval("Date") %>' CssClass="nls"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject">
                                    <ItemTemplate>
                                        <asp:Label ID="lblinssubject" runat="server" Text='<%#Eval("Subject") %>' CssClass="nls"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvDGFTFTP" runat="server" ShowHeader="False" AutoGenerateColumns="False"
                            OnRowCommand="gvDGFTFTP_RowCommand" BorderColor="#CCCCCC" BorderStyle="None"
                            BorderWidth="1px" CellPadding="4" ForeColor="Black">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td style="vertical-align: top; padding-top: 30px">
                                                    <asp:LinkButton ID="lnkFTPChapterName" runat="server" Text='<%#Eval("ChapterName") %>'
                                                        CommandName="FTPchapter" CssClass="nls"></asp:LinkButton>
                                                    <br />
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                        <asp:GridView ID="gvDGFTpublicnotice" runat="server" AutoGenerateColumns="False"
                            OnRowCommand="gvDGFTpublicnotice_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Public Notice No." HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkNoticenum" runat="server" Text='<%#Eval("NoticeNumber") %>'
                                            CommandName="number" CssClass="nls"></asp:LinkButton>
                                        <br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcirculardate" runat="server" Text='<%#Eval("Date") %>' CssClass="nls"></asp:Label><br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%#Eval("Subject") %>' Width="300px"
                                            CssClass="nls"></asp:Label><br />
                                        <br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvCECNotifications" runat="server" ShowHeader="true" AutoGenerateColumns="False"   OnRowCommand="gvCECNotifications_RowCommand"
                            BorderColor="#CCCCCC" BorderStyle="None" 
                            BorderWidth="1px" CellPadding="4" ForeColor="Black"> 
                                <Columns>
                                  <asp:TemplateField HeaderText="Notification No " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkNoticenum" runat="server" Text='<%#Eval("FileNumber") %>'
                                            CommandName="Notificationnum" CssClass="nls"></asp:LinkButton>
                                        <br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>' CssClass="nls"></asp:Label><br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>' CssClass="nls"></asp:Label><br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                           <asp:GridView ID="gvSTNotification" runat="server" ShowHeader="true" AutoGenerateColumns="False" OnRowCommand="gvSTNotification_RowCommand" 
                            BorderColor="#CCCCCC" BorderStyle="None" 
                            BorderWidth="1px" CellPadding="4" ForeColor="Black"> 
                                <Columns>
                                  <asp:TemplateField HeaderText="Notification No " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkNoticenum" runat="server" Text='<%#Eval("FileNumber") %>'
                                            CommandName="Notificationnum" CssClass="nls"></asp:LinkButton>
                                        <br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>' CssClass="nls"></asp:Label><br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>' CssClass="nls"></asp:Label><br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Literal ID="ltlIndex" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
