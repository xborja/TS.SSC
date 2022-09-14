using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TS.SSC.Portal.ViewModels
{
    public class UtilListadoVM
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

        public static List<UtilListadosVM> ToListEstados()
        {
            List<UtilListadosVM> items = new List<UtilListadosVM>();
            items.Add(new UtilListadosVM { Valor = 0, Texto = "Inactivo", });
            items.Add(new UtilListadosVM { Valor = 1, Texto = "Activo", });
            return items;
        }
    }
}