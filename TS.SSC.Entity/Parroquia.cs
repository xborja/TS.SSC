using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TS.Core;
using System.Data;
using System.Data.SqlClient;
using TS.Core.DAO;


namespace TS.SSC.Entity
{
    public class Parroquia : Control
    {
        public static string NombreEntidad = "Parroquia";
        #region propiedades
        [Display(Name = "Id")]
        public int id { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Lugar")]
        public string lugar { get; set; }
        [Display(Name = "Dirección")]
        public string direccion { get; set; }
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }
        [Display(Name = "Parroco")]
        public string parroco { get; set; }

        #endregion


    }
}
