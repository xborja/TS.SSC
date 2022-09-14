namespace TS.SSC.Windows
{
    partial class FrmRegistroSacramento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistroSacramento));
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbPersona = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtFechaBautismo = new System.Windows.Forms.DateTimePicker();
            this.txtLugarBautismo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtLugarNacimiento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnBuscaPersona = new System.Windows.Forms.Button();
            this.txtNombreMadre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombrePadre = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.txtLegalId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDaFe = new System.Windows.Forms.TextBox();
            this.cboSacramento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFechaSacramento = new System.Windows.Forms.DateTimePicker();
            this.txtPartida = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMadrina = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPadrino = new System.Windows.Forms.TextBox();
            this.txtLibro = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMinistro = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.gbPersona.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnNuevo.Location = new System.Drawing.Point(704, 286);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(74, 26);
            this.btnNuevo.TabIndex = 33;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.Location = new System.Drawing.Point(512, 286);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(39, 26);
            this.btnLast.TabIndex = 32;
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(467, 286);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(39, 26);
            this.btnNext.TabIndex = 31;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.Location = new System.Drawing.Point(422, 286);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(39, 26);
            this.btnPrev.TabIndex = 30;
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.Location = new System.Drawing.Point(379, 286);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(39, 26);
            this.btnFirst.TabIndex = 29;
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(852, 286);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 26);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.Black;
            this.btnAceptar.Location = new System.Drawing.Point(778, 286);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(74, 26);
            this.btnAceptar.TabIndex = 27;
            this.btnAceptar.Text = "Grabar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.GuardarRegistro);
            // 
            // gbPersona
            // 
            this.gbPersona.Controls.Add(this.label5);
            this.gbPersona.Controls.Add(this.dtFechaBautismo);
            this.gbPersona.Controls.Add(this.txtLugarBautismo);
            this.gbPersona.Controls.Add(this.label6);
            this.gbPersona.Controls.Add(this.label4);
            this.gbPersona.Controls.Add(this.dtFechaNacimiento);
            this.gbPersona.Controls.Add(this.txtLugarNacimiento);
            this.gbPersona.Controls.Add(this.label3);
            this.gbPersona.Controls.Add(this.lblCodigo);
            this.gbPersona.Controls.Add(this.btnBuscaPersona);
            this.gbPersona.Controls.Add(this.txtNombreMadre);
            this.gbPersona.Controls.Add(this.txtCodigo);
            this.gbPersona.Controls.Add(this.lblEstado);
            this.gbPersona.Controls.Add(this.lblNombre);
            this.gbPersona.Controls.Add(this.txtNombrePadre);
            this.gbPersona.Controls.Add(this.txtNombre);
            this.gbPersona.Controls.Add(this.lblPrecio);
            this.gbPersona.Controls.Add(this.lblCosto);
            this.gbPersona.Controls.Add(this.txtLegalId);
            this.gbPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPersona.Location = new System.Drawing.Point(5, 12);
            this.gbPersona.Name = "gbPersona";
            this.gbPersona.Size = new System.Drawing.Size(450, 268);
            this.gbPersona.TabIndex = 34;
            this.gbPersona.TabStop = false;
            this.gbPersona.Text = "Datos Persona";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Fecha Bautismo";
            // 
            // dtFechaBautismo
            // 
            this.dtFechaBautismo.CustomFormat = "dd/MMM/yyyy";
            this.dtFechaBautismo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaBautismo.Location = new System.Drawing.Point(133, 179);
            this.dtFechaBautismo.Name = "dtFechaBautismo";
            this.dtFechaBautismo.Size = new System.Drawing.Size(308, 21);
            this.dtFechaBautismo.TabIndex = 21;
            // 
            // txtLugarBautismo
            // 
            this.txtLugarBautismo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLugarBautismo.Location = new System.Drawing.Point(133, 152);
            this.txtLugarBautismo.Name = "txtLugarBautismo";
            this.txtLugarBautismo.Size = new System.Drawing.Size(308, 21);
            this.txtLugarBautismo.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Lugar Bautismo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Fecha Nac.";
            // 
            // dtFechaNacimiento
            // 
            this.dtFechaNacimiento.CustomFormat = "dd/MMM/yyyy";
            this.dtFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaNacimiento.Location = new System.Drawing.Point(133, 127);
            this.dtFechaNacimiento.Name = "dtFechaNacimiento";
            this.dtFechaNacimiento.Size = new System.Drawing.Size(308, 21);
            this.dtFechaNacimiento.TabIndex = 17;
            // 
            // txtLugarNacimiento
            // 
            this.txtLugarNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLugarNacimiento.Location = new System.Drawing.Point(133, 100);
            this.txtLugarNacimiento.Name = "txtLugarNacimiento";
            this.txtLugarNacimiento.Size = new System.Drawing.Size(308, 21);
            this.txtLugarNacimiento.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Lugar Nac.";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(17, 21);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 15);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Codigo";
            // 
            // btnBuscaPersona
            // 
            this.btnBuscaPersona.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBuscaPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscaPersona.ForeColor = System.Drawing.Color.White;
            this.btnBuscaPersona.Location = new System.Drawing.Point(407, 14);
            this.btnBuscaPersona.Name = "btnBuscaPersona";
            this.btnBuscaPersona.Size = new System.Drawing.Size(34, 26);
            this.btnBuscaPersona.TabIndex = 14;
            this.btnBuscaPersona.Text = "...";
            this.btnBuscaPersona.UseVisualStyleBackColor = false;
            this.btnBuscaPersona.Click += new System.EventHandler(this.btnBuscarPersona_Click);
            // 
            // txtNombreMadre
            // 
            this.txtNombreMadre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreMadre.Location = new System.Drawing.Point(133, 232);
            this.txtNombreMadre.Name = "txtNombreMadre";
            this.txtNombreMadre.Size = new System.Drawing.Size(308, 21);
            this.txtNombreMadre.TabIndex = 9;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(133, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(268, 21);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(17, 235);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(103, 15);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Nombre Madre";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(17, 49);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 15);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombrePadre
            // 
            this.txtNombrePadre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePadre.Location = new System.Drawing.Point(133, 205);
            this.txtNombrePadre.Name = "txtNombrePadre";
            this.txtNombrePadre.Size = new System.Drawing.Size(308, 21);
            this.txtNombrePadre.TabIndex = 7;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(133, 46);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(308, 21);
            this.txtNombre.TabIndex = 3;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(17, 208);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(100, 15);
            this.lblPrecio.TabIndex = 6;
            this.lblPrecio.Text = "Nombre Padre";
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCosto.Location = new System.Drawing.Point(17, 76);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(65, 15);
            this.lblCosto.TabIndex = 4;
            this.lblCosto.Text = "Ced/RUC";
            // 
            // txtLegalId
            // 
            this.txtLegalId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLegalId.Location = new System.Drawing.Point(133, 73);
            this.txtLegalId.Name = "txtLegalId";
            this.txtLegalId.Size = new System.Drawing.Size(308, 21);
            this.txtLegalId.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDaFe);
            this.groupBox1.Controls.Add(this.cboSacramento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtFechaSacramento);
            this.groupBox1.Controls.Add(this.txtPartida);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFolio);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtMadrina);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtPadrino);
            this.groupBox1.Controls.Add(this.txtLibro);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtMinistro);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(476, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 268);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Sacramento";
            // 
            // txtDaFe
            // 
            this.txtDaFe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDaFe.Location = new System.Drawing.Point(131, 238);
            this.txtDaFe.Name = "txtDaFe";
            this.txtDaFe.Size = new System.Drawing.Size(308, 21);
            this.txtDaFe.TabIndex = 37;
            // 
            // cboSacramento
            // 
            this.cboSacramento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSacramento.FormattingEnabled = true;
            this.cboSacramento.Location = new System.Drawing.Point(131, 19);
            this.cboSacramento.Name = "cboSacramento";
            this.cboSacramento.Size = new System.Drawing.Size(308, 23);
            this.cboSacramento.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Fecha";
            // 
            // dtFechaSacramento
            // 
            this.dtFechaSacramento.CustomFormat = "dd/MMM/yyyy";
            this.dtFechaSacramento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaSacramento.Location = new System.Drawing.Point(131, 49);
            this.dtFechaSacramento.Name = "dtFechaSacramento";
            this.dtFechaSacramento.Size = new System.Drawing.Size(308, 21);
            this.dtFechaSacramento.TabIndex = 21;
            // 
            // txtPartida
            // 
            this.txtPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartida.Location = new System.Drawing.Point(131, 125);
            this.txtPartida.Name = "txtPartida";
            this.txtPartida.Size = new System.Drawing.Size(308, 21);
            this.txtPartida.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Partida";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Folio";
            // 
            // txtFolio
            // 
            this.txtFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolio.Location = new System.Drawing.Point(131, 100);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(308, 21);
            this.txtFolio.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Libro";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Sacramento";
            // 
            // txtMadrina
            // 
            this.txtMadrina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMadrina.Location = new System.Drawing.Point(131, 184);
            this.txtMadrina.Name = "txtMadrina";
            this.txtMadrina.Size = new System.Drawing.Size(308, 21);
            this.txtMadrina.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 8;
            this.label10.Text = "Madrina";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(17, 241);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Da Fe";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtPadrino
            // 
            this.txtPadrino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPadrino.Location = new System.Drawing.Point(131, 152);
            this.txtPadrino.Name = "txtPadrino";
            this.txtPadrino.Size = new System.Drawing.Size(308, 21);
            this.txtPadrino.TabIndex = 7;
            // 
            // txtLibro
            // 
            this.txtLibro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLibro.Location = new System.Drawing.Point(131, 76);
            this.txtLibro.Name = "txtLibro";
            this.txtLibro.Size = new System.Drawing.Size(308, 21);
            this.txtLibro.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 15);
            this.label12.TabIndex = 6;
            this.label12.Text = "Padrino";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 211);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "Ministro";
            // 
            // txtMinistro
            // 
            this.txtMinistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinistro.Location = new System.Drawing.Point(131, 211);
            this.txtMinistro.Name = "txtMinistro";
            this.txtMinistro.Size = new System.Drawing.Size(308, 21);
            this.txtMinistro.TabIndex = 5;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Location = new System.Drawing.Point(630, 286);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(74, 26);
            this.btnBuscar.TabIndex = 36;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Location = new System.Drawing.Point(555, 286);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(74, 26);
            this.btnImprimir.TabIndex = 37;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FrmRegistroSacramento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 322);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPersona);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "FrmRegistroSacramento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Sacramentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegistroSacramento_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegistroSacramento_Load);
            this.gbPersona.ResumeLayout(false);
            this.gbPersona.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gbPersona;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtFechaBautismo;
        private System.Windows.Forms.TextBox txtLugarBautismo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFechaNacimiento;
        private System.Windows.Forms.TextBox txtLugarNacimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnBuscaPersona;
        private System.Windows.Forms.TextBox txtNombreMadre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombrePadre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.TextBox txtLegalId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFechaSacramento;
        private System.Windows.Forms.TextBox txtPartida;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMadrina;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPadrino;
        private System.Windows.Forms.TextBox txtLibro;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMinistro;
        private System.Windows.Forms.ComboBox cboSacramento;
        private System.Windows.Forms.TextBox txtDaFe;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnImprimir;
    }
}