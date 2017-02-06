<%@ Page Title="Web Counter" Language="C#" MasterPageFile="~/WebCounter.Master" AutoEventWireup="true" CodeBehind="WebCounterWithDb.aspx.cs" Inherits="StateManagement.WebCounterWithDb" %>

<asp:Content ID="WebCounterDb" ContentPlaceHolderID="WebCounterContainer" runat="server">
    <asp:Panel CssClass="text-left" runat="server" ID="ImagePlaceholderDb">
        <asp:Image ImageUrl="nnn" ID="CounterImageDb" runat="server" />
        <br />
        <asp:Label Text="*done with cookies instead of sql db to keep things simple..." runat="server" />
    </asp:Panel>
</asp:Content>
