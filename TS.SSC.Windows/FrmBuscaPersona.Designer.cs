namespace TS.SSC.Windows
{
    partial class FrmBuscaPersona
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
            this.lblValor = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dgPersonas = new System.Windows.Forms.DataGridView();
            this.colIdCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLegalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(24, 19);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(71, 15);
            this.lblValor.TabIndex = 22;
            this.lblValor.Text = "Busqueda";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(124, 16);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(402, 21);
            this.txtSubTotal.TabIndex = 23;
            this.txtSubTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSubTotal_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnAceptar);
            this.groupBox2.Location = new System.Drawing.Point(12, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 45);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(431, 13);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 26);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(351, 13);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(74, 26);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dgPersonas
            // 
            this.dgPersonas.AllowUserToAddRows = false;
            this.dgPersonas.AllowUserToDeleteRows = false;
            this.dgPersonas.AllowUserToOrderColumns = true;
            this.dgPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdCliente,
            this.colLegalId,
            this.colNomCliente});
            this.dgPersonas.Location = new System.Drawing.Point(12, 52);
            this.dgPersonas.MultiSelect = false;
            this.dgPersonas.Name = "dgPersonas";
            this.dgPersonas.ReadOnly = true;
            this.dgPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPersonas.Size = new System.Drawing.Size(511, 232);
            this.dgPersonas.TabIndex = 20;
            this.dgPersonas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPersonas_CellContentClick);
            // 
            // colIdCliente
            // 
            this.colIdCliente.DataPropertyName = "idPersona";
            this.colIdCliente.HeaderText = "IdPersona";
            this.colIdCliente.Name = "colIdCliente";
            this.colIdCliente.ReadOnly = true;
            this.colIdCliente.Visible = false;
            // 
            // colLegalId
            // 
            this.colLegalId.DataPropertyName = "legalId";
            this.colLegalId.HeaderText = "Cedula/RUC";
            this.colLegalId.MaxInputLength = 20;
            this.colLegalId.Name = "colLegalId";
            this.colLegalId.ReadOnly = true;
            this.colLegalId.Width = 150;
            // 
            // colNomCliente
            // 
            this.colNomCliente.DataPropertyName = "Nombre";
            this.colNomCliente.HeaderText = "Persona";
            this.colNomCliente.Name = "colNomCliente";
            this.colNomCliente.ReadOnly = true;
            this.colNomCliente.Width = 300;
            // 
            // FrmBuscaPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 343);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgPersonas);
            this.Name = "FrmBuscaPersona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBuscaPersona";
            this.Load += new System.EventHandler(this.FrmBuscaPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.DataGridView dgPersonas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLegalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomCliente;
    }
}