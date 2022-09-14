using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Core.DAO;
using TS.SSC.Entity;

namespace TS.SSC.BL
{
    public class ParroquiaBL
    {
        #region CRUD
        public static List<Parroquia> ToList()
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string NombreBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref NombreBase);
            List<Parroquia> items = new List<Parroquia>();
            Parroquia item;

            string sSQL = ResourcesEntity.GetDBScript("ParroquiaSelect", TipoBase).Replace("@DATABASENAME", NombreBase);
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

                            item = new Parroquia();
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
        public static Parroquia GetByID(int id)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            Parroquia item = new Parroquia();
            string sSQL = ResourcesEntity.GetDBScript("ParroquiaSelect", TipoBase).Replace("@DATABASENAME", horaIniBase);
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
        public static int Create(Parroquia item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Insert;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Parroquia.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@nombre", DataBase.ToDBNull(item.nombre));
            sSQL = DataBase.SetParamValue(sSQL, "@lugar", DataBase.ToDBNull(item.lugar));
            sSQL = DataBase.SetParamValue(sSQL, "@direccion", DataBase.ToDBNull(item.direccion));
            sSQL = DataBase.SetParamValue(sSQL, "@telefono", DataBase.ToDBNull(item.telefono));
            sSQL = DataBase.SetParamValue(sSQL, "@parroco", DataBase.ToDBNull(item.parroco));
            sSQL = DataBase.SetParamValue(sSQL, "@userCrea", DataBase.ToDBNull(item.UsuarioCrea));
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
        public static int Update(Parroquia item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Update;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Parroquia.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@nombre", DataBase.ToDBNull(item.nombre));
            sSQL = DataBase.SetParamValue(sSQL, "@lugar", DataBase.ToDBNull(item.lugar));
            sSQL = DataBase.SetParamValue(sSQL, "@direccion", DataBase.ToDBNull(item.direccion));
            sSQL = DataBase.SetParamValue(sSQL, "@telefono", DataBase.ToDBNull(item.telefono));
            sSQL = DataBase.SetParamValue(sSQL, "@parroco", DataBase.ToDBNull(item.parroco));
            sSQL = DataBase.SetParamValue(sSQL, "@userModif", DataBase.ToDBNull(item.UsuarioModif));
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
        public static int Delete(Parroquia item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Delete;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Parroquia.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
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

        internal static void cargaObjeto(DataRow row, ref Parroquia item)
        {
            item = new Parroquia();
            {
                item.id = row.Table.Columns.Contains("id") ? DataBase.intToNull(row["id"]) : 0;
                item.nombre = row.Table.Columns.Contains("nombre") ? DataBase.strToNull(row["nombre"]) : "";
                item.lugar= row.Table.Columns.Contains("lugar") ? DataBase.strToNull(row["lugar"]) : "";
                item.direccion = row.Table.Columns.Contains("direccion") ? DataBase.strToNull(row["direccion"]) : "";
                item.telefono = row.Table.Columns.Contains("telefono") ? DataBase.strToNull(row["telefono"]) : "";
                item.parroco = row.Table.Columns.Contains("parroco") ? DataBase.strToNull(row["parroco"]) : "";
            }
        }
    }

}
