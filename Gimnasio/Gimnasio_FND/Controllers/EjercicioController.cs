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
    public class EjercicioController : Controller
    {
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
                return View();
            }
 
        }


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


    }
}
