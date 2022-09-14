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
    public partial class FrmRegistroSacramento : Form
    {
        ModoPantallaEnum modoPantalla = ModoPantallaEnum.Navegacion;
        private Persona personaSacramento { get; set; }
        private List<Sacramento> SacramentoList { get; set; }
        private RegistroSacramento registroActual { get; set; }
        private List<Persona> PersonaList { get; set; }
        private List<RegistroSacramento> RegistroList { get; set; }

        #region Controllers
        private void EnceraPersona()
        {
            try
            {
                PersonaList = PersonaBL.ToList(1);
                CargarListados();
                personaSacramento = new Persona();
                CargarPersonaNueva();

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void EnceraRegSacramento()
        {
            try
            {
                RegistroList = new List<RegistroSacramento>();
                //RegistroList = RegistroSacramentoBL.ToList(1);
                //registroActual = new RegistroSacramento();
                //CargarRegistro();

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void EnceraDatos()
        {
            registroActual = null;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtLegalId.Text = "";
            txtLugarNacimiento.Text = "";
            dtFechaNacimiento.Text = "";
            txtLugarBautismo.Text = "";
            dtFechaBautismo.Text = "";
            txtNombrePadre.Text = "";
            txtNombreMadre.Text = "";
            cboSacramento.SelectedIndex = -1;
            dtFechaSacramento.Text = "";
            txtLibro.Text = "";
            txtFolio.Text = "";
            txtPartida.Text = "";
            txtPadrino.Text = "";
            txtMadrina.Text = "";
            txtMinistro.Text = "";
            txtDaFe.Text = "";
        }

        private void CargarListados()
        {
            try
            {
                PersonaList = PersonaBL.ToList(1);
                RegistroList = RegistroSacramentoBL.ToList(1);
                SacramentoList = SacramentoBL.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GuardarPersona()
        {

            int resultado;
            if (personaSacramento.id == 0)
            {
                personaSacramento.idParroquia = 1;
                personaSacramento.Nombre = txtNombre.Text;
                personaSacramento.Cedula = txtLegalId.Text;
                personaSacramento.LugarNacimiento = txtLugarNacimiento.Text;
                personaSacramento.FechaNacimiento = dtFechaNacimiento.Value;
                personaSacramento.LugarBautismo = txtLugarBautismo.Text;
                personaSacramento.FechaBautismo = dtFechaBautismo.Value;
                personaSacramento.NombrePadre = txtNombrePadre.Text;
                personaSacramento.NombreMadre = txtNombreMadre.Text;
                personaSacramento.UsuarioCrea = clsUtils.UsuarioSesion.userName;
                try
                {
                    resultado = PersonaBL.Create(personaSacramento);
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
        private void GuardarRegistro(object sender, EventArgs e)
        {
            RegistroSacramento item = new RegistroSacramento();
            //Antes de guardar la venta, debemos guardar el cliente si es nuevo
            EnceraRegSacramento();
            GuardarPersona();
            item = new RegistroSacramento();
            item.idPersona = personaSacramento.id;
            item.idParroquia = 1;
            item.idSacramento = int.Parse(cboSacramento.SelectedValue.ToString());
            item.fechaRegistro = dtFechaSacramento.Value;
            item.libro = int.Parse(txtLibro.Text);
            item.folio = int.Parse(txtFolio.Text);
            item.partida = txtPartida.Text;
            item.nombrePadrino = txtPadrino.Text;
            item.nombreMadrina = txtMadrina.Text;
            item.nombreMinistro = txtMinistro.Text;
            item.nombreDaFe = txtDaFe.Text;
            //registroActual = new RegistroSacramento();
            if (registroActual == null || registroActual.id == 0)
            {
                item.UsuarioCrea = clsUtils.UsuarioSesion.userName;
                //cargar los datos con los campos correspondientes.
                RegistroSacramentoBL.Create(item);

            }
            else
            {
                item.id = registroActual.id;
                item.UsuarioModif = clsUtils.UsuarioSesion.userName;
                //cargar los datos con los campos correspondientes.
                RegistroSacramentoBL.Update(item);

            }
            MessageBox.Show("Registro Sacramento guardado correctamente");
            registroActual = item;
            IniciaPantalla(item);

        }
        private void ImprimeRegistro()
        {
            FrmReporte form = new FrmReporte();
            form.Show();
            form.renderReportSacramento(registroActual.id);
        }
        private void ConsultarPersona()
        {
            personaSacramento = PersonaList.Find(x => x.id.ToString().Contains(txtCodigo.Text.Trim()));
            if (personaSacramento != null)
            {
                CargarPersona();

            }
            else
            {
                personaSacramento = new Persona();
                txtNombre.Text = personaSacramento.Nombre;
                txtLegalId.Text = personaSacramento.Cedula;
                txtLugarNacimiento.Text = personaSacramento.LugarNacimiento;
                txtLugarBautismo.Text = personaSacramento.LugarBautismo;
                dtFechaNacimiento.Value = personaSacramento.FechaNacimiento;
                dtFechaBautismo.Value = personaSacramento.FechaBautismo;
                txtNombrePadre.Text = personaSacramento.NombrePadre;
                txtNombreMadre.Text = personaSacramento.NombreMadre;
            }

        }
        public void CargarPersonaBusqueda()
        {

            txtCodigo.Text = personaSacramento.id.ToString();
            txtNombre.Text = personaSacramento.Nombre;
            txtLegalId.Text = personaSacramento.Cedula;
            txtLugarNacimiento.Text = personaSacramento.LugarNacimiento;
            dtFechaNacimiento.Value = personaSacramento.FechaNacimiento;
            txtLugarBautismo.Text = personaSacramento.LugarBautismo;
            dtFechaBautismo.Value = personaSacramento.FechaBautismo;
            txtNombrePadre.Text = personaSacramento.NombrePadre;
            txtNombreMadre.Text = personaSacramento.NombreMadre;
        }
        public void CargarPersonaNueva()
        {

            txtCodigo.Text = personaSacramento.id.ToString();
            txtNombre.Text = personaSacramento.Nombre;
            txtLegalId.Text = personaSacramento.Cedula;
            txtLugarNacimiento.Text = personaSacramento.LugarNacimiento;
            dtFechaNacimiento.Value = DateTime.Today;
            txtLugarBautismo.Text = personaSacramento.LugarBautismo;
            dtFechaBautismo.Value = DateTime.Today;
            txtNombrePadre.Text = personaSacramento.NombrePadre;
            txtNombreMadre.Text = personaSacramento.NombreMadre;
        }
        public void CargarPersona()
        {
            personaSacramento = PersonaBL.GetByID(registroActual.idParroquia, registroActual.idPersona);
            if (personaSacramento != null)
            {
                txtCodigo.Text = personaSacramento.id.ToString();
                txtNombre.Text = personaSacramento.Nombre;
                txtLegalId.Text = personaSacramento.Cedula;
                txtLugarNacimiento.Text = personaSacramento.LugarNacimiento;
                dtFechaNacimiento.Value = personaSacramento.FechaNacimiento;
                txtLugarBautismo.Text = personaSacramento.LugarBautismo;
                dtFechaBautismo.Value = personaSacramento.FechaBautismo;
                txtNombrePadre.Text = personaSacramento.NombrePadre;
                txtNombreMadre.Text = personaSacramento.NombreMadre;
            }
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

        private void MuestraItem()
        {
            CargarPersona();
            cboSacramento.SelectedValue = registroActual.idSacramento;
            dtFechaSacramento.Value = registroActual.fechaRegistro;
            txtLibro.Text = registroActual.libro.ToString();
            txtFolio.Text = registroActual.folio.ToString();
            txtPartida.Text = registroActual.partida;
            txtPadrino.Text = registroActual.nombrePadrino;
            txtMadrina.Text = registroActual.nombreMadrina;
            txtMinistro.Text = registroActual.nombreMinistro;
            txtDaFe.Text = registroActual.nombreDaFe;
        }

        #endregion


        public FrmRegistroSacramento()
        {
            InitializeComponent();
            CargarListados();
        }
        private void FrmRegistroSacramento_Load(object sender, EventArgs e)
        {
            //EnceraRegSacramento();
            //EnceraPersona();
            //registroActual = null;
            int idparroquia = 1;
            Parroquia itemP = ParroquiaBL.GetByID(idparroquia);
            List<RegistroSacramento> listRegistroSacramento = RegistroSacramentoBL.ToList(itemP.id);

            List<Sacramento> ListaSacramentos = SacramentoBL.ToList();
            cboSacramento.DataSource = ListaSacramentos;
            cboSacramento.DisplayMember = "nombreSacramento";
            cboSacramento.ValueMember = "id";

            CargarItems();
            navegaItems(TipoNavegacionEnum.Primero);

        }
        private void CargarItems()
        {
            RegistroList = RegistroSacramentoBL.ToList(1);
            RegistroList = RegistroList.OrderBy(x => x.id).ToList();

        }
        private void navegaItems(TipoNavegacionEnum tipoNavegacion)
        {
            RegistroSacramento RegistroSacramentoTemp;
            switch (tipoNavegacion)
            {
                case TipoNavegacionEnum.Primero:
                    registroActual = RegistroList.First();
                    MuestraItem();
                    break;
                case TipoNavegacionEnum.Anterior:
                    if (registroActual.id != RegistroList.First().id)
                    {
                        RegistroSacramentoTemp = RegistroList.Where(x => x.id < registroActual.id).Last();
                        registroActual = RegistroSacramentoTemp;
                        MuestraItem();

                    }
                    break;
                case TipoNavegacionEnum.Siguiente:
                    if (registroActual.id != RegistroList.Last().id)
                    {
                        RegistroSacramentoTemp = RegistroList.Where(x => x.id > registroActual.id).First();
                        registroActual = RegistroSacramentoTemp;
                        MuestraItem();

                    }

                    break;
                case TipoNavegacionEnum.Ultimo:
                    registroActual = RegistroList.Last();
                    MuestraItem();
                    break;
                default:
                    break;
            }
        }

        private void FrmRegistroSacramento_FormClosing(object sender, FormClosingEventArgs e)
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


        void ActivaBotonera()
        {
            switch (modoPantalla)
            {
                case ModoPantallaEnum.Navegacion:
                    btnImprimir.Enabled = true;
                    btnBuscar.Enabled = true;
                    btnFirst.Enabled = true;
                    btnPrev.Enabled = true;
                    btnNext.Enabled = true;
                    btnLast.Enabled = true;
                    btnNuevo.Enabled = true;

                    break;
                case ModoPantallaEnum.Edicion:
                    btnImprimir.Enabled = false;
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
        private bool ValidaDatos()
        {
            bool validacion = true;
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado el nombre, por favor validar");
                validacion = false;
            }

            else if (txtLegalId.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado el RUC, por favor validar");
                validacion = false;
            }
            else if (txtLugarNacimiento.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado el Lugar de nacimiento, por favor validar");
                validacion = false;
            }
            else if (dtFechaNacimiento.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado la fecha de nacimiento, por favor validar");
                validacion = false;
            }
            else if (txtLugarBautismo.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado el lugar de bautismo, por favor validar");
                validacion = false;
            }
            else if (dtFechaBautismo.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado la fecha de bautismo, por favor validar");
                validacion = false;
            }
            else if (txtNombrePadre.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado nombre de padre, por favor validar");
                validacion = false;
            }
            else if (txtNombreMadre.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado nombre de madre, por favor validar");
                validacion = false;
            }
            else if (cboSacramento.SelectedIndex == -1)
            {
                MessageBox.Show("No ha seleccionado el Sacramento, por favor validar");
                validacion = false;
            }
            else if (dtFechaSacramento.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado fecha, por favor validar");
                validacion = false;
            }
            else if (txtLibro.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado libro, por favor validar");
                validacion = false;
            }

            else if (cboSacramento.SelectedIndex == -1)
            {
                MessageBox.Show("No ha ingresado el sacramento, por favor validar");
                validacion = false;
            }


            else if (txtFolio.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado folio, por favor validar");
                validacion = false;
            }
            else if (txtPartida.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado partida, por favor validar");
                validacion = false;
            }
            else if (txtPadrino.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado Padrino, por favor validar");
                validacion = false;
            }
            else if (txtMadrina.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado Madrina, por favor validar");
                validacion = false;
            }
            else if (txtMinistro.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado Ministro, por favor validar");
                validacion = false;
            }
            else if (txtDaFe.Text.Trim() == "")
            {
                MessageBox.Show("No ha ingresado Da Fe, por favor validar");
                validacion = false;
            }

            return validacion;
        }

        #region botonera
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
                registroActual = RegistroList.Where(x => x.id == FrmBusqueda.idEntidad).FirstOrDefault();
                MuestraItem();
                FrmBusqueda.idEntidad = 0;
            }
        }
        private void btnBuscarPersona_Click(object sender, EventArgs e)
        {
            FrmBuscaPersona frmBusqueda = new FrmBuscaPersona();
            frmBusqueda.ShowDialog();
            if (FrmBuscaPersona.PersonaResultado != null)
            {
                personaSacramento = FrmBuscaPersona.PersonaResultado;
                CargarPersonaBusqueda();

            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            modoPantalla = ModoPantallaEnum.Edicion;
            ActivaBotonera();
            EnceraPersona();
            EnceraDatos();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos())
                GrabaItem();

        }

        private void GrabaItem()
        {

            RegistroSacramento item = new RegistroSacramento();
            item.idParroquia = 1;
            item.idPersona = personaSacramento.id;
            item.idSacramento = int.Parse(cboSacramento.SelectedValue.ToString());
            item.fechaRegistro = dtFechaSacramento.Value;
            item.libro = int.Parse(txtLibro.Text);
            item.folio = int.Parse(txtFolio.Text);
            item.partida = txtPartida.Text;
            item.nombrePadrino = txtPadrino.Text;
            item.nombreMadrina = txtMadrina.Text;
            item.nombreDaFe = txtDaFe.Text;
            int resultado;
            if (txtCodigo.Text == "")
            {
                item.UsuarioCrea = clsUtils.UsuarioSesion.userName;
                resultado = RegistroSacramentoBL.Create(item);
            }
            else
            {
                item.UsuarioModif = clsUtils.UsuarioSesion.userName;
                item.id = registroActual.id;
                resultado = RegistroSacramentoBL.Update(item);
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

        private void IniciaPantalla(RegistroSacramento item)
        {
            modoPantalla = ModoPantallaEnum.Navegacion;
            CargarItems();
            registroActual = item;
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
        private void FrmRegistroSacramentos_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DialogResult resultado;
            resultado = MessageBox.Show("Imprimir en formato pre impreso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                FrmReporte form = new FrmReporte();
                form.Show();
                form.renderReportSacramento(registroActual.id);

            }
            else
            {
                FrmReporte form = new FrmReporte();
                form.Show();
                
                form.renderReportSacramentoMembrete(registroActual.id);

            }

        }
    }
}
