using Sap.Data.Hana;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
//using System.Data.SQLite;
using System.Globalization;

namespace TS.Core.DAO
{
    public class DataBase
    {
        #region Propiedades
        public string strConexion;
        public string TipoBase;
        public TipoBaseEnum tipoBase;
        public DbConnection conn;
        public DbTransaction transaction;
        //public MySqlConnection conn;
        //public MySqlTransaction transaction;
        #endregion
        public DataBase()
        {
            strConexion = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            TipoBase = ConfigurationManager.AppSettings["TipoBase"];
            try
            {
                Enum.TryParse<TipoBaseEnum>(TipoBase.ToUpper(), out tipoBase);

                if (tipoBase == TipoBaseEnum.SQLSERVER)
                {
                    conn = new SqlConnection(strConexion);
                }
                if (tipoBase == TipoBaseEnum.HANA)
                {
                    conn = new HanaConnection(strConexion);
                }
            }
            catch (System.Exception ex)
            {
                var mensaje = ex.Message;
                throw;
            }
        }

        public DataBase(string ConStringName)
        {
            try
            {
                strConexion = ConfigurationManager.ConnectionStrings[ConStringName].ConnectionString;
                conn.ConnectionString = strConexion;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public DataBase(string ConString, TipoBaseEnum tipoBaseOrigen)
        {
            try
            {
                strConexion = ConString;
                tipoBase = tipoBaseOrigen;
                try
                {
                    //Enum.TryParse<TipoBaseEnum>(TipoBase.ToUpper(), out tipoBase);

                    if (tipoBase == TipoBaseEnum.SQLSERVER)
                    {
                        conn = new SqlConnection(strConexion);
                    }
                    if (tipoBase == TipoBaseEnum.HANA)
                    {
                        conn = new HanaConnection(strConexion);
                    }
                }
                catch (System.Exception ex)
                {
                    var mensaje = ex.Message;
                    throw;
                }
            }
            catch (System.Exception ex)
            {
                var mensaje = ex.Message;
                //throw;
            }
        }

        #region funciones
        //public static void CreateSqlLiteDatabase(string nombreBase)
        //{
        //    SQLiteConnection.CreateFile(nombreBase);
        //}
        public void openConnection() // Open database Connection
        {
            try
            {
                conn.Close();
                conn.Open();
                transaction = conn.BeginTransaction();

            }
            catch (System.Exception Ex)
            {
                var mensaje = Ex.Message;
                throw;
            }
        }

        public void openConnectionNoTransaction() // Open database Connection
        {
            try
            {
                conn.Close();
                conn.Open();
                //transaction = conn.BeginTransaction();

            }
            catch (System.Exception Ex)
            {
                var mensaje = Ex.Message;
                throw;
            }
        }

        public void closeConnection() // database connection close
        {
            if (conn.State != ConnectionState.Closed)
            {
                if (transaction.Connection != null)
                { transaction.Commit(); }
                conn.Close();
            }
        }

        public void errorTransaction()
        {
            if (conn.State != ConnectionState.Closed)
            {
                if (transaction.Connection != null)
                    transaction.Rollback();
                conn.Close();
            }
        }

        /// <summary>
        /// Ejecuta una sentencia no de seleccion
        /// </summary>
        /// <param name="sSQL">Sentencia de ejecucion (insert, delete, update)</param>
        public void ExecuteSQL(string sSQL)
        {
            //DbCommand cmdDate = conn.CreateCommand();
            //cmdDate.CommandText = " SET DATEFORMAT dmy";
            //cmdDate.CommandType = CommandType.Text;
            //cmdDate.Transaction = transaction;
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            //MySqlCommand cmdDate = new MySqlCommand(" SET DATEFORMAT dmy", conn, transaction);
            //cmdDate.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
        }

        public void ExecuteSQLTransaction(string sSQL)
        {
            //DbCommand cmdDate = conn.CreateCommand();
            //cmdDate.CommandText = " SET DATEFORMAT dmy";
            //cmdDate.CommandType = CommandType.Text;
            //cmdDate.Transaction = transaction;
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            //MySqlCommand cmdDate = new MySqlCommand(" SET DATEFORMAT dmy", conn, transaction);
            //cmdDate.ExecuteNonQuery();
            transaction = conn.BeginTransaction();
            cmd.ExecuteNonQuery();
            transaction.Commit();
        }

        /// <summary>
        /// Ejecuta una sentencia con parametros
        /// </summary>
        /// <param name="sSQL">Sentencia a ejecutar (por ejemplo: sp_insertaclientes)</param>
        /// <param name="ParameterArray">Lista de parametros</param>
        public void ExecuteSQL(string sSQL, DbParameter[] ParameterArray)
        {
            //DbCommand cmdDate = conn.CreateCommand();
            //cmdDate.CommandText = " SET DATEFORMAT dmy";
            //cmdDate.CommandType = CommandType.Text;
            //cmdDate.Transaction = transaction;
            //cmdDate.ExecuteNonQuery();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            cmd.Parameters.AddRange(ParameterArray);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Ejecuta una sentencia con parametros
        /// </summary>
        /// <param name="sSQL">Sentencia a ejecutar (por ejemplo: sp_insertaclientes)</param>
        /// <param name="ParameterList">Lista de parametros</param>
        public void ExecuteSQL(string sSQL, List<DbParameter> ParameterList)
        {
            //DbCommand cmdDate = conn.CreateCommand();
            //cmdDate.CommandText = " SET DATEFORMAT dmy";
            //cmdDate.CommandType = CommandType.Text;
            //cmdDate.Transaction = transaction;
            //cmdDate.ExecuteNonQuery();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            foreach (DbParameter sqlparam in ParameterList)
            {
                cmd.Parameters.Add(sqlparam);
            }
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// ejecuta un procedimiento almacenado
        /// </summary>
        /// <param name="sSQL">nombre del procedimiento</param>
        /// <param name="ParameterList">parametros del procedimiento</param>
        public void ExecuteSQLProc(string sSQL, List<DbParameter> ParameterList)
        {
            //SqlCommand cmdDate = new SqlCommand( " SET DATEFORMAT dmy", conn, transaction);
            //cmdDate.ExecuteNonQuery();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = transaction;
            cmd.CommandTimeout = 300;
            foreach (DbParameter sqlparam in ParameterList)
            {
                cmd.Parameters.Add(sqlparam);
            }
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// ejecuta un procedimiento almacenado
        /// </summary>
        /// <param name="sSQL">nombre del procedimiento</param>
        /// <param name="ParameterArray">parametros del procedimiento</param>
        public void ExecuteSQLProc(string sSQL, DbParameter[] ParameterArray)
        {
            //SqlCommand cmdDate = new SqlCommand(" SET DATEFORMAT dmy", conn, transaction);
            //cmdDate.ExecuteNonQuery();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = transaction;

            cmd.Parameters.AddRange(ParameterArray);
            cmd.ExecuteNonQuery();
        }

        public int InsertIdentity(string sSQL)
        {
            //DbCommand cmdDate = conn.CreateCommand();
            //cmdDate.CommandText = " SET DATEFORMAT dmy";
            //cmdDate.CommandType = CommandType.Text;
            //cmdDate.Transaction = transaction;
            //cmdDate.ExecuteNonQuery();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            return System.Convert.ToInt32(cmd.ExecuteScalar());

        }

        public int InsertIdentity(string sSQL, DbParameter[] ParameterArray)
        {
            DbCommand cmdDate = conn.CreateCommand();
            cmdDate.CommandText = " SET DATEFORMAT dmy";
            cmdDate.CommandType = CommandType.Text;
            cmdDate.Transaction = transaction;
            cmdDate.ExecuteNonQuery();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            cmd.Parameters.AddRange(ParameterArray);
            return System.Convert.ToInt32(cmd.ExecuteScalar());

        }

        public int InsertIdentity(string sSQL, List<DbParameter> ParameterList)
        {
            //DbCommand cmdDate = conn.CreateCommand();
            //cmdDate.CommandText = " SET DATEFORMAT dmy";
            //cmdDate.CommandType = CommandType.Text;
            //cmdDate.Transaction = transaction;
            //cmdDate.ExecuteNonQuery();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            foreach (DbParameter sqlparam in ParameterList)
            {
                cmd.Parameters.Add(sqlparam);
            }
            return System.Convert.ToInt32(cmd.ExecuteScalar());
        }

        public int InsertIdentityProc(string sSQL, List<DbParameter> ParameterList)
        {
            //DbCommand cmdDate = conn.CreateCommand();
            //cmdDate.CommandText = " SET DATEFORMAT dmy";
            //cmdDate.CommandType = CommandType.Text;
            //cmdDate.Transaction = transaction;
            //cmdDate.ExecuteNonQuery();
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = transaction;
            foreach (DbParameter sqlparam in ParameterList)
            {
                cmd.Parameters.Add(sqlparam);
            }
            return System.Convert.ToInt32(cmd.ExecuteScalar());

        }

        /// <summary>
        /// Llena datos en una tabla
        /// </summary>
        /// <param name="sSQL">Sentencia de datos</param>
        /// <param name="sTable">Nombre de la tabla a retornar (puede ser un nombre generico)</param>
        /// <returns></returns>
        public DataSet FillData(string sSQL, string sTable)
        {
            DbCommand cmd = conn.CreateCommand();
            DbDataAdapter adapter = null;
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            if (tipoBase == TipoBaseEnum.SQLSERVER)
            {
                adapter = new SqlDataAdapter();

            }
            if (tipoBase == TipoBaseEnum.HANA)
            {
                adapter = new HanaDataAdapter();

            }
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds, sTable);
            return ds;
        }

        /// <summary>
        /// Llena datos en una tabla
        /// </summary>
        /// <param name="sSQL">Sentencia o procedimiento</param>
        /// <param name="sTable">nombre de la tabla a retornar</param>
        /// <param name="ParameterArray">Lista de parametros</param>
        /// <returns></returns>
        public DataSet FillData(string sSQL, string sTable, DbParameter[] ParameterArray)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            cmd.Parameters.AddRange(ParameterArray);
            // DbProviderFactory dbProvider = DbProviderFactories.GetFactory(strProvider);
            DbDataAdapter adapter = null;
            if (tipoBase == TipoBaseEnum.SQLSERVER)
            {
                adapter = new SqlDataAdapter();
            }
            if (tipoBase == TipoBaseEnum.HANA)
            {
                adapter = new HanaDataAdapter();
            };
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds, sTable);
            return ds;
        }

        /// <summary>
        /// Llena datos en una tabla
        /// </summary>
        /// <param name="sSQL">Sentencia o procedimiento</param>
        /// <param name="sTable">nombre de la tabla a retornar</param>
        /// <param name="ParameterList">Lista de parametros</param>
        /// <returns></returns>
        public DataSet FillData(string sSQL, string sTable, List<DbParameter> ParameterList)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.Text;
            cmd.Transaction = transaction;
            DbDataAdapter adapter = null;
            foreach (DbParameter sqlparam in ParameterList)
            {
                cmd.Parameters.Add(sqlparam);
            }
            if (tipoBase == TipoBaseEnum.SQLSERVER)
            {
                adapter = new SqlDataAdapter();
            }
            if (tipoBase == TipoBaseEnum.HANA)
            {
                adapter = new HanaDataAdapter();
            }
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds, sTable);
            return ds;
        }

        /// <summary>
        /// Llena datos en una tabla con la invocación de un procedimiento almacenado
        /// </summary>
        /// <param name="sSQL">Sentencia o procedimiento</param>
        /// <param name="sTable">nombre de la tabla a retornar</param>
        /// <param name="ParameterList">Lista de parametros</param>
        /// <returns></returns>
        public DataSet FillDataProc(string sSQL, string sTable, List<DbParameter> ParameterList)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sSQL;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = transaction;
            cmd.CommandTimeout = 300;
            foreach (DbParameter sqlparam in ParameterList)
            {
                cmd.Parameters.Add(sqlparam);
            }
            // DbProviderFactory dbProvider = DbProviderFactories.GetFactory(strProvider);
            DbDataAdapter adapter = null;
            if (tipoBase == TipoBaseEnum.SQLSERVER)
            {
                adapter = new SqlDataAdapter();
            }
            if (tipoBase == TipoBaseEnum.HANA)
            {
                adapter = new HanaDataAdapter();
            }
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds, sTable);
            return ds;
        }

        public static void getDBSettings(ref TipoBaseEnum tipoBase, ref string NombreBase)
        {
            string TipoBase = ConfigurationManager.AppSettings["TipoBase"];
            Enum.TryParse<TipoBaseEnum>(TipoBase.ToUpper(), out tipoBase);
            NombreBase = ConfigurationManager.AppSettings["NombreBase"];
        }
        #endregion

        #region utilitarios de valores de base de datos
        /// <summary>
        /// Utilitario para convertir un valor nulo en DBNull
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDBNull(object value)
        {
            if (null != value)
                return value;
            return DBNull.Value;
        }
        public static object ToNull(object value)
        {
            if (DBNull.Value.Equals(value))
                return null;
            return value;
        }
        /// <summary>
        /// Devuelve 0 si el valor del objeto entero es null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int intToNull(object value)
        {
            if (DBNull.Value.Equals(value) || value.ToString() == "")
                return 0;
            if (value.GetType() == typeof(Decimal))
                return decimal.ToInt16(((Decimal)value));
            if (value.GetType() == typeof(Boolean))
            {
                if ((Boolean)value) return 1;
                else return 0;
            }
            return int.Parse(value.ToString());
        }
        public static bool boolToNull(object value)
        {
            if (DBNull.Value.Equals(value))
                return false;
            return Convert.ToBoolean(value);
        }
        public static double doubleToNull(object value)
        {
            if (DBNull.Value.Equals(value))
                return 0.00;
            return double.Parse(value.ToString());
        }
        public static string strToNull(object value)
        {
            if (DBNull.Value.Equals(value))
                return "";
            return value.ToString();
        }
        public static string byteIToNull(object value)
        {
            if (DBNull.Value.Equals(value))
                return "";
            return value.ToString();
        }

        public static int boolToInt(object value)
        {
            if (value.ToString() == "True")
                return 1;
            else
                return 0;
        }

        public static bool intToBool(object value)
        {
            if (value.ToString() == "1")
                return true;
            else
                return false;
        }
        public static DateTime DateTimeToNull(object value)
        {

            string TipoBase = ConfigurationManager.AppSettings["TipoBase"];
            string DateText = value.ToString();
            if (DBNull.Value.Equals(value))
                return DateTime.MinValue;
            else
            {
                if (TipoBase == "SQLSERVER")
                {

                    return (DateTime)value;
                }
                if (TipoBase == "MySql")
                {
                    return (DateTime.ParseExact(DateText, "MM/dd/yyyy hh:mm:ss", CultureInfo.InvariantCulture));
                };

                return (DateTime)value;
            }
        }
        public static object DateTimeToNull(DateTime value)
        {
            if (value.Equals(DateTime.MinValue))
                return DBNull.Value;
            else
                return value;
        }

        //public static string SetParamValue(string strOrigen, string parametro, object paramvalue)
        //{
        //    string strValue = string.Empty;
        //    if (paramvalue == null)
        //        return strOrigen.Replace(parametro, "NULL");
        //    //Tomar tipo de dato
        //    switch (paramvalue.GetType().FullName)
        //    {
        //        case ("System.String"):
        //            strValue = "'" + paramvalue.ToString() + "'";
        //            break;
        //        case ("System.DateTime"):
        //            strValue = "'" + ((DateTime)(paramvalue)).ToString("yyyy/MM/dd HH:mm:ss") + "'";
        //            break;
        //        default:
        //            strValue = paramvalue.ToString();
        //            break;
        //    }
        //    return strOrigen.Replace(parametro, strValue);
        //}

        public static string SetParamValue(string strOrigen, string parametro, object paramvalue)
        {
            string TipoBase = ConfigurationManager.AppSettings["TipoBase"];
            string strValue = string.Empty;
            if (paramvalue == null)
                return strOrigen.Replace(parametro, "NULL");
            //Tomar tipo de dato
            switch (paramvalue.GetType().FullName)
            {
                case ("System.String"):
                    strValue = "'" + paramvalue.ToString() + "'";
                    break;
                case ("System.DateTime"):
                    //logica dependiendo de la base porque mysql hana y sql son diferentes
                    if (TipoBase == "SQLSERVER")
                    {
                        strValue = "'" + ((DateTime)(paramvalue)).ToString("yyyyMMdd HH:mm:ss") + "'";
                        break;
                    }
                    if (TipoBase == "hana")
                    {
                        strValue = "'" + ((DateTime)(paramvalue)).ToString("yyyy/MM/dd HH:mm:ss") + "'";
                        break;
                    };
                    if (String.Compare(strValue, DateTime.MinValue.ToString("yyyy/MM/dd HH:mm:ss")) < 0)
                        return strOrigen.Replace(parametro, "NULL");
                    break;
                case ("System.Boolean"):
                    //logica dependiendo de la base porque mysql hana y sql son diferentes
                    if (TipoBase == "SQLSERVER")
                    {
                        strValue = Convert.ToInt32(paramvalue).ToString();
                        break;
                    }
                    if (TipoBase == "hana")
                    {
                        strValue = paramvalue.ToString();
                        break;
                    };
                    break;
                case ("System.DBNull"):
                    return strOrigen.Replace(parametro, "NULL");
                //logica dependiendo de la base porque mysql hana y sql son diferentes
                default:
                    strValue = paramvalue.ToString();
                    break;
            }
            return strOrigen.Replace(parametro, strValue);
        }
        public static string SetParamValue(TipoBaseEnum tipoBase, string strOrigen, string parametro, object paramvalue)
        {
            string strValue = string.Empty;
            if (paramvalue == null)
                return strOrigen.Replace(parametro, "NULL");
            if (paramvalue== DBNull.Value)
                return strOrigen.Replace(parametro, "NULL");
            //Tomar tipo de dato
            switch (paramvalue.GetType().FullName)
            {
                case ("System.String"):
                    strValue = "'" + paramvalue.ToString() + "'";
                    break;
                case ("System.DateTime"):
                    if (tipoBase == TipoBaseEnum.HANA)
                    {
                        strValue = "'" + ((DateTime)(paramvalue)).ToString("yyyy/MM/dd HH:mm:ss") + "'";
                        if (String.Compare(strValue, "'" + DateTime.MinValue.ToString("yyyy/MM/dd HH:mm:ss") + "'") <= 0)
                            return strOrigen.Replace(parametro, "NULL");
                    }
                    if (tipoBase == TipoBaseEnum.SQLSERVER)
                    {
                        strValue = "'" + ((DateTime)(paramvalue)).ToString("yyyyMMdd HH:mm:ss") + "'";
                        if (String.Compare(strValue, "'" + DateTime.MinValue.ToString("yyyyMMdd HH:mm:ss") + "'") <= 0)
                            return strOrigen.Replace(parametro, "NULL");
                    }
                    else
                    {
                        strValue = "'" + ((DateTime)(paramvalue)).ToString("yyyy/MM/dd HH:mm:ss") + "'";
                        if (String.Compare(strValue, "'" + DateTime.MinValue.ToString("yyyy/MM/dd HH:mm:ss") + "'") <= 0)
                            return strOrigen.Replace(parametro, "NULL");
                    }
                    break;
                case ("System.Boolean"):
                    if (tipoBase == TipoBaseEnum.HANA)
                        strValue = ((Boolean)paramvalue).ToString();
                    if (tipoBase == TipoBaseEnum.SQLSERVER)
                    {
                        int testInt = (Boolean)paramvalue ? 1 : 0;
                        strValue = testInt.ToString();
                    }
                    break;
                default:
                    strValue = paramvalue.ToString();
                    break;
            }
            return strOrigen.Replace(parametro, strValue);
        }
        public static string SetValue(TipoBaseEnum tipoBase, object paramvalue)
        {
            string TipoBase = ConfigurationManager.AppSettings["TipoBase"];
            string strValue = string.Empty;
            if (paramvalue == null)
                return "NULL";
            //Tomar tipo de dato
            switch (paramvalue.GetType().FullName)
            {
                case ("System.String"):
                    strValue = "'" + paramvalue.ToString() + "'";
                    break;
                case ("System.DateTime"):
                    if (tipoBase == TipoBaseEnum.HANA)
                        strValue = "'" + ((DateTime)(paramvalue)).ToString("yyyy/MM/dd HH:mm:ss") + "'";
                    if (tipoBase == TipoBaseEnum.SQLSERVER)
                        strValue = "'" + ((DateTime)(paramvalue)).ToString("yyyyMMdd HH:mm:ss") + "'";
                    else
                    {
                        strValue = "'" + ((DateTime)(paramvalue)).ToString("yyyy/MM/dd HH:mm:ss") + "'";
                    }
                    break;
                default:
                    strValue = paramvalue.ToString();
                    break;
            }
            return strValue;
        }
        /// <summary>
        /// Envia el valor directo del parametro enviado
        /// </summary>
        /// <param name="strOrigen"></param>
        /// <param name="parametro"></param>
        /// <param name="paramvalueDirect"></param>
        /// <returns></returns>
        public static string SetParamValueDirect(string strOrigen, string parametro, string paramvalueDirect)
        {
            string strValue = string.Empty;
            strValue = paramvalueDirect;
            return strOrigen.Replace(parametro, strValue);
        }

        #endregion

    }

    public enum TipoBaseEnum
    {
        SQLSERVER,
        HANA,
        MYSQL,
        SQLLite
    }
    public enum TipoOperacionEnum
    {
        Select,
        Insert,
        Update,
        Delete
    }
}

