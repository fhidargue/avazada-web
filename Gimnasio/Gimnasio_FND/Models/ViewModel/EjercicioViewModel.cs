using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio_FND.Models.ViewModel
{
    public class EjercicioViewModel
    {
        public int IdEjercicio { get; set; }
        public string Descripcion { get; set; }
        public string Intensidad { get; set; }
        public string Equipo { get; set; }
    }
}
