namespace ccimarketplace
{
    partial class Producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Producto));
            this.label1 = new System.Windows.Forms.Label();
            this.txtarticulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fechainicio = new System.Windows.Forms.DateTimePicker();
            this.listararticulo = new System.Windows.Forms.DataGridView();
            this.btgenerar = new System.Windows.Forms.Button();
            this.btexportarexcel = new System.Windows.Forms.Button();
            this.btsalir = new System.Windows.Forms.Button();
            this.fechafinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btintegrados_noint = new System.Windows.Forms.Button();
            this.btinsumoprovee = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.imagencargar = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cubocargar = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listararticulo)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagencargar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubocargar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "NOM ARTICULO";
            // 
            // txtarticulo
            // 
            this.txtarticulo.Location = new System.Drawing.Point(143, 31);
            this.txtarticulo.Name = "txtarticulo";
            this.txtarticulo.Size = new System.Drawing.Size(247, 20);
            this.txtarticulo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "FECHA INICIO";
            // 
            // fechainicio
            // 
            this.fechainicio.Location = new System.Drawing.Point(143, 68);
            this.fechainicio.Name = "fechainicio";
            this.fechainicio.Size = new System.Drawing.Size(247, 20);
            this.fechainicio.TabIndex = 3;
            // 
            // listararticulo
            // 
            this.listararticulo.AllowUserToAddRows = false;
            this.listararticulo.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.listararticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listararticulo.Location = new System.Drawing.Point(37, 193);
            this.listararticulo.Name = "listararticulo";
            this.listararticulo.RowHeadersVisible = false;
            this.listararticulo.Size = new System.Drawing.Size(639, 225);
            this.listararticulo.TabIndex = 4;
            // 
            // btgenerar
            // 
            this.btgenerar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btgenerar.BackgroundImage")));
            this.btgenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btgenerar.Location = new System.Drawing.Point(448, 127);
            this.btgenerar.Name = "btgenerar";
            this.btgenerar.Size = new System.Drawing.Size(61, 47);
            this.btgenerar.TabIndex = 5;
            this.btgenerar.UseVisualStyleBackColor = true;
            this.btgenerar.Click += new System.EventHandler(this.btgenerar_Click);
            // 
            // btexportarexcel
            // 
            this.btexportarexcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btexportarexcel.BackgroundImage")));
            this.btexportarexcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btexportarexcel.Location = new System.Drawing.Point(532, 127);
            this.btexportarexcel.Name = "btexportarexcel";
            this.btexportarexcel.Size = new System.Drawing.Size(61, 46);
            this.btexportarexcel.TabIndex = 6;
            this.btexportarexcel.UseVisualStyleBackColor = true;
            this.btexportarexcel.Click += new System.EventHandler(this.btexportarexcel_Click);
            // 
            // btsalir
            // 
            this.btsalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btsalir.BackgroundImage")));
            this.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btsalir.Location = new System.Drawing.Point(37, 424);
            this.btsalir.Name = "btsalir";
            this.btsalir.Size = new System.Drawing.Size(58, 42);
            this.btsalir.TabIndex = 7;
            this.btsalir.UseVisualStyleBackColor = true;
            this.btsalir.Click += new System.EventHandler(this.btsalir_Click);
            // 
            // fechafinal
            // 
            this.fechafinal.Location = new System.Drawing.Point(143, 104);
            this.fechafinal.Name = "fechafinal";
            this.fechafinal.Size = new System.Drawing.Size(247, 20);
            this.fechafinal.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "FECHA FINAL";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(448, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 107);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar opcion de insumos";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 27);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Info Insumos";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(16, 73);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(129, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Insumo por Proveedor";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 50);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(164, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Pro. Integrados no integrados";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btintegrados_noint
            // 
            this.btintegrados_noint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btintegrados_noint.BackgroundImage")));
            this.btintegrados_noint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btintegrados_noint.Location = new System.Drawing.Point(448, 127);
            this.btintegrados_noint.Name = "btintegrados_noint";
            this.btintegrados_noint.Size = new System.Drawing.Size(61, 47);
            this.btintegrados_noint.TabIndex = 31;
            this.btintegrados_noint.UseVisualStyleBackColor = true;
            this.btintegrados_noint.Click += new System.EventHandler(this.btintegrados_noint_Click);
            // 
            // btinsumoprovee
            // 
            this.btinsumoprovee.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btinsumoprovee.BackgroundImage")));
            this.btinsumoprovee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btinsumoprovee.Location = new System.Drawing.Point(448, 127);
            this.btinsumoprovee.Name = "btinsumoprovee";
            this.btinsumoprovee.Size = new System.Drawing.Size(61, 47);
            this.btinsumoprovee.TabIndex = 32;
            this.btinsumoprovee.UseVisualStyleBackColor = true;
            this.btinsumoprovee.Click += new System.EventHandler(this.btinsumoprovee_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(535, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Importar ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(461, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Buscar";
            // 
            // imagencargar
            // 
            this.imagencargar.Image = ((System.Drawing.Image)(resources.GetObject("imagencargar.Image")));
            this.imagencargar.Location = new System.Drawing.Point(37, 193);
            this.imagencargar.Name = "imagencargar";
            this.imagencargar.Size = new System.Drawing.Size(639, 225);
            this.imagencargar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagencargar.TabIndex = 37;
            this.imagencargar.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(301, 272);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Exportando Datos";
            // 
            // cubocargar
            // 
            this.cubocargar.Image = ((System.Drawing.Image)(resources.GetObject("cubocargar.Image")));
            this.cubocargar.Location = new System.Drawing.Point(284, 173);
            this.cubocargar.Name = "cubocargar";
            this.cubocargar.Size = new System.Drawing.Size(143, 123);
            this.cubocargar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cubocargar.TabIndex = 38;
            this.cubocargar.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(34, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "0";
            // 
            // Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(711, 469);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cubocargar);
            this.Controls.Add(this.imagencargar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btinsumoprovee);
            this.Controls.Add(this.btintegrados_noint);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fechafinal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btsalir);
            this.Controls.Add(this.btexportarexcel);
            this.Controls.Add(this.btgenerar);
            this.Controls.Add(this.listararticulo);
            this.Controls.Add(this.fechainicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtarticulo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Producto";
            this.Load += new System.EventHandler(this.Producto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listararticulo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagencargar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubocargar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtarticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fechainicio;
        private System.Windows.Forms.DataGridView listararticulo;
        private System.Windows.Forms.Button btgenerar;
        private System.Windows.Forms.Button btexportarexcel;
        private System.Windows.Forms.Button btsalir;
        private System.Windows.Forms.DateTimePicker fechafinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btintegrados_noint;
        private System.Windows.Forms.Button btinsumoprovee;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox imagencargar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox cubocargar;
        private System.Windows.Forms.Label label10;
    }
}