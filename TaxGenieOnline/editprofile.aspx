<%@ Page Title="EditProfile" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="editprofile.aspx.cs" Inherits="TaxGenieOnline.editprofile" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">

    <script type="text/javascript">
        //Function to allow only numbers to textbox
        function validate(key) {
            //getting key code of pressed key
            var keycode = (key.which) ? key.which : key.keyCode;
            //comparing pressed keycodes
            if (((keycode < 48 || keycode > 57)
             && keycode != 8 && keycode != 9 && keycode != 13
             && keycode != 37 && keycode != 39
             && keycode != 46
             && keycode != 144)) {
                return false;
            }
            else {
                return true;
            }
        }

        function validatealphabetics(key) {
            var keycode = (key.which) ? key.which : key.keyCode
            //comparing pressed keycodes
            if (((keycode < 65 || keycode > 90) && (keycode < 48 || keycode > 57) && (keycode < 97 || keycode > 122)//For alphanumeric  
             && keycode != 8 && keycode != 9 && keycode != 13 //Backspace,Tab and Enter
             && keycode != 37 && keycode != 39//Left Key and Right Key
             && keycode != 46//Delete
             && keycode != 32//Spacebar
             && keycode != 95//Underscore
             && keycode != 45)) { //Hyphen
                return false;
            }
            else {
                return true;
            }
        }
    </script>

    <div class="cl22 fleft">
        <div class="contentbox">
            <img src="images/middle_box_top.png" width="501" height="4" alt="" />
            <div class="contentboxmiddle">
                <div class="newshldr" style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="left">
                        <asp:ObjectDataSource ID="ods_PersonalProfile" runat="server" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="UserProfile" TypeName="TaxGenie_DAL.UserProfileTableAdapters.aspnet_UserProfile_DetailsTableAdapter"
                            UpdateMethod="Update" OnUpdated="ods_PersonalProfile_Updated">
                            <UpdateParameters>
                                <asp:Parameter DbType="Guid" Name="UserId" />
                                <asp:Parameter Name="FirstName" Type="String" />
                                <asp:Parameter Name="LastName" Type="String" />
                                <asp:Parameter Name="Gender" Type="String" />
                                <asp:Parameter Name="Age" Type="Int32" />
                                <asp:Parameter Name="MailId" Type="String" />
                                <asp:Parameter Name="Address" Type="String" />
                                <asp:Parameter Name="City" Type="String" />
                                <asp:Parameter Name="State" Type="String" />
                                <asp:Parameter Name="Country" Type="String" />
                                <asp:Parameter Name="PinCode" Type="Int64" />
                                <asp:Parameter Name="Phone1" Type="Int64" />
                                <asp:Parameter Name="Phone2" Type="Int64" />
                            </UpdateParameters>
                            <SelectParameters>
                                <asp:Parameter DbType="Guid" Name="UserId" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:FormView ID="frmv_PersonalProfile" runat="server" DefaultMode="Edit" DataSourceID="ods_PersonalProfile"
                            OnItemCommand="frmv_PersonalProfile_ItemCommand" Width="100%">
                            <EditItemTemplate>
                                <table border="0" style="font-size: 100%; font-family: Verdana" cellpadding="5px"
                                    cellspacing="5px">
                                    <tr>
                                        <td class="nls" align="center" colspan="2" style="font-weight: bold;">
                                            Create New Account
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblFirstname" runat="server" CssClass="nls" AssociatedControlID="txtFirstname">
                        First Name:</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:TextBox ID="txtFirstname" runat="server" CssClass="nl" Text='<%# Bind("FirstName") %>'
                                                onKeypress="return validatealphabetics(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvFirstname" runat="server" ControlToValidate="txtFirstname"
                                                ErrorMessage="Firstname is required." ToolTip="Firstname is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblLastname" runat="server" CssClass="nls">
                        Last Name:</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:TextBox ID="txtLastname" runat="server" CssClass="nl" Text='<%# Bind("LastName") %>'
                                                onKeypress="return validatealphabetics(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvLastname" runat="server" ControlToValidate="txtLastname"
                                                ErrorMessage="Lastname is required." ToolTip="Latname is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblGender" runat="server" CssClass="nls">
                        Gender:</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:RadioButtonList ID="rbtGender" runat="server" RepeatDirection="Horizontal" SelectedValue='<%# Bind("Gender") %>'>
                                                <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                                                <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="rvGender" runat="server" ControlToValidate="rbtGender"
                                                InitialValue="" ErrorMessage="Gender is required." ToolTip="Gender is required."
                                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblAge" runat="server" CssClass="nls">
                        Age:</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:TextBox ID="txtAge" runat="server" CssClass="nl" Width="50" Text='<%# Bind("Age") %>'
                                                onKeypress="return validate(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvAge" runat="server" ControlToValidate="txtAge"
                                                ErrorMessage="Age is required." ToolTip="Age is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                   <%-- <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblEmail" runat="server" CssClass="nls">
                        Email ID:</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="nl" Text='<%# Bind("MailId") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvEmail" runat="server" ControlToValidate="txtEmail"
                                                ErrorMessage="MailId is required." ToolTip="MailId is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblAdress" runat="server" CssClass="nls">
                        Address:</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:TextBox ID="txtAdress" runat="server" CssClass="nl" Text='<%# Bind("Address") %>'
                                                TextMode="MultiLine" Height="70"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvAdress" runat="server" ControlToValidate="txtAdress"
                                                ErrorMessage="Address is required." ToolTip="Adress is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblCity" runat="server" CssClass="nls">
                       City:</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="nl" Text='<%# Bind("City") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvCity" runat="server" ControlToValidate="txtCity"
                                                ErrorMessage="City is required." ToolTip="City is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblState" runat="server" CssClass="nls">
                       State:</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:TextBox ID="txtState" runat="server" CssClass="nl" Text='<%# Bind("State") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvState" runat="server" ControlToValidate="txtState"
                                                ErrorMessage="State is required." ToolTip="State is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblCountry" runat="server" CssClass="nls">
                       Country:</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:TextBox ID="txtCountry" runat="server" CssClass="nl" Text='<%# Bind("Country") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvCountry" runat="server" ControlToValidate="txtCountry"
                                                ErrorMessage="Country is required." ToolTip="Country is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblPincode" runat="server" CssClass="nls">
                      Pin Code:</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:TextBox ID="txtPincode" runat="server" CssClass="nl" Text='<%# Bind("PinCode") %>'
                                                onKeypress="return validate(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvPincode" runat="server" ControlToValidate="txtPincode"
                                                ErrorMessage="Pincode is required." ToolTip="Pincode is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblPhone1" runat="server" CssClass="nls">
                      Phone Number(Primary):</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:TextBox ID="txtPhone1" runat="server" CssClass="nl" Text='<%# Bind("Phone1") %>'
                                                onKeypress="return validate(event)"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rvPhone1" runat="server" ControlToValidate="txtPhone1"
                                                ErrorMessage="Phone Number required." ToolTip="Phone Number required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="padding-top: 10px">
                                            <asp:Label ID="lblPhone2" runat="server" CssClass="nls">
                      Phone Number(Secondary):</asp:Label>
                                        </td>
                                        <td style="padding: 10px 0 0 15px">
                                            <asp:TextBox ID="txtPhone2" runat="server" CssClass="nl" Text='<%# Bind("Phone2") %>'
                                                onKeypress="return validate(event)"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" style="padding-top: 10px" colspan="2">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Update" CommandName="Update" />
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                        </asp:FormView>
                    </div>
                </div>
            </div>
            <img src="images/middle_box_bottom.png" width="501" height="6" alt="" />
        </div>
    </div>
</asp:Content>
