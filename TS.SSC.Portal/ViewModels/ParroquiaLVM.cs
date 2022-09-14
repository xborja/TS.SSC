using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TS.SSC.Portal.ViewModels
{
    public class ParroquiaLVM
    {
        public List<ParroquiaVM> Items { get; set; }

        public ParroquiaLVM()
        {
            this.Items = new List<ParroquiaVM>();
        }
    }
}