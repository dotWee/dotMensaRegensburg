using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MensaRegensburg.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MensaRegensburg.Controllers
{
    public class MenuController : Controller
    {
		public IActionResult Index([Bind(Prefix = "id")] string weekdayValue)
		{
            Weekday weekday = Item.ValuesMap.FirstOrDefault(x => x.Value == weekdayValue).Key;

            MenuViewModel model = new MenuViewModel(weekday);
			return View(model);
		}
    }
}
