<%@ Page Title="Tic Tac Toe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TicTacToe.aspx.cs" Inherits="WebAndHtmlControls.TicTacToe" %>

<asp:Content ID="TicTacToe" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-4 col-md-offset-4 text-center">
            <h1>Tic Tac Toe</h1>
            <br />
            <asp:Table runat="server" ID="Table">
                <asp:TableRow runat="server" CssClass="tr">
                    <asp:TableCell runat="server" CssClass="td">
                        <asp:ImageButton ID="CellAt1" CommandName="CellAt1" OnCommand="Button_Command"
                            ImageUrl="../Images/tranBg.png" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell runat="server" CssClass="td">
                        <asp:ImageButton ID="CellAt2" CommandName="CellAt2" OnCommand="Button_Command"
                            ImageUrl="../Images/tranBg.png" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell runat="server" CssClass="td">
                        <asp:ImageButton ID="CellAt3" CommandName="CellAt3" OnCommand="Button_Command"
                            ImageUrl="../Images/tranBg.png" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" CssClass="tr">
                    <asp:TableCell runat="server" CssClass="td">
                        <asp:ImageButton ID="CellAt4" CommandName="CellAt4" OnCommand="Button_Command"
                            ImageUrl="../Images/tranBg.png" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell runat="server" CssClass="td">
                        <asp:ImageButton ID="CellAt5" CommandName="CellAt5" OnCommand="Button_Command"
                            ImageUrl="../Images/tranBg.png" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell runat="server" CssClass="td">
                        <asp:ImageButton ID="CellAt6" CommandName="CellAt6" OnCommand="Button_Command"
                            ImageUrl="../Images/tranBg.png" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server" CssClass="tr">
                    <asp:TableCell runat="server" CssClass="td">
                        <asp:ImageButton ID="CellAt7" CommandName="CellAt7" OnCommand="Button_Command"
                            ImageUrl="../Images/tranBg.png" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell runat="server" CssClass="td">
                        <asp:ImageButton ID="CellAt8" CommandName="CellAt8" OnCommand="Button_Command"
                            ImageUrl="../Images/tranBg.png" runat="server" />
                    </asp:TableCell>
                    <asp:TableCell runat="server" CssClass="td">
                        <asp:ImageButton ID="CellAt9" CommandName="CellAt9" OnCommand="Button_Command"
                            ImageUrl="../Images/tranBg.png" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Panel runat="server" ID="ExitPanel" Visible="false">
                <h2 runat="server" id="ExitMessage"></h2>
                <asp:Button Text="Play Again" ID="PlayAgain" OnClick="PlayAgain_Click" CssClass="btn btn-success" runat="server" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
