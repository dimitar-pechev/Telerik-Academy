<%@ Page Title="Upload Stuff" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadTxts.aspx.cs" Inherits="AspNetFileUpload.UploadTxts" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ccl" %>

<asp:Content ID="UploadStuff" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="row">
        <ccl:AjaxFileUpload runat="server"
            AllowedFileTypes="zip"
            MaximumNumberOfFiles="1"
            MaxFileSize="102400"
            ID="UploadForm"
            OnUploadComplete="UploadForm_UploadComplete" />
        <br />
        <p class="text-center">Only .zip files allowed! If the .zip contains files different from plain text format, they won't be read and stored to the DB properly!</p>
        <br />
        <asp:Button Text="Get Files Text from DB" CssClass="btn btn-success" runat="server" ID="BtnGetFilesFromDb" OnClick="BtnGetFilesFromDb_Click" />
        <asp:Panel runat="server" ID="Result" Visible="false">
            <h3 class="text-center">Extracted text</h3>
        </asp:Panel>
    </div>
</asp:Content>
