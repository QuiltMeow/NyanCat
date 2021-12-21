namespace Nyan_Cat
{
    partial class NyanInfo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NyanInfo));
            this.labelNyan = new System.Windows.Forms.Label();
            this.timerNyan = new System.Windows.Forms.Timer(this.components);
            this.labelLowerVolume = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNyan
            // 
            this.labelNyan.AutoSize = true;
            this.labelNyan.BackColor = System.Drawing.Color.Transparent;
            this.labelNyan.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNyan.ForeColor = System.Drawing.Color.White;
            this.labelNyan.Location = new System.Drawing.Point(30, 45);
            this.labelNyan.Name = "labelNyan";
            this.labelNyan.Size = new System.Drawing.Size(55, 15);
            this.labelNyan.TabIndex = 1;
            this.labelNyan.Text = "等待中 ...";
            // 
            // timerNyan
            // 
            this.timerNyan.Enabled = true;
            this.timerNyan.Tick += new System.EventHandler(this.timerNyan_Tick);
            // 
            // labelLowerVolume
            // 
            this.labelLowerVolume.AutoSize = true;
            this.labelLowerVolume.BackColor = System.Drawing.Color.Transparent;
            this.labelLowerVolume.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLowerVolume.ForeColor = System.Drawing.Color.LightBlue;
            this.labelLowerVolume.Location = new System.Drawing.Point(55, 70);
            this.labelLowerVolume.Name = "labelLowerVolume";
            this.labelLowerVolume.Size = new System.Drawing.Size(46, 15);
            this.labelLowerVolume.TabIndex = 2;
            this.labelLowerVolume.Text = "小聲點 ";
            this.labelLowerVolume.MouseClick += new System.Windows.Forms.MouseEventHandler(this.labelLowerVolume_MouseClick);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Gold;
            this.labelTitle.Location = new System.Drawing.Point(25, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(150, 16);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "NON - STOP NYAN CAT";
            // 
            // NyanInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(200, 100);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelLowerVolume);
            this.Controls.Add(this.labelNyan);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NyanInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Nyan Info";
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NyanInfo_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NyanInfo_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNyan;
        private System.Windows.Forms.Timer timerNyan;
        private System.Windows.Forms.Label labelLowerVolume;
        private System.Windows.Forms.Label labelTitle;
    }
}