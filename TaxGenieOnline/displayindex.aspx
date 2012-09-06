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
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px; margin-left: 30px;
                    min-height: 200px">
                    <div class="doc2" align="left" style="margin-left: 30px;">
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
                        <asp:GridView ID="gvindexcircular" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" OnRowCommand="gvindexcircular_RowCommand" EnableModelValidation="True"
                            GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="CircularNumber" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="117px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkCircularNumber" runat="server" Text='<%#Eval("CircularNumber") %>'
                                            CommandName="number" CssClass="nls"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcirculardate" runat="server" Text='<%#Eval("Date") %>' CssClass="nls"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FileNumber" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcircularfileno" runat="server" Text='<%#Eval("FileNumber") %>'
                                            CssClass="nls"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%#Eval("Subject") %>' CssClass="nls"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="300px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <asp:GridView ID="gvindexinstructions" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" ForeColor="#333333" OnRowCommand="gvindexinstructions_RowCommand"
                            EnableModelValidation="True" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="FileNumber" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="117px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkFileNumber" runat="server" Text='<%#Eval("FileNumber") %>'
                                            CommandName="fnumber" CssClass="nls"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="117px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblinstructionsdate" runat="server" Text='<%#Eval("Date") %>' CssClass="nls"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="500px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblinssubject" runat="server" Text='<%#Eval("Subject") %>' CssClass="nls"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="500px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
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
                            OnRowCommand="gvDGFTpublicnotice_RowCommand" CellPadding="4" EnableModelValidation="True"
                            ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Public Notice No." HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="117px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkNoticenum" runat="server" Text='<%#Eval("NoticeNumber") %>'
                                            CommandName="number" CssClass="nls"></asp:LinkButton>
                                        <br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="117px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcirculardate" runat="server" Text='<%#Eval("Date") %>' CssClass="nls"></asp:Label><br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="500px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%#Eval("Subject") %>' CssClass="nls"></asp:Label><br />
                                        <br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="500px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <asp:GridView ID="gvCECNotifications" runat="server" AutoGenerateColumns="False"
                            OnRowCommand="gvCECNotifications_RowCommand" CellPadding="4" ForeColor="#333333"
                            EnableModelValidation="True" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Notification No " HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="117px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkNoticenum" runat="server" Text='<%#Eval("FileNumber") %>'
                                            CommandName="Notificationnum" CssClass="nls"></asp:LinkButton>
                                        <br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="117px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>' CssClass="nls"></asp:Label><br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="500px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>' CssClass="nls"></asp:Label><br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="500px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <asp:GridView ID="gvSTNotification" runat="server" AutoGenerateColumns="False" OnRowCommand="gvSTNotification_RowCommand"
                            CellPadding="4" ForeColor="#333333" EnableModelValidation="True" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Notification No " HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="117px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkNoticenum" runat="server" Text='<%#Eval("FileNumber") %>'
                                            CommandName="Notificationnum" CssClass="nls"></asp:LinkButton>
                                        <br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="117px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>' CssClass="nls"></asp:Label><br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true" HeaderStyle-HorizontalAlign="Left"
                                    HeaderStyle-Width="500px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>' CssClass="nls"></asp:Label><br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="500px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                        <asp:Literal ID="ltlIndex" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
