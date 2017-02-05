<%@ Page Title="TODO List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="DataSourceControls.TodoList" %>

<asp:Content ID="TodoList" ContentPlaceHolderID="MainContent" runat="server">
    <asp:EntityDataSource runat="server"
        ID="EntityDataSourceCategories"
        ConnectionString="name=TodoListEntities"
        DefaultContainerName="TodoListEntities"
        EntitySetName="Categories"
        EnableFlattening="false">
    </asp:EntityDataSource>

    <asp:EntityDataSource runat="server"
        ID="EntityDataSourceTodos"
        ConnectionString="name=TodoListEntities"
        DefaultContainerName="TodoListEntities"
        EnableDelete="true"
        EnableInsert="true"
        EnableUpdate="true"
        Where="it.CategoryId = @CatId"
        EntitySetName="Todos" EnableFlattening="false">
        <WhereParameters>
            <asp:ControlParameter Name="CatId" ControlID="ListBoxCategories" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>

    <h1 class="text-center">TODO List</h1>
    <div class="row">
        <div class="col-md-6">
            <h3 class="text-center">Categories</h3>
            <asp:ListBox ID="ListBoxCategories" runat="server"
                DataTextField="Name"
                OnSelectedIndexChanged="ListBoxCategories_SelectedIndexChanged"
                CssClass="form-control"
                DataValueField="CategoryId"
                DataSourceID="EntityDataSourceCategories"
                AutoPostBack="true" />
            <br />
            <asp:Panel runat="server" ID="PanelEditCategories" CssClass="text-right" Visible="false">
                <asp:TextBox runat="server" ID="InputEditCategory" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label Text="You cannot delete categories that have TODOs!" Visible="false" ID="ErrorMessage" CssClass="color: red;" runat="server" />
                <br />
                <asp:Button Text="Add category" CssClass="btn btn-success btn-sm" runat="server" ID="BtnAddNewCategory" OnClick="BtnAddNewCategory_Click" />
                <asp:Button Text="Edit Selected" CssClass="btn btn-warning btn-sm" runat="server" ID="BtnEditSelectedCategory" OnClick="BtnEditSelectedCategory_Click" />
                <asp:Button Text="Remove Selected" CssClass="btn btn-danger btn-sm" runat="server" ID="BtnRemoveSelectedCategory" OnClick="BtnRemoveSelectedCategory_Click" />
            </asp:Panel>
            <asp:Button Text="Edit Categories" CssClass="btn btn-success pull-right" ID="BtnEditCategories" runat="server" OnClick="BtnEditCategories_Click" />
        </div>
        <asp:Panel runat="server" ID="PanelResults" Visible="false">
            <div class="col-md-6">
                <asp:ListView runat="server" ID="ListViewTodos"
                    OnItemInserting="ListViewTodos_ItemInserting"
                    OnItemDeleted="ListViewTodos_ItemDeleted"
                    OnItemUpdated="ListViewTodos_ItemUpdated"
                    DataSourceID="EntityDataSourceTodos"
                    DataKeyNames="TodoId"
                    ItemType="DataSourceControls.Todo">
                    <ItemTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <%#: Item.Title %>
                            </div>
                            <div class="panel-body">
                                <%#: Item.Body %>
                                <span class="pull-right"><b>Last Change: </b><%#: Item.LastChange %></span>
                            </div>
                            <div class="panel-footer text-right">
                                <asp:Button Text="Edit" runat="server" CssClass="btn-success btn  btn-sm" CommandName="Edit" ID="BtnEditTodo" />
                                <asp:Button Text="Remove" runat="server" CssClass="btn-danger btn  btn-sm" CommandName="Delete" ID="BtnRemoveTodo" />
                            </div>
                        </div>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <h3 class="text-center">TODOs:</h3>
                        <div class="row">
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                        </div>
                    </LayoutTemplate>
                    <EditItemTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <b>
                                    <asp:TextBox runat="server" CssClass="form-control" Text="<%#: BindItem.Title %>" ID="BindTitle"></asp:TextBox></b>
                            </div>
                            <div class="panel-body">
                                <asp:TextBox runat="server" CssClass="form-control" Text="<%#: BindItem.Body %>" ID="BindBody" Rows="5"></asp:TextBox>
                            </div>
                            <div class="panel-footer text-left">
                                <asp:Button Text="Confirm" CssClass="btn btn-success btn-sm" CommandName="Update" ID="BtnUpdateConifrm" runat="server" />
                                <asp:Button Text="Cancel" CssClass="btn btn-danger btn-sm" CommandName="Cancel" ID="BtnCancelConifrm" runat="server" />
                            </div>
                        </div>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <b>
                                    <asp:TextBox runat="server" CssClass="form-control" Text="<%#: BindItem.Title %>" ID="BindTitleNew"></asp:TextBox></b>
                            </div>
                            <div class="panel-body">
                                <asp:TextBox runat="server" CssClass="form-control" Text="<%#: BindItem.Body %>" ID="BindBodyNew" Rows="5"></asp:TextBox>
                                <asp:HiddenField runat="server" ID="NewTodoCategory" Value="<%#: BindItem.CategoryId %>" />
                            </div>
                            <div class="panel-footer text-right">
                                <asp:Button Text="Insert" CssClass="btn btn-success btn-sm" CommandName="Insert" ID="BtnInsertConifrm" runat="server" />
                                <asp:Button Text="Clear" CssClass="btn btn-danger btn-sm" CommandName="Cancel" ID="BtnClearConifrm" runat="server" />
                            </div>
                        </div>
                    </InsertItemTemplate>
                    <EmptyDataTemplate>
                        <h3 class="text-center">No TODOs in this category yet!</h3>
                    </EmptyDataTemplate>
                </asp:ListView>
                <asp:Button Text="Add new" CssClass="btn btn-success pull-right" runat="server" ID="BtnAddNewTodo" OnClick="BtnAddNewTodo_Click" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
