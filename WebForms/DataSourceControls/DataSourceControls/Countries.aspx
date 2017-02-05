<%@ Page Title="Countries" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="DataSourceControls.Countries" %>

<asp:Content ID="Countries" ContentPlaceHolderID="MainContent" runat="server">
    <asp:EntityDataSource runat="server"
        ID="EntityDataSourceContinents"
        ConnectionString="name=CountriesEntities"
        DefaultContainerName="CountriesEntities"
        EntitySetName="Continents"
        EnableFlattening="false">
    </asp:EntityDataSource>

    <asp:EntityDataSource runat="server"
        ID="EntityDataSourceCountries"
        ConnectionString="name=CountriesEntities"
        DefaultContainerName="CountriesEntities"
        EntitySetName="Countries"
        EnableDelete="true"
        EnableInsert="true"
        EnableUpdate="true"
        Where="it.ContinentId = @ContId"
        EnableFlattening="false">
        <WhereParameters>
            <asp:ControlParameter Name="ContId" ControlID="ListBoxContinents" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>

    <asp:EntityDataSource runat="server"
        ID="EntityDataSourceTowns"
        ConnectionString="name=CountriesEntities"
        DefaultContainerName="CountriesEntities"
        EntitySetName="Towns"
        EnableFlattening="false"
        EnableDelete="true"
        EnableInsert="true"
        EnableUpdate="true"
        Where="it.CountryId = @CounId">
        <WhereParameters>
            <asp:ControlParameter ControlID="GridViewCountries" Name="CounId" Type="Int32" />
        </WhereParameters>
    </asp:EntityDataSource>

    <div class="row text-center">
        <h1>Geography and Stuff</h1>
        <div class="row">
            <div class="col-md-6">
                <h3 class="text-center">Select continent</h3>
                <asp:ListBox runat="server"
                    ID="ListBoxContinents"
                    DataSourceID="EntityDataSourceContinents"
                    ItemType="DataSourceControls.Continent"
                    Rows="7" AutoPostBack="True"
                    CssClass="form-control"
                    OnSelectedIndexChanged="ListBoxContinents_SelectedIndexChanged"
                    DataTextField="Name" DataValueField="ContinentId"></asp:ListBox>
                <br />
                <asp:TextBox runat="server" ID="AddContinentInput" CssClass="form-control" />
                <br />
                <asp:Label Text="You cannot remove continents that has cities associated with it!" ID="ErrorMessage" Visible="false" runat="server" />
                <br />
                <asp:Button CssClass="btn btn-success btn-sm" Text="Add Continent" ID="BtnAddContinent" OnClick="BtnAddContinent_Click" runat="server" />
                <asp:Button CssClass="btn btn-warning btn-sm" Text="Edit Selected" ID="BtnEditContinent" OnClick="BtnEditContinent_Click" runat="server" />
                <asp:Button CssClass="btn btn-danger btn-sm" Text="Remove Selected" ID="BtnRemoveContinent" OnClick="BtnRemoveContinent_Click" runat="server" />
                <br />
                <asp:Panel runat="server" Visible="false" ID="Cities">
                    <h3 class="text-center">Cities</h3>
                    <asp:ListView runat="server" ID="ListViewTowns"
                        OnItemInserting="ListViewTowns_ItemInserting"
                        DataSourceID="EntityDataSourceTowns"
                        DataKeyNames="TownId" Enabled="true"
                        ItemType="DataSourceControls.Town">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Button Text="Edit" runat="server" CssClass="btn-success btn btn-sm" CommandName="Edit" ID="BtnEditCity" />
                                    <asp:Button Text="Delete" runat="server" CssClass="btn-danger btn btn-sm" CommandName="Delete" ID="BtnDeleteCity" />
                                </td>
                                <td><%#: Item.Name %></td>
                                <td><%#: Item.Population %></td>
                            </tr>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <tr>
                                <td>
                                    <asp:Button ID="BtnUpdateCity" runat="server" CssClass="btn btn-success btn-xs" CommandName="Update" Text="Update" />
                                    <asp:Button ID="BtnCancelCity" runat="server" CommandName="Cancel" CssClass="btn btn-danger btn-xs" Text="Cancel" />
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBoxCityName" runat="server" Text='<%# BindItem.Name %>' />
                                </td>
                                <td>
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" Text='<%# BindItem.Population %>' />
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="text-center">Add new city</h3>
                                </div>
                                <div class="panel-body">
                                    <asp:Label Text="City name:" AssociatedControlID="CityName" runat="server" />
                                    <asp:TextBox CssClass="form-control" runat="server" ID="CityName" Text="<%# BindItem.Name %>" />
                                    <asp:RequiredFieldValidator ErrorMessage="Required!" ControlToValidate="CityName" runat="server" />
                                    <asp:Label Text="Population:" AssociatedControlID="Population" runat="server" />
                                    <asp:TextBox CssClass="form-control" runat="server" ID="Population" Text="<%# BindItem.Population %>" />
                                    <asp:RangeValidator ErrorMessage="Allowed value: 0 to 50 000 000!" ControlToValidate="Population" MinimumValue="0" MaximumValue="50000000" runat="server" />
                                    <asp:RequiredFieldValidator ErrorMessage="Required!" ControlToValidate="Population" runat="server" />
                                    <asp:HiddenField runat="server" ID="NewCityCountryId" Value="<%# BindItem.CountryId %>" />
                                </div>
                                <div class="panel-footer">
                                    <asp:Button ID="BtnInsertNewCity" CssClass="btn btn-success btn-sm" runat="server" CommandName="Insert" Text="Insert" />
                                </div>
                            </div>
                        </InsertItemTemplate>
                        <LayoutTemplate>
                            <table class="table table-hover table-responsive table-bordered">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th class="text-center">Name</th>
                                        <th class="text-center">Population</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                                </tbody>
                            </table>
                            <asp:PlaceHolder ID="insertItemPlaceholder" runat="server" />
                            <asp:Button Text="Add city" runat="server" ID="BtnAddCity" CssClass="btn btn-success btn-sm" OnClick="BtnAddCity_Click" />
                        </LayoutTemplate>
                    </asp:ListView>
                </asp:Panel>
                <br />
            </div>
            <asp:Panel runat="server" Visible="false" CssClass="col-md-6" ID="countries">
                <h3 class="text-center">Select country</h3>
                <asp:GridView runat="server" CssClass="table table-hover table-responsive table-bordered"
                    DataSourceID="EntityDataSourceCountries"
                    OnRowEditing="GridViewCountries_RowEditing"
                    OnRowDeleted="GridViewCountries_RowDeleted"
                    ID="GridViewCountries" DataKeyNames="CountryId"
                    OnSelectedIndexChanged="GridViewCountries_SelectedIndexChanged"
                    AutoGenerateColumns="false" AllowSorting="true">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-success btn-sm" />
                        <asp:CommandField ShowEditButton="true" ControlStyle-CssClass="btn btn-warning btn-sm" />
                        <asp:CommandField ShowDeleteButton="true" ControlStyle-CssClass="btn btn-danger btn-sm" />
                        <asp:ImageField AlternateText="Name" ConvertEmptyStringToNull="true"
                            HeaderText="Flag" DataImageUrlField="FlagImageUrl" NullImageUrl="https://upload.wikimedia.org/wikipedia/commons/7/75/Transparent_flag_with_question_mark.png" />
                        <asp:BoundField DataField="Name" HeaderText="Country" SortExpression="Name" ReadOnly="false" />
                        <asp:BoundField DataField="Language" HeaderText="Official Language" SortExpression="Language" />
                        <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
                    </Columns>
                </asp:GridView>
                <asp:Button Text="Add Country" Visible="true" ID="BtnRevealAddCountryPanel" CssClass="btn btn-success pull-right" OnClick="BtnRevealAddCountryPanel_Click" runat="server" />
                <asp:Panel runat="server" ID="AddNewCountryPanel" Visible="false">
                    <h3 class="text-center">Add new country</h3>
                    <input type="text" class="form-control" name="CountryName" value="" placeholder="Country name..." runat="server" id="NewCountryName" />
                    <input type="text" class="form-control" name="OfficialLanguage" value="" placeholder="Official language(s)..." runat="server" id="NewCountryLanguage" />
                    <input type="number" min="0" max="2000000000" class="form-control" name="Population" value="" placeholder="Population..." runat="server" id="NewCountryPopulation" />
                    <input type="text" class="form-control" name="FlagImageUrl" value="" placeholder="Flag Image Url (Optional)..." runat="server" id="NewCountryFlag" />
                    <br />
                    <asp:Button runat="server" ID="BtnNewCountry" Text="Add Country" CssClass="btn btn-success pull-right" OnClick="BtnNewCountry_Click" />
                </asp:Panel>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
