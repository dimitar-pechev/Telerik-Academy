<%@ Page Title="Dummy Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DummyLogin.aspx.cs" Inherits="StateManagement.DummyLogin" %>

<asp:Content ID="DummyLogin" ContentPlaceHolderID="MainContainer" runat="server">
    <h1 class="text-center">Login to Your Dummy Profile!</h1>
    <div class="col-md-4 col-md-offset-4 text-center">
        <asp:TextBox runat="server" CssClass="form-control" ID="Username" />
        <asp:RequiredFieldValidator ErrorMessage="Type something..." ControlToValidate="Username" runat="server" />
        <br />
        <asp:Button Text="Login! (The username doesn't really matter...)" runat="server" ID="BtnLogin" OnClick="BtnLogin_Click" CssClass="btn btn-success btn-block" />
    </div>
</asp:Content>
