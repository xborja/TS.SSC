using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS.Core
{
    public class Control
    {
        public string MensajeProceso { get; set; }
        public int EstadoProceso { get; set; }
        #region datos de auditoria
        public string UsuarioCrea { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioModif { get; set; }
        public DateTime FechaModif { get; set; }
        #endregion
    }
}
