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
            this.Informativo = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // areaDesarrollo
            // 
            this.areaDesarrollo.BackColor = System.Drawing.SystemColors.Desktop;
            this.areaDesarrollo.Font = new System.Drawing.Font("Microsoft JhengHei", 10.15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.areaDesarrollo.ForeColor = System.Drawing.SystemColors.Menu;
            this.areaDesarrollo.Location = new System.Drawing.Point(-1, 25);
            this.areaDesarrollo.Name = "areaDesarrollo";
            this.areaDesarrollo.Size = new System.Drawing.Size(1075, 512);
            this.areaDesarrollo.TabIndex = 0;
            this.areaDesarrollo.Text = "Code Here  :3";
            this.areaDesarrollo.TextChanged += new System.EventHandler(this.areaDesarrollo_textChanged);
            // 
            // Informativo
            // 
            this.Informativo.BackColor = System.Drawing.Color.Purple;
            this.Informativo.Location = new System.Drawing.Point(-1, 712);
            this.Informativo.Name = "Informativo";
            this.Informativo.ReadOnly = true;
            this.Informativo.Size = new System.Drawing.Size(1075, 22);
            this.Informativo.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox1.Location = new System.Drawing.Point(-1, 543);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1075, 163);
            this.textBox1.TabIndex = 2;
            // 
            // IDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1073, 735);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Informativo);
            this.Controls.Add(this.areaDesarrollo);
            this.Name = "IDE";
            this.Text = "CodeHere ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox areaDesarrollo;
        private System.Windows.Forms.TextBox Informativo;
        private System.Windows.Forms.TextBox textBox1;
    }
}

