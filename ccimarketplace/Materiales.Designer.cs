namespace ccimarketplace
{
    partial class Materiales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Materiales));
            this.listaempremateri = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fechainicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.listamateriales = new System.Windows.Forms.DataGridView();
            this.tbconsultamateri = new System.Windows.Forms.Button();
            this.tbexportalexcelmateri = new System.Windows.Forms.Button();
            this.tbsalirmate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btconsultatodas = new System.Windows.Forms.Button();
            this.fechafinal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.imagencargar = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cubocargar = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listamateriales)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagencargar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubocargar)).BeginInit();
            this.SuspendLayout();
            // 
            // listaempremateri
            // 
            this.listaempremateri.FormattingEnabled = true;
            this.listaempremateri.Location = new System.Drawing.Point(121, 19);
            this.listaempremateri.Name = "listaempremateri";
            this.listaempremateri.Size = new System.Drawing.Size(211, 21);
            this.listaempremateri.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "EMPRESA";
            // 
            // fechainicio
            // 
            this.fechainicio.Location = new System.Drawing.Point(121, 60);
            this.fechainicio.Name = "fechainicio";
            this.fechainicio.Size = new System.Drawing.Size(200, 20);
            this.fechainicio.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "FECHA INICIO";
            // 
            // listamateriales
            // 
            this.listamateriales.AllowUserToAddRows = false;
            this.listamateriales.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.listamateriales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listamateriales.Location = new System.Drawing.Point(30, 161);
            this.listamateriales.Name = "listamateriales";
            this.listamateriales.RowHeadersVisible = false;
            this.listamateriales.Size = new System.Drawing.Size(638, 232);
            this.listamateriales.TabIndex = 6;
            // 
            // tbconsultamateri
            // 
            this.tbconsultamateri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbconsultamateri.BackgroundImage")));
            this.tbconsultamateri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbconsultamateri.Location = new System.Drawing.Point(386, 92);
            this.tbconsultamateri.Name = "tbconsultamateri";
            this.tbconsultamateri.Size = new System.Drawing.Size(61, 48);
            this.tbconsultamateri.TabIndex = 7;
            this.tbconsultamateri.UseVisualStyleBackColor = true;
            this.tbconsultamateri.Click += new System.EventHandler(this.tbconsultamateri_Click);
            // 
            // tbexportalexcelmateri
            // 
            this.tbexportalexcelmateri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbexportalexcelmateri.BackgroundImage")));
            this.tbexportalexcelmateri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbexportalexcelmateri.Location = new System.Drawing.Point(463, 92);
            this.tbexportalexcelmateri.Name = "tbexportalexcelmateri";
            this.tbexportalexcelmateri.Size = new System.Drawing.Size(61, 48);
            this.tbexportalexcelmateri.TabIndex = 8;
            this.tbexportalexcelmateri.UseVisualStyleBackColor = true;
            this.tbexportalexcelmateri.Click += new System.EventHandler(this.tbexportalexcelmateri_Click);
            // 
            // tbsalirmate
            // 
            this.tbsalirmate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbsalirmate.BackgroundImage")));
            this.tbsalirmate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbsalirmate.Location = new System.Drawing.Point(30, 399);
            this.tbsalirmate.Name = "tbsalirmate";
            this.tbsalirmate.Size = new System.Drawing.Size(59, 42);
            this.tbsalirmate.TabIndex = 9;
            this.tbsalirmate.UseVisualStyleBackColor = true;
            this.tbsalirmate.Click += new System.EventHandler(this.tbsalirmate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(385, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 66);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(145, 27);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(88, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Una empresa";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 28);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(119, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Todas las empresas";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(121, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "CONSULTA: TODAS LAS EMPRESAS";
            // 
            // btconsultatodas
            // 
            this.btconsultatodas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btconsultatodas.BackgroundImage")));
            this.btconsultatodas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btconsultatodas.Location = new System.Drawing.Point(386, 92);
            this.btconsultatodas.Name = "btconsultatodas";
            this.btconsultatodas.Size = new System.Drawing.Size(61, 48);
            this.btconsultatodas.TabIndex = 12;
            this.btconsultatodas.UseVisualStyleBackColor = true;
            this.btconsultatodas.Click += new System.EventHandler(this.btconsultatodas_Click);
            // 
            // fechafinal
            // 
            this.fechafinal.Location = new System.Drawing.Point(121, 99);
            this.fechafinal.Name = "fechafinal";
            this.fechafinal.Size = new System.Drawing.Size(200, 20);
            this.fechafinal.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "FECHA FINAL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(460, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Importar ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(395, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Buscar";
            // 
            // imagencargar
            // 
            this.imagencargar.Image = ((System.Drawing.Image)(resources.GetObject("imagencargar.Image")));
            this.imagencargar.Location = new System.Drawing.Point(30, 161);
            this.imagencargar.Name = "imagencargar";
            this.imagencargar.Size = new System.Drawing.Size(638, 232);
            this.imagencargar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagencargar.TabIndex = 35;
            this.imagencargar.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(297, 260);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Exportando Datos";
            // 
            // cubocargar
            // 
            this.cubocargar.Image = ((System.Drawing.Image)(resources.GetObject("cubocargar.Image")));
            this.cubocargar.Location = new System.Drawing.Point(280, 161);
            this.cubocargar.Name = "cubocargar";
            this.cubocargar.Size = new System.Drawing.Size(143, 123);
            this.cubocargar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cubocargar.TabIndex = 37;
            this.cubocargar.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(27, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "0";
            // 
            // Materiales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(702, 445);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cubocargar);
            this.Controls.Add(this.imagencargar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fechafinal);
            this.Controls.Add(this.btconsultatodas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbsalirmate);
            this.Controls.Add(this.tbexportalexcelmateri);
            this.Controls.Add(this.tbconsultamateri);
            this.Controls.Add(this.listamateriales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fechainicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listaempremateri);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Materiales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Materiales";
            this.Load += new System.EventHandler(this.Materiales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listamateriales)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagencargar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubocargar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox listaempremateri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker fechainicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView listamateriales;
        private System.Windows.Forms.Button tbconsultamateri;
        private System.Windows.Forms.Button tbexportalexcelmateri;
        private System.Windows.Forms.Button tbsalirmate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btconsultatodas;
        private System.Windows.Forms.DateTimePicker fechafinal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox imagencargar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox cubocargar;
        private System.Windows.Forms.Label label10;
    }
}