namespace RealTimePOS
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gunaGradientCircleButton1 = new Guna.UI.WinForms.GunaGradientCircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(112, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Punto De Venta";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(149, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // gunaGradientCircleButton1
            // 
            this.gunaGradientCircleButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientCircleButton1.AnimationSpeed = 0.03F;
            this.gunaGradientCircleButton1.BaseColor1 = System.Drawing.Color.Lavender;
            this.gunaGradientCircleButton1.BaseColor2 = System.Drawing.Color.Black;
            this.gunaGradientCircleButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientCircleButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientCircleButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientCircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaGradientCircleButton1.ForeColor = System.Drawing.Color.White;
            this.gunaGradientCircleButton1.Image = null;
            this.gunaGradientCircleButton1.ImageSize = new System.Drawing.Size(52, 52);
            this.gunaGradientCircleButton1.Location = new System.Drawing.Point(360, 10);
            this.gunaGradientCircleButton1.Name = "gunaGradientCircleButton1";
            this.gunaGradientCircleButton1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(145)))), ((int)(((byte)(221)))));
            this.gunaGradientCircleButton1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(255)))));
            this.gunaGradientCircleButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientCircleButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientCircleButton1.OnHoverImage = null;
            this.gunaGradientCircleButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientCircleButton1.Size = new System.Drawing.Size(31, 31);
            this.gunaGradientCircleButton1.TabIndex = 9;
            this.gunaGradientCircleButton1.Text = "Test";
            this.gunaGradientCircleButton1.Click += new System.EventHandler(this.gunaGradientCircleButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(403, 214);
            this.Controls.Add(this.gunaGradientCircleButton1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI.WinForms.GunaGradientCircleButton gunaGradientCircleButton1;
    }
}

