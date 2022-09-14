using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TS.SSC.BL;

namespace TS.SSC.Windows
{
    public partial class FrmReporte : Form
    {
        public FrmReporte()
        {
            InitializeComponent();
        }
        public void renderReportSacramento( int idElemento)
        {
            List<printSacramentoBL> datasource = printSacramentoBL.ToList(1, idElemento);
            rvReporte.ProcessingMode = ProcessingMode.Local;
            LocalReport localreport = rvReporte.LocalReport;
            localreport.ReportPath = Application.StartupPath + "/Reportes/printRegistroSacramento.rdlc";
            ReportDataSource rds = new ReportDataSource("DSReporte", datasource);
            localreport.DataSources.Add(rds);
            rvReporte.RefreshReport();

        }

        public void renderReportSacramentoMembrete(int idElemento)
        {
            List<printSacramentoBL> datasource = printSacramentoBL.ToList(1, idElemento);
            rvReporte.ProcessingMode = ProcessingMode.Local;
            LocalReport localreport = rvReporte.LocalReport;
            localreport.ReportPath = Application.StartupPath + "/Reportes/printRegistroSacramentoMembrete.rdlc";
            ReportDataSource rds = new ReportDataSource("DSReporte", datasource);
            localreport.DataSources.Add(rds);
            rvReporte.RefreshReport();

        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            this.rvReporte.RefreshReport();
        }
    }
}
