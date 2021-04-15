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
    [Route("api/Rutina")]
    [ApiController]
    public class RutinaController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetRutina()
        {
            try
            {
                IEnumerable<Rutina> rutinas;
                using (var context = new UnidadDeTrabajo<Rutina>(new GimnasioContext()))
                {
                    rutinas = context.genericDAL.GetAll();
                }
                return new JsonResult(rutinas);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return new JsonResult(null);
            }

        }

        [HttpGet("{id:int}")]
        public JsonResult GetRutina(int id)
        {
            try
            {
                Rutina rutina;
                using (var context = new UnidadDeTrabajo<Rutina>(new GimnasioContext()))
                {
                    rutina = context.genericDAL.Get(id);
                }
                return new JsonResult(rutina);
            }
            catch (Exception ex)
            {

                var s = ex.Message;
                return new JsonResult(null);
            }

        }


        [HttpPost]
        public IActionResult CreateRutina(Rutina rutina)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Rutina>(new GimnasioContext());
                context.genericDAL.Add(rutina);
                return (context.Complete()) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }


        [HttpPut]
        public IActionResult UpdateRutina(Rutina rutina)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Rutina>(new GimnasioContext());
                context.genericDAL.Update(rutina);
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
        public IActionResult DeleteRutina(int id)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Rutina>(new GimnasioContext());
                Rutina rutina = context.genericDAL.Get(id);
                context.genericDAL.Remove(rutina);
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
