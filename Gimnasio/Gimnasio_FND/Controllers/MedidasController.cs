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
    public class MedidasController : Controller
    {
        [HttpGet("Index")]
        [Authorize(Roles = "Entrenador")]
        public IActionResult Index(int id)
        {
            try
            {
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
    }
}
