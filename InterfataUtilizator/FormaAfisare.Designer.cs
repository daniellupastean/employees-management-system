namespace InterfataUtilizator
{
    partial class FormaAfisare
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
            this.dataGridMasini = new System.Windows.Forms.DataGridView();
            this.groupBoxEditare = new System.Windows.Forms.GroupBox();
            this.lblIdMasina = new System.Windows.Forms.Label();
            this.btnActualizeaza = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCompanii = new System.Windows.Forms.ComboBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtPret = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.btnAfiseazaFormaAdaugare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMasini)).BeginInit();
            this.groupBoxEditare.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridMasini
            // 
            this.dataGridMasini.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMasini.Location = new System.Drawing.Point(47, 34);
            this.dataGridMasini.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridMasini.Name = "dataGridMasini";
            this.dataGridMasini.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridMasini.Size = new System.Drawing.Size(637, 182);
            this.dataGridMasini.TabIndex = 0;
            this.dataGridMasini.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridMasini_CellContentClick);
            // 
            // groupBoxEditare
            // 
            this.groupBoxEditare.Controls.Add(this.lblIdMasina);
            this.groupBoxEditare.Controls.Add(this.btnActualizeaza);
            this.groupBoxEditare.Controls.Add(this.label4);
            this.groupBoxEditare.Controls.Add(this.label3);
            this.groupBoxEditare.Controls.Add(this.label2);
            this.groupBoxEditare.Controls.Add(this.label1);
            this.groupBoxEditare.Controls.Add(this.cmbCompanii);
            this.groupBoxEditare.Controls.Add(this.txtModel);
            this.groupBoxEditare.Controls.Add(this.txtPret);
            this.groupBoxEditare.Controls.Add(this.txtData);
            this.groupBoxEditare.Location = new System.Drawing.Point(47, 347);
            this.groupBoxEditare.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxEditare.Name = "groupBoxEditare";
            this.groupBoxEditare.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxEditare.Size = new System.Drawing.Size(779, 194);
            this.groupBoxEditare.TabIndex = 1;
            this.groupBoxEditare.TabStop = false;
            this.groupBoxEditare.Text = "Editare informatii catalog";
            this.groupBoxEditare.Visible = false;
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
            // btnActualizeaza
            // 
            this.btnActualizeaza.Location = new System.Drawing.Point(467, 73);
            this.btnActualizeaza.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizeaza.Name = "btnActualizeaza";
            this.btnActualizeaza.Size = new System.Drawing.Size(100, 28);
            this.btnActualizeaza.TabIndex = 8;
            this.btnActualizeaza.Text = "Actualizeaza";
            this.btnActualizeaza.UseVisualStyleBackColor = true;
            this.btnActualizeaza.Click += new System.EventHandler(this.btnActualizeaza_Click);
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
            // btnAfiseazaFormaAdaugare
            // 
            this.btnAfiseazaFormaAdaugare.Location = new System.Drawing.Point(692, 34);
            this.btnAfiseazaFormaAdaugare.Margin = new System.Windows.Forms.Padding(4);
            this.btnAfiseazaFormaAdaugare.Name = "btnAfiseazaFormaAdaugare";
            this.btnAfiseazaFormaAdaugare.Size = new System.Drawing.Size(172, 28);
            this.btnAfiseazaFormaAdaugare.TabIndex = 2;
            this.btnAfiseazaFormaAdaugare.Text = "Formulare Adaugare";
            this.btnAfiseazaFormaAdaugare.UseVisualStyleBackColor = true;
            this.btnAfiseazaFormaAdaugare.Click += new System.EventHandler(this.btnAfiseazaFormaAdaugare_Click);
            // 
            // FormaAfisare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 583);
            this.Controls.Add(this.btnAfiseazaFormaAdaugare);
            this.Controls.Add(this.groupBoxEditare);
            this.Controls.Add(this.dataGridMasini);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormaAfisare";
            this.Text = "Catalog Masini";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormaAfisare_FormClosed);
            this.Load += new System.EventHandler(this.FormaAfisare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMasini)).EndInit();
            this.groupBoxEditare.ResumeLayout(false);
            this.groupBoxEditare.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridMasini;
        private System.Windows.Forms.GroupBox groupBoxEditare;
        private System.Windows.Forms.Button btnActualizeaza;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCompanii;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtPret;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label lblIdMasina;
        private System.Windows.Forms.Button btnAfiseazaFormaAdaugare;
    }
}

