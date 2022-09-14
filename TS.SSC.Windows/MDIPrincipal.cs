using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TS.SSC.Windows
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;

        #region Funciones
        public void activacionMenu(bool estadoActivacion)
        {
            this.menuStrip.Enabled = estadoActivacion;
        }

        public void cerrarSesion()
        {
            foreach (Form pantalla in this.MdiChildren)
            {
                if (pantalla.Name != "MDIPrincipal")
                {
                    pantalla.Close();
                    pantalla.Dispose();
                }

            }
            activacionMenu(false);
            FrmLogin frmItem = new FrmLogin();
            frmItem.MdiParent = this;
            frmItem.Show();

        }
        private void CerrarAplicacion(ref bool cerrarApp)
        {
            cerrarApp = false;
            DialogResult resultado;
            resultado = MessageBox.Show("Salir de la aplicación?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                cerrarApp = true;
                //Application.Exit();

            }
            else
            {
                cerrarApp = false;
            }
        }
        #endregion

        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (!item.Focused)
                {
                    item.Visible = false;
                    item.Dispose();
                }
            }
        }

        private void cerrarTodosLosFormulariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form item in this.MdiChildren)
            {
                if (!item.Focused)
                {
                    item.Visible = false;
                    item.Dispose();
                }
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cerrarSesion();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MDIPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool cierraAplicacion = false;
            CerrarAplicacion(ref cierraAplicacion);
            if (!cierraAplicacion)
            {
                e.Cancel = true;
            }
        }

        private void MDIPrincipal_Shown(object sender, EventArgs e)
        {
            activacionMenu(false);
            FrmLogin form = new FrmLogin();
            form.MdiParent = this;
            form.Show();
        }

        private void cerrarFormularioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form item in this.MdiChildren)
            {
                if (item.Name == "FrmPersona")
                {
                    abierto = true;
                    item.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                FrmPersona form = new FrmPersona();
                form.MdiParent = this;
                form.Show();
            }

        }

        private void sacramentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form item in this.MdiChildren)
            {
                if (item.Name == "FrmPersona")
                {
                    abierto = true;
                    item.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                FrmPersona form = new FrmPersona();
                form.MdiParent = this;
                form.Show();
            }

        }

        private void registroSacramentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool abierto = false;
            foreach (Form item in this.MdiChildren)
            {
                if (item.Name == "FrmRegistroSacramento")
                {
                    abierto = true;
                    item.Focus();
                    break;
                }
            }
            if (abierto == false)
            {
                FrmRegistroSacramento form = new FrmRegistroSacramento();
                form.MdiParent = this;
                form.Show();
            }

        }

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
     
        }
    }
}
