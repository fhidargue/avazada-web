using System;
using System.Collections.Generic;

#nullable disable

namespace BackEnd.Entities
{
    public partial class Bitacora
    {
        public int IdBitacora { get; set; }
        public int? IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public string Modulo { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
