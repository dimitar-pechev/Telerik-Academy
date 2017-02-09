<%@ Page Title="Register Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="ValidationControls.RegisterForm" %>

<asp:Content ID="RegisterForm" ContentPlaceHolderID="MainContainer" runat="server">
    <h1 class="text-center">Register Form</h1>
    <div class="row">
        <div class="col-md-4 text-center">
            <asp:ScriptManager runat="server" />
            <asp:Panel runat="server" CssClass="panel panel-default">
                <div class="panel-heading">
                    Personal Information
                </div>
                <div class="panel-body">
                    <asp:Label Text="First Name:" runat="server" AssociatedControlID="FirstName" />
                    <asp:TextBox runat="server" CssClass="form-control text-field" ID="FirstName" ValidationGroup="ValidationPersonalInfo" />
                    <asp:RequiredFieldValidator ErrorMessage="First name field cannot be blank!"
                        ForeColor="red" Display="Dynamic" ValidationGroup="ValidationPersonalInfo"
                        ControlToValidate="FirstName"
                        runat="server" />

                    <br />
                    <asp:Label Text="Last Name:" runat="server" AssociatedControlID="LastName" />
                    <asp:TextBox runat="server" CssClass="form-control text-field" ID="LastName" />
                    <asp:RequiredFieldValidator ValidationGroup="ValidationPersonalInfo" ErrorMessage="Last Name field cannot be blank!"
                        ForeColor="red" Display="Dynamic"
                        ControlToValidate="LastName"
                        runat="server" />

                    <br />
                    <asp:Label Text="Age:" runat="server" AssociatedControlID="Age" />
                    <asp:TextBox runat="server" CssClass="form-control text-field" ID="Age" />
                    <asp:RequiredFieldValidator ValidationGroup="ValidationPersonalInfo" ErrorMessage="Age field cannot be blank!"
                        ForeColor="red" Display="Dynamic"
                        ControlToValidate="Age"
                        runat="server" />
                    <asp:RangeValidator ValidationGroup="ValidationPersonalInfo" ErrorMessage="Age must be between 18 and 81!" ControlToValidate="Age" runat="server"
                        ForeColor="red" Display="Dynamic" MaximumValue="81" MinimumValue="18" />

                    <br />
                    <asp:Label Text="Gender" runat="server" AssociatedControlID="RadioButtonsGender" />
                    <br />
                    <asp:RequiredFieldValidator ValidationGroup="ValidationPersonalInfo" ErrorMessage="Select gender!" Display="Dynamic" ForeColor="red" ControlToValidate="RadioButtonsGender" runat="server" />
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:RadioButtonList CssClass="table" runat="server" ID="RadioButtonsGender" AutoPostBack="true"
                                OnSelectedIndexChanged="RadioButtonsGender_SelectedIndexChanged" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Male" />
                                <asp:ListItem Text="Female" />
                            </asp:RadioButtonList>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="DropDownListMale" Visible="false">
                                <asp:ListItem Text="Mercedes" />
                                <asp:ListItem Text="Audi" />
                                <asp:ListItem Text="BMW" />
                                <asp:ListItem Text="Mazda" />
                                <asp:ListItem Text="Zastava" />
                                <asp:ListItem Text="Moskvich" />
                            </asp:DropDownList>

                            <asp:DropDownList runat="server" CssClass="form-control" ID="DropDownListFemale" Visible="false">
                                <asp:ListItem Text="Espresso" />
                                <asp:ListItem Text="Capuccino" />
                                <asp:ListItem Text="Mocha" />
                                <asp:ListItem Text="Late" />
                                <asp:ListItem Text="Джезвенце" />
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="panel-body">
                    <asp:Button Text="Validate" ValidationGroup="ValidationPersonalInfo" ID="BtnValidatePersonalInfo"
                        CssClass="btn btn-warning" runat="server" />
                </div>
            </asp:Panel>
        </div>
        <div class="col-md-4 text-center">
            <asp:Panel runat="server" CssClass="panel panel-default">
                <div class="panel-heading">
                    Login Information
                </div>
                <div class="panel-body">
                    <asp:Label Text="Username:" runat="server" AssociatedControlID="Username" />
                    <asp:TextBox runat="server" CssClass="form-control text-field" ID="Username" />
                    <asp:RequiredFieldValidator ErrorMessage="Username field cannot be blank!"
                        ForeColor="red" Display="Dynamic" ValidationGroup="ValidationLoginInfo"
                        ControlToValidate="Username"
                        runat="server" />
                    <br />
                    <asp:Label Text="Password:" runat="server" AssociatedControlID="Password" />
                    <asp:TextBox runat="server" CssClass="form-control text-field" ID="Password" />
                    <asp:RequiredFieldValidator ErrorMessage="Password field cannot be blank!"
                        ForeColor="red" Display="Dynamic" ValidationGroup="ValidationLoginInfo"
                        ControlToValidate="Password"
                        runat="server" />

                    <br />
                    <asp:Label Text="Repeat Password:" runat="server" AssociatedControlID="RepeatPassword" />
                    <asp:TextBox runat="server" CssClass="form-control text-field" ID="RepeatPassword" />
                    <asp:RequiredFieldValidator ErrorMessage="Repeat Password field cannot be blank!"
                        ForeColor="red" Display="Dynamic" ValidationGroup="ValidationLoginInfo"
                        ControlToValidate="RepeatPassword"
                        runat="server" />
                    <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                        ControlToCompare="Password" ValidationGroup="ValidationLoginInfo"
                        ControlToValidate="RepeatPassword" Display="Dynamic"
                        ErrorMessage="Passwords don't match!" ForeColor="Red" />

                </div>
                <div class="panel-body">
                    <asp:Button Text="Validate" ValidationGroup="ValidationLoginInfo" ID="BtnValidateLogin" CssClass="btn btn-warning" runat="server" />
                </div>
            </asp:Panel>
            <asp:ValidationSummary ValidationGroup="ValidationPersonalInfo" runat="server" ForeColor="Red" />
            <asp:ValidationSummary ValidationGroup="ValidationLoginInfo" runat="server" ForeColor="Red" />
            <asp:ValidationSummary ValidationGroup="ValidationContactsInfo" runat="server" ForeColor="Red" />
        </div>
        <div class="col-md-4 text-center">
            <asp:Panel runat="server" CssClass="panel panel-default">
                <div class="panel-heading">
                    Contact Information
                </div>
                <div class="panel-body">
                    <asp:Label Text="E-Mail:" runat="server" AssociatedControlID="EMail" />
                    <asp:TextBox runat="server" CssClass="form-control text-field" ID="EMail" />
                    <asp:RequiredFieldValidator ErrorMessage="E-Mail field cannot be blank!"
                        ForeColor="red" Display="Dynamic" ValidationGroup="ValidationContactsInfo"
                        ControlToValidate="EMail"
                        runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="Please, provide a valid E-Mail!"
                        ControlToValidate="EMail" runat="server" ValidationGroup="ValidationContactsInfo"
                        Display="Dynamic" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />

                    <br />
                    <asp:Label Text="Address:" runat="server" AssociatedControlID="Address" />
                    <asp:TextBox runat="server" CssClass="form-control text-field" ID="Address" />
                    <asp:RequiredFieldValidator ErrorMessage="Address field cannot be blank!"
                        ForeColor="red" Display="Dynamic" ValidationGroup="ValidationContactsInfo"
                        ControlToValidate="Address"
                        runat="server" />

                    <br />
                    <asp:Label Text="Phone:" runat="server" AssociatedControlID="Phone" />
                    <asp:TextBox runat="server" CssClass="form-control text-field" ID="Phone" />
                    <asp:RequiredFieldValidator ErrorMessage="Phone field cannot be blank!"
                        ForeColor="red" Display="Dynamic" ValidationGroup="ValidationContactsInfo"
                        ControlToValidate="Phone"
                        runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="Please, provide a valid phone number!"
                        ControlToValidate="Phone" runat="server" ValidationGroup="ValidationContactsInfo"
                        Display="Dynamic" ForeColor="Red" ValidationExpression="[0-9]*" />
                </div>
                <div class="panel-body">
                    <asp:Button Text="Validate" ValidationGroup="ValidationContactsInfo" ID="BtnValidateContactInfo" CssClass="btn btn-warning" runat="server" />
                </div>
            </asp:Panel>
            <br />
            <asp:Button Text="Submit form" ID="BtnSubmitAll" OnClick="BtnSubmitAll_Click" CssClass="btn btn-lg btn-success pull-right" runat="server" />
        </div>
    </div>
</asp:Content>
