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
    [Route("api/Autenticacion")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {

        private readonly IMapper _mapper;

        public AutenticacionController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult Autenticar(Usuario usuario)
        {
            try
            {
                using var context = new UnidadDeTrabajo<Usuario>(new GimnasioContext());
                Usuario temp = context.usuarioDal.GetComplete(usuario);


                if (temp != null)
                {

                    UsuarioDto usuarioDto = _mapper.Map<UsuarioDto>(temp);
                    return Ok(usuarioDto);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError);

            }

        }
    }
}
