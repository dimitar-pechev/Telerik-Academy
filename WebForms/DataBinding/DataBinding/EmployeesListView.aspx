<%@ Page Title="Employees ListView" Language="C#" MasterPageFile="~/Employees.Master" AutoEventWireup="true" CodeBehind="EmployeesListView.aspx.cs" Inherits="DataBindingHW.EmployeesListView" %>

<asp:Content ID="EmployeesListView" ContentPlaceHolderID="EmployeesContent" runat="server">
    <div class="col-md-6 text-left">
        <asp:ListView ID="ListViewEmployees" runat="server" 
            ItemType="DataBindingHW.Employee">
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
        </asp:ListView>

        <asp:DataPager ID="DataPagerEmployees" runat="server"
            PagedControlID="ListViewEmployees" PageSize="1"
            QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
            </Fields>
        </asp:DataPager>
    </div>
</asp:Content>
