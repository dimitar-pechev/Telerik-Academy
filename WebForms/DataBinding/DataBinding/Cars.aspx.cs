using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBindinHW.Models;

namespace DataBinding
{
    public partial class Cars : Page
    {
        private static CarProducer[] producers = new CarProducer[]
        {
            new CarProducer() { Name = "Audi", Models = new List<string>() { "A3", "A4", "A6", "A8", "TT" } },
            new CarProducer() { Name = "BMW", Models = new List<string>() { "Z8", "313", "3" } },
            new CarProducer() { Name = "Mercedes", Models = new List<string>() { "SLS", "CL 320", "CLC 250", "E200" } },
            new CarProducer() { Name = "Volkswagen", Models = new List<string>() { "Golf", "Polo", "Touareg", "Passat", "Sharan" } },
        };

        private static string[] extras = new string[] { "Климатик", "Лети джанти", "Стерео уредба", "Кожен салон" };

        private static string[] engines = new string[] { "Дизел", "Бензин", "Електирчески" };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            this.Producer.DataSource = producers;
            this.Producer.DataBind();

            // corresponding to the default value of the first dropdown list
            this.Models.DataSource = producers[0].Models;
            this.Models.DataBind();

            this.Extras.DataSource = extras;
            this.Extras.DataBind();

            this.Engine.DataSource = engines;
            this.Engine.DataBind();
        }

        protected void Producer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var models = producers.FirstOrDefault(x => x.Name == this.Producer.SelectedValue).Models;
            this.Models.DataSource = models;
            this.Models.DataBind();
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            this.CarsOptions.Visible = false;
            this.ResultContainer.Visible = true;

            foreach (ListItem item in this.Extras.Items)
            {
                if (item.Selected)
                {
                    this.SelectedExtras.Items.Add(item);
                }
            }

            this.DataBind();
        }
    }
}