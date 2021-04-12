using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackEnd.DAL
{
    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        private readonly GimnasioContext context;

        public IDALGenerico<T> genericDAL;

        public PersonalDal usuarioDal;


        public UnidadDeTrabajo(GimnasioContext _context)
        {
            context = _context;
            genericDAL = new DALGenericoImpl<T>(context);
            usuarioDal = new PersonalDal(context);

        }

        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }

        }


        public void Dispose()
        {
            context.Dispose();
        }
    }
}
