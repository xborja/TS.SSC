using System;
using System.Resources;
using TS.Core.DAO;

namespace TS.SSC.BL
{
    internal class ResourcesEntity: Resources
    {
        internal static string GetDBScript(string SQLScript, TipoBaseEnum tipoBase)
        {
            string strTipoBase = Enum.GetName(typeof(TipoBaseEnum), tipoBase);
            string strSQL = ResourceManager.GetString(SQLScript + "_" + strTipoBase);
            if (strSQL == null || strSQL == "")
            {
                strSQL = ResourceManager.GetString(SQLScript);
                if (strSQL == null || strSQL == "")
                    strSQL = "";
            }

            return strSQL;
        }
    }
}
