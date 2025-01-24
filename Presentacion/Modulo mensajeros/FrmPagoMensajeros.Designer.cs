namespace SistemaContable.Presentacion
{
    partial class FrmPagoMensajeros
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label = new System.Windows.Forms.Label();
            this.PanelSuperior = new System.Windows.Forms.Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lbNombre = new System.Windows.Forms.Label();
            this.dgvDeudas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFichos = new System.Windows.Forms.TextBox();
            this.txtPendiente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFichosDomingo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOtrosServicios = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbDeuda = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbPago = new System.Windows.Forms.Label();
            this.cbAprobo = new System.Windows.Forms.CheckBox();
            this.btnGenerarPago = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.lbDocumento = new System.Windows.Forms.Label();
            this.lbValor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudas)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.Transparent;
            this.label.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.White;
            this.label.Location = new System.Drawing.Point(12, 70);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(90, 20);
            this.label.TabIndex = 6;
            this.label.Text = "Documento:";
            // 
            // PanelSuperior
            // 
            this.PanelSuperior.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelSuperior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelSuperior.Controls.Add(this.guna2ControlBox1);
            this.PanelSuperior.Controls.Add(this.guna2ControlBox2);
            this.PanelSuperior.Location = new System.Drawing.Point(0, 1);
            this.PanelSuperior.Name = "PanelSuperior";
            this.PanelSuperior.Size = new System.Drawing.Size(430, 25);
            this.PanelSuperior.TabIndex = 7;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(391, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(32, 20);
            this.guna2ControlBox1.TabIndex = 3;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.ForeColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(349, 3);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(32, 20);
            this.guna2ControlBox2.TabIndex = 4;
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.BackColor = System.Drawing.Color.Transparent;
            this.lbNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.ForeColor = System.Drawing.Color.White;
            this.lbNombre.Location = new System.Drawing.Point(12, 38);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(93, 25);
            this.lbNombre.TabIndex = 8;
            this.lbNombre.Text = "NOMBRE";
            // 
            // dgvDeudas
            // 
            this.dgvDeudas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDeudas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDeudas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(64)))));
            this.dgvDeudas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeudas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDeudas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDeudas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeudas.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDeudas.EnableHeadersVisualStyles = false;
            this.dgvDeudas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(64)))));
            this.dgvDeudas.Location = new System.Drawing.Point(16, 108);
            this.dgvDeudas.Name = "dgvDeudas";
            this.dgvDeudas.ReadOnly = true;
            this.dgvDeudas.RowHeadersVisible = false;
            this.dgvDeudas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeudas.Size = new System.Drawing.Size(397, 140);
            this.dgvDeudas.TabIndex = 9;
            this.dgvDeudas.SelectionChanged += new System.EventHandler(this.dgvDeudas_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Fichos de la semana:";
            // 
            // txtFichos
            // 
            this.txtFichos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFichos.Location = new System.Drawing.Point(62, 281);
            this.txtFichos.Name = "txtFichos";
            this.txtFichos.Size = new System.Drawing.Size(83, 25);
            this.txtFichos.TabIndex = 11;
            this.txtFichos.TextChanged += new System.EventHandler(this.txtFichos_TextChanged);
            // 
            // txtPendiente
            // 
            this.txtPendiente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPendiente.Location = new System.Drawing.Point(272, 281);
            this.txtPendiente.Name = "txtPendiente";
            this.txtPendiente.Size = new System.Drawing.Size(83, 25);
            this.txtPendiente.TabIndex = 13;
            this.txtPendiente.TextChanged += new System.EventHandler(this.txtPendiente_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(260, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Pendiente:";
            // 
            // txtFichosDomingo
            // 
            this.txtFichosDomingo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFichosDomingo.Location = new System.Drawing.Point(62, 365);
            this.txtFichosDomingo.Name = "txtFichosDomingo";
            this.txtFichosDomingo.Size = new System.Drawing.Size(83, 25);
            this.txtFichosDomingo.TabIndex = 15;
            this.txtFichosDomingo.TextChanged += new System.EventHandler(this.txtFichosDomingo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "Fichos domingo:";
            // 
            // txtOtrosServicios
            // 
            this.txtOtrosServicios.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtrosServicios.Location = new System.Drawing.Point(272, 365);
            this.txtOtrosServicios.Name = "txtOtrosServicios";
            this.txtOtrosServicios.Size = new System.Drawing.Size(83, 25);
            this.txtOtrosServicios.TabIndex = 17;
            this.txtOtrosServicios.TextChanged += new System.EventHandler(this.txtOtrosServicios_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(246, 337);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Otros servicios:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(57, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 25);
            this.label5.TabIndex = 18;
            this.label5.Text = "Deuda:";
            // 
            // lbDeuda
            // 
            this.lbDeuda.AutoSize = true;
            this.lbDeuda.BackColor = System.Drawing.Color.Transparent;
            this.lbDeuda.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDeuda.ForeColor = System.Drawing.Color.White;
            this.lbDeuda.Location = new System.Drawing.Point(137, 411);
            this.lbDeuda.Name = "lbDeuda";
            this.lbDeuda.Size = new System.Drawing.Size(22, 25);
            this.lbDeuda.TabIndex = 19;
            this.lbDeuda.Text = "0";
            this.lbDeuda.TextChanged += new System.EventHandler(this.lbDeuda_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(57, 448);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Pago:";
            // 
            // lbPago
            // 
            this.lbPago.AutoSize = true;
            this.lbPago.BackColor = System.Drawing.Color.Transparent;
            this.lbPago.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPago.ForeColor = System.Drawing.Color.White;
            this.lbPago.Location = new System.Drawing.Point(137, 448);
            this.lbPago.Name = "lbPago";
            this.lbPago.Size = new System.Drawing.Size(83, 25);
            this.lbPago.TabIndex = 21;
            this.lbPago.Text = "x.xxx.xxx";
            // 
            // cbAprobo
            // 
            this.cbAprobo.AutoSize = true;
            this.cbAprobo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAprobo.ForeColor = System.Drawing.Color.White;
            this.cbAprobo.Location = new System.Drawing.Point(313, 453);
            this.cbAprobo.Name = "cbAprobo";
            this.cbAprobo.Size = new System.Drawing.Size(72, 21);
            this.cbAprobo.TabIndex = 22;
            this.cbAprobo.Text = "Aprobó";
            this.cbAprobo.UseVisualStyleBackColor = true;
            this.cbAprobo.CheckedChanged += new System.EventHandler(this.cbAprobo_CheckedChanged);
            // 
            // btnGenerarPago
            // 
            this.btnGenerarPago.AutoRoundedCorners = true;
            this.btnGenerarPago.BorderRadius = 14;
            this.btnGenerarPago.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerarPago.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerarPago.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerarPago.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerarPago.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(25)))), ((int)(((byte)(40)))));
            this.btnGenerarPago.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPago.ForeColor = System.Drawing.Color.White;
            this.btnGenerarPago.Location = new System.Drawing.Point(142, 497);
            this.btnGenerarPago.Name = "btnGenerarPago";
            this.btnGenerarPago.Size = new System.Drawing.Size(117, 31);
            this.btnGenerarPago.TabIndex = 23;
            this.btnGenerarPago.Text = "Generar pago";
            this.btnGenerarPago.Click += new System.EventHandler(this.btnGenerarPago_Click);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.PanelSuperior;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // lbDocumento
            // 
            this.lbDocumento.AutoSize = true;
            this.lbDocumento.BackColor = System.Drawing.Color.Transparent;
            this.lbDocumento.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDocumento.ForeColor = System.Drawing.Color.White;
            this.lbDocumento.Location = new System.Drawing.Point(108, 70);
            this.lbDocumento.Name = "lbDocumento";
            this.lbDocumento.Size = new System.Drawing.Size(46, 20);
            this.lbDocumento.TabIndex = 24;
            this.lbDocumento.Text = "x.x.x.x";
            // 
            // lbValor
            // 
            this.lbValor.AutoSize = true;
            this.lbValor.Location = new System.Drawing.Point(272, 411);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(13, 13);
            this.lbValor.TabIndex = 25;
            this.lbValor.Text = "0";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 530);
            this.panel1.TabIndex = 26;
            // 
            // FrmPagoMensajeros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(430, 556);
            this.Controls.Add(this.lbValor);
            this.Controls.Add(this.lbDocumento);
            this.Controls.Add(this.btnGenerarPago);
            this.Controls.Add(this.cbAprobo);
            this.Controls.Add(this.lbPago);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbDeuda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOtrosServicios);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFichosDomingo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPendiente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFichos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDeudas);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.PanelSuperior);
            this.Controls.Add(this.label);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPagoMensajeros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FrmPagoMensajeros_Load);
            this.PanelSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel PanelSuperior;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.DataGridView dgvDeudas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFichos;
        private System.Windows.Forms.TextBox txtPendiente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFichosDomingo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOtrosServicios;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbDeuda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbPago;
        private System.Windows.Forms.CheckBox cbAprobo;
        private Guna.UI2.WinForms.Guna2Button btnGenerarPago;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Label lbDocumento;
        private System.Windows.Forms.Label lbValor;
        private System.Windows.Forms.Panel panel1;
    }
}