<%@ Page Title="<%#: this.FullName %>" Language="C#" MasterPageFile="~/Employees.Master" AutoEventWireup="true" CodeBehind="EmployeeDetails.aspx.cs" Inherits="DataBindingHW.EmployeeDetails" %>

<asp:Content ID="EmployeeDetails" ContentPlaceHolderID="EmployeesContent" runat="server">
    <div class="row text-center">
        <h1><%#: this.FullName %></h1>
        <div class="text-left">
            <asp:DetailsView ID="DetailsViewEmployee" runat="server" CssClass="table table-hovered eployees-table"
                AutoGenerateRows="true" AllowPaging="false">
            </asp:DetailsView>
            <br />            
        </div>
        <asp:Button Text="Back" CssClass="btn btn-lg btn-success" ID="BtnBack" OnClick="BtnBack_Click" runat="server" />
        <br />
        <br />
    </div>
</asp:Content>
