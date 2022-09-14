using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using TS.Core;
using TS.Core.DAO;
namespace TS.SSC.Entity
{
    public class Usuario : Control
    {
        public static string NombreEntidad = "Usuario";
        #region propiedades

        public int id { get; set; }
        public int idParroquia { get; set; }
        [Display(Name = "UserName")]

        public string userName { get; set; }
        [Display(Name = "Password")]

        public string password { get; set; }
        public string passwordHash { get; set; }
        public string tipoUsuario { get; set; }
        [Display(Name = "Nombre usuario")]

        public string nombreUsuario { get; set; }
        [Display(Name = "Estado")]

        public bool estado { get; set; }


        #endregion


    }
}
