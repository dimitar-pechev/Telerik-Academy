using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNetMvcEssentials.Controllers
{
    public class CalculatorController : Controller
    {
        private static string ErrorMessage = "You just had to push it... Can't deal with numbers which names I don't even know...";

        // GET: Calculator
        public ActionResult Index(string quantityString, string unit)
        {
            if (string.IsNullOrEmpty(quantityString))
            {
                quantityString = "1";
            }

            var quantity = 0m;
            var isParsable = decimal.TryParse(quantityString, out quantity);

            if (!isParsable)
            {
                ViewBag.ErrorMessage = ErrorMessage;
                return View();
            }

            var bytesDictionary = new Dictionary<string, decimal>();

            var units = new string[]
            {
                "bit", "byte", "kilobit", "kilobyte", "megabit", "megabyte", "gigabit", "gigabyte", "terabit", "terabyte"
            };

            var bitValue = 1m;
            bytesDictionary.Add(units[0], bitValue);

            for (int i = 1; i < units.Length; i++)
            {
                if (i % 2 != 0)
                {
                    bitValue /= 8;
                }
                else
                {
                    bitValue /= 128;
                }

                bytesDictionary.Add(units[i], bitValue);
            }
            
            var index = Array.IndexOf(units, unit);
            var multiplier = 1L;

            for (int i = 1; i <= index; i++)
            {
                if (i % 2 == 0)
                {
                    multiplier *= 128;
                }
                else
                {
                    multiplier *= 8;
                }
            }

            try
            {
                for (int i = 0; i < units.Length; i++)
                {
                    bytesDictionary[units[i]] *= (decimal)quantity * multiplier;

                    if (((Math.Ceiling(bytesDictionary[units[i]]) / bytesDictionary[units[i]]) < 1.0000000000001m))
                    {
                        bytesDictionary[units[i]] = Math.Ceiling(bytesDictionary[units[i]]);
                    }
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = ErrorMessage;
            }

            ViewBag.BytesDictionary = bytesDictionary;
            ViewBag.unit = new SelectList(units);

            return View();
        }
    }
}