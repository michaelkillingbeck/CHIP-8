namespace CHIP8.WinForms
{
    partial class frmMain
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
            this.btnLoadRom = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.picScreen = new CHIP8.WinForms.CustomPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadRom
            // 
            this.btnLoadRom.Location = new System.Drawing.Point(9, 12);
            this.btnLoadRom.Name = "btnLoadRom";
            this.btnLoadRom.Size = new System.Drawing.Size(109, 23);
            this.btnLoadRom.TabIndex = 0;
            this.btnLoadRom.Text = "Load ROM";
            this.btnLoadRom.UseVisualStyleBackColor = true;
            this.btnLoadRom.Click += new System.EventHandler(this.btnLoadRom_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(540, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(109, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // picScreen
            // 
            this.picScreen.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.picScreen.Location = new System.Drawing.Point(9, 41);
            this.picScreen.Name = "picScreen";
            this.picScreen.Size = new System.Drawing.Size(640, 320);
            this.picScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picScreen.TabIndex = 2;
            this.picScreen.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 371);
            this.Controls.Add(this.picScreen);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnLoadRom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "CHIP-8";
            ((System.ComponentModel.ISupportInitialize)(this.picScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadRom;
        private System.Windows.Forms.Button btnReset;
        private CustomPictureBox picScreen;
    }
}

