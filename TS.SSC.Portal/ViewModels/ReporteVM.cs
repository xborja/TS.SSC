using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using TS.SSC.Entity;
using TS.SSC.Portal.Services;
using TS.SSC.Portal.ViewModels;

namespace TS.SSC.Portal.ViewModels
{
    public class ReporteVM
    {
        public List<OpcionReporte> ListReportes { get; set; }
        public DataTable DataTable { get; set; }
        [Required(ErrorMessage = "Elija un reporte")]
        public int opcionReporte { get; set; }
        public string MensajeProceso { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public int idGrupoOperacion { get; set; }
        public int idCierrePeriodico { get; set; }
        public void CargarListados()
        {
            CargaOpciones();
        }

        public void CargaOpciones()
        {
            ListReportes = new List<ViewModels.OpcionReporte>();
            ListReportes.Add(new OpcionReporte { idOpcion = 1, Descripcion = "Resumen de Pago" });
            ListReportes.Add(new OpcionReporte { idOpcion = 2, Descripcion = "Rol Pago empleados" });
         
        }
    }

    public class OpcionReporte
    {
        public int idOpcion { get; set; }
        public string Descripcion { get; set; }
    }



}