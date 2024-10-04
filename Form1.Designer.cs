namespace PhoneAndTaxi
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Linea1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CopiarLinea1 = new System.Windows.Forms.Button();
            this.Linea2 = new System.Windows.Forms.GroupBox();
            this.CopiarLinea2 = new System.Windows.Forms.Button();
            this.Linea1.SuspendLayout();
            this.Linea2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Linea1
            // 
            this.Linea1.Controls.Add(this.label1);
            this.Linea1.Controls.Add(this.CopiarLinea1);
            this.Linea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Linea1.Location = new System.Drawing.Point(12, 18);
            this.Linea1.Name = "Linea1";
            this.Linea1.Size = new System.Drawing.Size(530, 180);
            this.Linea1.TabIndex = 0;
            this.Linea1.TabStop = false;
            this.Linea1.Text = "Linea 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(445, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estado";
            // 
            // CopiarLinea1
            // 
            this.CopiarLinea1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopiarLinea1.Location = new System.Drawing.Point(6, 46);
            this.CopiarLinea1.Name = "CopiarLinea1";
            this.CopiarLinea1.Size = new System.Drawing.Size(515, 105);
            this.CopiarLinea1.TabIndex = 1;
            this.CopiarLinea1.Text = "L1";
            this.CopiarLinea1.UseVisualStyleBackColor = true;
            this.CopiarLinea1.Click += new System.EventHandler(this.CopiarLinea1_Click);
            // 
            // Linea2
            // 
            this.Linea2.Controls.Add(this.CopiarLinea2);
            this.Linea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Linea2.Location = new System.Drawing.Point(548, 18);
            this.Linea2.Name = "Linea2";
            this.Linea2.Size = new System.Drawing.Size(530, 180);
            this.Linea2.TabIndex = 1;
            this.Linea2.TabStop = false;
            this.Linea2.Text = "Linea 2";
            // 
            // CopiarLinea2
            // 
            this.CopiarLinea2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopiarLinea2.Location = new System.Drawing.Point(16, 46);
            this.CopiarLinea2.Name = "CopiarLinea2";
            this.CopiarLinea2.Size = new System.Drawing.Size(515, 105);
            this.CopiarLinea2.TabIndex = 2;
            this.CopiarLinea2.Text = "L2";
            this.CopiarLinea2.UseVisualStyleBackColor = true;
            this.CopiarLinea2.Click += new System.EventHandler(this.CopiarLinea2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 215);
            this.Controls.Add(this.Linea2);
            this.Controls.Add(this.Linea1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Phone And Taxi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Linea1.ResumeLayout(false);
            this.Linea1.PerformLayout();
            this.Linea2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Linea1;
        private System.Windows.Forms.GroupBox Linea2;
        private System.Windows.Forms.Button CopiarLinea1;
        private System.Windows.Forms.Button CopiarLinea2;
        private System.Windows.Forms.Label label1;
    }
}

