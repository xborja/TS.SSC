using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS.SSC.Entity;
using TS.SSC.Portal.Services;

namespace TS.SSC.Portal.ViewModels
{
    public class UtilListadosVM
    {
        public int Valor { get; set; }
        public string Texto { get; set; }
        public string Selected { get; set; }

        public static List<UtilListadosVM> ToList()
        {
            List<UtilListadosVM> items = new List<UtilListadosVM>();
            items.Add(new UtilListadosVM { Valor = 0, Texto = "No", });
            items.Add(new UtilListadosVM { Valor = 1, Texto = "Si", });
            return items;
        }
        public static List<UtilListadosVM> ToListEstado()
        {
            List<UtilListadosVM> items = new List<UtilListadosVM>();
            items.Add(new UtilListadosVM { Valor = 0, Texto = "Inactivo", });
            items.Add(new UtilListadosVM { Valor = 1, Texto = "Activo", });
            return items;
        }
        public static List<UtilListadosVM> ToListGenero()
        {
            List<UtilListadosVM> items = new List<UtilListadosVM>();
            items.Add(new UtilListadosVM { Valor = 0, Texto = "M", });
            items.Add(new UtilListadosVM { Valor = 1, Texto = "F", });
            return items;
        }
        public static List<UtilListadosVM> ToListApertura()
        {
            List<UtilListadosVM> items = new List<UtilListadosVM>();
            items.Add(new UtilListadosVM { Valor = 0, Texto = "No", });
            items.Add(new UtilListadosVM { Valor = 1, Texto = "Si", });
            return items;
        }

        public static List<UtilListadosVM> ToListOperadores()
        {
            List<UtilListadosVM> items = new List<UtilListadosVM>();
            items.Add(new UtilListadosVM { Valor = 1, Texto = "SalarioIESS", });
            items.Add(new UtilListadosVM { Valor = 2, Texto = "Sueldo", });
            items.Add(new UtilListadosVM { Valor = 3, Texto = "SueldoDelMes", });
            items.Add(new UtilListadosVM { Valor = 4, Texto = "Total Aportable" });
            return items;
        }
        public static List<UtilListadosVM> ToListTipoValor()
        {
            List<UtilListadosVM> items = new List<UtilListadosVM>();
            items.Add(new UtilListadosVM { Valor = 1, Texto = "Operador", });
            items.Add(new UtilListadosVM { Valor = 2, Texto = "Rubro Nomina", });
            items.Add(new UtilListadosVM { Valor = 3, Texto = "Valor", });
            return items;
        }
        public static List<UtilListadosVM> ToListTipoRegistro()
        {
            List<UtilListadosVM> items = new List<UtilListadosVM>();
            items.Add(new UtilListadosVM { Valor = 1, Texto = "Resultado", });
            items.Add(new UtilListadosVM { Valor = 2, Texto = "Diferencia", });
            
            return items;
        }
        public static List<UtilListadosVM> ToListOperacion()
        {
            List<UtilListadosVM> items = new List<UtilListadosVM>();
            items.Add(new UtilListadosVM { Valor = 1, Texto = "+", });
            items.Add(new UtilListadosVM { Valor = 2, Texto = "-", });
            items.Add(new UtilListadosVM { Valor = 3, Texto = "*", });
            items.Add(new UtilListadosVM { Valor = 4, Texto = "/", });
            return items;
        }
    }

        public class TipoJustificacionVM /*TipoJustificacion*/
        {
            public int Valor { get; set; }
            public string Texto { get; set; }
            public string Selected { get; set; }
            public static List<TipoJustificacionVM> ToList()
            {
                List<TipoJustificacionVM> items = new List<TipoJustificacionVM>();
                items.Add(new TipoJustificacionVM { Valor = 1, Texto = "Atraso Entrada", });
                items.Add(new TipoJustificacionVM { Valor = 2, Texto = "Adelanto Salida", });
                return items;
            }

        }
        public class TipoJustificacionLVM
        {

            public List<TipoJustificacionVM> TiposJustific;

            public TipoJustificacionLVM()
            {
                TiposJustific = new List<TipoJustificacionVM>();
            }
        }


        public class EstadoJustificacionVM
        {
            public int Valor { get; set; }
            public string Texto { get; set; }
            public string Selected { get; set; }
            public static List<EstadoJustificacionVM> ToList()
            {
                List<EstadoJustificacionVM> items = new List<EstadoJustificacionVM>();
                items.Add(new EstadoJustificacionVM { Valor = 0, Texto = "Pendiente", });
                items.Add(new EstadoJustificacionVM { Valor = -1, Texto = "Rechazado", });
                items.Add(new EstadoJustificacionVM { Valor = 1, Texto = "Aprobado", });
                return items;
            }

        }

}