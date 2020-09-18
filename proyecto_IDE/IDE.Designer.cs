using System;
using System.Security.Cryptography.X509Certificates;

namespace proyecto_IDE
{
    [Serializable]
    partial class IDE
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
            this.areaDesarrollo = new System.Windows.Forms.RichTextBox();
            this.txtBx_Informativo = new System.Windows.Forms.TextBox();
            this.txtBx_mensajero = new System.Windows.Forms.TextBox();
            this.lst_lineario = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarCambiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarYSalirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarPalabraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // areaDesarrollo
            // 
            this.areaDesarrollo.AcceptsTab = true;
            this.areaDesarrollo.BackColor = System.Drawing.SystemColors.Desktop;
            this.areaDesarrollo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.areaDesarrollo.Font = new System.Drawing.Font("Microsoft JhengHei", 10.15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.areaDesarrollo.ForeColor = System.Drawing.SystemColors.Window;
            this.areaDesarrollo.Location = new System.Drawing.Point(44, 25);
            this.areaDesarrollo.Name = "areaDesarrollo";
            this.areaDesarrollo.Size = new System.Drawing.Size(1030, 512);
            this.areaDesarrollo.TabIndex = 2;
            this.areaDesarrollo.Text = "Code Here  :3";
            this.areaDesarrollo.WordWrap = false;
            this.areaDesarrollo.TextChanged += new System.EventHandler(this.areaDesarrollo_textChanged);
            this.areaDesarrollo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.areaDesarrollo_KeyUp);
            this.areaDesarrollo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.areaDesarrollo_MouseMoved);
            // 
            // txtBx_Informativo
            // 
            this.txtBx_Informativo.BackColor = System.Drawing.Color.Purple;
            this.txtBx_Informativo.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBx_Informativo.ForeColor = System.Drawing.SystemColors.Menu;
            this.txtBx_Informativo.Location = new System.Drawing.Point(-1, 712);
            this.txtBx_Informativo.Name = "txtBx_Informativo";
            this.txtBx_Informativo.ReadOnly = true;
            this.txtBx_Informativo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBx_Informativo.Size = new System.Drawing.Size(1075, 23);
            this.txtBx_Informativo.TabIndex = 1;
            this.txtBx_Informativo.TabStop = false;
            this.txtBx_Informativo.Text = "Linea: 1 Columna: 0";
            // 
            // txtBx_mensajero
            // 
            this.txtBx_mensajero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.txtBx_mensajero.Font = new System.Drawing.Font("Ebrima", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBx_mensajero.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.txtBx_mensajero.Location = new System.Drawing.Point(-1, 543);
            this.txtBx_mensajero.Multiline = true;
            this.txtBx_mensajero.Name = "txtBx_mensajero";
            this.txtBx_mensajero.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBx_mensajero.Size = new System.Drawing.Size(1075, 163);
            this.txtBx_mensajero.TabIndex = 2;
            // 
            // lst_lineario
            // 
            this.lst_lineario.BackColor = System.Drawing.SystemColors.WindowText;
            this.lst_lineario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lst_lineario.Font = new System.Drawing.Font("Microsoft JhengHei", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_lineario.ForeColor = System.Drawing.Color.Violet;
            this.lst_lineario.FormattingEnabled = true;
            this.lst_lineario.ItemHeight = 22;
            this.lst_lineario.Items.AddRange(new object[] {
            "1"});
            this.lst_lineario.Location = new System.Drawing.Point(-1, 25);
            this.lst_lineario.MaximumSize = new System.Drawing.Size(39, 500);
            this.lst_lineario.MinimumSize = new System.Drawing.Size(39, 500);
            this.lst_lineario.Name = "lst_lineario";
            this.lst_lineario.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lst_lineario.Size = new System.Drawing.Size(39, 484);
            this.lst_lineario.TabIndex = 1;
            this.lst_lineario.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.acercaDeToolStripMenuItem,
            this.compilarToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1073, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarCambiosToolStripMenuItem,
            this.guardarYSalirToolStripMenuItem,
            this.exportarErroresToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.guardarToolStripMenuItem.Text = "Guardar Como";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarCambiosToolStripMenuItem
            // 
            this.guardarCambiosToolStripMenuItem.Enabled = false;
            this.guardarCambiosToolStripMenuItem.Name = "guardarCambiosToolStripMenuItem";
            this.guardarCambiosToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.guardarCambiosToolStripMenuItem.Text = "Guardar cambios";
            this.guardarCambiosToolStripMenuItem.Click += new System.EventHandler(this.guardarCambiosToolStripMenuItem_Click);
            // 
            // guardarYSalirToolStripMenuItem
            // 
            this.guardarYSalirToolStripMenuItem.Enabled = false;
            this.guardarYSalirToolStripMenuItem.Name = "guardarYSalirToolStripMenuItem";
            this.guardarYSalirToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.guardarYSalirToolStripMenuItem.Text = "Guardar y cerrar";
            // 
            // exportarErroresToolStripMenuItem
            // 
            this.exportarErroresToolStripMenuItem.Name = "exportarErroresToolStripMenuItem";
            this.exportarErroresToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exportarErroresToolStripMenuItem.Text = "ExportarErrores";
            this.exportarErroresToolStripMenuItem.Click += new System.EventHandler(this.exportarErroresToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // compilarToolStripMenuItem
            // 
            this.compilarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compilarToolStripMenuItem1});
            this.compilarToolStripMenuItem.Name = "compilarToolStripMenuItem";
            this.compilarToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.compilarToolStripMenuItem.Text = "Opciones";
            // 
            // compilarToolStripMenuItem1
            // 
            this.compilarToolStripMenuItem1.Name = "compilarToolStripMenuItem1";
            this.compilarToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.compilarToolStripMenuItem1.Text = "Compilar";
            this.compilarToolStripMenuItem1.Click += new System.EventHandler(this.compilarToolStripMenuItem1_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buscarPalabraToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // buscarPalabraToolStripMenuItem
            // 
            this.buscarPalabraToolStripMenuItem.Name = "buscarPalabraToolStripMenuItem";
            this.buscarPalabraToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.buscarPalabraToolStripMenuItem.Text = "BuscarPalabra";
            // 
            // IDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1073, 735);
            this.Controls.Add(this.lst_lineario);
            this.Controls.Add(this.txtBx_mensajero);
            this.Controls.Add(this.txtBx_Informativo);
            this.Controls.Add(this.areaDesarrollo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IDE";
            this.Text = "CodeHere ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox areaDesarrollo;
        private System.Windows.Forms.TextBox txtBx_Informativo;
        private System.Windows.Forms.TextBox txtBx_mensajero;
        private System.Windows.Forms.ListBox lst_lineario;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarCambiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarYSalirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compilarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compilarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportarErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarPalabraToolStripMenuItem;
    }
}

