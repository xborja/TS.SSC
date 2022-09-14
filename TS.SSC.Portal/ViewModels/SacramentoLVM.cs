using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TS.SSC.Portal.ViewModels
{
    public class SacramentoLVM
    {
        public List<SacramentoVM> Items { get; set; }

        public SacramentoLVM()
        {
            this.Items = new List<SacramentoVM>();
        }
    }
}