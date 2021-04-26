using AutoMapper;
using BackEnd.DAL;
using BackEnd.Entities;
using BackEndAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    [Route("api/Subscripcion")]
    [ApiController]
    public class SubscripcionController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetSubscripciones()
        {
            try
            {
                IEnumerable<Subscripcion> subscripciones;
                using (var context = new UnidadDeTrabajo<Subscripcion>(new GimnasioContext()))
                {
                    subscripciones = context.genericDAL.GetAll();
                }
                return new JsonResult(subscripciones);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return new JsonResult(null);
            }
        }

        [HttpGet("{id:int}")]
        public JsonResult GetSubscripcion(int id)
        {
            try
            {
                Subscripcion subscripcion;
                using (var context = new UnidadDeTrabajo<Subscripcion>(new GimnasioContext()))
                {
                    subscripcion = context.genericDAL.Get(id);
                }
                return new JsonResult(subscripcion);
            }
            catch (Exception ex)
            {

                var s = ex.Message;
                return new JsonResult(null);
            }
        }

        [HttpPost]
        [Route("agregar")]
        public IActionResult CreateSubscripcion(Subscripcion subscripcion)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Subscripcion>(new GimnasioContext());
                context.genericDAL.Add(subscripcion);
                return (context.Complete()) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpPut]
        [Route("actualizar")]
        public IActionResult UpdateSubscripcion(Subscripcion subscripcion)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Subscripcion>(new GimnasioContext());
                context.genericDAL.Update(subscripcion);
                return (context.Complete()) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteSubscripcion(int id)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Subscripcion>(new GimnasioContext());
                Subscripcion subscripcion = context.genericDAL.Get(id);
                context.genericDAL.Remove(subscripcion);
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
