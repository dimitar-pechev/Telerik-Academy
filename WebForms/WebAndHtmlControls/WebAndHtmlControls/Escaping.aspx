<%@ Page Title="Escaping" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
     CodeBehind="Escaping.aspx.cs" Inherits="WebAndHtmlControls.Escaping" ValidateRequest="false" %>

<asp:Content ID="Escaping" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center">
        <h1>Escaping Dangerous Chars</h1>
        <div class="col-md-4 col-md-offset-4 text-center">
            <br />
            <asp:Label Text="Enter a script tag or whatever you like below:" runat="server" AssociatedControlID="InputBox" />
            <asp:TextBox runat="server" ID="InputBox" CssClass="form-control" />
            <br />
            <asp:Button Text="Submit" CssClass="btn btn-success btn-block" runat="server" ID="BtnSubmit" OnClick="BtnSubmit_Click" />
            <br />
            <asp:Literal Text="" Mode="Encode" runat="server" ID="Result" />
        </div>
    </div>
</asp:Content>
 