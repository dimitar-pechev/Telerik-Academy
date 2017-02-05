using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataSourceControls
{
    public partial class TodoList : System.Web.UI.Page
    {
        private TodoListEntities db = new TodoListEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnEditCategories_Click(object sender, EventArgs e)
        {
            this.BtnEditCategories.Visible = false;
            this.PanelEditCategories.Visible = true;
        }

        protected void BtnEditSelectedCategory_Click(object sender, EventArgs e)
        {
            if (this.ListBoxCategories.SelectedItem == null ||
                string.IsNullOrEmpty(this.InputEditCategory.Text.Trim()))
            {
                return;
            }

            int id;
            var isParsable = int.TryParse(this.ListBoxCategories.SelectedItem.Value, out id);

            if (!isParsable)
            {
                return;
            }

            var category = this.db.Categories.FirstOrDefault(td => td.CategoryId == id);
            var newCategoryName = this.InputEditCategory.Text.Trim();
            category.Name = newCategoryName;
            this.InputEditCategory.Text = string.Empty;
            this.db.SaveChanges();
            this.ListBoxCategories.DataBind();
        }

        protected void BtnRemoveSelectedCategory_Click(object sender, EventArgs e)
        {
            if (this.ListBoxCategories.SelectedItem == null)
            {
                return;
            }

            int id;
            var isParsable = int.TryParse(this.ListBoxCategories.SelectedItem.Value, out id);

            if (!isParsable)
            {
                return;
            }

            var targetCategory = this.db.Categories.FirstOrDefault(c => c.CategoryId == id);

            if (targetCategory.Todos.Count != 0)
            {
                this.ErrorMessage.Visible = true;
                return;
            }

            this.db.Categories.Remove(targetCategory);

            this.db.SaveChanges();
            this.ListBoxCategories.DataBind();
        }

        protected void BtnAddNewCategory_Click(object sender, EventArgs e)
        {
            var categoryName = this.InputEditCategory.Text.Trim();

            if (string.IsNullOrEmpty(categoryName) || this.db.Categories.Any(c => c.Name == categoryName))
            {
                this.InputEditCategory.Text = string.Empty;
                return;
            }

            var category = new Category() { Name = categoryName };
            this.db.Categories.Add(category);

            this.db.SaveChanges();
            this.ListBoxCategories.DataBind();
            this.InputEditCategory.Text = string.Empty;
        }

        protected void BtnAddNewTodo_Click(object sender, EventArgs e)
        {
            this.ListViewTodos.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void ListViewTodos_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            object categoryId = "CategoryId";
            e.Values[categoryId] = int.Parse(this.ListBoxCategories.SelectedValue.ToString());

            object lastChange = "LastChange";
            e.Values[lastChange] = DateTime.Now;
        }

        protected void ListViewTodos_ItemEditing(object sender, ListViewEditEventArgs e)
        {
            var editedItem = this.ListBoxCategories.Items[e.NewEditIndex];
        }

        protected void ListViewTodos_ItemUpdated(object sender, ListViewUpdatedEventArgs e)
        {
            var title = e.NewValues["Title"];
            var todo = this.db.Todos.FirstOrDefault(td => td.Title == title.ToString());

            todo.LastChange = DateTime.Now;
            this.db.SaveChanges();
        }

        protected void ListBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PanelResults.Visible = true;
            this.ErrorMessage.Visible = false;
        }

        protected void ListViewTodos_ItemDeleted(object sender, ListViewDeletedEventArgs e)
        {
            this.ErrorMessage.Visible = false;
        }
    }
}