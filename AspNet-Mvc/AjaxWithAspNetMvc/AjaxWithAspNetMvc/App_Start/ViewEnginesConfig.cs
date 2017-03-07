using System.Web.Mvc;

namespace AjaxWithAspNetMvc.App_Start
{
    public class ViewEnginesConfig
    {
        public static void RegisterEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}