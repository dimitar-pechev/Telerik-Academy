<%@ Page Title="Sessions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sessions.aspx.cs" Inherits="StateManagement.Sessions" %>

<asp:Content ID="Sessions" ContentPlaceHolderID="MainContainer" runat="server">
    <h1 class="text-center">String Storage in Session Object</h1>
    <div class="col-md-6 col-md-offset-3">
        <div class="row text-center">
            <asp:TextBox runat="server" CssClass="form-control" ID="InputText" />
            <br />
            <asp:Button Text="Add to Storage" CssClass="btn btn-success" runat="server" ID="BtnAddToStorage" OnClick="BtnAddToStorage_Click" />
            <br />
        </div>
        <asp:Panel runat="server" ID="PanelStrings">
        </asp:Panel>
    </div>
</asp:Content>
