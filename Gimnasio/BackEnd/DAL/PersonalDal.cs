﻿using BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.DAL
{
    public class PersonalDAL
    {
        private GimnasioContext _context;
        public PersonalDAL(GimnasioContext context)
        {
            _context = context;
        }

        public List<Usuario> GetComplete()
        {
            return _context.Usuarios
                .Include(r => r.IdRolNavigation)
                .Include(r => r.IdSucursalNavigation)
                .ToList();
        }

        public Usuario GetComplete(int id)
        {
            return _context.Usuarios
                .Include(r => r.IdRolNavigation)
                .Include(r => r.IdSucursalNavigation)                
                .FirstOrDefault(r => r.IdUsuario == id);
        }

        public Usuario GetComplete(Usuario usuario)
        {
            return _context.Usuarios
                .Include(r => r.IdRolNavigation)
                .Include(r => r.IdSucursalNavigation)
                .FirstOrDefault(r => r.Email.Equals(usuario.Email) && r.Contrasenia.Equals(usuario.Contrasenia));
        }
    }
}
