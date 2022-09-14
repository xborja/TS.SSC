using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS.SSC.Entity;



namespace TS.SSC.Portal.ViewModels
{
    public class UsuarioLVM : EstadoClase
    {
        public List<UsuarioVM> Items { get; set; }


        public UsuarioLVM()
        {
            this.Items = new List<UsuarioVM>();
        }
    }
}