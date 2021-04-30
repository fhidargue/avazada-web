using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio_FND.Models.ViewModel
{
    public class MedidaViewModel
    {
        public int IdMedida { get; set; }
        public int IdUsuario { get; set; }
        public decimal? Peso { get; set; }
        public int? PorcentajeMasa { get; set; }
        public int? PorcentajeGrasa { get; set; }
        public decimal? Altura { get; set; }
    }
}
