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
    public class Sacramento:Control
    {
        public static string NombreEntidad = "Sacramento";

        #region propiedades
        [Display(Name = "Id")]

        public int id { get; set; }
        [Display(Name = "Nombre sacramento")]
        public string nombreSacramento { get; set; }
        [Display(Name = "Estado")]

        public bool estado { get; set; }
        
        #endregion

    }
}
