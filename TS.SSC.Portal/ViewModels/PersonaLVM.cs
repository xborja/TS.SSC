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
        public string LetraDesde { get; set; }
        public string LetraHasta { get; set; }
        public string FNombre { get; set; }

        public List<String> LetraList { get; set; }

        public PersonaLVM()
        {
            this.Items = new List<PersonaVM>();
            cargaListaLetras();
        }
        private void cargaListaLetras()
        {
            LetraList = new List<String>();
            LetraList.Add("A");
            LetraList.Add("B");
            LetraList.Add("C");
            LetraList.Add("D");
            LetraList.Add("E");
            LetraList.Add("F");
            LetraList.Add("G");
            LetraList.Add("H");
            LetraList.Add("I");
            LetraList.Add("J");
            LetraList.Add("K");
            LetraList.Add("L");
            LetraList.Add("M");
            LetraList.Add("N");
            LetraList.Add("Ñ");
            LetraList.Add("O");
            LetraList.Add("P");
            LetraList.Add("Q");
            LetraList.Add("R");
            LetraList.Add("S");
            LetraList.Add("T");
            LetraList.Add("U");
            LetraList.Add("V");
            LetraList.Add("W");
            LetraList.Add("X");
            LetraList.Add("Y");
            LetraList.Add("Z");
        }


    }
}