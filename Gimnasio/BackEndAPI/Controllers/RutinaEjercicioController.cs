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
        public JsonResult GetRutina()
        {
            try
            {
                IEnumerable<RutinaXejercicio> rutinas;
                IEnumerable<RutinaEjercicioDto> rutinasDto;
                using (var context = new UnidadDeTrabajo<Rutina>(new GimnasioContext()))
                {
                    rutinas = context.rutinaDal.GetComplete();
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

        //[HttpGet("GetRutinas/{id:int}")]
        //public JsonResult GetRutinas(int id)
        //{
        //    try
        //    {
        //        List<RutinaXejercicio> rutinas;
        //        List<RutinaEjercicioDto> rutinasDto;
        //        using (var context = new UnidadDeTrabajo<Rutina>(new GimnasioContext()))
        //        {
        //            rutinas = context.rutinaDal.GetCompleteRutina(id);
        //            rutinasDto = _mapper.Map<List<RutinaEjercicioDto>>(rutinas);
        //        }
        //        return new JsonResult(rutinasDto);
        //    }
        //    catch (Exception ex)
        //    {

        //        var s = ex.Message;
        //        return new JsonResult(null);
        //    }

        //}

        [HttpPost]
        public IActionResult CreateRutina(RutinaXejercicio rutina)
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
    }
}
