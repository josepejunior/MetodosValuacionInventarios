namespace ValuacionInventarios
{
    partial class frmControlDeInventarios
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblFecha = new Label();
            cmbTipoMetodo = new ComboBox();
            cmbConcepto = new ComboBox();
            label5 = new Label();
            txtCantidad = new TextBox();
            label6 = new Label();
            txtValorUnitario = new TextBox();
            lvFecha = new ListView();
            columnHeader1 = new ColumnHeader();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label13 = new Label();
            btnRegistrar = new Button();
            lvSalidas = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            lvSaldos = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            label4 = new Label();
            lblHora = new Label();
            lvEntradas = new ListView();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(374, 9);
            label1.Name = "label1";
            label1.Size = new Size(279, 30);
            label1.TabIndex = 0;
            label1.Text = "CONTROL DE INVENTARIO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 67);
            label2.Name = "label2";
            label2.Size = new Size(112, 17);
            label2.TabIndex = 1;
            label2.Text = "Metodo a Utilizar";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(278, 67);
            label3.Name = "label3";
            label3.Size = new Size(66, 17);
            label3.TabIndex = 2;
            label3.Text = "Concepto";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblFecha.Location = new Point(862, 9);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(76, 17);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "                 ";
            // 
            // cmbTipoMetodo
            // 
            cmbTipoMetodo.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cmbTipoMetodo.FormattingEnabled = true;
            cmbTipoMetodo.Location = new Point(130, 64);
            cmbTipoMetodo.Name = "cmbTipoMetodo";
            cmbTipoMetodo.Size = new Size(133, 25);
            cmbTipoMetodo.TabIndex = 4;
            // 
            // cmbConcepto
            // 
            cmbConcepto.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cmbConcepto.FormattingEnabled = true;
            cmbConcepto.Location = new Point(350, 64);
            cmbConcepto.Name = "cmbConcepto";
            cmbConcepto.Size = new Size(121, 25);
            cmbConcepto.TabIndex = 5;
            cmbConcepto.SelectedIndexChanged += cmbConcepto_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(490, 67);
            label5.Name = "label5";
            label5.Size = new Size(62, 17);
            label5.TabIndex = 6;
            label5.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            txtCantidad.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtCantidad.Location = new Point(558, 64);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(85, 25);
            txtCantidad.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(661, 67);
            label6.Name = "label6";
            label6.Size = new Size(90, 17);
            label6.TabIndex = 8;
            label6.Text = "Valor Unitario";
            // 
            // txtValorUnitario
            // 
            txtValorUnitario.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtValorUnitario.Location = new Point(757, 64);
            txtValorUnitario.Name = "txtValorUnitario";
            txtValorUnitario.Size = new Size(96, 25);
            txtValorUnitario.TabIndex = 9;
            // 
            // lvFecha
            // 
            lvFecha.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            lvFecha.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lvFecha.Location = new Point(12, 143);
            lvFecha.Name = "lvFecha";
            lvFecha.Size = new Size(97, 264);
            lvFecha.TabIndex = 10;
            lvFecha.UseCompatibleStateImageBehavior = false;
            lvFecha.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Fecha y Hora ";
            columnHeader1.Width = 93;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(12, 106);
            label7.Name = "label7";
            label7.Size = new Size(102, 34);
            label7.TabIndex = 14;
            label7.Text = "FECHA Y HORA\r\n DEL REGISTRO";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(222, 116);
            label8.Name = "label8";
            label8.Size = new Size(74, 17);
            label8.TabIndex = 15;
            label8.Text = "ENTRADAS";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(525, 116);
            label9.Name = "label9";
            label9.Size = new Size(59, 17);
            label9.TabIndex = 16;
            label9.Text = "SALIDAS";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label10.Location = new Point(820, 116);
            label10.Name = "label10";
            label10.Size = new Size(56, 17);
            label10.TabIndex = 17;
            label10.Text = "SALDOS";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label13.Location = new Point(813, 9);
            label13.Name = "label13";
            label13.Size = new Size(43, 17);
            label13.TabIndex = 18;
            label13.Text = "Fecha";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRegistrar.Location = new Point(898, 63);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(96, 25);
            btnRegistrar.TabIndex = 19;
            btnRegistrar.Text = "REGISTRAR";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lvSalidas
            // 
            lvSalidas.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7 });
            lvSalidas.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lvSalidas.Location = new Point(410, 143);
            lvSalidas.Name = "lvSalidas";
            lvSalidas.Size = new Size(289, 264);
            lvSalidas.TabIndex = 20;
            lvSalidas.UseCompatibleStateImageBehavior = false;
            lvSalidas.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Cantidad";
            columnHeader5.Width = 95;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Valor Unitario";
            columnHeader6.Width = 95;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Valor Total";
            columnHeader7.Width = 95;
            // 
            // lvSaldos
            // 
            lvSaldos.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader9, columnHeader10 });
            lvSaldos.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lvSaldos.Location = new Point(705, 143);
            lvSaldos.Name = "lvSaldos";
            lvSaldos.Size = new Size(289, 264);
            lvSaldos.TabIndex = 21;
            lvSaldos.UseCompatibleStateImageBehavior = false;
            lvSaldos.View = View.Details;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Cantidad";
            columnHeader8.Width = 95;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Valor Unitario";
            columnHeader9.Width = 95;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Valor Total";
            columnHeader10.Width = 95;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(813, 39);
            label4.Name = "label4";
            label4.Size = new Size(38, 17);
            label4.TabIndex = 23;
            label4.Text = "Hora";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblHora.Location = new Point(862, 39);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(76, 17);
            lblHora.TabIndex = 22;
            lblHora.Text = "                 ";
            // 
            // lvEntradas
            // 
            lvEntradas.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader3, columnHeader4 });
            lvEntradas.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lvEntradas.Location = new Point(115, 143);
            lvEntradas.Name = "lvEntradas";
            lvEntradas.Size = new Size(289, 264);
            lvEntradas.TabIndex = 24;
            lvEntradas.UseCompatibleStateImageBehavior = false;
            lvEntradas.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Cantidad";
            columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Valor Unitario";
            columnHeader3.Width = 95;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Valor Total";
            columnHeader4.Width = 95;
            // 
            // frmControlDeInventarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 421);
            Controls.Add(lvEntradas);
            Controls.Add(label4);
            Controls.Add(lblHora);
            Controls.Add(lvSaldos);
            Controls.Add(lvSalidas);
            Controls.Add(btnRegistrar);
            Controls.Add(label13);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(lvFecha);
            Controls.Add(txtValorUnitario);
            Controls.Add(label6);
            Controls.Add(txtCantidad);
            Controls.Add(label5);
            Controls.Add(cmbConcepto);
            Controls.Add(cmbTipoMetodo);
            Controls.Add(lblFecha);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmControlDeInventarios";
            Text = "Control De Inventarios";
            Load += ControlDeInventarios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblFecha;
        private ComboBox cmbTipoMetodo;
        private ComboBox cmbConcepto;
        private Label label5;
        private TextBox txtCantidad;
        private Label label6;
        private TextBox txtValorUnitario;
        private ListView lvFecha;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label13;
        private ColumnHeader columnHeader1;
        private Button btnRegistrar;
        private ListView lvSalidas;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ListView lvSaldos;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private Label label4;
        private Label lblHora;
        private ListView lvEntradas;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
    }
}