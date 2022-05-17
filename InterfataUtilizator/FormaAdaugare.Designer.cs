namespace InterfataUtilizator
{
    partial class FormaAdaugare
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIdMasina = new System.Windows.Forms.Label();
            this.btnAdaugaMasina = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCompanii = new System.Windows.Forms.ComboBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtPret = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdaugaComp = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblIdMasina);
            this.groupBox1.Controls.Add(this.btnAdaugaMasina);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbCompanii);
            this.groupBox1.Controls.Add(this.txtModel);
            this.groupBox1.Controls.Add(this.txtPret);
            this.groupBox1.Controls.Add(this.txtData);
            this.groupBox1.Location = new System.Drawing.Point(16, 246);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(525, 194);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adaugare masina";
            // 
            // lblIdMasina
            // 
            this.lblIdMasina.AutoSize = true;
            this.lblIdMasina.Location = new System.Drawing.Point(575, 85);
            this.lblIdMasina.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdMasina.Name = "lblIdMasina";
            this.lblIdMasina.Size = new System.Drawing.Size(0, 17);
            this.lblIdMasina.TabIndex = 9;
            this.lblIdMasina.Visible = false;
            // 
            // btnAdaugaMasina
            // 
            this.btnAdaugaMasina.Location = new System.Drawing.Point(403, 143);
            this.btnAdaugaMasina.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdaugaMasina.Name = "btnAdaugaMasina";
            this.btnAdaugaMasina.Size = new System.Drawing.Size(100, 28);
            this.btnAdaugaMasina.TabIndex = 8;
            this.btnAdaugaMasina.Text = "Adauga";
            this.btnAdaugaMasina.UseVisualStyleBackColor = true;
            this.btnAdaugaMasina.Click += new System.EventHandler(this.btnAdaugaMasina_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 156);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Pret";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Companie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data Fabricatie";
            // 
            // cmbCompanii
            // 
            this.cmbCompanii.FormattingEnabled = true;
            this.cmbCompanii.Location = new System.Drawing.Point(151, 63);
            this.cmbCompanii.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCompanii.Name = "cmbCompanii";
            this.cmbCompanii.Size = new System.Drawing.Size(219, 24);
            this.cmbCompanii.TabIndex = 3;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(151, 106);
            this.txtModel.Margin = new System.Windows.Forms.Padding(4);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(219, 22);
            this.txtModel.TabIndex = 2;
            // 
            // txtPret
            // 
            this.txtPret.Location = new System.Drawing.Point(151, 146);
            this.txtPret.Margin = new System.Windows.Forms.Padding(4);
            this.txtPret.Name = "txtPret";
            this.txtPret.Size = new System.Drawing.Size(219, 22);
            this.txtPret.TabIndex = 1;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(151, 28);
            this.txtData.Margin = new System.Windows.Forms.Padding(4);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(219, 22);
            this.txtData.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(419, 463);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnAdaugaComp);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtTelefon);
            this.groupBox2.Controls.Add(this.txtAdresa);
            this.groupBox2.Controls.Add(this.txtNume);
            this.groupBox2.Location = new System.Drawing.Point(16, 31);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(525, 194);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adaugare companie";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(151, 64);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(219, 22);
            this.txtEmail.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(575, 85);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 17);
            this.label5.TabIndex = 9;
            this.label5.Visible = false;
            // 
            // btnAdaugaComp
            // 
            this.btnAdaugaComp.Location = new System.Drawing.Point(403, 143);
            this.btnAdaugaComp.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdaugaComp.Name = "btnAdaugaComp";
            this.btnAdaugaComp.Size = new System.Drawing.Size(100, 28);
            this.btnAdaugaComp.TabIndex = 8;
            this.btnAdaugaComp.Text = "Adauga";
            this.btnAdaugaComp.UseVisualStyleBackColor = true;
            this.btnAdaugaComp.Click += new System.EventHandler(this.btnAdaugaComp_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 156);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Adresa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 73);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 114);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Telefon";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 37);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Nume";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(151, 106);
            this.txtTelefon.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(219, 22);
            this.txtTelefon.TabIndex = 2;
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(151, 146);
            this.txtAdresa.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(219, 22);
            this.txtAdresa.TabIndex = 1;
            // 
            // txtNume
            // 
            this.txtNume.Location = new System.Drawing.Point(151, 28);
            this.txtNume.Margin = new System.Windows.Forms.Padding(4);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(219, 22);
            this.txtNume.TabIndex = 0;
            // 
            // FormaAdaugare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 505);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormaAdaugare";
            this.Text = "Adaugare companie/masina";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormaAdaugare_FormClosed);
            this.Load += new System.EventHandler(this.FormaAdaugare_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblIdMasina;
        private System.Windows.Forms.Button btnAdaugaMasina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCompanii;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtPret;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdaugaComp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.TextBox txtEmail;
    }
}