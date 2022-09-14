using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS.SSC.Entity;

namespace TS.SSC.Portal.ViewModels
{
    public class SacramentoVM:Sacramento
    {
        public string estadoM
        {
            get
            {
                if (estado == true)
                {
                    return "Activo";
                }
                else
                {
                    return "Inactivo";
                }
            }
        }
        public int estadoT { get; set; }
        
        

        public List<UtilListadosVM> listestados = UtilListadosVM.ToListEstado();
    }
}