using AutoMapper;
using BackEnd.Entities;
using BackEndAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndAPI.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<Rol, RolDto>().ReverseMap();

            CreateMap<Sucursal, SucursalDto>().ReverseMap();
        }
    }
}
