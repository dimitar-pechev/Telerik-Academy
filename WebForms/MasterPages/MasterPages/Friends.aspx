<%@ Page Title="Friends" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="MasterPages.Friends" %>
<asp:Content ID="Friends" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Friends of Someone</h2>
    <asp:BulletedList runat="server" ID="FriendsList" DisplayMode="HyperLink" CssClass="friends-list">
        <asp:ListItem Text="Luis Suarez" Value="#" />
        <asp:ListItem Text="Steven Gerrard" Value="#" />
        <asp:ListItem Text="Adam Lallana" Value="#" />
        <asp:ListItem Text="Georgi Ivanov - Romzo" Value="#" />
    </asp:BulletedList>
</asp:Content>
