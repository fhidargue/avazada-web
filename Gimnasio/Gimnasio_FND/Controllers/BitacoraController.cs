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
    public class BitacoraController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Bitacora");

                response.EnsureSuccessStatusCode();

                var content = response.Content.ReadAsStringAsync().Result;
                List<BitacoraViewModel> bitacoras = JsonConvert.DeserializeObject<List<BitacoraViewModel>>(content);

                return View(bitacoras);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                throw;
            }
        }
    }
}
