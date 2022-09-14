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
    public partial class FrmPersona : Form
    {
        ModoPantallaEnum modoPantalla = ModoPantallaEnum.Navegacion;
        Persona itemActual = new Persona();
        List<Persona> ItemList = new List<Persona>();
        #region Controller
        private void EnceraDatos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtLegalId.Text = "";
            txtLugarNacimiento.Text = "";
            dtFechaNacimiento.Value = DateTime.Today;
            txtLugarBautismo.Text = "";
            dtFechaBautismo.Value = DateTime.Today;
            txtNombrePadre.Text = "";
            txtNombreMadre.Text = "";
        }
        private void CargarItems()
        {
            ItemList = PersonaBL.ToList(1);
            ItemList = ItemList.OrderBy(x => x.id).ToList();
        }
        private void navegaItems(TipoNavegacionEnum tipoNavegacion)
        {
            Persona itemTemp;
            if (ItemList.Count==0)
            {
                return;
            }
            switch (tipoNavegacion)
            {
                case TipoNavegacionEnum.Primero:
                    itemActual = ItemList.First();
                    MuestraItem();
                    break;
                case TipoNavegacionEnum.Anterior:
                    if (itemActual != ItemList.First())
                    {
                        itemTemp = ItemList.Where(x => x.id < itemActual.id).Last();
                        itemActual = itemTemp;
                        MuestraItem();

                    }
                    break;
                case TipoNavegacionEnum.Siguiente:
                    if (itemActual != ItemList.Last())
                    {
                        itemTemp = ItemList.Where(x => x.id > itemActual.id).First();
                        itemActual = itemTemp;
                        MuestraItem();

                    }

                    break;
                case TipoNavegacionEnum.Ultimo:
                    itemActual = ItemList.Last();
                    MuestraItem();
                    break;
                default:
                    break;
            }
        }
        private bool ValidaDatos()
        {
            bool validacion = true;
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado el nombre, por favor validar");
                validacion = false;
            }

            else if (txtLugarNacimiento.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado la cédula o el RUC, por favor validar");
                validacion = false;
            }
            else if (txtLugarBautismo.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado la cédula o el RUC, por favor validar");
                validacion = false;
            }


            return validacion;
        }
        private void MuestraItem()
        {
            txtCodigo.Text = itemActual.id.ToString();
            txtNombre.Text = itemActual.Nombre;
            txtLegalId.Text = itemActual.Cedula;
            txtLugarNacimiento.Text = itemActual.LugarNacimiento;
            dtFechaNacimiento.Value = itemActual.FechaNacimiento;
            txtLugarBautismo.Text = itemActual.LugarBautismo;
            dtFechaBautismo.Value = itemActual.FechaBautismo;
            txtNombrePadre.Text = itemActual.NombrePadre;
            txtNombreMadre.Text = itemActual.NombreMadre;
        }
        private void GrabaItem()
        {

            Persona item = new Persona();
            item.idParroquia = 1;
            item.Nombre = txtNombre.Text;
            item.Cedula = txtLegalId.Text;
            item.LugarNacimiento = txtLugarNacimiento.Text;
            item.FechaNacimiento = dtFechaNacimiento.Value;
            item.LugarBautismo = txtLugarBautismo.Text;
            item.FechaBautismo = dtFechaBautismo.Value;
            item.NombrePadre = txtNombrePadre.Text;
            item.NombreMadre = txtNombreMadre.Text; int resultado;
            if (txtCodigo.Text == "")
            {
                item.UsuarioCrea = clsUtils.UsuarioSesion.userName;
                resultado = PersonaBL.Create(item);
            }
            else
            {
                item.UsuarioModif = clsUtils.UsuarioSesion.userName;
                item.id = itemActual.id;
                resultado = PersonaBL.Update(item);
            }
            if (resultado == 1)
            {
                MessageBox.Show("Registro Guardado correctamente");
                IniciaPantalla(item);
            }
            else
            {
                MessageBox.Show("error");
            }
        }
        void ActivaBotonera()
        {
            switch (modoPantalla)
            {
                case ModoPantallaEnum.Navegacion:
                    btnBuscar.Enabled = true;
                    btnFirst.Enabled = true;
                    btnPrev.Enabled = true;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                    btnNuevo.Enabled = true;

                    break;
                case ModoPantallaEnum.Edicion:
                    btnBuscar.Enabled = false;
                    btnFirst.Enabled = false;
                    btnPrev.Enabled = false;
                    btnNext.Enabled = false;
                    btnLast.Enabled = false;
                    btnNuevo.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        private void IniciaPantalla(Persona item)
        {
            modoPantalla = ModoPantallaEnum.Navegacion;
            CargarItems();
            itemActual = item;
            MuestraItem();
            ActivaBotonera();
        }
        private void IniciaPantalla()
        {
            //EnceraDatos();
            modoPantalla = ModoPantallaEnum.Navegacion;
            CargarItems();
            MuestraItem();
            ActivaBotonera();
        }
        private void CerrarVentana(ref bool cerrarApp)
        {
            cerrarApp = false;
            DialogResult resultado;
            resultado = MessageBox.Show("Salir de la pantalla?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
        private void CancelarEdicion()
        {
            DialogResult resultado;
            resultado = MessageBox.Show("Cancelar edición de registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                IniciaPantalla();

            }

        }

        #endregion


        public FrmPersona()
        {
            InitializeComponent();
        }


        private void FrmPersona_Load(object sender, EventArgs e)
        {
            CargarItems();
            navegaItems(TipoNavegacionEnum.Primero);
        }

        private void FrmPersona_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool cierraAplicacion = false;
            CerrarVentana(ref cierraAplicacion);
            if (!cierraAplicacion)
            {
                e.Cancel = true;
            }
            else
            { this.Dispose(); }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            navegaItems(TipoNavegacionEnum.Primero);
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            navegaItems(TipoNavegacionEnum.Anterior);

        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            navegaItems(TipoNavegacionEnum.Siguiente);
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            navegaItems(TipoNavegacionEnum.Ultimo);
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FrmBusqueda form = new FrmBusqueda();
            form.entidad = EntidadBusquedaEnum.RegistroSacramento;
            form.ShowDialog();
            if (FrmBusqueda.idEntidad != 0)
            {
                itemActual = ItemList.Where(x => x.id == FrmBusqueda.idEntidad).FirstOrDefault();
                MuestraItem();
                FrmBusqueda.idEntidad = 0;
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            modoPantalla = ModoPantallaEnum.Edicion;
            ActivaBotonera();
            EnceraDatos();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
                GrabaItem();

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            switch (modoPantalla)
            {
                case ModoPantallaEnum.Navegacion:
                    this.Close();
                    break;
                case ModoPantallaEnum.Edicion:
                    CancelarEdicion();
                    break;
                default:
                    break;
            }
        }

    }
}
