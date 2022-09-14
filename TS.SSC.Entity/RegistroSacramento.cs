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
    public class RegistroSacramento: Control
    {
        public static string NombreEntidad = "RegistroSacramento";
        #region propiedades
        [Display(Name = "Id")]
        public int id { get; set; }
        [Display(Name = "Parroquia")]
        public int idParroquia { get; set; }
        [Display(Name = "Persona")]
        public int idPersona { get; set; }
        [Display(Name = "Sacramento")]
        public int idSacramento { get; set; }
        [Display(Name = "Fecha registro")]
        public DateTime fechaRegistro { get; set; }
        [Display(Name = "Libro")]
        public int libro { get; set; }
        [Display(Name = "Folio")]
        public int folio { get; set; }
        [Display(Name = "Partida")]
        public string partida{ get; set; }
        [Display(Name = "Padrino")]
        public string nombrePadrino{ get; set; }
        [Display(Name = "Madrina")]
        public string nombreMadrina{ get; set; }
        [Display(Name = "Ministro")]
        public string  nombreMinistro { get; set; }
        [Display(Name = "Da fe")]
        public string nombreDaFe { get; set; }

        #endregion

        #region propiedades especiales
        public string Parroquia { get; set; }
        public string Sacramento { get; set; }
        public string Persona { get; set; }
     
        #endregion

    }
}
