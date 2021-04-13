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
    [Route("api/Ejercicio")]
    [ApiController]
    public class EjercicioController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetEjercicio()
        {
            try
            {
                IEnumerable<Ejercicio> ejercicios;
                using (var context = new UnidadDeTrabajo<Ejercicio>(new GimnasioContext()))
                {
                    ejercicios = context.genericDAL.GetAll();
                }
                return new JsonResult(ejercicios);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return new JsonResult(null);
            }

        }

        [HttpGet("{id:int}")]
        public JsonResult GetEjercicio(int id)
        {
            try
            {
                Ejercicio ejercicio;
                using (var context = new UnidadDeTrabajo<Ejercicio>(new GimnasioContext()))
                {
                    ejercicio = context.genericDAL.Get(id);
                }
                return new JsonResult(ejercicio);
            }
            catch (Exception ex)
            {

                var s = ex.Message;
                return new JsonResult(null);
            }

        }


        [HttpPost]
        public IActionResult CreateEjercicio(Ejercicio ejercicio)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Ejercicio>(new GimnasioContext());
                context.genericDAL.Add(ejercicio);
                return (context.Complete()) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }


        [HttpPatch]
        public IActionResult UpdateEjercicio(Ejercicio ejercicio)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Ejercicio>(new GimnasioContext());
                context.genericDAL.Update(ejercicio);
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
        public IActionResult DeleteEjercicio(int id)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Ejercicio>(new GimnasioContext());
                Ejercicio ejercicio = context.genericDAL.Get(id);
                context.genericDAL.Remove(ejercicio);
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
