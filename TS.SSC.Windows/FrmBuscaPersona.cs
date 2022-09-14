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
    public partial class FrmBuscaPersona : Form
    {
        private List<Persona> PersonaList = new List<Persona>();
        public static Persona PersonaResultado;
     
        #region Controller
        private void CargarPersonas()
        {
            PersonaList = PersonaBL.ToList(1);
            dgPersonas.Rows.Clear();
            foreach (var item in PersonaList)
            {
                dgPersonas.Rows.Add(item.id, item.Cedula, item.Nombre);
            }
            dgPersonas.Refresh();

        }

        private void CargarPersonas(List<Persona> PersonaListParam)
        {
            dgPersonas.Rows.Clear();
            foreach (var item in PersonaListParam)
            {
                dgPersonas.Rows.Add(item.id, item.Cedula, item.Nombre);
            }
            dgPersonas.Refresh();
        }
        
        #endregion

        public FrmBuscaPersona()
        {
            InitializeComponent();
            CargarPersonas();
        }
        private void FrmBuscaPersona_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dgPersonas.Rows.Count > 1)
            {
                var idPersona = dgPersonas.SelectedRows[0].Cells[0].Value;
                PersonaResultado = PersonaList.Where(x => x.id == (int)idPersona).FirstOrDefault();
            }

            this.Close();
            this.Dispose();
        }

        private void txtSubTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            BuscaPersona(txtSubTotal.Text);
        }
        private void BuscaPersona(string nombre)
        {
            var ListPersonaResultado = PersonaList.Where(x => x.Nombre.ToUpper().Contains(nombre.ToUpper())).ToList();
            CargarPersonas(ListPersonaResultado);
        }

        private void dgPersonas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                var idPersona = senderGrid.Rows[e.RowIndex].Cells[0].Value;
                PersonaResultado = PersonaList.Where(x => x.id == (int)idPersona).FirstOrDefault();
                this.Close();
                this.Dispose();

            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            PersonaResultado = new Persona();
            this.Close();
            this.Dispose();
        }


    }
}
