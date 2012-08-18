<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/TaxGenie.Master" AutoEventWireup="true"
    CodeBehind="changepwd.aspx.cs" Inherits="TaxGenieOnline.changepwd" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div class="cl22 fleft">
        <div class="contentbox">
            <img src="images/middle_box_top.png" width="501" height="4" alt="" />
            <div class="contentboxmiddle">
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="center">
                        <asp:ChangePassword ID="ChangePassword1" runat="server">
                            <ChangePasswordTemplate>
                                <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                    <tr>
                                        <td>
                                            <table border="0" cellpadding="0">
                                                <tr>
                                                    <td align="center" colspan="2" class="nls" style="font-weight: bold">
                                                        Change Your Password
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" style="padding-top: 10px;">
                                                        <asp:Label ID="CurrentPasswordLabel" runat="server" CssClass="nls" AssociatedControlID="CurrentPassword">Old Password:</asp:Label>
                                                    </td>
                                                    <td style="padding-top: 10px;">
                                                        <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" CssClass="nl"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword"
                                                            ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="NewPasswordLabel" runat="server" CssClass="nls" AssociatedControlID="NewPassword">New Password:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password" CssClass="nl"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword"
                                                            ErrorMessage="New Password is required." ToolTip="New Password is required."
                                                            ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" CssClass="nls" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password" CssClass="nl"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword"
                                                            ErrorMessage="Confirm New Password is required." ToolTip="Confirm New Password is required."
                                                            ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword"
                                                            ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                                                            ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2" style="color: Red;" class="nls">
                                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword"
                                                                        Text="Change Password" ValidationGroup="ChangePassword1" />
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel"
                                                                        Text="Cancel" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ChangePasswordTemplate>
                            <SuccessTemplate>
                                <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                                    <tr>
                                        <td>
                                            <table border="0" cellpadding="0">
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        Change Password Complete
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Your password has been changed!
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">
                                                        <asp:Button ID="ContinuePushButton" runat="server" CausesValidation="False" CommandName="Continue"
                                                            Text="Continue" PostBackUrl="~/Home.aspx" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </SuccessTemplate>
                        </asp:ChangePassword>
                    </div>
                </div>
            </div>
            <img src="images/middle_box_bottom.png" width="501" height="6" alt="" />
        </div>
    </div>
</asp:Content>
