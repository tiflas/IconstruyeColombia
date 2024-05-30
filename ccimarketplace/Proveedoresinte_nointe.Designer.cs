
namespace ccimarketplace
{
    partial class Proveedoresinte_nointe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proveedoresinte_nointe));
            this.listaprovinte = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.fechafinal = new System.Windows.Forms.DateTimePicker();
            this.btconsultatodas = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tbexportalcentcos = new System.Windows.Forms.Button();
            this.tbconsultaprove = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fechainicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.listaempreprove = new System.Windows.Forms.ComboBox();
            this.tbsalirmate = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.imagencargar = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cubocargar = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listaprovinte)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagencargar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubocargar)).BeginInit();
            this.SuspendLayout();
            // 
            // listaprovinte
            // 
            this.listaprovinte.AllowUserToAddRows = false;
            this.listaprovinte.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.listaprovinte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaprovinte.Location = new System.Drawing.Point(27, 172);
            this.listaprovinte.Name = "listaprovinte";
            this.listaprovinte.Size = new System.Drawing.Size(634, 212);
            this.listaprovinte.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(67, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "FECHA FINAL";
            // 
            // fechafinal
            // 
            this.fechafinal.Location = new System.Drawing.Point(155, 120);
            this.fechafinal.Name = "fechafinal";
            this.fechafinal.Size = new System.Drawing.Size(200, 20);
            this.fechafinal.TabIndex = 38;
            // 
            // btconsultatodas
            // 
            this.btconsultatodas.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btconsultatodas.BackgroundImage")));
            this.btconsultatodas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btconsultatodas.Location = new System.Drawing.Point(418, 93);
            this.btconsultatodas.Name = "btconsultatodas";
            this.btconsultatodas.Size = new System.Drawing.Size(61, 47);
            this.btconsultatodas.TabIndex = 37;
            this.btconsultatodas.UseVisualStyleBackColor = true;
            this.btconsultatodas.Click += new System.EventHandler(this.btconsultatodas_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(141, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(238, 15);
            this.label3.TabIndex = 36;
            this.label3.Text = "CONSULTA CON TODAS LAS EMPRESAS";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(418, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 66);
            this.groupBox1.TabIndex = 35;
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
            // tbexportalcentcos
            // 
            this.tbexportalcentcos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbexportalcentcos.BackgroundImage")));
            this.tbexportalcentcos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbexportalcentcos.Location = new System.Drawing.Point(496, 92);
            this.tbexportalcentcos.Name = "tbexportalcentcos";
            this.tbexportalcentcos.Size = new System.Drawing.Size(61, 47);
            this.tbexportalcentcos.TabIndex = 34;
            this.tbexportalcentcos.UseVisualStyleBackColor = true;
            this.tbexportalcentcos.Click += new System.EventHandler(this.tbexportalcentcos_Click);
            // 
            // tbconsultaprove
            // 
            this.tbconsultaprove.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbconsultaprove.BackgroundImage")));
            this.tbconsultaprove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbconsultaprove.Location = new System.Drawing.Point(418, 93);
            this.tbconsultaprove.Name = "tbconsultaprove";
            this.tbconsultaprove.Size = new System.Drawing.Size(61, 47);
            this.tbconsultaprove.TabIndex = 33;
            this.tbconsultaprove.UseVisualStyleBackColor = true;
            this.tbconsultaprove.Click += new System.EventHandler(this.tbconsultaprove_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(65, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 32;
            this.label2.Text = "FECHA INICIO";
            // 
            // fechainicio
            // 
            this.fechainicio.Location = new System.Drawing.Point(155, 81);
            this.fechainicio.Name = "fechainicio";
            this.fechainicio.Size = new System.Drawing.Size(200, 20);
            this.fechainicio.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 30;
            this.label1.Text = "EMPRESA";
            // 
            // listaempreprove
            // 
            this.listaempreprove.FormattingEnabled = true;
            this.listaempreprove.Location = new System.Drawing.Point(155, 40);
            this.listaempreprove.Name = "listaempreprove";
            this.listaempreprove.Size = new System.Drawing.Size(211, 21);
            this.listaempreprove.TabIndex = 29;
            // 
            // tbsalirmate
            // 
            this.tbsalirmate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tbsalirmate.BackgroundImage")));
            this.tbsalirmate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tbsalirmate.Location = new System.Drawing.Point(27, 390);
            this.tbsalirmate.Name = "tbsalirmate";
            this.tbsalirmate.Size = new System.Drawing.Size(58, 42);
            this.tbsalirmate.TabIndex = 41;
            this.tbsalirmate.UseVisualStyleBackColor = true;
            this.tbsalirmate.Click += new System.EventHandler(this.tbsalirmate_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(500, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Importar ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(426, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Buscar";
            // 
            // imagencargar
            // 
            this.imagencargar.Image = ((System.Drawing.Image)(resources.GetObject("imagencargar.Image")));
            this.imagencargar.Location = new System.Drawing.Point(27, 172);
            this.imagencargar.Name = "imagencargar";
            this.imagencargar.Size = new System.Drawing.Size(634, 212);
            this.imagencargar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imagencargar.TabIndex = 44;
            this.imagencargar.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(289, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Exportando Datos";
            // 
            // cubocargar
            // 
            this.cubocargar.Image = ((System.Drawing.Image)(resources.GetObject("cubocargar.Image")));
            this.cubocargar.Location = new System.Drawing.Point(272, 157);
            this.cubocargar.Name = "cubocargar";
            this.cubocargar.Size = new System.Drawing.Size(143, 123);
            this.cubocargar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cubocargar.TabIndex = 45;
            this.cubocargar.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(24, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "0";
            // 
            // Proveedoresinte_nointe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(687, 436);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cubocargar);
            this.Controls.Add(this.imagencargar);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbsalirmate);
            this.Controls.Add(this.listaprovinte);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fechafinal);
            this.Controls.Add(this.btconsultatodas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbexportalcentcos);
            this.Controls.Add(this.tbconsultaprove);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fechainicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listaempreprove);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Proveedoresinte_nointe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores integrados - no integrados";
            this.Load += new System.EventHandler(this.Proveedoresinte_nointe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaprovinte)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagencargar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubocargar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listaprovinte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker fechafinal;
        private System.Windows.Forms.Button btconsultatodas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button tbexportalcentcos;
        private System.Windows.Forms.Button tbconsultaprove;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fechainicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox listaempreprove;
        private System.Windows.Forms.Button tbsalirmate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox imagencargar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox cubocargar;
        private System.Windows.Forms.Label label10;
    }
}