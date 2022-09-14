using TS.SSC.Entity;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using TS.SSC.Portal.ViewModels;
using TS.SSC.BL;

namespace TS.SSC.Portal.Services
{
    public static class PDFService
    {
        public static byte[] ExportLiquidacionRolToPDFStream(int ProformaID, DataSet dsReporte)
        {
            //string Estado = dsReporte.Tables[0].Rows[0]["ProfEstado"] + "";
            ////string Fecha = ((DateTime)dsReporte.Tables[0].Rows[0]["ProfFecha"]).ToString("yyyy/MM/dd");
            //string Fecha = ((DateTime)dsReporte.Tables[0].Rows[0]["ProfFecha"]).ToString("MMMM dd yyyy", new CultureInfo("es-ES"));
            string NombreFinal = "Proforma_" + ProformaID.ToString() + ".pdf";
            ReportDataSource rds;
            string ReportName = "rptLiquidacionRol";
            Warning[] warnings;
            ReportViewer rvReporte = new ReportViewer();
            for (int i = 0; i < dsReporte.Tables.Count; i++)
            {
                rds = new ReportDataSource(dsReporte.Tables[i].TableName, dsReporte.Tables[i]);
                rvReporte.LocalReport.DataSources.Add(rds);
            }
            rvReporte.LocalReport.ReportPath = "Reportes/" + ReportName + ".rdlc";


            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            byte[] bytes = rvReporte.LocalReport.Render(
               "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            //string filename = Path.Combine(Path.GetTempPath(), NombreFinal);

            return bytes;
        }

        public static byte[] ExportRegistroAPDFStream(List<printSacramentoBL> printactual)
        {
            string NombreFinal = "Registro_" + printactual.Select(x=>x.idRegistro).FirstOrDefault().ToString() + ".pdf";
            ReportDataSource rds;
            string ReportName = "printRegistroSacramento";
            Warning[] warnings;
            ReportViewer rvReporte = new ReportViewer();

            rds = new ReportDataSource("DSReporte", printactual);
            rvReporte.LocalReport.DataSources.Add(rds);
            rvReporte.LocalReport.ReportPath = "Reportes/" + ReportName + ".rdlc";

            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            byte[] bytes = rvReporte.LocalReport.Render(
               "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);
            //string filename = Path.Combine(Path.GetTempPath(), NombreFinal);

            return bytes;
        }
        public static byte[] ExportRegistroMembreteAPDFStream(List<printSacramentoBL> printactual)
        {
            string NombreFinal = "Registro_" + printactual.Select(x => x.idRegistro).FirstOrDefault().ToString() + ".pdf";
            ReportDataSource rds;
            string ReportName = "printRegistroSacramentoMembrete";
            Warning[] warnings;
            ReportViewer rvReporte = new ReportViewer();

            rds = new ReportDataSource("DSReporte", printactual);
            rvReporte.LocalReport.DataSources.Add(rds);
            rvReporte.LocalReport.ReportPath = "Reportes/" + ReportName + ".rdlc";

            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            byte[] bytes = rvReporte.LocalReport.Render(
               "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);
            //string filename = Path.Combine(Path.GetTempPath(), NombreFinal);

            return bytes;
        }

    }
}