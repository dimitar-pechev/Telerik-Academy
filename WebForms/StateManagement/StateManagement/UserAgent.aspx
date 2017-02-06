<%@ Page Title="User Agent" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserAgent.aspx.cs" Inherits="StateManagement.UserAgent" %>

<asp:Content ID="UserAgent" ContentPlaceHolderID="MainContainer" runat="server">
    <div class="col-md-4 col-md-offset-4 text-center">
        <h1>User Agent</h1>
        <br />
        <asp:Button Text="Get Info" runat="server" ID="BtnGetUserInfo" OnClick="BtnGetUserInfo_Click" CssClass="btn btn-success" />
        <br />
        <br />
        <asp:Label Text="" runat="server" ID="BrowserType" />
        <br />
        <asp:Label Text="" runat="server" ID="UserIp" />
    </div>
</asp:Content>
