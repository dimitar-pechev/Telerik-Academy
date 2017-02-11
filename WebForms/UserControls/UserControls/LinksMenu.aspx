<%@ Page Title="Links Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LinksMenu.aspx.cs" Inherits="UserControls.LinksMenu" %>

<%@ Register Src="~/ListMenu.ascx" TagPrefix="userControls"
    TagName="ListMenu" %>

<asp:Content ID="LinksMenu" ContentPlaceHolderID="MainContainer" runat="server">    
    <userControls:ListMenu BackgroundColor="Green"  FontColor="Red" runat="server" ID="MyListMenu"/>
</asp:Content>
