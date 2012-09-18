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
                        <asp:GridView ID="gvindex" runat="server" AutoGenerateColumns="False" OnRowCommand="gvindex_RowCommand"
                            CssClass="sGrid" AlternatingRowStyle-CssClass="alt">
                            <Columns>
                                <asp:TemplateField HeaderText="Chapters">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkChapterName" runat="server" Text='<%#Eval("ChapterName") %>'
                                            CommandName="chapter"></asp:LinkButton>
                                        <br />
                                        <asp:Label ID="lblsection" runat="server" Text='<%#Eval("Sections") %>' CssClass="nls"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvindexcircular" runat="server" AutoGenerateColumns="False" OnRowCommand="gvindexcircular_RowCommand"
                            EnableModelValidation="True" CssClass="mGrid" AlternatingRowStyle-CssClass="alt">
                            <Columns>
                                <asp:TemplateField HeaderText="CircularNumber" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkCircularNumber" runat="server" Text='<%#Eval("CircularNumber") %>'
                                            CommandName="number"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcirculardate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FileNumber" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcircularfileno" runat="server" Text='<%#Eval("FileNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="300px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvindexinstructions" runat="server" AutoGenerateColumns="False"
                            OnRowCommand="gvindexinstructions_RowCommand" EnableModelValidation="True" CssClass="mGrid"
                            AlternatingRowStyle-CssClass="alt">
                            <Columns>
                                <asp:TemplateField HeaderText="FileNumber" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkFileNumber" runat="server" Text='<%#Eval("FileNumber") %>'
                                            CommandName="fnumber"></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="117px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblinstructionsdate" runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblinssubject" runat="server" Text='<%#Eval("Subject") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="500px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvDGFTFTP" runat="server" AutoGenerateColumns="False" OnRowCommand="gvDGFTFTP_RowCommand"
                            CssClass="sGrid" AlternatingRowStyle-CssClass="alt">
                            <Columns>
                                <asp:TemplateField HeaderText="Foreign Trade Policies">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkFTPChapterName" runat="server" Text='<%#Eval("ChapterName") %>'
                                            CommandName="FTPchapter"></asp:LinkButton>
                                        <br />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvDGFTpublicnotice" runat="server" AutoGenerateColumns="False"
                            OnRowCommand="gvDGFTpublicnotice_RowCommand" EnableModelValidation="True" CssClass="mGrid"
                            AlternatingRowStyle-CssClass="alt">
                            <Columns>
                                <asp:TemplateField HeaderText="Public Notice No." HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkNoticenum" runat="server" Text='<%#Eval("NoticeNumber") %>'
                                            CommandName="number"></asp:LinkButton>
                                        <br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="117px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcirculardate" runat="server" Text='<%#Eval("Date") %>'></asp:Label><br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsubject" runat="server" Text='<%#Eval("Subject") %>'></asp:Label><br />
                                        <br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="500px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvCECNotifications" runat="server" AutoGenerateColumns="False"
                            OnRowCommand="gvCECNotifications_RowCommand" EnableModelValidation="True" CssClass="mGrid"
                            AlternatingRowStyle-CssClass="alt">
                            <Columns>
                                <asp:TemplateField HeaderText="Notification No " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkNoticenum" runat="server" Text='<%#Eval("FileNumber") %>'
                                            CommandName="Notificationnum"></asp:LinkButton>
                                        <br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="117px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label><br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>'></asp:Label><br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="500px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="gvSTNotification" runat="server" AutoGenerateColumns="False" OnRowCommand="gvSTNotification_RowCommand"
                            EnableModelValidation="True" CssClass="mGrid" AlternatingRowStyle-CssClass="alt">
                            <Columns>
                                <asp:TemplateField HeaderText="Notification No " HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkNoticenum" runat="server" Text='<%#Eval("FileNumber") %>'
                                            CommandName="Notificationnum"></asp:LinkButton>
                                        <br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="117px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label><br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="100px"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subject" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubject" runat="server" Text='<%#Eval("Subject") %>'></asp:Label><br />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Font-Bold="True" Width="500px"></HeaderStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Literal ID="ltlIndex" runat="server"></asp:Literal>
                        <asp:Label ID="lblCL" runat="server"></asp:Label>
                         <asp:Literal ID="ltlCL" runat="server"></asp:Literal>
                          <asp:Literal ID="ltlCLheadnotes" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
