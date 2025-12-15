namespace Course_Project.Forms
{
    partial class UsersForm
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.lblFN = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.lblLN = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblU = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblR = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnResetPass = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(2, 2);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(532, 448);
            this.dgvUsers.TabIndex = 0;
            // 
            // lblFN
            // 
            this.lblFN.AutoSize = true;
            this.lblFN.Location = new System.Drawing.Point(571, 13);
            this.lblFN.Name = "lblFN";
            this.lblFN.Size = new System.Drawing.Size(26, 13);
            this.lblFN.TabIndex = 1;
            this.lblFN.Text = "Ім\'я";
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(574, 29);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(124, 20);
            this.txtFirstname.TabIndex = 2;
            // 
            // lblLN
            // 
            this.lblLN.AutoSize = true;
            this.lblLN.Location = new System.Drawing.Point(571, 65);
            this.lblLN.Name = "lblLN";
            this.lblLN.Size = new System.Drawing.Size(56, 13);
            this.lblLN.TabIndex = 3;
            this.lblLN.Text = "Прізвище";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(574, 91);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(124, 20);
            this.txtLastName.TabIndex = 4;
            // 
            // lblU
            // 
            this.lblU.AutoSize = true;
            this.lblU.Location = new System.Drawing.Point(571, 125);
            this.lblU.Name = "lblU";
            this.lblU.Size = new System.Drawing.Size(34, 13);
            this.lblU.TabIndex = 5;
            this.lblU.Text = "Логін";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(574, 153);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(124, 20);
            this.txtUsername.TabIndex = 6;
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Location = new System.Drawing.Point(574, 192);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(45, 13);
            this.lblR.TabIndex = 7;
            this.lblR.Text = "Пароль";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(577, 282);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Додати";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(577, 324);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(97, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Вилучити";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnResetPass
            // 
            this.btnResetPass.Location = new System.Drawing.Point(577, 365);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(97, 23);
            this.btnResetPass.TabIndex = 11;
            this.btnResetPass.Text = "Скинути пароль";
            this.btnResetPass.UseVisualStyleBackColor = true;
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(574, 225);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(124, 20);
            this.txtPassword.TabIndex = 12;
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnResetPass);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblR);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblU);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLN);
            this.Controls.Add(this.txtFirstname);
            this.Controls.Add(this.lblFN);
            this.Controls.Add(this.dgvUsers);
            this.Name = "UsersForm";
            this.Text = "UsersForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label lblFN;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Label lblLN;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblU;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.TextBox txtPassword;
    }
}