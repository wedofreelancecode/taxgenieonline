<%@ Page Title="Unauthorized Access" Language="C#" MasterPageFile="~/TaxGenie.Master"
    AutoEventWireup="true" CodeBehind="UnauthorizedAccess.aspx.cs" Inherits="TaxGenieOnline.UnauthorizedAccess" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl22 fleft">
        <div class="contentbox">
            <img src="images/middle_box_top.png" width="501" height="4" alt="" />
            <div class="contentboxmiddle">
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="center">
                        <h2>
                            Unauthorized Access</h2>
                        <p style="color: Red; font-size: 12px;">
                            Sorry, this page is available only for subscribers. If you are already a subscriber,
                            please login. Else, you may create a login ID by registering as a new user and subscribe
                            to our tailor-made packages or Contact Us.
                        </p>
                        <br />
                        <br />
                        <asp:LoginView ID="LoginView1" runat="server">
                            <AnonymousTemplate>
                                <asp:Login ID="Login1" runat="server" Width="100%" OnAuthenticate="Login1_Authenticate">
                                    <LayoutTemplate>
                                            <tr>
                                                <td style="text-align: right">
                                                    User Name:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="UserName" runat="server" style="margin-bottom:5px;" CssClass="una nll login"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right">
                                                    Password:
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="Password" runat="server" style="margin-bottom:5px;" TextMode="Password" CssClass="una nll login"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                        ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td align="center">
                                                    <asp:Button ID="btnLogin" runat="server" CssClass="una nbs fleft" CommandName="Login"
                                                        ValidationGroup="Login1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <div style="color: Red">
                                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-right: 15px;">
                                                    <a href="pwdrecovery.aspx" class="fright">Forgot Password?</a>
                                                </td>
                                                <td>
                                                    New User?<a href="../memberreg.aspx"> Register Here</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:Login>
                            </AnonymousTemplate>
                            <LoggedInTemplate>
                                <div style="padding: 10px 17px 0 0" align="right">
                                    <span style="font-family: Arial; font-size: 12px;">Welcome</span>
                                    <asp:Label ID="lblWlcmName" runat="server" Font-Size="12px" Font-Bold="true"></asp:Label><br />
                                    <a href="../editprofile.aspx" style="color: Black;">Edit Profile</a>&nbsp;&nbsp;|&nbsp;&nbsp;
                                    <a href="../changepwd.aspx" style="color: Black;">Change Password</a>&nbsp;&nbsp;|&nbsp;&nbsp;<asp:LoginStatus
                                        ID="LoginStatus1" runat="server" ForeColor="Black" LogoutAction="RedirectToLoginPage" />
                                </div>
                            </LoggedInTemplate>
                        </asp:LoginView>
                    </div>
                </div>
            </div>
            <img src="images/middle_box_bottom.png" width="501" height="6" alt="" />
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("input.una[name*='UserName'], input.una[name*='Password']").keypress(function (event) {
                var e = event || window.event;
                if (e.charCode === 13) {
                    $('.una').filter(":submit").click();
                }
            })
        });
    </script>
</asp:Content>
 