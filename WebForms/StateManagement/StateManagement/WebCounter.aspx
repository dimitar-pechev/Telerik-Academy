<%@ Page Title="Web Counter" Language="C#" MasterPageFile="~/WebCounter.Master" AutoEventWireup="true" CodeBehind="WebCounter.aspx.cs" Inherits="StateManagement.WebCounter" %>

<asp:Content ID="WebCounter" ContentPlaceHolderID="WebCounterContainer" runat="server">
    <asp:Panel CssClass="text-left" runat="server" ID="ImagePlaceholder">
        <asp:Image ImageUrl="nnn" ID="CounterImage" runat="server" />
    </asp:Panel>
</asp:Content>
