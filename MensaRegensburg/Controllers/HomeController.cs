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
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
