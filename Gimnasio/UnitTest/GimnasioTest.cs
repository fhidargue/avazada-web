using BackEnd.DAL;
using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest
{
    public class GimnasioTest
    {
        [Fact]
        public void TestAdd()
        { 
            Gimnasio gimnasio = new Gimnasio
            {
                Sede = "Alajuela",
                Contacto = "Bianca Brenes",
                Email = "bbrenes@gimnasio.com",
                Direccion = "Grecia, Alajuela"
            };
            
            using (UnidadDeTrabajo<Gimnasio> unidad = new UnidadDeTrabajo<Gimnasio>(new GimnasioContext()))
            {
                bool result = unidad.genericDAL.Add(gimnasio);
                result = unidad.Complete();
                Assert.True(result, "Es verdadero");
            }

        }
    }
}
