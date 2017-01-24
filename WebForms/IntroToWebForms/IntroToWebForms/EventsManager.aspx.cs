using System;
using System.Collections.Generic;
using System.Web.UI;

namespace IntroToWebForms
{
    public partial class EventsManager : Page
    {
        private IList<string> progressRates = new List<string>();

        protected override void OnPreInit(EventArgs e)
        {
            this.progressRates.Add("OnPreInit");
        }

        protected override void OnInit(EventArgs e)
        {
            this.progressRates.Add("OnInit");
        }

        protected override void OnInitComplete(EventArgs e)
        {
            this.progressRates.Add("OnInitComplete");
        }

        protected override void OnPreLoad(EventArgs e)
        {
            this.progressRates.Add("OnPreLoad");
        }

        protected override void OnLoad(EventArgs e)
        {
            this.progressRates.Add("OnLoad");
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            this.progressRates.Add("OnLoadComplete");
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.progressRates.Add("OnPreRender");
        }

        protected override void OnPreRenderComplete(EventArgs e)
        {
            this.progressRates.Add("OnPreRenderComplete");
        }

        protected override void OnSaveStateComplete(EventArgs e)
        {
            this.progressRates.Add("OnSaveStateComplete");

            foreach (var str in this.progressRates)
            {
                this.BulletedList.Items.Add(str);
            }
        }
    }
}