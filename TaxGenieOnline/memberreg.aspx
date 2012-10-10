<%@ Page Title="TaxGenieOnline" Language="C#" MasterPageFile="~/TaxGenie.Master"
    AutoEventWireup="true" CodeBehind="memberreg.aspx.cs" Inherits="TaxGenieOnline.UserRegistration.memberreg" %>

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
                    <div align="center">
                        <asp:ObjectDataSource ID="odsUserProfile" runat="server" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}"
                            SelectMethod="UserProfile" TypeName="TaxGenie_DAL.UserProfileTableAdapters.aspnet_UserProfile_DetailsTableAdapter"
                            UpdateMethod="Update">
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
                            <InsertParameters>
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
                            </InsertParameters>
                        </asp:ObjectDataSource>
                        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" RequireEmail="False"
                            AutoGeneratePassword="True" LoginCreatedUser="False" OnCreatedUser="CreateUserWizard1_CreatedUser"
                            OnCreatingUser="CreateUserWizard1_OnCreatingUser" 
                            CreateUserButtonText="Create">
                            <WizardSteps>
                                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                                    <ContentTemplate>
                                        <table border="0" style="font-size: 100%; font-family: Verdana" cellpadding="5px"
                                            cellspacing="5px" width="100%">
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
                                                    <asp:TextBox ID="txtFirstname" runat="server" CssClass="nl" onKeypress="return validatealphabetics(event)"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtLastname" runat="server" CssClass="nl" onKeypress="return validatealphabetics(event)"></asp:TextBox>
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
                                                    <asp:RadioButtonList ID="rbtGender" runat="server" RepeatDirection="Horizontal">
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
                                                    <asp:TextBox ID="txtAge" runat="server" CssClass="nl" Width="50" onKeypress="return validate(event)"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rvAge" runat="server" ControlToValidate="txtAge"
                                                        ErrorMessage="Age is required." ToolTip="Age is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding-top: 10px">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="nls">
                        Email ID:</asp:Label>
                                                </td>
                                                <td style="padding: 10px 0 0 15px">
                                                    <asp:TextBox ID="UserName" runat="server" CssClass="nl"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                        ErrorMessage="MailId is required." ToolTip="MailId is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="ConfirmUserNameLabel" runat="server" AssociatedControlID="ConfirmUserName"
                                                        CssClass="nls">
                       Confirm Email ID:</asp:Label>
                                                </td>
                                                <td style="padding: 10px 0 0 15px">
                                                    <asp:TextBox ID="ConfirmUserName" runat="server" CssClass="nl"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ConfirmUserName"
                                                        ErrorMessage="MailId is required." ToolTip="MailId is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <asp:CompareValidator ID="MailIdCompare" runat="server" ControlToCompare="UserName"
                                                        CssClass="nls" ControlToValidate="ConfirmUserName" Display="Dynamic" ErrorMessage="The MailId and Confirmation MailId must match."
                                                        ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" style="color: red" class="nls">
                                                    <asp:RegularExpressionValidator ID="revErrorMsg" runat="server" ErrorMessage="Please enter a valid e-mail address."
                                                        ControlToValidate="UserName" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                        ValidationGroup="CreateUserWizard1"></asp:RegularExpressionValidator>
                                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" style="padding-top: 10px">
                                                    <asp:Label ID="lblAdress" runat="server" CssClass="nls">
                        Address:</asp:Label>
                                                </td>
                                                <td style="padding: 10px 0 0 15px">
                                                    <asp:TextBox ID="txtAdress" runat="server" CssClass="nl" TextMode="MultiLine" Height="70"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtCity" runat="server" CssClass="nl"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtState" runat="server" CssClass="nl"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtCountry" runat="server" CssClass="nl"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtPincode" runat="server" CssClass="nl" onKeypress="return validate(event)"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtPhone1" runat="server" CssClass="nl" onKeypress="return validate(event)"></asp:TextBox>
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
                                                    <asp:TextBox ID="txtPhone2" runat="server" CssClass="nl" onKeypress="return validate(event)"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                    <CustomNavigationTemplate>
                                        <table border="0" cellspacing="5" style="width: 100%; height: 100%;">
                                            <tr align="right">
                                                <td align="center" colspan="0">
                                                    <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Create"
                                                        ValidationGroup="CreateUserWizard1" />
                                                </td>
                                            </tr>
                                        </table>
                                    </CustomNavigationTemplate>
                                </asp:CreateUserWizardStep>
                                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                                    <ContentTemplate>
                                        <table border="0" style="font-size: 100%; font-family: Verdana" id="TABLE1">
                                            <tr>
                                                <td align="center" style="font-weight: bold; color: white; background-color: #5d7b9d;
                                                    height: 18px;">
                                                    Complete
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    This account has been created successfully for the <br /> user <b><asp:Literal ID="lblUsername" runat="server" Text=""></asp:Literal></b>.<br /><br />
                                                    Your login credentials has been sent to your <br /> E-Mail(<b>
                                                        <asp:Literal ID="lblPWD" runat="server" Text=""></asp:Literal></b>).
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    &nbsp;<asp:Button ID="ContinueButton" runat="server" BackColor="#FFFBFF" BorderColor="#CCCCCC"
                                                        BorderStyle="Solid" BorderWidth="1px" CausesValidation="False" CommandName="Continue"
                                                        Font-Names="Verdana" ForeColor="#284775" Text="Continue" ValidationGroup="CreateUserWizard1"
                                                        PostBackUrl="~/Home.aspx" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:CompleteWizardStep>
                            </WizardSteps>
                        </asp:CreateUserWizard>
                    </div>
                </div>
            </div>
            <img src="images/middle_box_bottom.png" width="501" height="6" alt="" />
        </div>
    </div>
</asp:Content>
