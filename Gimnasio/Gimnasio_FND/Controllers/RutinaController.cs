using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gimnasio_FND.Models.ViewModel;
using Gimnasio_FND.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gimnasio_FND.Controllers
{
    public class RutinaController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Rutina");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                List<RutinaViewModel> rutinas = JsonConvert.DeserializeObject<List<RutinaViewModel>>(content);

                return View(rutinas);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult EditRutina(int id)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Rutina/" + id);

            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;
            RutinaViewModel rutina = JsonConvert.DeserializeObject<RutinaViewModel>(content);

            response = serviceObj.GetResponse("api/Ejercicio");
            content = response.Content.ReadAsStringAsync().Result;

            List<EjercicioViewModel> ejercicio = JsonConvert.DeserializeObject<List<EjercicioViewModel>>(content);
            rutina.Ejercicios = ejercicio;

            return View(rutina);
        }

        [HttpPost]
        public IActionResult AddRutinaEjercicio(RutinaXejercicio model)
        {

            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/RutinaEjercicio/", model);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Mensaje = "Ejercicio Agregado";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo agregar el ejercicio";
            }
            return RedirectToAction("EditRutina", "Rutina", new { id = model.IdRutina });
        }
    }
}
