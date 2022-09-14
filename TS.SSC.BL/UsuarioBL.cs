using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.SSC.Entity;
using TS.Core.DAO;

namespace TS.SSC.BL
{
    public class UsuarioBL
    {
        #region CRUD
        public static List<Usuario> ToList(int idParroquia)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string NombreBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref NombreBase);
            List<Usuario> items = new List<Usuario>();
            Usuario item;

            string sSQL = ResourcesEntity.GetDBScript("UsuarioSelect", TipoBase).Replace("@DATABASENAME", NombreBase);
            sSQL = DataBase.SetParamValue(sSQL, "@idParroquia", idParroquia);
            sSQL = DataBase.SetParamValueDirect(sSQL, "@userName", "\"userName\"");
            sSQL = DataBase.SetParamValueDirect(sSQL, "@password", "\"password\"");
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

                            item = new Usuario();
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
        public static Usuario GetByID(int id)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            Usuario item = new Usuario();
            string sSQL = ResourcesEntity.GetDBScript("UsuarioSelect", TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValueDirect(sSQL, "@idParroquia", "\"idParroquia\"");
            sSQL = DataBase.SetParamValue(sSQL, "@id", id);
            sSQL = DataBase.SetParamValueDirect(sSQL, "@userName", "\"userName\"");
            sSQL = DataBase.SetParamValueDirect(sSQL, "@password", "\"password\"");
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
        public static int Create(Usuario item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Insert;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Usuario.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@idParroquia", DataBase.ToDBNull(item.idParroquia));
            sSQL = DataBase.SetParamValue(sSQL, "@userName", DataBase.ToDBNull(item.userName));
            sSQL = DataBase.SetParamValue(sSQL, "@passwordHash", DataBase.ToDBNull(item.passwordHash));

            sSQL = DataBase.SetParamValue(sSQL, "@password", DataBase.ToDBNull(item.password));
            sSQL = DataBase.SetParamValue(sSQL, "@tipoUsuario", DataBase.ToDBNull(item.tipoUsuario));
            sSQL = DataBase.SetParamValue(sSQL, "@nombreUsuario", DataBase.ToDBNull(item.nombreUsuario));
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
        public static int Update(Usuario item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Update;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Usuario.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@idParroquia", DataBase.ToDBNull(item.idParroquia));
            sSQL = DataBase.SetParamValue(sSQL, "@userName", DataBase.ToDBNull(item.userName));
            sSQL = DataBase.SetParamValue(sSQL, "@passwordHash", DataBase.ToDBNull(item.passwordHash));
            sSQL = DataBase.SetParamValue(sSQL, "@password", DataBase.ToDBNull(item.password));
            sSQL = DataBase.SetParamValue(sSQL, "@tipoUsuario", DataBase.ToDBNull(item.tipoUsuario));
            sSQL = DataBase.SetParamValue(sSQL, "@nombreUsuario", DataBase.ToDBNull(item.nombreUsuario));
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
        public static int Delete(Usuario item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Delete;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Usuario.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
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

        #region Metodos Especiales
        public static Usuario GetByUserName(string username, string password)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            Usuario item = new Usuario();
            string sSQL = ResourcesEntity.GetDBScript("UsuarioSelect", TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValueDirect(sSQL, "@idParroquia", "\"idParroquia\"");
            sSQL = DataBase.SetParamValueDirect(sSQL, "@id", "\"id\"");
            sSQL = DataBase.SetParamValue(sSQL, "@userName", username);
            sSQL = DataBase.SetParamValue(sSQL, "@password", password);

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
        public static Usuario GetByUserName(string username)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            Usuario item = new Usuario();
            string sSQL = ResourcesEntity.GetDBScript("UsuarioSelect", TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValueDirect(sSQL, "@idParroquia", "\"idParroquia\"");
            sSQL = DataBase.SetParamValueDirect(sSQL, "@id", "\"id\"");
            sSQL = DataBase.SetParamValue(sSQL, "@userName", username);
            sSQL = DataBase.SetParamValueDirect(sSQL, "@password", "\"password\"");
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

        public static int UpdatePass(Usuario item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = Usuario.NombreEntidad + "UpdatePass";
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(sSQL, "@passwordHash", DataBase.ToDBNull(item.passwordHash));
            sSQL = DataBase.SetParamValue(sSQL, "@password", DataBase.ToDBNull(item.password));
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

        #endregion

        internal static void cargaObjeto(DataRow row, ref Usuario item)
        {
            item = new Usuario();
            {
                item.id = row.Table.Columns.Contains("id") ? DataBase.intToNull(row["id"]) : 0;
                item.idParroquia = row.Table.Columns.Contains("idParroquia") ? DataBase.intToNull(row["idParroquia"]) : 0;
                item.userName = row.Table.Columns.Contains("userName") ? DataBase.strToNull(row["userName"]) : "";
                item.password = row.Table.Columns.Contains("password") ? DataBase.strToNull(row["password"]) : "";
                item.passwordHash = row.Table.Columns.Contains("passwordHash") ? DataBase.strToNull(row["passwordHash"]) : "";
                item.tipoUsuario = row.Table.Columns.Contains("tipoUsuario") ? DataBase.strToNull(row["tipoUsuario"]) : "";
                item.estado = row.Table.Columns.Contains("estado") ? DataBase.boolToNull(row["estado"]) : false;
                item.nombreUsuario = row.Table.Columns.Contains("nombreUsuario") ? DataBase.strToNull(row["nombreUsuario"]) : "";
            }
        }

    }
}
