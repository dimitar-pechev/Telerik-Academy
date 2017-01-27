<%@ Page Title="Random Number" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RandomNumberGenerator.aspx.cs" Inherits="WebAndHtmlControls.RandomNumberGenerator" %>

<asp:Content ID="RandomNumber" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row text-center">
            <h1>Random Number Generator</h1>
            <div class="col-md-5 text-center">
                <h3>HTML Controls</h3>
                <label for="randomFrom">
                    Start from:
                </label>
                <input class="form-control" type="text" runat="server" id="randomFrom" />
                <br />
                <label for="randomUntil">
                    Until:
                </label>
                <input type="text" runat="server" id="randomUntil" class="form-control" />
                <br />
                <button type="button" class="btn btn-success btn-block" runat="server" id="HtmlBtnSubmit" onserverclick="HtmlBtnSubmit_ServerClick">Generate!</button>
                <br />
                <span class="result" runat="server" id="HtmlResult"></span>
            </div>
            <div class="col-md-5 col-md-offset-2 text-center">
                <h3>Web Controls</h3>
                <asp:Label Text="Start from:" runat="server" AssociatedControlID="webRandomFrom" />
                <asp:TextBox runat="server" ID="webRandomFrom"  CssClass="form-control"  />
                <br />
                <asp:Label Text="Until:" runat="server" AssociatedControlID="webRandomUntil" />
                <asp:TextBox runat="server" ID="webRandomUntil"  CssClass="form-control" />
                <br />
                <asp:Button CssClass="btn btn-success btn-block" Text="Generate!" runat="server" ID="WebBtnSubmit" OnClick="WebBtnSubmit_Click"/>
                <br />
                <asp:Label Text="" runat="server" ID="WebResult" CssClass="result" />
            </div>
        </div>
    </div>
</asp:Content>
