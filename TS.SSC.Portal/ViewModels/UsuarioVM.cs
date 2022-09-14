using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS.SSC.Entity;
using TS.SSC.Portal.Services;

namespace TS.SSC.Portal.ViewModels
{
    public class UsuarioVM : Usuario
    {
        #region propiedades especiales
        public string EstadoReg
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
  
        #endregion

        public void CargarListas()
        {
        }

        public void CargarDetalles()
        {
           
        }
    }
}