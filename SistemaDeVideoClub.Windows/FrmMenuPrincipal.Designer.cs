﻿
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
            this.btngeneros = new System.Windows.Forms.Button();
            this.btnProvincias = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btngeneros
            // 
            this.btngeneros.Location = new System.Drawing.Point(12, 12);
            this.btngeneros.Name = "btngeneros";
            this.btngeneros.Size = new System.Drawing.Size(119, 58);
            this.btngeneros.TabIndex = 0;
            this.btngeneros.Text = "Generos";
            this.btngeneros.UseVisualStyleBackColor = true;
            this.btngeneros.Click += new System.EventHandler(this.btngeneros_Click);
            // 
            // btnProvincias
            // 
            this.btnProvincias.Location = new System.Drawing.Point(163, 15);
            this.btnProvincias.Name = "btnProvincias";
            this.btnProvincias.Size = new System.Drawing.Size(119, 55);
            this.btnProvincias.TabIndex = 1;
            this.btnProvincias.Text = "Provincias";
            this.btnProvincias.UseVisualStyleBackColor = true;
            this.btnProvincias.Click += new System.EventHandler(this.btnProvincias_Click_1);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnProvincias);
            this.Controls.Add(this.btngeneros);
            this.Name = "FrmMenuPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btngeneros;
        private System.Windows.Forms.Button btnProvincias;
    }
}

