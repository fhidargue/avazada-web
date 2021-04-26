using Gimnasio_FND.Models.ViewModel;
using Gimnasio_FND.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gimnasio_FND.Controllers
{
    public class SucursalController : Controller
    {
        #region Vistas
        [Authorize]
        public IActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Sucursal");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                List<SucursalViewModel> sucursals = JsonConvert.DeserializeObject<List<SucursalViewModel>>(content);

                return View(sucursals);
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
        public IActionResult GetSucursal(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Sucursal/" + id);

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                SucursalViewModel sucursal = JsonConvert.DeserializeObject<SucursalViewModel>(content);

                return Json(sucursal);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return Json(null);
            }
        }



        [HttpPost]
        public IActionResult CreateSucursal(SucursalViewModel sucursal)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Sucursal", sucursal);
                response.EnsureSuccessStatusCode();

                TempData["datos"] = (response.IsSuccessStatusCode) ? "Sucursal Creado" : "Hubo un error creando el sucursal";

                return RedirectToAction("Index", "Sucursal");
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpPost]
        public IActionResult UpdateSucursal(SucursalViewModel sucursal)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Sucursal", sucursal);
                response.EnsureSuccessStatusCode();

                TempData["datos"] = (response.IsSuccessStatusCode) ? "Sucursal Actualizado" : "Hubo un error actualizando el sucursal";

                return RedirectToAction("Index", "Sucursal");
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }
        }

        [HttpPost]
        public IActionResult DeleteSucursal(SucursalViewModel sucursal)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Sucursal/" + sucursal.IdSucursal);
                response.EnsureSuccessStatusCode();

                //TempData["datos"] = (response.IsSuccessStatusCode) ? "Usuario Actualizado" : "Hubo un error actualizando el usuario";

                return RedirectToAction("Index", "Sucursal");
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
