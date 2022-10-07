namespace UIL
{
    partial class FlightAdmin
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
            this.ButtonViewOneById = new System.Windows.Forms.Button();
            this.ButtonViewAll = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonUpdate = new System.Windows.Forms.Button();
            this.ButtonInsert = new System.Windows.Forms.Button();
            this.dataGridViewFlight = new System.Windows.Forms.DataGridView();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboBoxOriginSpaceport = new System.Windows.Forms.ComboBox();
            this.ComboBoxOriginGate = new System.Windows.Forms.ComboBox();
            this.ComboBoxDestinationGate = new System.Windows.Forms.ComboBox();
            this.ComboBoxDestinationSpaceport = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ComboBoxSpaceship = new System.Windows.Forms.ComboBox();
            this.DateTimePickerVertrekDatum = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonViewOneById
            // 
            this.ButtonViewOneById.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonViewOneById.Location = new System.Drawing.Point(143, 685);
            this.ButtonViewOneById.Name = "ButtonViewOneById";
            this.ButtonViewOneById.Size = new System.Drawing.Size(125, 51);
            this.ButtonViewOneById.TabIndex = 21;
            this.ButtonViewOneById.Text = "View one by ID";
            this.ButtonViewOneById.UseVisualStyleBackColor = false;
            this.ButtonViewOneById.Click += new System.EventHandler(this.ButtonViewOneById_Click);
            // 
            // ButtonViewAll
            // 
            this.ButtonViewAll.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonViewAll.Location = new System.Drawing.Point(11, 685);
            this.ButtonViewAll.Name = "ButtonViewAll";
            this.ButtonViewAll.Size = new System.Drawing.Size(125, 51);
            this.ButtonViewAll.TabIndex = 20;
            this.ButtonViewAll.Text = "View all";
            this.ButtonViewAll.UseVisualStyleBackColor = false;
            this.ButtonViewAll.Click += new System.EventHandler(this.ButtonViewAll_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.BackColor = System.Drawing.Color.Red;
            this.ButtonDelete.Location = new System.Drawing.Point(536, 685);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(125, 51);
            this.ButtonDelete.TabIndex = 19;
            this.ButtonDelete.Text = "Delete";
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.BackColor = System.Drawing.Color.Yellow;
            this.ButtonUpdate.Location = new System.Drawing.Point(405, 685);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(125, 51);
            this.ButtonUpdate.TabIndex = 18;
            this.ButtonUpdate.Text = "Update";
            this.ButtonUpdate.UseVisualStyleBackColor = false;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ButtonInsert
            // 
            this.ButtonInsert.BackColor = System.Drawing.Color.Lime;
            this.ButtonInsert.Location = new System.Drawing.Point(274, 685);
            this.ButtonInsert.Name = "ButtonInsert";
            this.ButtonInsert.Size = new System.Drawing.Size(125, 51);
            this.ButtonInsert.TabIndex = 17;
            this.ButtonInsert.Text = "Insert";
            this.ButtonInsert.UseVisualStyleBackColor = false;
            this.ButtonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
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
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(40, 303);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(56, 27);
            this.numericUpDown1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Vertrek gate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Van Spaceport";
            // 
            // ComboBoxOriginSpaceport
            // 
            this.ComboBoxOriginSpaceport.FormattingEnabled = true;
            this.ComboBoxOriginSpaceport.Location = new System.Drawing.Point(112, 333);
            this.ComboBoxOriginSpaceport.Name = "ComboBoxOriginSpaceport";
            this.ComboBoxOriginSpaceport.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxOriginSpaceport.TabIndex = 26;
            this.ComboBoxOriginSpaceport.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOriginSpaceport_SelectedIndexChanged);
            // 
            // ComboBoxOriginGate
            // 
            this.ComboBoxOriginGate.FormattingEnabled = true;
            this.ComboBoxOriginGate.Location = new System.Drawing.Point(107, 367);
            this.ComboBoxOriginGate.Name = "ComboBoxOriginGate";
            this.ComboBoxOriginGate.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxOriginGate.TabIndex = 27;
            // 
            // ComboBoxDestinationGate
            // 
            this.ComboBoxDestinationGate.FormattingEnabled = true;
            this.ComboBoxDestinationGate.Location = new System.Drawing.Point(506, 367);
            this.ComboBoxDestinationGate.Name = "ComboBoxDestinationGate";
            this.ComboBoxDestinationGate.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxDestinationGate.TabIndex = 31;
            // 
            // ComboBoxDestinationSpaceport
            // 
            this.ComboBoxDestinationSpaceport.FormattingEnabled = true;
            this.ComboBoxDestinationSpaceport.Location = new System.Drawing.Point(510, 333);
            this.ComboBoxDestinationSpaceport.Name = "ComboBoxDestinationSpaceport";
            this.ComboBoxDestinationSpaceport.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxDestinationSpaceport.TabIndex = 30;
            this.ComboBoxDestinationSpaceport.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDestinationSpaceport_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(391, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Naar Spaceport";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "Aankomst gate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 457);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Select spaceship";
            // 
            // ComboBoxSpaceship
            // 
            this.ComboBoxSpaceship.FormattingEnabled = true;
            this.ComboBoxSpaceship.Location = new System.Drawing.Point(136, 453);
            this.ComboBoxSpaceship.Name = "ComboBoxSpaceship";
            this.ComboBoxSpaceship.Size = new System.Drawing.Size(151, 28);
            this.ComboBoxSpaceship.TabIndex = 33;
            // 
            // DateTimePickerVertrekDatum
            // 
            this.DateTimePickerVertrekDatum.Location = new System.Drawing.Point(116, 517);
            this.DateTimePickerVertrekDatum.MinDate = new System.DateTime(2022, 10, 7, 0, 0, 0, 0);
            this.DateTimePickerVertrekDatum.Name = "DateTimePickerVertrekDatum";
            this.DateTimePickerVertrekDatum.Size = new System.Drawing.Size(250, 27);
            this.DateTimePickerVertrekDatum.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 522);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "Vertrekdatum";
            // 
            // FlightAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 748);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DateTimePickerVertrekDatum);
            this.Controls.Add(this.ComboBoxSpaceship);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ComboBoxDestinationGate);
            this.Controls.Add(this.ComboBoxDestinationSpaceport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ComboBoxOriginGate);
            this.Controls.Add(this.ComboBoxOriginSpaceport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.ButtonViewOneById);
            this.Controls.Add(this.ButtonViewAll);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonUpdate);
            this.Controls.Add(this.ButtonInsert);
            this.Controls.Add(this.dataGridViewFlight);
            this.Name = "FlightAdmin";
            this.Text = "FlightAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button ButtonViewOneById;
        private Button ButtonViewAll;
        private Button ButtonDelete;
        private Button ButtonUpdate;
        private Button ButtonInsert;
        private DataGridView dataGridViewFlight;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox ComboBoxOriginSpaceport;
        private ComboBox ComboBoxOriginGate;
        private ComboBox ComboBoxDestinationGate;
        private ComboBox ComboBoxDestinationSpaceport;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox ComboBoxSpaceship;
        private DateTimePicker DateTimePickerVertrekDatum;
        private Label label7;
    }
}