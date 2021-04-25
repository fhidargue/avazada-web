using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Gimnasio_FND.Models.ViewModel;
using Gimnasio_FND.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gimnasio_FND.Controllers
{
    public class RutinaController : Controller
    {
        #region Vistas



        [Authorize(Roles = "Entrenador")]
        [HttpGet("MisClientes")]
        public IActionResult MisClientes()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Rutina");

                var content = response.Content.ReadAsStringAsync().Result;
                List<RutinaViewModel> usuarios = JsonConvert.DeserializeObject<List<RutinaViewModel>>(content);

                int entrenador = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier).Value);

                return View(usuarios.Where(r => r.IdUsuarioEntrenador == entrenador));
            }
            catch (Exception)
            {

                throw;
            }
        }


        [Authorize(Roles = "Entrenador, Cliente")]
        [HttpGet("{id:int}", Name = "IndexRutina")]
        public IActionResult IndexRutina(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Rutina");

                var content = response.Content.ReadAsStringAsync().Result;
                List<RutinaViewModel> rutinas = JsonConvert.DeserializeObject<List<RutinaViewModel>>(content);
                if (rutinas.Count <= 0 || rutinas is null)
                {
                    rutinas = new List<RutinaViewModel>();
                }

                if (User.IsInRole("Entrenador"))
                {
                    return View(rutinas.Where(r => r.IdUsuarioCliente == id));
                }
                else
                {
                    int userId = Convert.ToInt32(User.Claims.FirstOrDefault(r => r.Type == ClaimTypes.NameIdentifier).Value);
                    return View(rutinas.Where(r => r.IdUsuarioCliente == userId));
                }

            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }
        }

        [Authorize(Roles = "Entrenador")]
        [HttpGet("EditRutina", Name = "EditRutina")]
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

        #endregion

        #region Datos

        [Authorize(Roles = "Entrenador")]
        [HttpPost]
        public IActionResult CreateRutina(RutinaViewModel rutina)
        {

            rutina.IdUsuarioEntrenador = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            rutina.FechaAsignacion = DateTime.Now;
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse("api/Rutina/", rutina);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Mensaje = "Rutina creada";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo crear la rutina";
            }
            return RedirectToAction("IndexRutina", "Rutina", new { idRutina = rutina.IdUsuarioCliente });
        }

        [Authorize(Roles = "Entrenador")]
        [HttpPost]
        public IActionResult EditRutina(RutinaViewModel rutina)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Rutina/", rutina);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Mensaje = "Rutina editada";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo editar la rutina";
            }
            return RedirectToAction("EditRutina", "Rutina", new { id = rutina.IdRutina });
        }

        [Authorize(Roles = "Entrenador")]
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

        [Authorize(Roles = "Entrenador")]
        public IActionResult DeleteRutinaEjercicio(int idRutina, int idRutinaEjercicio)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse("api/RutinaEjercicio/" + idRutinaEjercicio);

            if (response.IsSuccessStatusCode)
            {
                ViewBag.Mensaje = "Rutina eliminada";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo eliminar la rutina";
            }
            return RedirectToAction("EditRutina", "Rutina", new { id = idRutina });
        }

        [Authorize(Roles = "Entrenador")]
        [HttpPost]
        public IActionResult GetRutinaEjercicio(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/RutinaEjercicio/" + id);
            var content = response.Content.ReadAsStringAsync().Result;
            RutinaXejercicio rutina = JsonConvert.DeserializeObject<RutinaXejercicio>(content);
            return (response.IsSuccessStatusCode) ? Json(rutina) : Json(null);
        }

        [Authorize(Roles = "Entrenador")]
        [HttpPost]
        public IActionResult EditRutinaEjercicio(RutinaXejercicio rutina)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/RutinaEjercicio", rutina);
            if (response.IsSuccessStatusCode)
            {
                ViewBag.Mensaje = "Rutina eliminada";
            }
            else
            {
                ViewBag.Mensaje = "No se pudo eliminar la rutina";
            }
            return RedirectToAction("EditRutina", "Rutina", new { id = rutina.IdRutina });
        }

        #endregion
    }
}
