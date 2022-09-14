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
using TS.SSC.Entity;

namespace TS.SSC.Windows
{
    public partial class FrmBusqueda : Form
    {
        public static int idEntidad = 0;
        private List<Persona> PersonaList = new List<Persona>();
        public static Persona PersonaResultado;
        public EntidadBusquedaEnum entidad { get; set; }
        DataTable dtListado;
        #region Controller
        void CargaListado()
        {
            switch (entidad)
            {
                case EntidadBusquedaEnum.Usuario:
                    CargaUsuario();
                    break;
                case EntidadBusquedaEnum.Persona:
                    CargaPersona();
                    break;
                case EntidadBusquedaEnum.Sacramento:
                    CargaSacramentos();
                    break;
                case EntidadBusquedaEnum.RegistroSacramento:
                    CargaRegistroSacramentos();
                    break;
                default:
                    break;
            }
            dgResultado.Refresh();
            dgResultado.Columns["Nombre"].Width = 250;
        }

        void CargaUsuario()
        {
            this.Text = "Busqueda de Usuarios";
            List<Usuario> listadoOrig = UsuarioBL.ToList(1);
            var listado = listadoOrig.Select(x => new { Id = x.id, User = x.userName, Nombre = x.nombreUsuario }).ToList();
            dtListado = listado.ToDataTableOfStrings();
            dgResultado.DataSource = dtListado;
        }

        void CargaPersona()
        {
            this.Text = "Busqueda de Personas";
            List<Persona> listadoOrig = PersonaBL.ToList(1);
            var listado = listadoOrig.Select(x => new { Id = x.id, Cedula_RUC = x.Cedula, Nombre = x.Nombre }).ToList();
            dtListado = listado.ToDataTableOfStrings();
            dgResultado.DataSource = dtListado;

        }
        void CargaSacramentos()
        {
            this.Text = "Busqueda de Sacramentos";
            List<Sacramento> listadoOrig = SacramentoBL.ToList();
            var listado = listadoOrig.Select(x => new { Id = x.id, Nombre = x.nombreSacramento }).ToList();
            dtListado = listado.ToDataTableOfStrings();
            dgResultado.DataSource = dtListado;

        }

        private void CargaRegistroSacramentos()
        {
            this.Text = "Busqueda de Registros de Sacramentos";
            List<RegistroSacramento> listadoOrig = RegistroSacramentoBL.ToList(1);
            var listado = listadoOrig.Select(x => new { Id = x.id, NSacramento = x.Sacramento, Nombre = x.Persona, Libro = x.libro, Folio = x.folio, Partida = x.partida }).ToList();
            dtListado = listado.ToDataTableOfStrings();
            dgResultado.DataSource = dtListado;
        }

        void FiltraGridView()
        {
            StringBuilder filter = new StringBuilder();
            foreach (DataGridViewColumn column in dgResultado.Columns)
            {
                if (filter.ToString() != "")
                    filter.Append(" OR ");
                filter.Append(column.Name + " like '%" + txtTextoBusqueda.Text + "%'");
            }
            DataTable dtResultado = dtListado.Clone();
            foreach (DataRow drtableOld in dtListado.Rows)
            {
                dtResultado.ImportRow(drtableOld);
            }
            if (txtTextoBusqueda.Text.Trim() != "")
                dtResultado.DefaultView.RowFilter = filter.ToString();
            dgResultado.DataSource = dtResultado;
            dgResultado.Refresh();
            //dgResultado.Columns["Nombre"].Width = 150;

        }
        #endregion
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgResultado.Rows.Count > 1)
            {
                idEntidad = int.Parse(dgResultado.SelectedRows[0].Cells[0].Value.ToString());
            }
            else
            { idEntidad = 0; }
            this.Close();
            this.Dispose();

        }
        private void txtTextoBusqueda_TextChanged(object sender, EventArgs e)
        {
            FiltraGridView();
        }
       
        public FrmBusqueda()
        {
            InitializeComponent();
        }
        private void FrmBusqueda_Load(object sender, EventArgs e)
        {
            CargaListado();
        }
    }
}
