<%@ Page Title="View State Terminator" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewStateTerminator.aspx.cs" Inherits="StateManagement.ViewStateTerminator" %>

<asp:Content ID="ViewStateTerminator" ContentPlaceHolderID="MainContainer" runat="server">
    <h1 class="text-center">View State Terminator</h1>

    <div class="col-md-6 col-md-offset-3 text-center">
        <asp:TextBox runat="server" ID="RandomInput" CssClass="form-control" />
        <br />
        <button type="button" class="btn btn-success" id="BtnClearViewState">Clear ViewState (JS Event)</button>
        <asp:Button Text="Trigger PostBack" runat="server" CssClass="btn btn-success" ID="BtnActivatePostBack" OnClick="BtnActivatePostBack_Click" />
    </div>
    <script>
        $('#BtnClearViewState').on('click', () => {
            $('#__VIEWSTATE').parent().html('');
        });
    </script>
</asp:Content>
