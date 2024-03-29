﻿using BackEnd.DAL;
using BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Controllers
{
    [Route("api/Medida")]
    [ApiController]
    public class MedidaController : ControllerBase
    {

        [HttpGet("{id:int}")]
        public JsonResult GetMedida(int id)
        {
            try
            {
                Medida medidas;
                using (var context = new UnidadDeTrabajo<Medida>(new GimnasioContext()))
                {
                    medidas = context.genericDAL.Get(id);
                }
                return new JsonResult(medidas);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return new JsonResult(null);
            }

        }


        [HttpPost]
        public IActionResult CreateMedida(Medida medidas)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Medida>(new GimnasioContext());
                context.genericDAL.Add(medidas);
                return (context.Complete()) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }


        [HttpPatch]
        public IActionResult UpdateMedida(Medida medidas)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Medida>(new GimnasioContext());
                context.genericDAL.Update(medidas);
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
        public IActionResult DeleteMedida(int id)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Medida>(new GimnasioContext());
                Medida medidas = context.genericDAL.Get(id);
                context.genericDAL.Remove(medidas);
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
