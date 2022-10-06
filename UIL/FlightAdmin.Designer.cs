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
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonViewOneById
            // 
            this.ButtonViewOneById.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonViewOneById.Location = new System.Drawing.Point(125, 514);
            this.ButtonViewOneById.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonViewOneById.Name = "ButtonViewOneById";
            this.ButtonViewOneById.Size = new System.Drawing.Size(109, 38);
            this.ButtonViewOneById.TabIndex = 21;
            this.ButtonViewOneById.Text = "View one by ID";
            this.ButtonViewOneById.UseVisualStyleBackColor = false;
            this.ButtonViewOneById.Click += new System.EventHandler(this.ButtonViewOneById_Click);
            // 
            // ButtonViewAll
            // 
            this.ButtonViewAll.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonViewAll.Location = new System.Drawing.Point(10, 514);
            this.ButtonViewAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonViewAll.Name = "ButtonViewAll";
            this.ButtonViewAll.Size = new System.Drawing.Size(109, 38);
            this.ButtonViewAll.TabIndex = 20;
            this.ButtonViewAll.Text = "View all";
            this.ButtonViewAll.UseVisualStyleBackColor = false;
            this.ButtonViewAll.Click += new System.EventHandler(this.ButtonViewAll_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.BackColor = System.Drawing.Color.Red;
            this.ButtonDelete.Location = new System.Drawing.Point(469, 514);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(109, 38);
            this.ButtonDelete.TabIndex = 19;
            this.ButtonDelete.Text = "Delete";
            this.ButtonDelete.UseVisualStyleBackColor = false;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonUpdate
            // 
            this.ButtonUpdate.BackColor = System.Drawing.Color.Yellow;
            this.ButtonUpdate.Location = new System.Drawing.Point(354, 514);
            this.ButtonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonUpdate.Name = "ButtonUpdate";
            this.ButtonUpdate.Size = new System.Drawing.Size(109, 38);
            this.ButtonUpdate.TabIndex = 18;
            this.ButtonUpdate.Text = "Update";
            this.ButtonUpdate.UseVisualStyleBackColor = false;
            this.ButtonUpdate.Click += new System.EventHandler(this.ButtonUpdate_Click);
            // 
            // ButtonInsert
            // 
            this.ButtonInsert.BackColor = System.Drawing.Color.Lime;
            this.ButtonInsert.Location = new System.Drawing.Point(240, 514);
            this.ButtonInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ButtonInsert.Name = "ButtonInsert";
            this.ButtonInsert.Size = new System.Drawing.Size(109, 38);
            this.ButtonInsert.TabIndex = 17;
            this.ButtonInsert.Text = "Insert";
            this.ButtonInsert.UseVisualStyleBackColor = false;
            this.ButtonInsert.Click += new System.EventHandler(this.ButtonInsert_Click);
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Location = new System.Drawing.Point(10, 9);
            this.dataGridViewUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.RowHeadersWidth = 51;
            this.dataGridViewUser.RowTemplate.Height = 29;
            this.dataGridViewUser.Size = new System.Drawing.Size(568, 214);
            this.dataGridViewUser.TabIndex = 16;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(35, 227);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(49, 23);
            this.numericUpDown1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Vertrek gate";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Van Spaceport";
            // 
            // ComboBoxOriginSpaceport
            // 
            this.ComboBoxOriginSpaceport.FormattingEnabled = true;
            this.ComboBoxOriginSpaceport.Location = new System.Drawing.Point(98, 250);
            this.ComboBoxOriginSpaceport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ComboBoxOriginSpaceport.Name = "ComboBoxOriginSpaceport";
            this.ComboBoxOriginSpaceport.Size = new System.Drawing.Size(133, 23);
            this.ComboBoxOriginSpaceport.TabIndex = 26;
            this.ComboBoxOriginSpaceport.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOriginSpaceport_SelectedIndexChanged);
            // 
            // ComboBoxOriginGate
            // 
            this.ComboBoxOriginGate.FormattingEnabled = true;
            this.ComboBoxOriginGate.Location = new System.Drawing.Point(94, 275);
            this.ComboBoxOriginGate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ComboBoxOriginGate.Name = "ComboBoxOriginGate";
            this.ComboBoxOriginGate.Size = new System.Drawing.Size(133, 23);
            this.ComboBoxOriginGate.TabIndex = 27;
            // 
            // ComboBoxDestinationGate
            // 
            this.ComboBoxDestinationGate.FormattingEnabled = true;
            this.ComboBoxDestinationGate.Location = new System.Drawing.Point(443, 275);
            this.ComboBoxDestinationGate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ComboBoxDestinationGate.Name = "ComboBoxDestinationGate";
            this.ComboBoxDestinationGate.Size = new System.Drawing.Size(133, 23);
            this.ComboBoxDestinationGate.TabIndex = 31;
            // 
            // ComboBoxDestinationSpaceport
            // 
            this.ComboBoxDestinationSpaceport.FormattingEnabled = true;
            this.ComboBoxDestinationSpaceport.Location = new System.Drawing.Point(446, 250);
            this.ComboBoxDestinationSpaceport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ComboBoxDestinationSpaceport.Name = "ComboBoxDestinationSpaceport";
            this.ComboBoxDestinationSpaceport.Size = new System.Drawing.Size(133, 23);
            this.ComboBoxDestinationSpaceport.TabIndex = 30;
            this.ComboBoxDestinationSpaceport.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDestinationSpaceport_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(342, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Naar Spaceport";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(342, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 28;
            this.label5.Text = "Aankomst gate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "Select spaceship";
            // 
            // ComboBoxSpaceship
            // 
            this.ComboBoxSpaceship.FormattingEnabled = true;
            this.ComboBoxSpaceship.Location = new System.Drawing.Point(119, 340);
            this.ComboBoxSpaceship.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ComboBoxSpaceship.Name = "ComboBoxSpaceship";
            this.ComboBoxSpaceship.Size = new System.Drawing.Size(133, 23);
            this.ComboBoxSpaceship.TabIndex = 33;
            // 
            // FlightAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 561);
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
            this.Controls.Add(this.dataGridViewUser);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FlightAdmin";
            this.Text = "FlightAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
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
        private DataGridView dataGridViewUser;
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
    }
}