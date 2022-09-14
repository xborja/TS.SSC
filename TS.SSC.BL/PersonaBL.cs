using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Core.DAO;
using TS.SSC.Entity;
/// <summary>
/// Conjunto de clases para la sintesis para los parámetros de la plantilla calculo nomina
/// </summary>
namespace TS.SSC.BL
{

    public class PersonaBL
    {
        #region CRUD
        public static List<Persona> ToList(int idParroquia)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string NombreBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref NombreBase);
            List<Persona> items = new List<Persona>();
            Persona item;

            string sSQL = ResourcesEntity.GetDBScript("PersonaSelect", TipoBase).Replace("@DATABASENAME", NombreBase);
            sSQL = DataBase.SetParamValue(sSQL, "@idParroquia", idParroquia);
            sSQL = DataBase.SetParamValueDirect(sSQL, "@id", "\"id\"");

            DataSet ds = new DataSet();
            DataBase db = new DataBase();
            db.openConnection();

            try
            {
                db.openConnection();
                ds = db.FillData(sSQL, "tblData");
                db.closeConnection();
                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)

                    {
                        foreach (DataRow row in ds.Tables["tblData"].Rows)
                        {

                            item = new Persona();
                            cargaObjeto(row, ref item);
                            items.Add(item);
                        }
                    }

            }
            catch (System.Exception Ex)
            {
                db.errorTransaction();
            }
            finally
            {
                db.closeConnection();
            }

            return items;
        }
        public static Persona GetByID(int idParroquia, int id)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            Persona item = new Persona();
            string sSQL = ResourcesEntity.GetDBScript("PersonaSelect", TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@idParroquia", idParroquia);
            sSQL = DataBase.SetParamValue(sSQL, "@id", id);

            DataSet ds = new DataSet();
            DataBase db = new DataBase();

            try
            {
                db.openConnection();
                ds = db.FillData(sSQL, "tblData");
                db.closeConnection();
                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables[0].Rows[0];
                        cargaObjeto(row, ref item);
                    }

            }
            catch (Exception ex)
            {

                db.errorTransaction();
            }
            finally
            {
                db.closeConnection();
            }

            return item;

        }
        public static Persona GetByCed(int idParroquia, string Cedula)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            Persona item = new Persona();
            string sSQL = ResourcesEntity.GetDBScript("PersonaSelect", TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@idParroquia", idParroquia);
            sSQL = DataBase.SetParamValueDirect(sSQL, "@id", "\"id\"");
            sSQL = DataBase.SetParamValue(sSQL, "@cedula", Cedula);

            DataSet ds = new DataSet();
            DataBase db = new DataBase();

            try
            {
                db.openConnection();
                ds = db.FillData(sSQL, "tblData");
                db.closeConnection();
                if (ds.Tables.Count > 0)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables[0].Rows[0];
                        cargaObjeto(row, ref item);
                    }

            }
            catch (Exception ex)
            {

                db.errorTransaction();
            }
            finally
            {
                db.closeConnection();
            }

            return item;

        }
        public static int Create(Persona item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Insert;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Persona.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@idParroquia", DataBase.ToDBNull(item.idParroquia));
            sSQL = DataBase.SetParamValue(sSQL, "@cedula", DataBase.ToDBNull(item.Cedula));
            sSQL = DataBase.SetParamValue(sSQL, "@nombrePadre", DataBase.ToDBNull(item.NombrePadre));
            sSQL = DataBase.SetParamValue(sSQL, "@nombreMadre", DataBase.ToDBNull(item.NombreMadre));
            sSQL = DataBase.SetParamValue(sSQL, "@nombre", DataBase.ToDBNull(item.Nombre));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@fechaNacimiento", DataBase.ToDBNull(item.FechaNacimiento));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@lugarNacimiento", DataBase.ToDBNull(item.LugarNacimiento));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@fechaBautismo", DataBase.ToDBNull(item.FechaBautismo));
            sSQL = DataBase.SetParamValue(sSQL, "@lugarBautismo", DataBase.ToDBNull(item.LugarBautismo));
            sSQL = DataBase.SetParamValue(sSQL, "@userCrea", DataBase.ToDBNull(item.UsuarioCrea));
            db = new DataBase();

            try
            {
                db.openConnection();
                identidad = db.InsertIdentity(sSQL);
                item.id = identidad;
                return 1;
            }
            catch (Exception ex)
            {
                item.MensajeProceso = ex.Message;
                item.EstadoProceso = -1;
                db.errorTransaction();
                return 0;
            }
            finally
            {
                db.closeConnection();

            }


        }
        public static int Update(Persona item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Update;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Persona.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@idParroquia", DataBase.ToDBNull(item.idParroquia));
            sSQL = DataBase.SetParamValue(sSQL, "@cedula", DataBase.ToDBNull(item.Cedula));
            sSQL = DataBase.SetParamValue(sSQL, "@nombrePadre", DataBase.ToDBNull(item.NombrePadre));
            sSQL = DataBase.SetParamValue(sSQL, "@nombreMadre", DataBase.ToDBNull(item.NombreMadre));
            sSQL = DataBase.SetParamValue(sSQL, "@nombre", DataBase.ToDBNull(item.Nombre));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@fechaNacimiento", DataBase.ToDBNull(item.FechaNacimiento));
            sSQL = DataBase.SetParamValue(sSQL, "@lugarNacimiento", DataBase.ToDBNull(item.LugarNacimiento));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@fechaBautismo", DataBase.ToDBNull(item.FechaBautismo));
            sSQL = DataBase.SetParamValue(sSQL, "@lugarBautismo", DataBase.ToDBNull(item.LugarBautismo));
            sSQL = DataBase.SetParamValue(sSQL, "@userModif", DataBase.ToDBNull(item.UsuarioModif));
            sSQL = DataBase.SetParamValue(sSQL, "@id", DataBase.ToDBNull(item.id));
            db = new DataBase();

            try
            {
                db.openConnection();
                db.ExecuteSQL(sSQL);
                return 1;
            }
            catch (Exception ex)
            {
                item.MensajeProceso = ex.Message;
                item.EstadoProceso = -1;
                db.errorTransaction();
                return 0;
            }
            finally
            {
                db.closeConnection();

            }


        }
        public static int Delete(Persona item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Delete;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Persona.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@id", DataBase.ToDBNull(item.id));
            db = new DataBase();

            try
            {
                db.openConnection();
                identidad = db.InsertIdentity(sSQL);
                return 1;
            }
            catch (Exception ex)
            {
                item.MensajeProceso = ex.Message;
                item.EstadoProceso = -1;
                db.errorTransaction();
                return 0;
            }
            finally
            {
                db.closeConnection();

            }
        }


        #endregion

        internal static void cargaObjeto(DataRow row, ref Persona item)
        {
            item = new Persona();
            {
                item.id = row.Table.Columns.Contains("id") ? DataBase.intToNull(row["id"]) : 0;
                item.idParroquia = row.Table.Columns.Contains("idParroquia") ? DataBase.intToNull(row["idParroquia"]) : 0;
                item.Nombre = row.Table.Columns.Contains("nombre") ? DataBase.strToNull(row["nombre"]) : "";
                item.Cedula = row.Table.Columns.Contains("cedula") ? DataBase.strToNull(row["cedula"]) : "";
                item.NombrePadre = row.Table.Columns.Contains("nombrePadre") ? DataBase.strToNull(row["nombrePadre"]) : "";
                item.NombreMadre = row.Table.Columns.Contains("nombreMadre") ? DataBase.strToNull(row["nombreMadre"]) : "";
                item.FechaNacimiento = row.Table.Columns.Contains("fechaNacimiento") ? DataBase.DateTimeToNull(row["fechaNacimiento"]) : System.DateTime.MinValue;
                item.LugarNacimiento = row.Table.Columns.Contains("lugarNacimiento") ? DataBase.strToNull(row["lugarNacimiento"]) : "";
                item.FechaBautismo = row.Table.Columns.Contains("fechaBautismo") ? DataBase.DateTimeToNull(row["fechaBautismo"]) : System.DateTime.MinValue;
                item.LugarBautismo = row.Table.Columns.Contains("lugarBautismo") ? DataBase.strToNull(row["lugarBautismo"]) : "";
                item.FechaB = row.Table.Columns.Contains("fechaBautismo") ? DataBase.DateTimeToNull(row["fechaBautismo"]).ToString("dd/MM/yyyy") : "";
                item.FechaN = row.Table.Columns.Contains("fechaNacimiento") ? DataBase.DateTimeToNull(row["fechaNacimiento"]).ToString("dd/MM/yyyy") : "";

            }
        }

    }
}
