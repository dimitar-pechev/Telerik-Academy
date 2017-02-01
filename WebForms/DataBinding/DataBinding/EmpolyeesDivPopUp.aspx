<%@ Page Title="Employees" Language="C#" MasterPageFile="~/Employees.Master" AutoEventWireup="true" CodeBehind="EmpolyeesDivPopUp.aspx.cs" Inherits="DataBindingHW.EmpolyeesDivPopUp" %>

<asp:Content ID="EmployeesDivPopUp" ContentPlaceHolderID="EmployeesContent" runat="server">
    <div class="col-md-6 text-center">
        <table id="table" class="table table-bordered table-hover table-responsive">
            <thead>
                <tr>
                    <th class="text-center">Name</th>
                    <th class="text-center">Country</th>
                    <th class="text-center">City</th>
                </tr>
            </thead>
            <tbody>
                <asp:ListView runat="server" ID="ListViewEmployeesPopUp" ItemType="DataBindingHW.Employee">
                    <ItemTemplate>
                        <tr id="<%#: Item.EmployeeID %>">
                            <td><%#: Item.FirstName + " " + Item.LastName %></td>
                            <td><%#: Item.Country %></td>
                            <td><%#: Item.City %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </tbody>
        </table>
        <asp:DataPager ID="DataPagerEmployeesPopUp" runat="server"
            PagedControlID="ListViewEmployeesPopUp" PageSize="5"
            QueryStringField="page">
            <Fields>
                <asp:NextPreviousPagerField ButtonCssClass="page-btn" ShowFirstPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" />
                <asp:NumericPagerField NumericButtonCssClass="page-btn"  />
                <asp:NextPreviousPagerField ShowLastPageButton="true"
                    ShowNextPageButton="false" ShowPreviousPageButton="false" ButtonCssClass="page-btn" />
            </Fields>
        </asp:DataPager>
    </div>
    <div id="pop" class="popbox">
        <h4 id="name"></h4>
        <p id="phone"></p>
        <p id="address"></p>
        <p id="notes"></p>
    </div>
    <script>
        $('tbody tr').hover((e) => {
            $.ajax({
                type: 'POST',
                url: '/EmpolyeesDivPopUp.aspx/GetEmployeeByID',
                contentType: 'application/json',
                data: JSON.stringify({ id: e.currentTarget.id })
            })
            .done((result) => {
                $('#name').html(result.d.Name);
                $('#phone').html("<b>Phone num:</b> " + result.d.Phone);
                $('#address').html("<b>Address:</b> " + result.d.Address);
                $('#notes').html("<b>Notes:</b> " + result.d.Notes);
            });

            $('#pop').show();
            $('#pop').css({
                position: "absolute",
                marginLeft: 0, marginTop: 0,
                top: $(e.currentTarget).position().top + 40, left: $(e.currentTarget).position().left + 80

            });
        });

        $('tbody').mouseleave((e) => {
            $('#pop').hide();
        });
    </script>
</asp:Content>
