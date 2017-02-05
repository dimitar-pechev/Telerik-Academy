using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataSourceControls
{
    public partial class Countries : Page
    {
        private CountriesEntities db = new CountriesEntities();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBoxContinents_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ErrorMessage.Visible = false;
            this.countries.Visible = true;
            this.Cities.Visible = false;
        }

        protected void GridViewCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cities.Visible = true;
            this.ErrorMessage.Visible = false;
        }

        protected void BtnAddContinent_Click(object sender, EventArgs e)
        {
            var newContinent = this.AddContinentInput.Text.Trim();
            this.AddContinentInput.Text = string.Empty;
            var isDuplicate = this.db.Continents.Any(c => c.Name == newContinent);

            if (string.IsNullOrEmpty(newContinent) || isDuplicate)
            {
                return;
            }

            this.db.Continents.Add(new Continent() { Name = newContinent });
            this.db.SaveChanges();
            this.ListBoxContinents.DataBind();
        }

        protected void BtnEditContinent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ListBoxContinents.SelectedValue) || string.IsNullOrEmpty(this.AddContinentInput.Text.Trim()))
            {
                return;
            }

            var targetContinent = this.db.Continents.FirstOrDefault(c => c.Name == this.ListBoxContinents.SelectedItem.Text);

            if (targetContinent == null)
            {
                return;
            }

            targetContinent.Name = this.AddContinentInput.Text.Trim();
            this.db.SaveChanges();
            this.AddContinentInput.Text = string.Empty;
            this.ListBoxContinents.DataBind();
        }

        protected void BtnRemoveContinent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ListBoxContinents.SelectedValue))
            {
                return;
            }

            var targetContinent = this.db.Continents.FirstOrDefault(c => c.Name == this.ListBoxContinents.SelectedItem.Text);

            if (targetContinent == null)
            {
                return;
            }

            if (targetContinent.Countries.Count != 0)
            {
                this.ErrorMessage.Visible = true;
                return;
            }

            this.db.Continents.Remove(targetContinent);
            this.db.SaveChanges();
            this.ListBoxContinents.DataBind();
        }

        protected void BtnNewCountry_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ListBoxContinents.SelectedItem.Text))
            {
                return;
            }

            var continent = this.db.Continents.FirstOrDefault(c => c.Name == this.ListBoxContinents.SelectedItem.Text);

            var name = this.NewCountryName.Value.Trim();
            var language = this.NewCountryLanguage.Value.Trim();
            var population = this.NewCountryPopulation.Value.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(language) || string.IsNullOrEmpty(population) || int.Parse(population) < 0)
            {
                return;
            }

            if (this.db.Countries.Any(c => c.Name == name))
            {
                return;
            }

            string flagUrl = null;
            if (!string.IsNullOrEmpty(this.NewCountryFlag.Value))
            {
                flagUrl = this.NewCountryFlag.Value;
            }

            var country = new Country() { Continent = continent, Name = name, Population = int.Parse(population), Language = language, FlagImageUrl = flagUrl };
            this.db.Countries.Add(country);
            this.db.SaveChanges();
            this.GridViewCountries.DataBind();

            this.NewCountryName.Value = string.Empty;
            this.NewCountryLanguage.Value = string.Empty;
            this.NewCountryPopulation.Value = string.Empty;
            this.NewCountryFlag.Value = string.Empty;
            this.AddNewCountryPanel.Visible = false;
            this.BtnRevealAddCountryPanel.Visible = true;
        }

        protected void BtnRevealAddCountryPanel_Click(object sender, EventArgs e)
        {
            this.BtnRevealAddCountryPanel.Visible = false;
            this.AddNewCountryPanel.Visible = true;
        }

        protected void BtnAddCity_Click(object sender, EventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void ListViewTowns_ItemInserting(object sender, ListViewInsertEventArgs e)
        {
            object countryId = "CountryId";
            e.Values[countryId] = int.Parse(this.GridViewCountries.SelectedValue.ToString());
        }

        protected void GridViewCountries_RowEditing(object sender, GridViewEditEventArgs e)
        {
            var countryName = this.GridViewCountries.Rows[e.NewEditIndex].Cells[4].Text;
            var targetCountry = this.db.Countries.FirstOrDefault(c => c.Name == countryName);
            if (string.IsNullOrEmpty(targetCountry.FlagImageUrl))
            {
                targetCountry.FlagImageUrl = string.Empty;
            }
            
            this.db.SaveChanges();
        }

        protected void GridViewCountries_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            this.ErrorMessage.Visible = false;
        }
    }
}