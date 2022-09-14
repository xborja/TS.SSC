using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.SSC.Entity;
using TS.Core.DAO;
using System.ComponentModel.DataAnnotations;

namespace TS.SSC.BL
{
    public class RegistroSacramentoBL
    {
        #region CRUD
        public static List<RegistroSacramento> ToList(int idParroquia)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string NombreBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref NombreBase);
            List<RegistroSacramento> items = new List<RegistroSacramento>();
            RegistroSacramento item;

            string sSQL = ResourcesEntity.GetDBScript("RegistroSacramentoConsulta", TipoBase).Replace("@DATABASENAME", NombreBase);
            sSQL = DataBase.SetParamValue(sSQL, "@idParroquia", idParroquia);
            sSQL = DataBase.SetParamValueDirect(sSQL, "@id", "a.\"id\"");

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

                            item = new RegistroSacramento();
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
        public static RegistroSacramento GetByID(int idParroquia, int id)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            RegistroSacramento item = new RegistroSacramento();
            string sSQL = ResourcesEntity.GetDBScript("RegistroSacramentoSelect", TipoBase).Replace("@DATABASENAME", horaIniBase);
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
        public static int Create(RegistroSacramento item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Insert;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = RegistroSacramento.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(TipoBase,sSQL, "@idParroquia", DataBase.ToDBNull(item.idParroquia));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@idPersona", DataBase.ToDBNull(item.idPersona));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@idSacramento", DataBase.ToDBNull(item.idSacramento));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@fechaRegistro", DataBase.ToDBNull(item.fechaRegistro));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@libro", DataBase.ToDBNull(item.libro));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@folio", DataBase.ToDBNull(item.folio));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@partida", DataBase.ToDBNull(item.partida));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@nombrePadrino", DataBase.ToDBNull(item.nombrePadrino));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@nombreMadrina", DataBase.ToDBNull(item.nombreMadrina));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@nombreMinistro", DataBase.ToDBNull(item.nombreMinistro));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@nombreDaFe", DataBase.ToDBNull(item.nombreDaFe));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@userCrea", DataBase.ToDBNull(item.UsuarioCrea));
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
        public static int Update(RegistroSacramento item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Update;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = RegistroSacramento.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
            DataBase db;
            int identidad;

            string sSQL = ResourcesEntity.GetDBScript(scriptOperacion, TipoBase).Replace("@DATABASENAME", horaIniBase);
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@idParroquia", DataBase.ToDBNull(item.idParroquia));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@idPersona", DataBase.ToDBNull(item.idPersona));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@idSacramento", DataBase.ToDBNull(item.idSacramento));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@fechaRegistro", DataBase.ToDBNull(item.fechaRegistro));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@libro", DataBase.ToDBNull(item.libro));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@folio", DataBase.ToDBNull(item.folio));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@partida", DataBase.ToDBNull(item.partida));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@nombrePadrino", DataBase.ToDBNull(item.nombrePadrino));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@nombreMadrina", DataBase.ToDBNull(item.nombreMadrina));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@nombreMinistro", DataBase.ToDBNull(item.nombreMinistro));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@nombreDaFe", DataBase.ToDBNull(item.nombreDaFe));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@userModif", DataBase.ToDBNull(item.UsuarioModif));
            sSQL = DataBase.SetParamValue(TipoBase, sSQL, "@id", DataBase.ToDBNull(item.id));
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
        public static int Delete(RegistroSacramento item)
        {
            TipoBaseEnum TipoBase = TipoBaseEnum.SQLSERVER;
            TipoOperacionEnum TipoOperacion = TipoOperacionEnum.Delete;
            string horaIniBase = string.Empty;
            DataBase.getDBSettings(ref TipoBase, ref horaIniBase);
            string scriptOperacion = RegistroSacramento.NombreEntidad + Enum.GetName(typeof(TipoOperacionEnum), TipoOperacion);
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

        internal static void cargaObjeto(DataRow row, ref RegistroSacramento item)
        {
            item = new RegistroSacramento();
            {
                item.id = row.Table.Columns.Contains("id") ? DataBase.intToNull(row["id"]) : 0;
                item.idParroquia = row.Table.Columns.Contains("idParroquia") ? DataBase.intToNull(row["idParroquia"]) : 0;
                item.idSacramento= row.Table.Columns.Contains("idSacramento") ? DataBase.intToNull(row["idSacramento"]) : 0;
                item.idPersona= row.Table.Columns.Contains("idPersona") ? DataBase.intToNull(row["idPersona"]) : 0;
                item.fechaRegistro = row.Table.Columns.Contains("fechaRegistro") ? DataBase.DateTimeToNull(row["fechaRegistro"]) : System.DateTime.MinValue;
                item.libro = row.Table.Columns.Contains("libro") ? DataBase.intToNull(row["libro"]) : 0;
                item.folio= row.Table.Columns.Contains("folio") ? DataBase.intToNull(row["folio"]) : 0;
                item.partida = row.Table.Columns.Contains("partida") ? DataBase.strToNull(row["partida"]) : "";
                item.Persona = row.Table.Columns.Contains("Persona") ? DataBase.strToNull(row["Persona"]) : "";
                item.Sacramento = row.Table.Columns.Contains("Sacramento") ? DataBase.strToNull(row["Sacramento"]) : "";
                item.Parroquia = row.Table.Columns.Contains("Parroquia") ? DataBase.strToNull(row["Parroquia"]) : "";
                item.nombrePadrino = row.Table.Columns.Contains("nombrePadrino") ? DataBase.strToNull(row["nombrePadrino"]) : "";
                item.nombreMadrina = row.Table.Columns.Contains("nombreMadrina") ? DataBase.strToNull(row["nombreMadrina"]) : "";
                item.nombreMinistro = row.Table.Columns.Contains("nombreMinistro") ? DataBase.strToNull(row["nombreMinistro"]) : "";
                item.nombreDaFe= row.Table.Columns.Contains("nombreDaFe") ? DataBase.strToNull(row["nombreDaFe"]) : "";
            }
        }


    }
}
