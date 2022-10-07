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
            this.dataGridViewFlight = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlight)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFlight
            // 
            this.dataGridViewFlight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFlight.Location = new System.Drawing.Point(11, 12);
            this.dataGridViewFlight.Name = "dataGridViewFlight";
            this.dataGridViewFlight.RowHeadersWidth = 51;
            this.dataGridViewFlight.RowTemplate.Height = 29;
            this.dataGridViewFlight.Size = new System.Drawing.Size(649, 285);
            this.dataGridViewFlight.TabIndex = 16;
            // 
            // FlightAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 748);
            this.Controls.Add(this.dataGridViewFlight);
            this.Name = "FlightAdmin";
            this.Text = "FlightAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewFlight;
    }
}