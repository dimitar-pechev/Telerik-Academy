<%@ Page Title="Offices - United Kingdom" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UnitedKingdom.aspx.cs" Inherits="SiteMapAndNavigation.Offices.UnitedKingdom" %>

<asp:Content ID="OfficesUnitedKingdom" ContentPlaceHolderID="MainContainer" runat="server">
    <h1 class="text-center">Awesome United Kingdom Offices Page</h1>
    <div class="container">
        <asp:Menu runat="server" SkipLinkText=""
            EnableViewState="False" IncludeStyleBlock="False" Orientation="Vertical"
            DataSourceID="Office2DataSource" StaticDisplayLevels="2"  />        
        <asp:SiteMapDataSource ID="Office2DataSource" runat="server"
            ShowStartingNode="False" StartingNodeOffset="2" />
    </div>
</asp:Content>
