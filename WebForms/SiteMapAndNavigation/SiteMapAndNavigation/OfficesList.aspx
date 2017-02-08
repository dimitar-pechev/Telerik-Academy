<%@ Page Title="Offices" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OfficesList.aspx.cs" Inherits="SiteMapAndNavigation.OfficesList" %>

<asp:Content ID="Offices" ContentPlaceHolderID="MainContainer" runat="server">
    <h1 class="text-center">Awesome Offices Page</h1>
    <div class="container">
        <asp:Menu runat="server" SkipLinkText=""
            EnableViewState="False" IncludeStyleBlock="False" Orientation="Vertical"
            DataSourceID="OfficesDataSource" StaticDisplayLevels="2" />
        <asp:SiteMapDataSource ID="OfficesDataSource" runat="server"
            ShowStartingNode="False" StartingNodeOffset="1" />
    </div>
</asp:Content>
