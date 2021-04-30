
namespace SistemaDeVideoClub.Windows
{
    partial class FrmDetalleAlquiler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DatosDataGridView = new System.Windows.Forms.DataGridView();
            this.cmnPelicula = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnPrecioAlquiler = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmnSocio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalPedido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DatosDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtTotalPedido);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Size = new System.Drawing.Size(531, 450);
            this.splitContainer1.SplitterDistance = 381;
            this.splitContainer1.TabIndex = 2;
            // 
            // DatosDataGridView
            // 
            this.DatosDataGridView.AllowUserToAddRows = false;
            this.DatosDataGridView.AllowUserToDeleteRows = false;
            this.DatosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmnPelicula,
            this.cmnPrecioAlquiler,
            this.cmnCodigo,
            this.cmnSocio});
            this.DatosDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatosDataGridView.Location = new System.Drawing.Point(0, 0);
            this.DatosDataGridView.MultiSelect = false;
            this.DatosDataGridView.Name = "DatosDataGridView";
            this.DatosDataGridView.ReadOnly = true;
            this.DatosDataGridView.RowHeadersVisible = false;
            this.DatosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DatosDataGridView.Size = new System.Drawing.Size(531, 381);
            this.DatosDataGridView.TabIndex = 64;
            // 
            // cmnPelicula
            // 
            this.cmnPelicula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cmnPelicula.HeaderText = "Pelicula";
            this.cmnPelicula.Name = "cmnPelicula";
            this.cmnPelicula.ReadOnly = true;
            // 
            // cmnPrecioAlquiler
            // 
            this.cmnPrecioAlquiler.HeaderText = "Precio de Alquiler";
            this.cmnPrecioAlquiler.Name = "cmnPrecioAlquiler";
            this.cmnPrecioAlquiler.ReadOnly = true;
            // 
            // cmnCodigo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnCodigo.DefaultCellStyle = dataGridViewCellStyle1;
            this.cmnCodigo.HeaderText = "Codigo";
            this.cmnCodigo.Name = "cmnCodigo";
            this.cmnCodigo.ReadOnly = true;
            // 
            // cmnSocio
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cmnSocio.DefaultCellStyle = dataGridViewCellStyle2;
            this.cmnSocio.HeaderText = "Socio";
            this.cmnSocio.Name = "cmnSocio";
            this.cmnSocio.ReadOnly = true;
            // 
            // txtTotalPedido
            // 
            this.txtTotalPedido.Location = new System.Drawing.Point(849, 19);
            this.txtTotalPedido.Name = "txtTotalPedido";
            this.txtTotalPedido.ReadOnly = true;
            this.txtTotalPedido.Size = new System.Drawing.Size(104, 20);
            this.txtTotalPedido.TabIndex = 67;
            this.txtTotalPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(798, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Total:";
            // 
            // FrmDetalleAlquiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmDetalleAlquiler";
            this.Text = "FrmDetalleAlquiler";
            this.Load += new System.EventHandler(this.FrmDetalleAlquiler_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DatosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView DatosDataGridView;
        private System.Windows.Forms.TextBox txtTotalPedido;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPelicula;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnPrecioAlquiler;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmnSocio;
    }
}