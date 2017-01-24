<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="GreetingsManager.aspx.cs" Inherits="IntroToWebForms.GreetingsManager" %>


<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Greetings and Stuff</h2>
        <asp:Label for="Name" runat="server">Enter your name: </asp:Label>
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <asp:Button ID="BtnSubmit" runat="server" Text="Submit!" OnClick="BtnSubmit_Click" />
        <br />
        <h3 runat="server" id="Greeting"></h3>
    </div>
</asp:Content>
