using System.Security.Cryptography.X509Certificates;

namespace proyecto_IDE
{
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
            this.txtBx_mensajero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
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
            this.lst_lineario.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_lineario.ForeColor = System.Drawing.Color.Purple;
            this.lst_lineario.FormattingEnabled = true;
            this.lst_lineario.ItemHeight = 20;
            this.lst_lineario.Items.AddRange(new object[] {
            "1"});
            this.lst_lineario.Location = new System.Drawing.Point(-1, 21);
            this.lst_lineario.MaximumSize = new System.Drawing.Size(39, 500);
            this.lst_lineario.MinimumSize = new System.Drawing.Size(39, 500);
            this.lst_lineario.Name = "lst_lineario";
            this.lst_lineario.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lst_lineario.Size = new System.Drawing.Size(39, 500);
            this.lst_lineario.TabIndex = 1;
            this.lst_lineario.TabStop = false;
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
            this.Name = "IDE";
            this.Text = "CodeHere ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox areaDesarrollo;
        private System.Windows.Forms.TextBox txtBx_Informativo;
        private System.Windows.Forms.TextBox txtBx_mensajero;
        private System.Windows.Forms.ListBox lst_lineario;
    }
}

