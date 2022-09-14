using System;
using System.ComponentModel.DataAnnotations;
using TS.Core;

namespace TS.SSC.Entity

{
    public class Persona : Control
    {
        public static string NombreEntidad = "Persona";
        #region propiedades
        public int id { get; set; }
        public int idParroquia { get; set; }
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }
        [Display(Name = "Nombre persona")]
        public string Nombre { get; set; }
        [Display(Name = "Nombre padre")]
        public string NombrePadre { get; set; }
        [Display(Name = "Nombre madre")]
        public string NombreMadre { get; set; }
        [Display(Name = "Fecha nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Lugar nacimiento")]
        public string LugarNacimiento { get; set; }
        [Display(Name = "Fecha bautismo")]
        public DateTime FechaBautismo { get; set; }
        [Display(Name = "Lugar bautismo")]
        public string LugarBautismo { get; set; }


        #endregion

        #region propiedades especiales
        #region propiedades de fechas


        public string FechaN { get; set; }
        public string FechaB { get; set; }
        public string FechaS { get; set; }

        #endregion
        #endregion

    }
}
