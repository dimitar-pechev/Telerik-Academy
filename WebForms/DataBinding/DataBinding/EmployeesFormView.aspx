<%@ Page Title="Employees Form View" Language="C#" MasterPageFile="~/Employees.Master" AutoEventWireup="true" CodeBehind="EmployeesFormView.aspx.cs" Inherits="DataBindingHW.EmployeesFormView" %>

<asp:Content ID="EmployeesFormView" ContentPlaceHolderID="EmployeesContent" runat="server">
    <div class="col-md-6">
        <asp:FormView CssClass="text-left emplyees-formview-table" runat="server" ID="FormViewEmployees"
            AllowPaging="true" ItemType="DataBindingHW.Employee"
            OnPageIndexChanging="FormViewEmployees_PageIndexChanging1">
            <ItemTemplate>
                <h3><%#: Item.FirstName + " " + Item.LastName  %></h3>
                <p><b>Country: </b><%#: Item.Country %></p>
                <p><b>City: </b><%#: Item.City %></p>
                <p><b>Address: </b><%#: Item.Address %></p>
                <p><b>Birth Date: </b><%#: Item.BirthDate.Value.ToString("dd/MMM/yyyy") %></p>
                <p><b>Home Phone: </b><%#:  Item.HomePhone %></p>
                <p><b>Hire Date: </b><%#: Item.HireDate.Value.ToString("dd/MMM/yyyy") %></p>
                <p><b>Notes: </b><%#: Item.Notes %></p>
            </ItemTemplate>
        </asp:FormView>
    </div>
</asp:Content>
