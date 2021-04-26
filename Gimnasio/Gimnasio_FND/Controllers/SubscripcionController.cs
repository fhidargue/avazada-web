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
    public class SubscripcionController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Subscripcion");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                List<SubscripcionViewModel> subscripciones = JsonConvert.DeserializeObject<List<SubscripcionViewModel>>(content);

                return View(subscripciones);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }
        }

        [HttpPost]
        public IActionResult GetSubscripcion(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Subscripcion/" + id);

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                SubscripcionViewModel subscripcion = JsonConvert.DeserializeObject<SubscripcionViewModel>(content);
                subscripcion.FechaInicio = subscripcion.FechaCreacion.ToString("yyyy-mm-dd");
                subscripcion.FechaFin = subscripcion.FechaVencimiento.ToString("yyyy-mm-dd");
                return Json(subscripcion);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return Json(null);
            }
        }

        [HttpPost]
        public IActionResult CreateSubscripcion(SubscripcionViewModel subscripcion)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Subscripcion/agregar", subscripcion);
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                
                //TempData["datos"] = (response.IsSuccessStatusCode) ? "Subscripción Creada" : "Hubo un error creando la subscripción";

                return RedirectToAction("Index", "Subscripcion");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult UpdateSubscripcion(SubscripcionViewModel subscripcion)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Subscripcion/actualizar", subscripcion);
                response.EnsureSuccessStatusCode();

                //TempData["datos"] = (response.IsSuccessStatusCode) ? "Subscripción Actualizada" : "Hubo un error actualizando la subscripción";

                return RedirectToAction("Index", "Subscripcion");
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }
        }

        [HttpPost]
        public IActionResult DeleteSubscripcion(SubscripcionViewModel subscripcion)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Subscripcion/" + subscripcion.IdSubscripcion);
                response.EnsureSuccessStatusCode();

                //TempData["datos"] = (response.IsSuccessStatusCode) ? "Usuario Actualizado" : "Hubo un error actualizando el usuario";

                return RedirectToAction("Index", "Subscripcion");
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }
        }
    }
}
