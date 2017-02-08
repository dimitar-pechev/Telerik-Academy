<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="AjaxControls.Employees" %>

<asp:Content ID="Employees" ContentPlaceHolderID="MainContainer" runat="server">
    <asp:ScriptManager runat="server" />
    <asp:EntityDataSource runat="server"
        ID="EntityDataSourceEmployees"
        ConnectionString="name=NorthwindEntities"
        DefaultContainerName="NorthwindEntities"
        EntitySetName="Employees"
        EnableFlattening="false">
    </asp:EntityDataSource>

    <asp:EntityDataSource runat="server"
        ID="EntityDataSourceOrders"
        ConnectionString="name=NorthwindEntities"
        DefaultContainerName="NorthwindEntities"
        EntitySetName="Orders"
        Where="it.EmployeeID = @EmpId"
        EnableFlattening="false">
        <WhereParameters>
            <asp:ControlParameter Name="EmpId" ControlID="GridViewEmployees" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>

    <h3 class="text-center">Employees</h3>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:GridView runat="server"
                DataSourceID="EntityDataSourceEmployees"
                ID="GridViewEmployees"
                DataKeyNames="EmployeeID"
                CssClass="table table-hover table-bordered table-responsive"
                OnSelectedIndexChanging="GridViewEmployees_SelectedIndexChanging"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-success btn-sm" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" DataFormatString="{0:dd MMM yyyy}" />
                    <asp:BoundField DataField="HireDate" HeaderText="Hire Date" DataFormatString="{0:dd MMM yyyy}" />
                    <asp:BoundField DataField="Country" HeaderText="Country" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="UpdateProgressOrders" runat="server">
        <ProgressTemplate>
            <div class="ajax-loader-container">
                <img src="/Images/black-broken-circle.gif"
                    alt="ajax-loader" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdatePanel runat="server" ID="Orders">
        <ContentTemplate>
            <h3 class="text-center">Orders</h3>
            <asp:GridView runat="server"
                DataSourceID="EntityDataSourceOrders"
                CssClass="table table-hover table-bordered"
                AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="OrderID" HeaderText="Order ID" />
                    <asp:BoundField DataField="ShipName" HeaderText="Receiver" />
                    <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:dd MMM yyyy}" />
                    <asp:BoundField DataField="RequiredDate" HeaderText="Required Date" DataFormatString="{0:dd MMM yyyy}" />
                    <asp:BoundField DataField="ShippedDate" HeaderText="Shipped Date" DataFormatString="{0:dd MMM yyyy}" />
                    <asp:BoundField DataField="ShipCountry" HeaderText="Ship Country" />
                    <asp:BoundField DataField="ShipCity" HeaderText="Ship City" />
                    <asp:BoundField DataField="ShipAddress" HeaderText="Ship Address" />
                </Columns>
                <EmptyDataTemplate>
                    <h4 class="text-center"> Select an employee...</h4>
                </EmptyDataTemplate>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
