using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Gimnasio_FND.Models.ViewModel;
using Gimnasio_FND.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gimnasio_FND.Controllers
{
    public class EjercicioController : Controller
    {
        #region Vistas
        [Authorize]
        public IActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Ejercicio");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                List<EjercicioViewModel> ejercicios = JsonConvert.DeserializeObject<List<EjercicioViewModel>>(content);

                return View(ejercicios);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }

        }
        #endregion


        #region Datos

        [HttpPost]
        public IActionResult GetEjercicio(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Ejercicio/" + id);

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                EjercicioViewModel ejercicio = JsonConvert.DeserializeObject<EjercicioViewModel>(content);

                return Json(ejercicio);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return Json(null);
            }
        }



        [HttpPost]
        public IActionResult CreateEjercicio(EjercicioViewModel ejercicio)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Ejercicio", ejercicio);
                response.EnsureSuccessStatusCode();

                TempData["datos"] = (response.IsSuccessStatusCode) ? "Ejercicio Creado" : "Hubo un error creando el ejercicio";

                return RedirectToAction("Index", "Ejercicio");
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpPost]
        public IActionResult UpdateEjercicio(EjercicioViewModel ejercicio)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Ejercicio", ejercicio);
                response.EnsureSuccessStatusCode();

                TempData["datos"] = (response.IsSuccessStatusCode) ? "Ejercicio Actualizado" : "Hubo un error actualizando el ejercicio";

                return RedirectToAction("Index", "Ejercicio");
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }
        }

        [HttpPost]
        public IActionResult DeleteEjercicio(EjercicioViewModel ejercicio)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Ejercicio/" + ejercicio.IdEjercicio);
                response.EnsureSuccessStatusCode();

                //TempData["datos"] = (response.IsSuccessStatusCode) ? "Usuario Actualizado" : "Hubo un error actualizando el usuario";

                return RedirectToAction("Index", "Ejercicio");
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }
        }
        #endregion

    }
}
