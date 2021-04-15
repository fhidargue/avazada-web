using Gimnasio_FND.Models.ViewModel;
using Gimnasio_FND.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gimnasio_FND.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Usuario");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                List<UsuarioViewModel> usuarios = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(content);

                ViewBag.Title = "All Usuarios";
                return View(usuarios);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(Models.ViewModel.UsuarioViewModel usuario)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Usuario/agregar", usuario);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }
    }
}
