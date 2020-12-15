namespace WindowsFormsApplication1
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.logOut = new System.Windows.Forms.Button();
            this.addGuard = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.showGuards = new System.Windows.Forms.Button();
            this.deleteGuard = new System.Windows.Forms.Button();
            this.updateGuard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // logOut
            // 
            this.logOut.BackColor = System.Drawing.Color.Yellow;
            this.logOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.logOut.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOut.ForeColor = System.Drawing.Color.White;
            this.logOut.Image = ((System.Drawing.Image)(resources.GetObject("logOut.Image")));
            this.logOut.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.logOut.Location = new System.Drawing.Point(339, 235);
            this.logOut.Margin = new System.Windows.Forms.Padding(2);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(91, 44);
            this.logOut.TabIndex = 0;
            this.logOut.Text = "LOGOUT";
            this.logOut.UseVisualStyleBackColor = false;
            this.logOut.Click += new System.EventHandler(this.deleteGuard_Click);
            // 
            // addGuard
            // 
            this.addGuard.BackColor = System.Drawing.Color.Yellow;
            this.addGuard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addGuard.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addGuard.ForeColor = System.Drawing.Color.White;
            this.addGuard.Image = ((System.Drawing.Image)(resources.GetObject("addGuard.Image")));
            this.addGuard.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.addGuard.Location = new System.Drawing.Point(9, 225);
            this.addGuard.Margin = new System.Windows.Forms.Padding(2);
            this.addGuard.Name = "addGuard";
            this.addGuard.Size = new System.Drawing.Size(91, 55);
            this.addGuard.TabIndex = 0;
            this.addGuard.Text = "ADD GUARD";
            this.addGuard.UseVisualStyleBackColor = false;
            this.addGuard.Click += new System.EventHandler(this.addGuard_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridView1.Location = new System.Drawing.Point(9, 10);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(302, 193);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // showGuards
            // 
            this.showGuards.BackColor = System.Drawing.Color.Yellow;
            this.showGuards.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showGuards.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showGuards.ForeColor = System.Drawing.Color.White;
            this.showGuards.Image = ((System.Drawing.Image)(resources.GetObject("showGuards.Image")));
            this.showGuards.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.showGuards.Location = new System.Drawing.Point(339, 23);
            this.showGuards.Margin = new System.Windows.Forms.Padding(2);
            this.showGuards.Name = "showGuards";
            this.showGuards.Size = new System.Drawing.Size(91, 45);
            this.showGuards.TabIndex = 2;
            this.showGuards.Text = "SHOW GUARDS";
            this.showGuards.UseVisualStyleBackColor = false;
            this.showGuards.Click += new System.EventHandler(this.showGuards_Click);
            // 
            // deleteGuard
            // 
            this.deleteGuard.BackColor = System.Drawing.Color.Yellow;
            this.deleteGuard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteGuard.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteGuard.ForeColor = System.Drawing.Color.White;
            this.deleteGuard.Image = ((System.Drawing.Image)(resources.GetObject("deleteGuard.Image")));
            this.deleteGuard.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.deleteGuard.Location = new System.Drawing.Point(115, 225);
            this.deleteGuard.Margin = new System.Windows.Forms.Padding(2);
            this.deleteGuard.Name = "deleteGuard";
            this.deleteGuard.Size = new System.Drawing.Size(91, 55);
            this.deleteGuard.TabIndex = 0;
            this.deleteGuard.Text = "DELETE GUARD";
            this.deleteGuard.UseVisualStyleBackColor = false;
            this.deleteGuard.Click += new System.EventHandler(this.deleteGuard_Click_1);
            // 
            // updateGuard
            // 
            this.updateGuard.BackColor = System.Drawing.Color.Yellow;
            this.updateGuard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.updateGuard.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateGuard.ForeColor = System.Drawing.Color.White;
            this.updateGuard.Image = ((System.Drawing.Image)(resources.GetObject("updateGuard.Image")));
            this.updateGuard.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.updateGuard.Location = new System.Drawing.Point(220, 225);
            this.updateGuard.Margin = new System.Windows.Forms.Padding(2);
            this.updateGuard.Name = "updateGuard";
            this.updateGuard.Size = new System.Drawing.Size(91, 54);
            this.updateGuard.TabIndex = 3;
            this.updateGuard.Text = "UPDATE GUARD";
            this.updateGuard.UseVisualStyleBackColor = false;
            this.updateGuard.Click += new System.EventHandler(this.updateGuard_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(439, 289);
            this.Controls.Add(this.updateGuard);
            this.Controls.Add(this.showGuards);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.addGuard);
            this.Controls.Add(this.deleteGuard);
            this.Controls.Add(this.logOut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Window";
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button logOut;
        private System.Windows.Forms.Button addGuard;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button showGuards;
        private System.Windows.Forms.Button deleteGuard;
        private System.Windows.Forms.Button updateGuard;
    }
}