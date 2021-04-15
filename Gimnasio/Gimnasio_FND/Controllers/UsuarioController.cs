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

        #region Vistas
        public IActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Usuario");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                List<UsuarioViewModel> usuarios = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(content);

                return View(usuarios);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion




        #region Datos

        [HttpPost]
        public IActionResult GetUsuario(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Usuario/" + id);

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                UsuarioViewModel usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);

                return Json(usuario);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return Json(null);
            }

        }



        [HttpPost]
        public IActionResult CreateUsuario(UsuarioViewModel usuario)
        {
            try
            {
                usuario.Contrasenia = usuario.Contrasenia = "HolaMundo25";
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Usuario", usuario);
                response.EnsureSuccessStatusCode();

                TempData["datos"] = (response.IsSuccessStatusCode) ? "Usuario Creado" : "Hubo un error creando el usuario";

                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception)
            {

                throw;
            }
        }



        [HttpPost]
        public IActionResult UpdateUsuario(UsuarioViewModel usuario)
        {
            try
            {
                usuario.Contrasenia = usuario.Contrasenia = "HolaMundo25";
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Usuario", usuario);
                response.EnsureSuccessStatusCode();

                TempData["datos"] = (response.IsSuccessStatusCode) ? "Usuario Actualizado" : "Hubo un error actualizando el usuario";

                return RedirectToAction("Index", "Usuario");
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
