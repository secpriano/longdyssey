namespace UIL
{
    partial class Dienstregeling
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
            this.ButtonGenerateSchedule = new System.Windows.Forms.Button();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.comboBoxSpaceships = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarZoom.LargeChange = 1;
            this.trackBarZoom.Location = new System.Drawing.Point(141, 510);
            this.trackBarZoom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBarZoom.Maximum = 100;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Size = new System.Drawing.Size(298, 45);
            this.trackBarZoom.SmallChange = 2;
            this.trackBarZoom.TabIndex = 0;
            this.trackBarZoom.ValueChanged += new System.EventHandler(this.TrackBarZoom_ValueChanged);
            // 
            // ButtonGenerateSchedule
            // 
            this.ButtonGenerateSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGenerateSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonGenerateSchedule.Location = new System.Drawing.Point(452, 12);
            this.ButtonGenerateSchedule.Name = "ButtonGenerateSchedule";
            this.ButtonGenerateSchedule.Size = new System.Drawing.Size(125, 50);
            this.ButtonGenerateSchedule.TabIndex = 1;
            this.ButtonGenerateSchedule.Text = "Generate Schedule";
            this.ButtonGenerateSchedule.UseVisualStyleBackColor = true;
            this.ButtonGenerateSchedule.Click += new System.EventHandler(this.ButtonGenerateSchedule_Click);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(239, 24);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(200, 23);
            this.dateTimePickerStartDate.TabIndex = 2;
            // 
            // comboBoxSpaceships
            // 
            this.comboBoxSpaceships.FormattingEnabled = true;
            this.comboBoxSpaceships.Location = new System.Drawing.Point(112, 24);
            this.comboBoxSpaceships.Name = "comboBoxSpaceships";
            this.comboBoxSpaceships.Size = new System.Drawing.Size(121, 23);
            this.comboBoxSpaceships.TabIndex = 3;
            // 
            // VluchtZoeken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(589, 561);
            this.Controls.Add(this.comboBoxSpaceships);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.ButtonGenerateSchedule);
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
        private Button ButtonGenerateSchedule;
        private DateTimePicker dateTimePickerStartDate;
        private ComboBox comboBoxSpaceships;
    }
}