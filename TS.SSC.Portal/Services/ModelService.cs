using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using TS.SSC.Entity;
using TS.SSC.Portal.ViewModels;

namespace TS.SSC.Portal.Services
{
    public class ModelService
    {
        public static PersonaVM ToView(Persona item)
        {
            PersonaVM itemv = new PersonaVM();
            PropertyInfo[] propsView = itemv.GetType().GetProperties();
            foreach (PropertyInfo prop in item.GetType().GetProperties())
            {
                propsView.First(m => m.Name == prop.Name).SetValue(itemv, prop.GetValue(item));
            }
            return itemv;
        }
        public static PersonaLVM ToView(List<Persona> items)
        {
            PersonaLVM itemsV = new PersonaLVM();
            foreach (var item in items)
            {
                itemsV.Items.Add(ToView(item));

            }

            return itemsV;
        }
        internal static Persona ToModel(PersonaVM item)
        {
            Persona itemV = new Persona();
            PropertyInfo[] propsView = item.GetType().GetProperties();
            foreach (PropertyInfo prop in itemV.GetType().GetProperties())
            {
                prop.SetValue(itemV, propsView.First(m => m.Name == prop.Name).GetValue(item));
            }
            return itemV;
        }

        public static ParroquiaVM ToView(Parroquia item)
        {
            ParroquiaVM itemv = new ParroquiaVM();
            PropertyInfo[] propsView = itemv.GetType().GetProperties();
            foreach (PropertyInfo prop in item.GetType().GetProperties())
            {
                propsView.First(m => m.Name == prop.Name).SetValue(itemv, prop.GetValue(item));
            }
            return itemv;
        }
        public static ParroquiaLVM ToView(List<Parroquia> items)
        {
            ParroquiaLVM itemsV = new ParroquiaLVM();
            foreach (var item in items)
            {
                itemsV.Items.Add(ToView(item));

            }

            return itemsV;
        }
        internal static Parroquia ToModel(ParroquiaVM item)
        {
            Parroquia itemV = new Parroquia();
            PropertyInfo[] propsView = item.GetType().GetProperties();
            foreach (PropertyInfo prop in itemV.GetType().GetProperties())
            {
                prop.SetValue(itemV, propsView.First(m => m.Name == prop.Name).GetValue(item));
            }
            return itemV;
        }

        public static SacramentoVM ToView(Sacramento item)
        {
            SacramentoVM itemv = new SacramentoVM();
            PropertyInfo[] propsView = itemv.GetType().GetProperties();
            foreach (PropertyInfo prop in item.GetType().GetProperties())
            {
                propsView.First(m => m.Name == prop.Name).SetValue(itemv, prop.GetValue(item));
            }
            return itemv;
        }
        public static SacramentoLVM ToView(List<Sacramento> items)
        {
            SacramentoLVM itemsV = new SacramentoLVM();
            foreach (var item in items)
            {
                itemsV.Items.Add(ToView(item));

            }

            return itemsV;
        }
        internal static Sacramento ToModel(SacramentoVM item)
        {
            Sacramento itemV = new Sacramento();
            PropertyInfo[] propsView = item.GetType().GetProperties();
            foreach (PropertyInfo prop in itemV.GetType().GetProperties())
            {
                prop.SetValue(itemV, propsView.First(m => m.Name == prop.Name).GetValue(item));
            }
            return itemV;
        }

        public static RegistroSacramentoVM ToView(RegistroSacramento item)
        {
            RegistroSacramentoVM itemv = new RegistroSacramentoVM();
            PropertyInfo[] propsView = itemv.GetType().GetProperties();
            foreach (PropertyInfo prop in item.GetType().GetProperties())
            {
                propsView.First(m => m.Name == prop.Name).SetValue(itemv, prop.GetValue(item));
            }
            return itemv;
        }
        public static RegistroSacramentoLVM ToView(List<RegistroSacramento> items)
        {
            RegistroSacramentoLVM itemsV = new RegistroSacramentoLVM();
            foreach (var item in items)
            {
                itemsV.Items.Add(ToView(item));

            }

            return itemsV;
        }
        internal static RegistroSacramento ToModel(RegistroSacramentoVM item)
        {
            RegistroSacramento itemV = new RegistroSacramento();
            PropertyInfo[] propsView = item.GetType().GetProperties();
            foreach (PropertyInfo prop in itemV.GetType().GetProperties())
            {
                prop.SetValue(itemV, propsView.First(m => m.Name == prop.Name).GetValue(item));
            }
            return itemV;
        }
      
        public static UsuarioVM ToView(Usuario item)
        {
            UsuarioVM itemv = new UsuarioVM();
            PropertyInfo[] propsView = itemv.GetType().GetProperties();
            foreach (PropertyInfo prop in item.GetType().GetProperties())
            {
                propsView.First(m => m.Name == prop.Name).SetValue(itemv, prop.GetValue(item));
            }
            return itemv;
        }
        public static UsuarioLVM ToView(List<Usuario> items)
        {
            UsuarioLVM itemsV = new UsuarioLVM();
            foreach (var item in items)
            {
                itemsV.Items.Add(ToView(item));

            }

            return itemsV;
        }
        internal static Usuario ToModel(UsuarioVM item)
        {
            Usuario itemV = new Usuario();
            PropertyInfo[] propsView = item.GetType().GetProperties();
            foreach (PropertyInfo prop in itemV.GetType().GetProperties())
            {
                prop.SetValue(itemV, propsView.First(m => m.Name == prop.Name).GetValue(item));
            }
            return itemV;

        }

    }

}