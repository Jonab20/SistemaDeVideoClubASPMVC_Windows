
namespace SistemaDeVideoClub.Windows
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAlquiler = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSocios = new System.Windows.Forms.Button();
            this.btnPeliculas = new System.Windows.Forms.Button();
            this.btnLocalidades = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btngeneros = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAlquiler
            // 
            this.btnAlquiler.Image = global::SistemaDeVideoClub.Windows.Properties.Resources.alquileres;
            this.btnAlquiler.Location = new System.Drawing.Point(511, 12);
            this.btnAlquiler.Name = "btnAlquiler";
            this.btnAlquiler.Size = new System.Drawing.Size(119, 154);
            this.btnAlquiler.TabIndex = 10;
            this.btnAlquiler.Text = "Alquileres";
            this.btnAlquiler.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAlquiler.UseVisualStyleBackColor = true;
            this.btnAlquiler.Click += new System.EventHandler(this.btnAlquiler_Click);
            // 
            // button6
            // 
            this.button6.Image = global::SistemaDeVideoClub.Windows.Properties.Resources.TipoDocumento;
            this.button6.Location = new System.Drawing.Point(136, 172);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(119, 74);
            this.button6.TabIndex = 9;
            this.button6.Text = "Tipos de Documentos";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Image = global::SistemaDeVideoClub.Windows.Properties.Resources.Estado;
            this.button5.Location = new System.Drawing.Point(12, 172);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(119, 74);
            this.button5.TabIndex = 8;
            this.button5.Text = "Estados";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Image = global::SistemaDeVideoClub.Windows.Properties.Resources.calificaciones;
            this.button4.Location = new System.Drawing.Point(261, 172);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 74);
            this.button4.TabIndex = 7;
            this.button4.Text = "Calificaciones";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = global::SistemaDeVideoClub.Windows.Properties.Resources.Soportes;
            this.button3.Location = new System.Drawing.Point(12, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 74);
            this.button3.TabIndex = 6;
            this.button3.Text = "Soportes";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::SistemaDeVideoClub.Windows.Properties.Resources.salir;
            this.button2.Location = new System.Drawing.Point(511, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(119, 74);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSocios
            // 
            this.btnSocios.Image = global::SistemaDeVideoClub.Windows.Properties.Resources.Socios;
            this.btnSocios.Location = new System.Drawing.Point(386, 12);
            this.btnSocios.Name = "btnSocios";
            this.btnSocios.Size = new System.Drawing.Size(119, 154);
            this.btnSocios.TabIndex = 4;
            this.btnSocios.Text = "Socios";
            this.btnSocios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSocios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSocios.UseVisualStyleBackColor = true;
            this.btnSocios.Click += new System.EventHandler(this.btnSocios_Click);
            // 
            // btnPeliculas
            // 
            this.btnPeliculas.Image = global::SistemaDeVideoClub.Windows.Properties.Resources.Peliculas;
            this.btnPeliculas.Location = new System.Drawing.Point(261, 12);
            this.btnPeliculas.Name = "btnPeliculas";
            this.btnPeliculas.Size = new System.Drawing.Size(119, 154);
            this.btnPeliculas.TabIndex = 3;
            this.btnPeliculas.Text = "Peliculas";
            this.btnPeliculas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPeliculas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPeliculas.UseVisualStyleBackColor = true;
            this.btnPeliculas.Click += new System.EventHandler(this.btnPeliculas_Click);
            // 
            // btnLocalidades
            // 
            this.btnLocalidades.Image = global::SistemaDeVideoClub.Windows.Properties.Resources.Localidades;
            this.btnLocalidades.Location = new System.Drawing.Point(136, 12);
            this.btnLocalidades.Name = "btnLocalidades";
            this.btnLocalidades.Size = new System.Drawing.Size(119, 74);
            this.btnLocalidades.TabIndex = 2;
            this.btnLocalidades.Text = "Localidades";
            this.btnLocalidades.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLocalidades.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLocalidades.UseVisualStyleBackColor = true;
            this.btnLocalidades.Click += new System.EventHandler(this.btnLocalidades_Click);
            // 
            // button1
            // 
            this.button1.Image = global::SistemaDeVideoClub.Windows.Properties.Resources.Provincias;
            this.button1.Location = new System.Drawing.Point(136, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 74);
            this.button1.TabIndex = 1;
            this.button1.Text = "Provincias";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnProvincias_Click_1);
            // 
            // btngeneros
            // 
            this.btngeneros.Image = global::SistemaDeVideoClub.Windows.Properties.Resources.Generos;
            this.btngeneros.Location = new System.Drawing.Point(12, 12);
            this.btngeneros.Name = "btngeneros";
            this.btngeneros.Size = new System.Drawing.Size(119, 74);
            this.btngeneros.TabIndex = 0;
            this.btngeneros.Text = "Generos";
            this.btngeneros.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btngeneros.UseVisualStyleBackColor = true;
            this.btngeneros.Click += new System.EventHandler(this.btngeneros_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 260);
            this.ControlBox = false;
            this.Controls.Add(this.btnAlquiler);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSocios);
            this.Controls.Add(this.btnPeliculas);
            this.Controls.Add(this.btnLocalidades);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btngeneros);
            this.MaximumSize = new System.Drawing.Size(653, 299);
            this.MinimumSize = new System.Drawing.Size(653, 299);
            this.Name = "FrmMenuPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btngeneros;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLocalidades;
        private System.Windows.Forms.Button btnPeliculas;
        private System.Windows.Forms.Button btnSocios;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnAlquiler;
    }
}

