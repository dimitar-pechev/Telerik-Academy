<%@ Page Title="Employees Repeater" Language="C#" MasterPageFile="~/Employees.Master" AutoEventWireup="true" CodeBehind="EmployeesRepeater.aspx.cs" Inherits="DataBindingHW.EmployeesRepeater" %>

<asp:Content ID="EmployeesRepeater" ContentPlaceHolderID="EmployeesContent" runat="server">
    <div class="col-md-6 text-left">
        <asp:Repeater runat="server" ID="RepeaterEmployees" ItemType="DataBindingHW.Employee">
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
            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
