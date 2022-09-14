using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.SSC.Entity;

namespace TS.SSC.BL
{
    public class printSacramentoBL
    {
        public int idRegistro { get; set; }
        public int libro { get; set; }
        public int folio { get; set; }
        public string partida { get; set; }
        public string nombrePersona { get; set; }
        public string nombrePadres { get; set; }
        public string nombrePadre { get; set; }
        public string nombreMadre { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string nombreSacramento { get; set; }
        public string  nombrePadrinos{ get; set; }
        public string nombreMinistro { get; set; }
        public string nombreDaFe { get; set; }
        public string nombreParroco { get; set; }
        public string lugarParroquia { get; set; }
        public string nombreParroquia { get; set; }

        public DateTime fechaNacimiento { get; set; }
        public string lugarNacimiento { get; set; }
        public DateTime fechaBautismo { get; set; }
        public string lugarBautismo { get; set; }
        public string NotaMarginal { get; set; }
        public string LugarYFechaNacimiento { 
            get 
            {
                return lugarNacimiento.ToUpper() + ", " + fechaNacimiento.ToString("MMMM dd 'de' yyyy", new CultureInfo("es-ES")).ToUpper();
            } 
        }

        public string FechaSacramento
        {
            get
            {
                return fechaRegistro.ToString("MMMM dd 'de' yyyy", new CultureInfo("es-ES")).ToUpper();
            }
        }
        public static List<printSacramentoBL> ToList(int idParroquia, int id)
        {
            List<printSacramentoBL> lista = new List<printSacramentoBL>();
            RegistroSacramento item;
            try
            {
                item = RegistroSacramentoBL.GetByID(idParroquia, id);
                Parroquia parroquia = ParroquiaBL.GetByID(idParroquia);
                Sacramento sacramento = SacramentoBL.GetByID(item.idSacramento);
                Persona persona = PersonaBL.GetByID(idParroquia, item.idPersona);
                printSacramentoBL itemprint = new printSacramentoBL();
                itemprint.idRegistro = item.id;
                itemprint.libro = item.libro;
                itemprint.folio = item.folio;
                itemprint.partida = item.partida;
                itemprint.nombrePersona = persona.Nombre;
                itemprint.fechaNacimiento = persona.FechaNacimiento;
                itemprint.lugarNacimiento = persona.LugarNacimiento;
                itemprint.fechaBautismo = persona.FechaBautismo;
                itemprint.lugarBautismo = persona.LugarBautismo;

                if (!string.IsNullOrEmpty(persona.NombrePadre))
                {
                    itemprint.nombrePadre = persona.NombrePadre;
                    itemprint.nombrePadres = persona.NombrePadre;
                }
                if (!string.IsNullOrEmpty(persona.NombreMadre))
                {
                    itemprint.nombreMadre = persona.NombreMadre;
                    if (string.IsNullOrEmpty(itemprint.nombrePadres))
                        itemprint.nombrePadres = persona.NombreMadre;
                    else
                        itemprint.nombrePadres+= " y " + persona.NombrePadre;
                }

                if (!string.IsNullOrEmpty(item.nombrePadrino))
                {
                    itemprint.nombrePadrinos = item.nombrePadrino;
                }
                if (!string.IsNullOrEmpty(item.nombreMadrina))
                {
                    if (string.IsNullOrEmpty(itemprint.nombrePadrinos))
                        itemprint.nombrePadrinos = item.nombreMadrina;
                    else
                        itemprint.nombrePadrinos += " y " + item.nombreMadrina;
                }

                itemprint.fechaRegistro = item.fechaRegistro;
                itemprint.nombreSacramento = sacramento.nombreSacramento;
                itemprint.nombreMinistro = item.nombreMinistro;
                itemprint.nombreDaFe = item.nombreDaFe;
                itemprint.nombreParroco = parroquia.parroco;
                itemprint.nombreParroquia = parroquia.nombre;
                itemprint.lugarParroquia = parroquia.lugar;
                lista.Add(itemprint);

            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
        public static List<printSacramentoBL> ToList()
        {
            return new List<printSacramentoBL>();
        }
    }

}
