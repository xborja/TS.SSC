using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TS.SSC.Entity;

namespace TS.SSC.Windows
{
    static class clsUtils
    {
        public static Usuario UsuarioSesion;
        public static bool ValidaNumero(TextBox textControl, char KeyChar)
        {
            bool validacion = false;
            if (!Char.IsDigit(KeyChar) && !Char.IsControl(KeyChar))
                if (KeyChar == '.')
                {
                    if ((textControl.Text.IndexOf(KeyChar) != -1) || (textControl.Text == ""))
                    {
                        validacion = true;
                    }
                }
                else
                {
                    validacion = true;
                }
            else
            {
                validacion = false;
            }
            return validacion;
        }
        public static DataTable ToDataTableOfStrings<T>(this IList<T> list)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, System.Type.GetType("System.String"));
            }
            object[] values = new object[props.Count];
            foreach (T item in list)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = props[i].GetValue(item).ToString() ?? "";
                table.Rows.Add(values);
            }
            return table;
        }
        public static DataTable ToDataTable<T>(this IList<T> list)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in list)
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                table.Rows.Add(values);
            }
            return table;
        }
    }
    public class clsEstado
    {
        public int idEstado { get; set; }
        public string Descripcion { get; set; }
        public static List<clsEstado> ToList()
        {
            List<clsEstado> estados = new List<clsEstado>();
            estados.Add(new clsEstado { idEstado = 1, Descripcion = "Activo" });
            estados.Add(new clsEstado { idEstado = 0, Descripcion = "Inactivo" });
            return estados;
        }

    }
    public enum TipoNavegacionEnum
    {
        Primero,
        Anterior,
        Siguiente,
        Ultimo
    }
    public enum EntidadBusquedaEnum
    {
        Usuario,
        Persona,
        Sacramento,
        RegistroSacramento
    }
    public enum TipoComprobanteVentaEnum
    {
        NotaVenta,
        Factura
    }
    public enum ModoPantallaEnum
    {
        Navegacion,
        Edicion
    }

}
