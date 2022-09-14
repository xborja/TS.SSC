using Microsoft.Reporting.WebForms;
using System;
using Microsoft.AspNet.Identity;
using System.Data;
using TS.SSC.Entity;

namespace TS.SSC.Portal.Reportes
{
    public partial class frmReporte : System.Web.UI.Page
    {
        public DataSet dsReporte;
        public string ReportName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["DSReporte"] == null || Session["TipoReporte"] == null)
                    return;
                dsReporte = (DataSet)Session["DSReporte"];
                string TipoReporte = Session["TipoReporte"].ToString();
                if (TipoReporte == "ResumenPago")
                {
                    ReportName = "rptResumenPago.rdlc";

                }
                if (TipoReporte == "RolDiario")
                {
                    ReportName = "rptRolDiario.rdlc";

                }
                if (TipoReporte == "RolDiarioADM")
                {
                    ReportName = "rptRolDiarioADM.rdlc";

                }

                if (TipoReporte == "RolIndividual")
                {
                    ReportName = "rptRolIndividual.rdlc";

                }

                renderReport();
                Session["DsReporte"] = null;
                Session["TipoReporte"] = null;
            }
        }
        public void renderReport()
        {
            ReportDataSource rds;
            rvReporte.LocalReport.DataSources.Clear();
            //dsReporte = ReporteDS.GetRequerimientoServicio(17);
            for (int i = 0; i < dsReporte.Tables.Count; i++)
            {
                rds = new ReportDataSource(dsReporte.Tables[i].TableName, dsReporte.Tables[i]);
                rvReporte.LocalReport.DataSources.Add(rds);
            }
            rvReporte.LocalReport.ReportPath = "Reportes/" + ReportName;
            rvReporte.LocalReport.Refresh();

        }

    }
}