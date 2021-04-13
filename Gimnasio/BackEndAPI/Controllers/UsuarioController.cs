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
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IMapper _mapper;

        public UsuarioController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            try
            {
                IEnumerable<UsuarioDto> usuarios;
                using (var context = new UnidadDeTrabajo<Usuario>(new GimnasioContext()))
                {
                    usuarios = _mapper.Map<List<UsuarioDto>>(context.usuarioDal.GetComplete());
                }
                return new JsonResult(usuarios);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return new JsonResult(null);
            }

        }

        [HttpGet("{id:int}")]
        public JsonResult GetUser(int id)
        {
            try
            {
                UsuarioDto usuario;
                using (var context = new UnidadDeTrabajo<Usuario>(new GimnasioContext()))
                {
                    usuario = _mapper.Map<UsuarioDto>(context.usuarioDal.GetComplete(id));
                }
                return new JsonResult(usuario);
            }
            catch (Exception ex)
            {

                var s = ex.Message;
                return new JsonResult(null);
            }

        }


        [HttpPost]
        public IActionResult CreateUser(Usuario usuario)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Usuario>(new GimnasioContext());
                context.genericDAL.Add(usuario);
                return (context.Complete()) ? Ok() : StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }


        [HttpPatch]
        public IActionResult UpdateUser(Usuario usuario)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Usuario>(new GimnasioContext());
                context.genericDAL.Update(usuario);
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
        public IActionResult DeleteUser(int id)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Usuario>(new GimnasioContext());
                Usuario usuario = context.genericDAL.Get(id);
                context.genericDAL.Remove(usuario);
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
