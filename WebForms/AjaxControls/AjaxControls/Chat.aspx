<%@ Page Title="Chat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="AjaxControls.Chat" %>

<asp:Content ID="Chat" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
            <h1 class="text-center">Chat Extravaganza</h1>
            <asp:Panel runat="server" ID="Credentials" CssClass="text-center">
                <asp:Label Text="Enter your name:" AssociatedControlID="Username" runat="server" />
                <asp:TextBox runat="server" ID="Username" CssClass="form-control" />
                <asp:RequiredFieldValidator ErrorMessage="Type something..." ControlToValidate="Username" runat="server" />
                <br />
                <asp:Button Text="Start chatting!" CssClass="btn btn-success" ID="BtnSubmitUsername" OnClick="BtnSubmitUsername_Click" runat="server" />
            </asp:Panel>

            <asp:Panel runat="server" ID="ChatPanel">
                <asp:UpdatePanel runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="TimerTimeRefresh" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:ListView runat="server" ID="ListViewMessages"
                            ItemType="AjaxControls.Message">
                            <LayoutTemplate>
                                <div class="panel panel-default" id="chat-box">
                                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                                </div>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <asp:Label Text="<%#: Item.MessageContent %>" runat="server" CssClass="message-content" />
                                <asp:Label Text="<%#: Item.Author %>" runat="server" CssClass="message-author" />
                                <asp:Label Text="<%#: Item.PostedOn.ToShortDateString() %>" runat="server" CssClass="message-date" />
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <h4 class="text-center">No messages yet...</h4>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox runat="server" CssClass="form-control" ID="ChatMessage" />
                        <br />
                        <asp:Button Text="Send" CssClass="btn btn-success btn-sm pull-right" runat="server" OnClick="ChatMessage_TextChanged" />
                        <asp:Button Text="Sign out" CssClass="btn btn-danger btn-sm pull-left" runat="server" ID="BtnSignOut" OnClick="BtnSignOut_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Timer ID="TimerTimeRefresh" runat="Server" Interval="500" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
