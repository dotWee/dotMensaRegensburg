using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MensaRegensburg.Models;
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

            if (String.IsNullOrWhiteSpace(weekdayValue))
            {
                Weekday weekday = Item.ValuesMap.FirstOrDefault(x => x.Value == weekdayValue).Key;
                model = new IndexViewModel(weekday);
            }

            else
            {
                model = new IndexViewModel(Enum.GetValues(typeof(Weekday)).Cast<Weekday>().ToArray());
            }

			Console.WriteLine($"id={weekdayValue}");
            return View(model);
		}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
