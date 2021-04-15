using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Medida
    {
        public int IdMedida { get; set; }
        public int IdUsuario { get; set; }
        public decimal? Peso { get; set; }
        public int? PorcentajeMasa { get; set; }
        public int? PorcentajeGrasa { get; set; }
        public decimal? Altura { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
