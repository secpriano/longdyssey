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
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.ButtonInsert = new System.Windows.Forms.Button();
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonViewOneById
            // 
            this.ButtonViewOneById.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonViewOneById.Location = new System.Drawing.Point(143, 686);
            this.ButtonViewOneById.Name = "ButtonViewOneById";
            this.ButtonViewOneById.Size = new System.Drawing.Size(125, 50);
            this.ButtonViewOneById.TabIndex = 21;
            this.ButtonViewOneById.Text = "View one by ID";
            this.ButtonViewOneById.UseVisualStyleBackColor = false;
            // 
            // ButtonViewAll
            // 
            this.ButtonViewAll.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonViewAll.Location = new System.Drawing.Point(12, 686);
            this.ButtonViewAll.Name = "ButtonViewAll";
            this.ButtonViewAll.Size = new System.Drawing.Size(125, 50);
            this.ButtonViewAll.TabIndex = 20;
            this.ButtonViewAll.Text = "View all";
            this.ButtonViewAll.UseVisualStyleBackColor = false;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.Red;
            this.buttonDelete.Location = new System.Drawing.Point(536, 686);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(125, 50);
            this.buttonDelete.TabIndex = 19;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.Yellow;
            this.buttonUpdate.Location = new System.Drawing.Point(405, 686);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(125, 50);
            this.buttonUpdate.TabIndex = 18;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // ButtonInsert
            // 
            this.ButtonInsert.BackColor = System.Drawing.Color.Lime;
            this.ButtonInsert.Location = new System.Drawing.Point(274, 686);
            this.ButtonInsert.Name = "ButtonInsert";
            this.ButtonInsert.Size = new System.Drawing.Size(125, 50);
            this.ButtonInsert.TabIndex = 17;
            this.ButtonInsert.Text = "Insert";
            this.ButtonInsert.UseVisualStyleBackColor = false;
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.RowHeadersWidth = 51;
            this.dataGridViewUser.RowTemplate.Height = 29;
            this.dataGridViewUser.Size = new System.Drawing.Size(649, 459);
            this.dataGridViewUser.TabIndex = 16;
            // 
            // FlightAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 748);
            this.Controls.Add(this.ButtonViewOneById);
            this.Controls.Add(this.ButtonViewAll);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.ButtonInsert);
            this.Controls.Add(this.dataGridViewUser);
            this.Name = "FlightAdmin";
            this.Text = "FlightAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button ButtonViewOneById;
        private Button ButtonViewAll;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button ButtonInsert;
        private DataGridView dataGridViewUser;
    }
}