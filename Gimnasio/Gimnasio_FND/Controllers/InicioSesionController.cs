using Gimnasio_FND.Models.Bll;
using Gimnasio_FND.Models.ViewModel;
using Gimnasio_FND.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    public class InicioSesionController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(IniciarSesionViewModel model)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Autenticacion", model);

                if (response.IsSuccessStatusCode)
                {

                    var content = response.Content.ReadAsStringAsync().Result;

                    UsuarioViewModel usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(content);

                    UsuarioBll.CapitalizeName(usuario);

                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nombre + " " + usuario.Apellidos));
                    identity.AddClaim(new Claim(ClaimTypes.Role, usuario.IdRolNavigation.Nombre));

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "InicioSesion");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IActionResult> CerrarSesion()
        {
            try
            {
                await HttpContext.SignOutAsync();

                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
