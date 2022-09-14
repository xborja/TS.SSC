using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TS.SSC.Portal.ViewModels
{
    public class RegistroSacramentoLVM
    {
        public List<RegistroSacramentoVM> Items { get; set; }

        public RegistroSacramentoLVM()
        {
            this.Items = new List<RegistroSacramentoVM>();
        }
    }
}