using BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackEnd.DAL
{
    public class RutinaDAL
    {
        private GimnasioContext _context;
        public RutinaDAL(GimnasioContext context)
        {
            _context = context;
        }

        #region RutinaEjercicio

        public List<RutinaXejercicio> GetCompleteRutinaEjercicio()
        {
            return _context.RutinaXejercicios
                .Include(r => r.IdEjercicioNavigation)
                .Include(r => r.IdRutinaNavigation).ThenInclude(r => r.IdUsuarioClienteNavigation)
                .Include(r => r.IdRutinaNavigation).ThenInclude(r => r.IdUsuarioEntrenadorNavigation)
                .ToList();
        }

        public RutinaXejercicio GetCompleteRutinaEjercicio(int id)
        {
            return _context.RutinaXejercicios
                .Include(r => r.IdEjercicioNavigation)
                .Include(r => r.IdRutinaNavigation)
                .Include(r => r.IdRutinaNavigation).ThenInclude(r => r.IdUsuarioClienteNavigation)
                .Include(r => r.IdRutinaNavigation).ThenInclude(r => r.IdUsuarioEntrenadorNavigation)
                .FirstOrDefault(r => r.IdRutinaEjercicio == id);
        }

        public List<RutinaXejercicio> GetCompleteRutinasEjercicios(int id)
        {
            return _context.RutinaXejercicios
                .Include(r => r.IdEjercicioNavigation)
                .Include(r => r.IdRutinaNavigation)
                .Include(r => r.IdRutinaNavigation).ThenInclude(r => r.IdUsuarioClienteNavigation)
                .Include(r => r.IdRutinaNavigation).ThenInclude(r => r.IdUsuarioEntrenadorNavigation)
                .Where(r => r.IdRutina == id)
                .ToList();
        }

        #endregion


        #region Rutina
        public List<Rutina> GetCompleteRutina()
        {
            return _context.Rutinas
                .Include(r => r.RutinaXejercicios)
                .Include(r => r.RutinaXejercicios).ThenInclude(r => r.IdEjercicioNavigation)
                .Include(r => r.IdUsuarioClienteNavigation)
                .Include(r => r.IdUsuarioEntrenadorNavigation)
                .ToList();
        }

        public Rutina GetCompleteRutina(int id)
        {
            return _context.Rutinas
               .Include(r => r.RutinaXejercicios)
               .Include(r => r.RutinaXejercicios).ThenInclude(r => r.IdEjercicioNavigation)
               .Include(r => r.IdUsuarioClienteNavigation)
                .Include(r => r.IdUsuarioEntrenadorNavigation)
               .FirstOrDefault(r => r.IdRutina == id);
        }
        #endregion

    }
}
