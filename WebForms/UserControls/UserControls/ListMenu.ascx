<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListMenu.ascx.cs" Inherits="UserControls.ListMenu" %>
<link href="/Content/main.css" rel="stylesheet" />

<asp:DataList runat="server" ID="DataListLinks" RepeatDirection="Horizontal">
    <ItemTemplate>
        <a href=<%#: Eval("Url") %> runat="server" class="data-list"><%#: Eval("Title") %></a>
    </ItemTemplate>
</asp:DataList>