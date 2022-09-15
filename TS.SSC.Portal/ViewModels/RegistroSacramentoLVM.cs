using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS.SSC.BL;
using TS.SSC.Entity;

namespace TS.SSC.Portal.ViewModels
{
    public class RegistroSacramentoLVM
    {
        public List<RegistroSacramentoVM> Items { get; set; }
        public List<Sacramento> sacramentos { get; set; }
        
        public int AnioDesde { get; set; }
        public int AnioHasta { get; set; }
        public int sacramento { get; set; } 
        public RegistroSacramentoLVM()
        {
            this.Items = new List<RegistroSacramentoVM>();
            this.sacramentos = SacramentoBL.ToList();
        }
    }
}