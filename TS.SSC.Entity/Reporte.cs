using System;
using System.Collections.Generic;
using System.Data;
using TS.Core.DAO;
using System.Data.SqlClient;
using System.Data.Common;

namespace TS.SSC.Entity
{
    public class Reporte
    {
        public static DataSet dsResumenPago(int idDepartamento, ref string MSGError)
        {
            DataSet ds = new DataSet();
            DataBase db = new DataBase();
            List<DbParameter> Parametros = new List<DbParameter>();
            string strSQL = "SP_Rpt_ResumenPagoPeriodo";
            MSGError = "";
            try
            {

                Parametros.Add(new SqlParameter("@idPeriodoOperacion", idDepartamento));
                db.openConnection();

                ds = db.FillDataProc(strSQL, "DSReporte", Parametros);
            }
            catch (Exception ex)
            {
                MSGError = ex.Message;
                db.errorTransaction();
                return new DataSet(); ;
            }
            finally
            {
                db.closeConnection();
            }
            return ds;
        }
      

    }
}
