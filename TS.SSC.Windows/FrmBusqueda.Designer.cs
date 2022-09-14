namespace TS.SSC.Windows
{
    partial class FrmBusqueda
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.gbResultado = new System.Windows.Forms.GroupBox();
            this.dgResultado = new System.Windows.Forms.DataGridView();
            this.gbHeader = new System.Windows.Forms.GroupBox();
            this.txtTextoBusqueda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.gbResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).BeginInit();
            this.gbHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnAceptar);
            this.groupBox2.Location = new System.Drawing.Point(25, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(665, 45);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(585, 12);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(74, 26);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(505, 12);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(74, 26);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // gbResultado
            // 
            this.gbResultado.Controls.Add(this.dgResultado);
            this.gbResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbResultado.Location = new System.Drawing.Point(12, 86);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(678, 272);
            this.gbResultado.TabIndex = 20;
            this.gbResultado.TabStop = false;
            this.gbResultado.Text = "Resultado de Búsqueda";
            // 
            // dgResultado
            // 
            this.dgResultado.AllowUserToAddRows = false;
            this.dgResultado.AllowUserToDeleteRows = false;
            this.dgResultado.AllowUserToOrderColumns = true;
            this.dgResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgResultado.Location = new System.Drawing.Point(13, 20);
            this.dgResultado.MultiSelect = false;
            this.dgResultado.Name = "dgResultado";
            this.dgResultado.ReadOnly = true;
            this.dgResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgResultado.Size = new System.Drawing.Size(649, 252);
            this.dgResultado.TabIndex = 17;
            // 
            // gbHeader
            // 
            this.gbHeader.Controls.Add(this.txtTextoBusqueda);
            this.gbHeader.Controls.Add(this.label1);
            this.gbHeader.Location = new System.Drawing.Point(12, 12);
            this.gbHeader.Name = "gbHeader";
            this.gbHeader.Size = new System.Drawing.Size(678, 60);
            this.gbHeader.TabIndex = 19;
            this.gbHeader.TabStop = false;
            // 
            // txtTextoBusqueda
            // 
            this.txtTextoBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTextoBusqueda.Location = new System.Drawing.Point(128, 22);
            this.txtTextoBusqueda.Name = "txtTextoBusqueda";
            this.txtTextoBusqueda.Size = new System.Drawing.Size(544, 21);
            this.txtTextoBusqueda.TabIndex = 20;
            this.txtTextoBusqueda.TextChanged += new System.EventHandler(this.txtTextoBusqueda_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Texto a Buscar";
            // 
            // FrmBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 415);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbResultado);
            this.Controls.Add(this.gbHeader);
            this.Name = "FrmBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBusqueda";
            this.Load += new System.EventHandler(this.FrmBusqueda_Load);
            this.groupBox2.ResumeLayout(false);
            this.gbResultado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgResultado)).EndInit();
            this.gbHeader.ResumeLayout(false);
            this.gbHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gbResultado;
        private System.Windows.Forms.DataGridView dgResultado;
        private System.Windows.Forms.GroupBox gbHeader;
        private System.Windows.Forms.TextBox txtTextoBusqueda;
        private System.Windows.Forms.Label label1;
    }
}