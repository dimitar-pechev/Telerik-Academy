<%@ Page Title="Offices - Bulgaria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bulgaria.aspx.cs" Inherits="SiteMapAndNavigation.Offices.Bulgaria" %>

<asp:Content ID="OfficesBulgaria" ContentPlaceHolderID="MainContainer" runat="server">
    <h1 class="text-center">Awesome Bulgarian Offices Page</h1>
    <div class="container">
        <asp:Menu runat="server" SkipLinkText=""
            EnableViewState="False" IncludeStyleBlock="False" Orientation="Vertical"
            DataSourceID="Office1DataSource" StaticDisplayLevels="2"  />        
        <asp:SiteMapDataSource ID="Office1DataSource" runat="server"
            ShowStartingNode="False" StartingNodeOffset="2" />
    </div>
</asp:Content>
