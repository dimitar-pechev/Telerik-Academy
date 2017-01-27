<%@ Page Title="Students and Courses" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentsAndCourses.aspx.cs" Inherits="WebAndHtmlControls.StudentsAndCourses" %>

<asp:Content ID="Students" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="col-md-6 col-md-offset-3 text-center">
            <h1 id="Heading" runat="server">Students Registration Form</h1>
            <asp:Panel runat="server" ID="RegPanel">
                <asp:Label Text="First name:" runat="server" AssociatedControlID="FirstName" />
                <asp:TextBox runat="server" ID="FirstName" CssClass="form-control" />
                <br />

                <asp:Label Text="Last name:" runat="server" AssociatedControlID="LastName" />
                <asp:TextBox runat="server" ID="LastName" CssClass="form-control" />
                <br />

                <asp:Label Text="Faculty number:" runat="server" AssociatedControlID="FacultyNumber" />
                <asp:TextBox runat="server" ID="FacultyNumber" CssClass="form-control" />
                <br />

                <asp:Label Text="University:" runat="server" AssociatedControlID="UniversityList" />
                <asp:DropDownList runat="server" ID="UniversityList" CssClass="form-control">
                    <asp:ListItem Text="Sofia University" />
                    <asp:ListItem Text="UNWE" />
                    <asp:ListItem Text="South-Western University" />
                    <asp:ListItem Text="Veliko Tarnovo University" />
                    <asp:ListItem Text="Plovdiv University" />
                </asp:DropDownList>
                <br />

                <asp:Label Text="Speciality:" runat="server" AssociatedControlID="SpecialitiesList" />
                <asp:DropDownList runat="server" ID="SpecialitiesList" CssClass="form-control">
                    <asp:ListItem Text="Balkan History and Politics" />
                    <asp:ListItem Text="Software Engeneering" />
                    <asp:ListItem Text="Greek Philology and Culture" />
                    <asp:ListItem Text="Linguistics" />
                    <asp:ListItem Text="International Relations" />
                </asp:DropDownList>
                <br />

                <asp:Label Text="Courses:" runat="server" AssociatedControlID="CoursesList" />
                <asp:ListBox runat="server" SelectionMode="Multiple" CssClass="form-control" ID="CoursesList">
                    <asp:ListItem Text="The Fall of Yugoslavia: Wars and Diplomacy" />
                    <asp:ListItem Text="Greek for Beginners" />
                    <asp:ListItem Text="Ouzo and Bouzouki for Beginners" />
                    <asp:ListItem Text="Intro to C#" />
                    <asp:ListItem Text="JavaScript Fundamentals" />
                    <asp:ListItem Text="Kosovo: Wars and Independence" />
                    <asp:ListItem Text="Ethnical Issues and Human Rights Watch in the Balkans" />
                    <asp:ListItem Text="More Ouzo, please" />
                </asp:ListBox>
                <br />

                <button type="button" class="btn btn-success btn-block" data-toggle="modal" id="BtnSubmitClient" data-target="#ConfirmCourses">Submit</button>
            </asp:Panel>
            <asp:Panel runat="server" ID="RegResult" CssClass="reg-result"></asp:Panel>
        </div>
    </div>

    <!-- Dialog box -->
    <div class="modal fade" id="ConfirmCourses" role="dialog">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Confirm selected courses</h4>
                </div>
                <div class="modal-body" id="modal-body">
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-success" runat="server" id="BtnConfirmCourses" onserverclick="BtnConfirmCourses_ServerClick"
                        data-dismiss="modal">
                        Confirm</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Return</button>
                </div>
            </div>
        </div>
    </div>
    <!-- -->

    <script src="/Scripts/students-event-handler.js"></script>
</asp:Content>
