using System.Web.Mvc;

namespace AspNetMvcEssentials.App_Start
{
    public class ViewEnginesConfig
    {
        internal static void RegisterEngines()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}