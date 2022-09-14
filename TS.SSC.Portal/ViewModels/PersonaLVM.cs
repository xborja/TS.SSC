using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS.SSC.Entity;

namespace TS.SSC.Portal.ViewModels
{
    public class PersonaLVM:EstadoClase
    {
        public List<PersonaVM> Items { get; set; }

        public PersonaLVM()
        {
            this.Items = new List<PersonaVM>();
        }
    }
}