using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gimnasio_FND.Models.ViewModel
{
    public class SubscripcionViewModel
    {
        public int IdSubscripcion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string MetodoPago { get; set; }
        public decimal? Monto { get; set; }

        public List<UsuarioViewModel> usuarios { get; set; }
        public virtual UsuarioViewModel IdUsuarioNavigation { get; set; }
    }
}
