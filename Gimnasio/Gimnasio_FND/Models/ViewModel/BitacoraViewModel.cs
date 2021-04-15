﻿using BackEnd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio_FND.Models.ViewModel
{
    public class BitacoraViewModel
    {
        public int IdBitacora { get; set; }
        public int? IdUsuario { get; set; }
        public string Descripcion { get; set; }
        public string Modulo { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
