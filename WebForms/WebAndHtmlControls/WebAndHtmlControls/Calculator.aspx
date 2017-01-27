<%@ Page Title="Calculator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="WebAndHtmlControls.Calculator" %>

<asp:Content ID="Calculator" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row text-center">
            <h1>Calculator Extravaganza</h1>
        </div>
        <br />
        <div class="col-md-4 col-md-offset-4 calc-container">
            <asp:Panel runat="server" CssClass="panel-result">
                <asp:Label Text="" runat="server" ID="ResultContainer" CssClass="text-right pull-right result-placeholder" />
            </asp:Panel>
            <asp:Panel runat="server" CssClass="panel-controls">
                <div class="row">
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="7" OnCommand="Button_Command" Text="7"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="8" OnCommand="Button_Command" Text="8"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="9" OnCommand="Button_Command" Text="9"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="add" OnCommand="Button_Command" Text="+"></asp:Button>
                </div>
                <div class="row">
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="4" OnCommand="Button_Command" Text="4"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="5" OnCommand="Button_Command" Text="5"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="6" OnCommand="Button_Command" Text="6"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="subst" OnCommand="Button_Command" Text="-"></asp:Button>
                </div>
                <div class="row">
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="1" OnCommand="Button_Command" Text="1"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="2" OnCommand="Button_Command" Text="2"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="3" OnCommand="Button_Command" Text="3"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="multiply" OnCommand="Button_Command" Text="x"></asp:Button>
                </div>
                <div class="row">
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="." OnCommand="Button_Command" Text="."></asp:Button>                    
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="0" OnCommand="Button_Command" Text="0"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="sqrt" OnCommand="Button_Command" Text="√"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="divide" OnCommand="Button_Command" Text="/"></asp:Button>
                </div>

                <div class="row">
                    <asp:Button runat="server" CssClass="col-md-3 number-cell text-center" CommandName="clear" OnCommand="Button_Command" Text="C" ID="dangerBtn"></asp:Button>
                    <asp:Button runat="server" CssClass="col-md-3 equals-sign text-center" CommandName="eqls" OnCommand="Button_Command" Text="="></asp:Button>
                </div>

<%--                <asp:Label Text="" runat="server" Visible="true" ID="PrevValue"/>
                <asp:Label Text="" runat="server" Visible="true" ID="ShouldErase"/>
                <asp:Label Text="" runat="server" Visible="true" ID="PrevSign" />--%>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
