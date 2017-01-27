using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAndHtmlControls
{
    public partial class StudentsAndCourses : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnConfirmCourses_ServerClick(object sender, EventArgs e)
        {
            this.RegPanel.Visible = false;
            this.Heading.InnerHtml = "Registration Successfull!";

            var fullName = $"{this.FirstName.Text} {this.LastName.Text}";
            var facultyNum = this.FacultyNumber.Text;
            var university = this.UniversityList.SelectedValue;
            var speciality = this.SpecialitiesList.SelectedValue;

            var coursesList = new BulletedList();
            foreach (ListItem item in this.CoursesList.Items)
            {
                if (item.Selected)
                {
                    coursesList.Items.Add(item.Value);
                }
            }
            
            var dialogBox = new Label();
            dialogBox.Text = $"Full Name: {fullName}<br />University: {university}<br />Speciality: {speciality}<br />Faculty Number: {facultyNum}<br />Courses signed:<br />";
            this.RegResult.CssClass += " text-left";
            this.RegResult.Controls.Add(dialogBox);
            this.RegResult.Controls.Add(coursesList);
        }
    }
}