<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LocationManager.aspx.cs" Inherits="IntroToWebForms.LocationManager" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Button ID="BtnLocation" runat="server" Text="Get Assembly Location" OnClick="BtnLocation_Click" />
        <br />
        <p runat="server" id="LocationBox"></p>
    </div>
</asp:Content>
