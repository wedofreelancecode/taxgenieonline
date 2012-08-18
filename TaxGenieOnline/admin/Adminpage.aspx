<%@ Page Title="Admin" Language="C#" MasterPageFile="~/TaxGenie.master" AutoEventWireup="true"
    CodeBehind="Adminpage.aspx.cs" Inherits="TaxGenieOnline.Adminpage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_main" runat="server">
    <div style="min-height:300px;"></div>
  <%--  <div class="cl2 fleft">
        <div class="contentbox">
            <%--<img src="../images/middle_box_top.png" width="726" height="4" alt="" />--%>
            <%--<div class="contentboxmiddle1 shdw shd">--%>
               <%-- <div style="padding-top: 15px; padding-bottom: 10px;">
                    <div align="center" style="width: 710px;">--%>
                        <%--<div align="center">
                        
                            <span class="nls">Select Item:</span>
                         <asp:DropDownList ID="ddledit" runat="server" CssClass="nls" 
                                AutoPostBack="true" onselectedindexchanged="ddledit_SelectedIndexChanged">
                                
                                <asp:ListItem>Select One</asp:ListItem>
                                <asp:ListItem>Upload Documents</asp:ListItem>
                                <asp:ListItem>Upload News</asp:ListItem>
                                 <asp:ListItem>Upload Newsflash</asp:ListItem>
                                <asp:ListItem>Edit Documents</asp:ListItem>
                                <asp:ListItem>Edit News Content</asp:ListItem>
                                <asp:ListItem>Edit Flash News</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rrddl" runat="server" ErrorMessage="*" InitialValue="Select One"
                                ControlToValidate="ddledit" ValidationGroup="cc"></asp:RequiredFieldValidator>
                        </div>
                    --%>   <%-- <br />
                    </div>
                </div>
            </div>--%>
            <%--<img src="../images/middle_box_bottom.png" width="724" height="6" alt="" />--%>
        <%--</div>
    </div>--%>
</asp:Content>
