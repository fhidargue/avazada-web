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
    [Route("api/Sucursal")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetSucursal()
        {
            try
            {
                IEnumerable<Sucursal> sucursals;
                using (var context = new UnidadDeTrabajo<Sucursal>(new GimnasioContext()))
                {
                    sucursals = context.genericDAL.GetAll();
                }
                return new JsonResult(sucursals);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return new JsonResult(null);
            }

        }

        [HttpGet("{id:int}")]
        public JsonResult GetSucursal(int id)
        {
            try
            {
                Sucursal sucursal;
                using (var context = new UnidadDeTrabajo<Sucursal>(new GimnasioContext()))
                {
                    sucursal = context.genericDAL.Get(id);
                }
                return new JsonResult(sucursal);
            }
            catch (Exception ex)
            {

                var s = ex.Message;
                return new JsonResult(null);
            }

        }


        [HttpPost]
        public IActionResult CreateSucursal(Sucursal sucursal)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Sucursal>(new GimnasioContext());
                context.genericDAL.Add(sucursal);
                return (context.Complete()) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }


        [HttpPatch]
        public IActionResult UpdateSucursal(Sucursal sucursal)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Sucursal>(new GimnasioContext());
                context.genericDAL.Update(sucursal);
                return (context.Complete()) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }

        /*
        [HttpDelete("{id:int}")]
        public IActionResult DeleteSucursal(int id)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Sucursal>(new GimnasioContext());
                Sucursal sucursal = context.genericDAL.Get(id);
                context.genericDAL.Remove(sucursal);
                return (context.Complete()) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        */
    }
}
