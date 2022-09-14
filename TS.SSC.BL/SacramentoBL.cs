using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TS.Core.DAO;
using TS.SSC.Entity;

namespace TS.SSC.BL
{
    public class SacramentoBL
    {
        #region CRUD
        public static List<Sacramento> ToList()
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string NombreBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref NombreBase);
            List<Sacramento> items = new List<Sacramento>();
            Sacramento item;

            string sSQL = ResourcesEntity.GetDBScript("SacramentoSelect", TipoBase).Replace("@DATABASENAME", NombreBase);
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

                            item = new Sacramento();
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
        public static Sacramento GetByID(int id)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            Sacramento item = new Sacramento();
            string sSQL = ResourcesEntity.GetDBScript("SacramentoSelect", TipoBase).Replace("@DATABASENAME", horaIniBase);
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
        public static int Create(Sacramento item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Insert;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Sacramento.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@nombreSacramento", DataBase.ToDBNull(item.nombreSacramento));
            sSQL = DataBase.SetParamValue(sSQL, "@estado", DataBase.ToDBNull(item.estado));
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
        public static int Update(Sacramento item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Update;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Sacramento.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@nombreSacramento", DataBase.ToDBNull(item.nombreSacramento));
            sSQL = DataBase.SetParamValue(sSQL, "@estado", DataBase.ToDBNull(item.estado));
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
        public static int Delete(Sacramento item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Delete;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Sacramento.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
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

        internal static void cargaObjeto(DataRow row, ref Sacramento item)
        {
            item = new Sacramento();
            {
                item.id = row.Table.Columns.Contains("id") ? DataBase.intToNull(row["id"]) : 0;
                item.nombreSacramento = row.Table.Columns.Contains("nombreSacramento") ? DataBase.strToNull(row["nombreSacramento"]) : "";
                item.estado = row.Table.Columns.Contains("estado") ? DataBase.boolToNull(row["estado"]) : false;
            }
        }


    }

}
