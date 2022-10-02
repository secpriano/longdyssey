namespace UIL
{
    partial class UserAdmin
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
            this.dataGridViewUser = new System.Windows.Forms.DataGridView();
            this.ButtonCreateUser = new System.Windows.Forms.Button();
            this.buttonUpdateUser = new System.Windows.Forms.Button();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.numericUpDownId = new System.Windows.Forms.NumericUpDown();
            this.labelId = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.ButtonViewAll = new System.Windows.Forms.Button();
            this.ButtonViewOneById = new System.Windows.Forms.Button();
            this.labelSpaceMiles = new System.Windows.Forms.Label();
            this.numericUpDownSpaceMiles = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpaceMiles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUser
            // 
            this.dataGridViewUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUser.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewUser.Name = "dataGridViewUser";
            this.dataGridViewUser.RowHeadersWidth = 51;
            this.dataGridViewUser.RowTemplate.Height = 29;
            this.dataGridViewUser.Size = new System.Drawing.Size(649, 459);
            this.dataGridViewUser.TabIndex = 0;
            // 
            // ButtonCreateUser
            // 
            this.ButtonCreateUser.BackColor = System.Drawing.Color.Lime;
            this.ButtonCreateUser.Location = new System.Drawing.Point(274, 686);
            this.ButtonCreateUser.Name = "ButtonCreateUser";
            this.ButtonCreateUser.Size = new System.Drawing.Size(125, 50);
            this.ButtonCreateUser.TabIndex = 1;
            this.ButtonCreateUser.Text = "Insert user";
            this.ButtonCreateUser.UseVisualStyleBackColor = false;
            this.ButtonCreateUser.Click += new System.EventHandler(this.ButtonCreateUser_Click);
            // 
            // buttonUpdateUser
            // 
            this.buttonUpdateUser.BackColor = System.Drawing.Color.Yellow;
            this.buttonUpdateUser.Location = new System.Drawing.Point(405, 686);
            this.buttonUpdateUser.Name = "buttonUpdateUser";
            this.buttonUpdateUser.Size = new System.Drawing.Size(125, 50);
            this.buttonUpdateUser.TabIndex = 2;
            this.buttonUpdateUser.Text = "Update user";
            this.buttonUpdateUser.UseVisualStyleBackColor = false;
            this.buttonUpdateUser.Click += new System.EventHandler(this.ButtonUpdateUser_Click);
            // 
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.BackColor = System.Drawing.Color.Red;
            this.buttonDeleteUser.Location = new System.Drawing.Point(536, 686);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(125, 50);
            this.buttonDeleteUser.TabIndex = 3;
            this.buttonDeleteUser.Text = "Delete user";
            this.buttonDeleteUser.UseVisualStyleBackColor = false;
            this.buttonDeleteUser.Click += new System.EventHandler(this.ButtonDeleteUser_Click);
            // 
            // numericUpDownId
            // 
            this.numericUpDownId.Location = new System.Drawing.Point(143, 481);
            this.numericUpDownId.Name = "numericUpDownId";
            this.numericUpDownId.Size = new System.Drawing.Size(68, 27);
            this.numericUpDownId.TabIndex = 4;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelId.Location = new System.Drawing.Point(12, 476);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(29, 28);
            this.labelId.TabIndex = 5;
            this.labelId.Text = "Id";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(12, 504);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(101, 28);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "FirstName";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAddress.Location = new System.Drawing.Point(12, 532);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(98, 28);
            this.labelAddress.TabIndex = 7;
            this.labelAddress.Text = "LastName";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.Location = new System.Drawing.Point(12, 560);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(59, 28);
            this.labelEmail.TabIndex = 8;
            this.labelEmail.Text = "Email";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(143, 509);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(168, 27);
            this.textBoxFirstName.TabIndex = 9;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(143, 537);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(168, 27);
            this.textBoxLastName.TabIndex = 10;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(143, 565);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(168, 27);
            this.textBoxEmail.TabIndex = 11;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPassword.Location = new System.Drawing.Point(12, 588);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(93, 28);
            this.labelPassword.TabIndex = 12;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(143, 592);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(168, 27);
            this.textBoxPassword.TabIndex = 13;
            // 
            // ButtonViewAll
            // 
            this.ButtonViewAll.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonViewAll.Location = new System.Drawing.Point(12, 686);
            this.ButtonViewAll.Name = "ButtonViewAll";
            this.ButtonViewAll.Size = new System.Drawing.Size(125, 50);
            this.ButtonViewAll.TabIndex = 14;
            this.ButtonViewAll.Text = "View all";
            this.ButtonViewAll.UseVisualStyleBackColor = false;
            this.ButtonViewAll.Click += new System.EventHandler(this.ButtonViewAll_Click);
            // 
            // ButtonViewOneById
            // 
            this.ButtonViewOneById.BackColor = System.Drawing.SystemColors.Control;
            this.ButtonViewOneById.Location = new System.Drawing.Point(143, 686);
            this.ButtonViewOneById.Name = "ButtonViewOneById";
            this.ButtonViewOneById.Size = new System.Drawing.Size(125, 50);
            this.ButtonViewOneById.TabIndex = 15;
            this.ButtonViewOneById.Text = "View one by ID";
            this.ButtonViewOneById.UseVisualStyleBackColor = false;
            this.ButtonViewOneById.Click += new System.EventHandler(this.ButtonViewOneById_Click);
            // 
            // labelSpaceMiles
            // 
            this.labelSpaceMiles.AutoSize = true;
            this.labelSpaceMiles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSpaceMiles.Location = new System.Drawing.Point(12, 616);
            this.labelSpaceMiles.Name = "labelSpaceMiles";
            this.labelSpaceMiles.Size = new System.Drawing.Size(114, 28);
            this.labelSpaceMiles.TabIndex = 16;
            this.labelSpaceMiles.Text = "Space miles";
            // 
            // numericUpDownSpaceMiles
            // 
            this.numericUpDownSpaceMiles.Location = new System.Drawing.Point(143, 621);
            this.numericUpDownSpaceMiles.Name = "numericUpDownSpaceMiles";
            this.numericUpDownSpaceMiles.Size = new System.Drawing.Size(168, 27);
            this.numericUpDownSpaceMiles.TabIndex = 17;
            // 
            // UserAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 748);
            this.Controls.Add(this.numericUpDownSpaceMiles);
            this.Controls.Add(this.labelSpaceMiles);
            this.Controls.Add(this.ButtonViewOneById);
            this.Controls.Add(this.ButtonViewAll);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.numericUpDownId);
            this.Controls.Add(this.buttonDeleteUser);
            this.Controls.Add(this.buttonUpdateUser);
            this.Controls.Add(this.ButtonCreateUser);
            this.Controls.Add(this.dataGridViewUser);
            this.Name = "UserAdmin";
            this.Text = "VluchtCRUD";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpaceMiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewUser;
        private Button ButtonCreateUser;
        private Button buttonUpdateUser;
        private Button buttonDeleteUser;
        private NumericUpDown numericUpDownId;
        private Label labelId;
        private Label labelName;
        private Label labelAddress;
        private Label labelEmail;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxEmail;
        private Label labelPassword;
        private TextBox textBoxPassword;
        private Button ButtonViewAll;
        private Button ButtonViewOneById;
        private Label labelSpaceMiles;
        private NumericUpDown numericUpDownSpaceMiles;
    }
}