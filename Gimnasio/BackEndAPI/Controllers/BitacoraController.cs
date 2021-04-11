using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    [Route("api/Bitacora")]
    [ApiController]
    public class BitacoraController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetBitacora()
        {
            try
            {
                IEnumerable<Bitacora> bitacoras;
                using (var context = new UnidadDeTrabajo<Bitacora>(new GimnasioContext()))
                {
                    bitacoras = context.genericDAL.GetAll();
                }
                return new JsonResult(bitacoras);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return new JsonResult(null);
            }

        }

        [HttpPost]
        public IActionResult CreateBitacora(Bitacora bitacora)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Bitacora>(new GimnasioContext());
                context.genericDAL.Add(bitacora);
                return (context.Complete()) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }
    }
}
