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
    [Route("api/RutinaEjercicio")]
    [ApiController]
    public class RutinaEjercicioController : ControllerBase
    {
        private readonly IMapper _mapper;
        public RutinaEjercicioController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult GetRutinaEjercicio()
        {
            try
            {
                IEnumerable<RutinaXejercicio> rutinas;
                IEnumerable<RutinaEjercicioDto> rutinasDto;
                using (var context = new UnidadDeTrabajo<Rutina>(new GimnasioContext()))
                {
                    rutinas = context.rutinaDal.GetCompleteRutinaEjercicio();
                    rutinasDto = _mapper.Map<List<RutinaEjercicioDto>>(rutinas);
                }
                return new JsonResult(rutinasDto);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return new JsonResult(null);
            }

        }


        [HttpGet("{id:int}")]
        public JsonResult GetRutinasEjercicio(int id)
        {
            try
            {
                RutinaXejercicio rutinas;
                RutinaEjercicioDto rutinasDto;
                using (var context = new UnidadDeTrabajo<Rutina>(new GimnasioContext()))
                {
                    rutinas = context.rutinaDal.GetCompleteRutinaEjercicio(id);
                    rutinasDto = _mapper.Map<RutinaEjercicioDto>(rutinas);
                }
                return new JsonResult(rutinasDto);
            }
            catch (Exception ex)
            {

                var s = ex.Message;
                return new JsonResult(null);
            }

        }


        [HttpPost]
        public IActionResult CreateRutinaEjercicio(RutinaXejercicio rutina)
        {
            try
            {
                using var context = new UnidadDeTrabajo<RutinaXejercicio>(new GimnasioContext());
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
        public IActionResult UpdateRutinaEjercicio(RutinaXejercicio rutina)
        {
            try
            {
                using var context = new UnidadDeTrabajo<RutinaXejercicio>(new GimnasioContext());
                context.genericDAL.Update(rutina);
                return (context.Complete()) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteRutinaEjercicio(int id)
        {
            try
            {
                using var context = new UnidadDeTrabajo<RutinaXejercicio>(new GimnasioContext());
                RutinaXejercicio rutina = context.genericDAL.Get(id);
                context.genericDAL.Remove(rutina);
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
