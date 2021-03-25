using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Medida
    {
        public int IdMedida { get; set; }
        public decimal Peso { get; set; }
        public decimal? PorcentajeMasa { get; set; }
        public decimal? PorcentajeGrasa { get; set; }
        public decimal? Altural { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
