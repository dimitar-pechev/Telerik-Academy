<%@ Page Title="XML Reader" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="XmlTreeView.aspx.cs" Inherits="DataBindingHW.XmlTreeView" %>

<asp:Content ID="XmlTreeView" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row text-center">
        <h1>XML TreeView</h1>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:TreeView runat="server" DataSourceID="CatalogueXmlDataSource" OnSelectedNodeChanged="TreeViewXmlReader_SelectedNodeChanged" ID="TreeViewXmlReader" NodeIndent="35">
            </asp:TreeView>
            <asp:XmlDataSource ID="CatalogueXmlDataSource" runat="server" DataFile="~/catalogue.xml"></asp:XmlDataSource>
        </div>
        <div class="col-md-8">
            <asp:Literal Text="" ID="ResultPlaceHolder" runat="server" />
            <asp:BulletedList runat="server" ID="BulletedListResult"></asp:BulletedList>
        </div>
    </div>
</asp:Content>
