using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MensaRegensburg.Models;
using MensaRegensburg.Library;
using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using System.IO;
using System.Runtime.Serialization.Json;

namespace MensaRegensburg.Controllers
{
    public class HomeController : Controller
    {
		public IActionResult Index([Bind(Prefix = "id")] string weekdayValue)
		{
            IndexViewModel model;

            // If a weekday is named using the asp-route-id tag, return the menu for this specific day
            if (Item.WeekdayValuesMap.ContainsValue(weekdayValue))
            {
                Weekday weekday = Item.WeekdayValuesMap.FirstOrDefault(x => x.Value == weekdayValue).Key;
                model = new IndexViewModel(weekday);

                Debug.WriteLine($"Menu for day={weekday} (weekdayValue={weekdayValue}) requested");
            }
        
            // In case to matching day is named, return the menu for the whole week
            else
            {
                model = new IndexViewModel(Enum.GetValues(typeof(Weekday)).Cast<Weekday>().ToArray());
                Debug.WriteLine($"Menu for whole week (weekdayValue={weekdayValue}) requested");
            }

            return View(model);
		}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
