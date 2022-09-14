using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TS.SSC.BL;
using TS.SSC.Entity;
using TS.SSC.Portal.Services;

namespace TS.SSC.Portal.ViewModels
{
    public class RegistroSacramentoVM:RegistroSacramento
    {
        #region modelos
        public ParroquiaVM ParroquiaM { get; set; }
        public SacramentoVM SacramentoM { get; set; }
        public PersonaVM PersonaM { get; set; }
        #endregion

        #region listas
        public PersonaLVM ListPersonas;
        public SacramentoLVM ListSacramentos;
        public PersonaVM personaSacramento;
        #endregion
        internal void cargarListas()
        {
            this.ListPersonas = ModelService.ToView(PersonaBL.ToList(this.idParroquia));
            this.ListSacramentos = ModelService.ToView(SacramentoBL.ToList());
        }

        internal void cargaPersona()
        {
            this.personaSacramento = ModelService.ToView(PersonaBL.GetByID(this.idParroquia, this.idPersona));
            this.PersonaM = ModelService.ToView(PersonaBL.GetByID(this.idParroquia, this.idPersona));

        }
    }
}