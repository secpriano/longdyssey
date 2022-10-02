namespace UIL
{
    partial class Dashboard
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
            this.ButtonVluchtZoeken = new System.Windows.Forms.Button();
            this.ButtonVluchtAdmin = new System.Windows.Forms.Button();
            this.ButtonSpaceshipAdmin = new System.Windows.Forms.Button();
            this.buttonSpaceportAdmin = new System.Windows.Forms.Button();
            this.ButtonUserAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonVluchtZoeken
            // 
            this.ButtonVluchtZoeken.Location = new System.Drawing.Point(12, 68);
            this.ButtonVluchtZoeken.Name = "ButtonVluchtZoeken";
            this.ButtonVluchtZoeken.Size = new System.Drawing.Size(125, 50);
            this.ButtonVluchtZoeken.TabIndex = 0;
            this.ButtonVluchtZoeken.Text = "Vlucht zoeken";
            this.ButtonVluchtZoeken.UseVisualStyleBackColor = true;
            this.ButtonVluchtZoeken.Click += new System.EventHandler(this.ButtonVluchtZoeken_Click);
            // 
            // ButtonVluchtAdmin
            // 
            this.ButtonVluchtAdmin.Location = new System.Drawing.Point(344, 12);
            this.ButtonVluchtAdmin.Name = "ButtonVluchtAdmin";
            this.ButtonVluchtAdmin.Size = new System.Drawing.Size(125, 50);
            this.ButtonVluchtAdmin.TabIndex = 1;
            this.ButtonVluchtAdmin.Text = "Vlucht beheer";
            this.ButtonVluchtAdmin.UseVisualStyleBackColor = true;
            this.ButtonVluchtAdmin.Click += new System.EventHandler(this.ButtonVluchtAdmin_Click);
            // 
            // ButtonSpaceshipAdmin
            // 
            this.ButtonSpaceshipAdmin.Location = new System.Drawing.Point(12, 12);
            this.ButtonSpaceshipAdmin.Name = "ButtonSpaceshipAdmin";
            this.ButtonSpaceshipAdmin.Size = new System.Drawing.Size(160, 50);
            this.ButtonSpaceshipAdmin.TabIndex = 2;
            this.ButtonSpaceshipAdmin.Text = "Ruimte schip beheer";
            this.ButtonSpaceshipAdmin.UseVisualStyleBackColor = true;
            this.ButtonSpaceshipAdmin.Click += new System.EventHandler(this.ButtonSpaceshipAdmin_Click);
            // 
            // buttonSpaceportAdmin
            // 
            this.buttonSpaceportAdmin.Location = new System.Drawing.Point(178, 12);
            this.buttonSpaceportAdmin.Name = "buttonSpaceportAdmin";
            this.buttonSpaceportAdmin.Size = new System.Drawing.Size(160, 50);
            this.buttonSpaceportAdmin.TabIndex = 3;
            this.buttonSpaceportAdmin.Text = "Spaceport beheer";
            this.buttonSpaceportAdmin.UseVisualStyleBackColor = true;
            this.buttonSpaceportAdmin.Click += new System.EventHandler(this.ButtonSpaceportAdmin_Click);
            // 
            // ButtonUserAdmin
            // 
            this.ButtonUserAdmin.Location = new System.Drawing.Point(475, 12);
            this.ButtonUserAdmin.Name = "ButtonUserAdmin";
            this.ButtonUserAdmin.Size = new System.Drawing.Size(135, 50);
            this.ButtonUserAdmin.TabIndex = 4;
            this.ButtonUserAdmin.Text = "Gebruiker beheer";
            this.ButtonUserAdmin.UseVisualStyleBackColor = true;
            this.ButtonUserAdmin.Click += new System.EventHandler(this.ButtonUserAdmin_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 129);
            this.Controls.Add(this.ButtonUserAdmin);
            this.Controls.Add(this.buttonSpaceportAdmin);
            this.Controls.Add(this.ButtonSpaceshipAdmin);
            this.Controls.Add(this.ButtonVluchtAdmin);
            this.Controls.Add(this.ButtonVluchtZoeken);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private Button ButtonVluchtZoeken;
        private Button ButtonVluchtAdmin;
        private Button ButtonSpaceshipAdmin;
        private Button buttonSpaceportAdmin;
        private Button ButtonUserAdmin;
    }
}