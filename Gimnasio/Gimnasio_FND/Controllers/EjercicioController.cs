using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Gimnasio_FND.Controllers
{
    public class EjercicioController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
