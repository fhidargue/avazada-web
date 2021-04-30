using Gimnasio_FND.Models.ViewModel;
using Gimnasio_FND.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Gimnasio_FND.Controllers
{
    public class PerfilController : Controller
    {    
        [HttpGet("PerfilUsuario")]
        public IActionResult PerfilUsuario()
        {
            try
            {
                int id = Convert.ToInt32(User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.NameIdentifier).Value);
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Usuario/" + id);

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                UsuarioViewModel usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);
                response = serviceObj.GetResponse("api/Medidas");
                content = response.Content.ReadAsStringAsync().Result;
                List<MedidaViewModel> medidas = JsonConvert.DeserializeObject<List<MedidaViewModel>>(content);
                PerfilViewModel perfil = new PerfilViewModel();
                perfil.Usuario = usuario;
                perfil.Medidas = (medidas != null) ? medidas.FirstOrDefault(r => r.IdUsuario == id) : new MedidaViewModel();
                return View(perfil);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return View(new PerfilViewModel());
            }
        }

        [HttpPost]
        public IActionResult UpdatePerfil(UsuarioViewModel usuario)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Usuario", usuario);
                response.EnsureSuccessStatusCode();

                return RedirectToAction("PerfilUsuario", "Perfil");
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }
        }

    }
}
