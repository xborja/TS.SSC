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
    public partial class FrmLogin : Form
    {
        private bool Login()
        {
            Usuario user = UsuarioBL.GetByUserName(txtUserName.Text, txtPassword.Text);
            //buscar el usuario y la contraseña en la base para acceder al  sistema
            if (user.id == 0) return false;
            clsUtils.UsuarioSesion = user;
            MDIPrincipal principalform = (MDIPrincipal)this.ParentForm;
            principalform.activacionMenu(true);
           // principalform.verificarJornada();
            return true;
        }
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Login())
            {
                //MDIPrincipal frmprincipal = new MDIPrincipal();
                //frmprincipal.Show();

                this.Close();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
