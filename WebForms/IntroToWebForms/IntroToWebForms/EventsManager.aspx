<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventsManager.aspx.cs" Inherits="IntroToWebForms.EventsManager" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Page lifecycle events:</h2>
        <asp:BulletedList runat="server" ID="BulletedList"></asp:BulletedList>
    </div>
</asp:Content>
