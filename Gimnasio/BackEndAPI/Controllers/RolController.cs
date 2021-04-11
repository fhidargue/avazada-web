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
    [Route("api/Rol")]
    [ApiController]
    public class RolController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetRol()
        {
            try
            {
                IEnumerable<Rol> roles;
                using (var context = new UnidadDeTrabajo<Rol>(new GimnasioContext()))
                {
                    roles = context.genericDAL.GetAll();
                }
                return new JsonResult(roles);
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return new JsonResult(null);
            }

        }

        [HttpGet("{id:int}")]
        public JsonResult GetRol(int id)
        {
            try
            {
                Rol rol;
                using (var context = new UnidadDeTrabajo<Rol>(new GimnasioContext()))
                {
                    rol = context.genericDAL.Get(id);
                }
                return new JsonResult(rol);
            }
            catch (Exception ex)
            {

                var s = ex.Message;
                return new JsonResult(null);
            }

        }
    }
}
