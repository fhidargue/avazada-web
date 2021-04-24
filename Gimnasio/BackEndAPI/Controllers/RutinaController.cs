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
    [Route("api/Rutina")]
    [ApiController]
    public class RutinaController : ControllerBase
    {

        private readonly IMapper _mapper;
        public RutinaController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult GetRutina()
        {
            try
            {
                IEnumerable<Rutina> rutinas;
                IEnumerable<RutinaDto> rutinasDto;
                using (var context = new UnidadDeTrabajo<Rutina>(new GimnasioContext()))
                {
                    rutinas = context.rutinaDal.GetCompleteRutina();
                    rutinasDto = _mapper.Map<List<RutinaDto>>(rutinas);
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
        public JsonResult GetRutina(int id)
        {
            try
            {
                Rutina rutina;
                RutinaDto rutinasDto;
                using (var context = new UnidadDeTrabajo<Rutina>(new GimnasioContext()))
                {
                    rutina = context.rutinaDal.GetCompleteRutina(id);
                    rutinasDto = _mapper.Map<RutinaDto>(rutina);
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
