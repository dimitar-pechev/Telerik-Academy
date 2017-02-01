<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Employees.Master" AutoEventWireup="true" CodeBehind="EmplyeesGridView.aspx.cs" Inherits="DataBindingHW.EmplyeesGridView" %>

<asp:Content ID="EmployeesGridView" ContentPlaceHolderID="EmployeesContent" runat="server">
    <div class="col-md-6 text-center">
        <asp:GridView CssClass="eployees-table table table-responsive table-hover" ID="GridViewEmployees" runat="server" AutoGenerateColumns="false"
            AllowPaging="True" PageSize="5" DataKeyNames="FullName"
            OnPageIndexChanging="GridViewEmployees_PageIndexChanging"
            PagerStyle-CssClass="page-btn">
            <Columns>
                <asp:HyperLinkField DataTextField="FullName" DataNavigateUrlFields="Url" HeaderText="Employee Name" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
