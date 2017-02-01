<%@ Page Title="Cars Rental" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="DataBinding.Cars" %>

<asp:Content ID="CarsRental" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row text-center">
        <h1>Car Rental Service</h1>
        <br />
        <div class="col-md-4 col-md-offset-4">
            <asp:Panel runat="server" ID="CarsOptions" Visible="true">
                <asp:Label Text="Producer:" AssociatedControlID="Producer" runat="server" />
                <asp:DropDownList CssClass="form-control"
                    DataTextField="Name"
                    OnSelectedIndexChanged="Producer_SelectedIndexChanged"
                    ID="Producer"
                    runat="server"
                    AutoPostBack="true">
                </asp:DropDownList>
                <asp:Label Text="Models:" AssociatedControlID="Models" runat="server" />
                <asp:DropDownList CssClass="form-control"
                    ID="Models"
                    runat="server">
                </asp:DropDownList>
                <br />
                <asp:Label Text="Extras:" runat="server" />
                <asp:CheckBoxList runat="server"
                    ID="Extras">
                </asp:CheckBoxList>
                <br />
                <asp:Label Text="Engine:" runat="server" />
                <br />
                <asp:RadioButtonList runat="server" ID="Engine" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
                <br />
                <asp:Button CssClass="btn btn-success btn-block" Text="Submit" runat="server" ID="SubmitBtn" OnClick="SubmitBtn_Click" />
            </asp:Panel>
            <asp:Panel runat="server" Visible="false" ID="ResultContainer">
                <asp:Label Text="<b>Producer & Model:</b> " runat="server" />
                <asp:Literal Text="<%# this.Producer.SelectedValue %>" ID="SelectedProducer" runat="server" />
                <asp:Literal Text="<%# this.Models.SelectedValue %>" ID="SelectedModel" runat="server" />
                <br />                
                <asp:Label Text="<b>Engine:</b> " runat="server" />
                <asp:Literal Text="<%# this.Engine.SelectedValue %>" ID="SelectedEngine" runat="server" />
                <br />
                <asp:Label Text="<b>Extras:</b>" runat="server" />
                <br />
                <asp:BulletedList runat="server" 
                    ID="SelectedExtras">
                </asp:BulletedList>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
