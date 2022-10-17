namespace UIL
{
    partial class VluchtZoeken
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
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarZoom.LargeChange = 1;
            this.trackBarZoom.Location = new System.Drawing.Point(10, 510);
            this.trackBarZoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBarZoom.Maximum = 50;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(568, 45);
            this.trackBarZoom.TabIndex = 0;
            this.trackBarZoom.ValueChanged += new System.EventHandler(this.TrackBarZoom_ValueChanged);
            // 
            // VluchtZoeken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(589, 561);
            this.Controls.Add(this.trackBarZoom);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VluchtZoeken";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VluchtZoeken";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.VluchtZoeken_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrackBar trackBarZoom;
    }
}