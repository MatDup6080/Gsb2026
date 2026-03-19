namespace Interface
{
    partial class FrmVisiteBilan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisiteBilan));
            panelCentral = new Panel();
            panelHaut = new Panel();
            lblPraticien = new Label();
            label2 = new Label();
            lblDate = new Label();
            label1 = new Label();
            btnSuivant = new Button();
            btnPrecedent = new Button();
            cbxEchantillon = new Panel();
            dgvEchantillon = new DataGridView();
            label6 = new Label();
            btnAjouter = new Button();
            cptQuantite = new NumericUpDown();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panelGauche = new Panel();
            cbxSecondMedicament = new ComboBox();
            cbxPremierMedicament = new ComboBox();
            msgSecondMedicament = new Label();
            msgPremierMedicament = new Label();
            msgBilan = new Label();
            btnEnregistrer = new Button();
            txtBilan = new TextBox();
            panelCentral.SuspendLayout();
            panelHaut.SuspendLayout();
            cbxEchantillon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEchantillon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cptQuantite).BeginInit();
            panelGauche.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.Size = new Size(800, 74);
            // 
            // panelCentral
            // 
            panelCentral.Controls.Add(panelHaut);
            panelCentral.Controls.Add(cbxEchantillon);
            panelCentral.Controls.Add(panelGauche);
            panelCentral.Location = new Point(12, 92);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(749, 310);
            panelCentral.TabIndex = 13;
            // 
            // panelHaut
            // 
            panelHaut.Controls.Add(lblPraticien);
            panelHaut.Controls.Add(label2);
            panelHaut.Controls.Add(lblDate);
            panelHaut.Controls.Add(label1);
            panelHaut.Controls.Add(btnSuivant);
            panelHaut.Controls.Add(btnPrecedent);
            panelHaut.Location = new Point(3, 3);
            panelHaut.Name = "panelHaut";
            panelHaut.Size = new Size(743, 50);
            panelHaut.TabIndex = 1;
            // 
            // lblPraticien
            // 
            lblPraticien.AutoSize = true;
            lblPraticien.Location = new Point(437, 17);
            lblPraticien.Name = "lblPraticien";
            lblPraticien.Size = new Size(100, 15);
            lblPraticien.TabIndex = 5;
            lblPraticien.Text = "Nom du praticien";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(378, 17);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 4;
            label2.Text = "chez";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(110, 17);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(161, 15);
            lblDate.TabIndex = 3;
            lblDate.Text = "date et heure du rendez-vous";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 17);
            label1.Name = "label1";
            label1.Size = new Size(16, 15);
            label1.TabIndex = 2;
            label1.Text = "le";
            // 
            // btnSuivant
            // 
            btnSuivant.BackColor = Color.Green;
            btnSuivant.Location = new Point(44, 13);
            btnSuivant.Name = "btnSuivant";
            btnSuivant.Size = new Size(29, 23);
            btnSuivant.TabIndex = 1;
            btnSuivant.Text = ">";
            btnSuivant.UseVisualStyleBackColor = false;
            // 
            // btnPrecedent
            // 
            btnPrecedent.BackColor = Color.Green;
            btnPrecedent.Location = new Point(12, 13);
            btnPrecedent.Name = "btnPrecedent";
            btnPrecedent.Size = new Size(26, 23);
            btnPrecedent.TabIndex = 0;
            btnPrecedent.Text = "<";
            btnPrecedent.UseVisualStyleBackColor = false;
            // 
            // cbxEchantillon
            // 
            cbxEchantillon.Controls.Add(dgvEchantillon);
            cbxEchantillon.Controls.Add(label6);
            cbxEchantillon.Controls.Add(btnAjouter);
            cbxEchantillon.Controls.Add(cptQuantite);
            cbxEchantillon.Controls.Add(comboBox1);
            cbxEchantillon.Controls.Add(label5);
            cbxEchantillon.Controls.Add(label4);
            cbxEchantillon.Controls.Add(label3);
            cbxEchantillon.Location = new Point(392, 59);
            cbxEchantillon.Name = "cbxEchantillon";
            cbxEchantillon.Size = new Size(354, 248);
            cbxEchantillon.TabIndex = 1;
            // 
            // dgvEchantillon
            // 
            dgvEchantillon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEchantillon.Location = new Point(17, 102);
            dgvEchantillon.Name = "dgvEchantillon";
            dgvEchantillon.Size = new Size(298, 143);
            dgvEchantillon.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 84);
            label6.Name = "label6";
            label6.Size = new Size(181, 15);
            label6.TabIndex = 6;
            label6.Text = "Liste des médiacments distribués";
            // 
            // btnAjouter
            // 
            btnAjouter.BackColor = Color.White;
            btnAjouter.Location = new Point(240, 48);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(75, 24);
            btnAjouter.TabIndex = 5;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = false;
            // 
            // cptQuantite
            // 
            cptQuantite.Location = new Point(182, 49);
            cptQuantite.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            cptQuantite.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            cptQuantite.Name = "cptQuantite";
            cptQuantite.Size = new Size(41, 23);
            cptQuantite.TabIndex = 4;
            cptQuantite.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(17, 49);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(142, 23);
            comboBox1.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(182, 31);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 2;
            label5.Text = "Quantité";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 31);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 1;
            label4.Text = "Médicament";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 10);
            label3.Name = "label3";
            label3.Size = new Size(125, 15);
            label3.TabIndex = 0;
            label3.Text = "Echantillons distribués";
            // 
            // panelGauche
            // 
            panelGauche.Controls.Add(cbxSecondMedicament);
            panelGauche.Controls.Add(cbxPremierMedicament);
            panelGauche.Controls.Add(msgSecondMedicament);
            panelGauche.Controls.Add(msgPremierMedicament);
            panelGauche.Controls.Add(msgBilan);
            panelGauche.Controls.Add(btnEnregistrer);
            panelGauche.Controls.Add(txtBilan);
            panelGauche.Location = new Point(3, 59);
            panelGauche.Name = "panelGauche";
            panelGauche.Size = new Size(383, 248);
            panelGauche.TabIndex = 0;
            // 
            // cbxSecondMedicament
            // 
            cbxSecondMedicament.FormattingEnabled = true;
            cbxSecondMedicament.Location = new Point(199, 28);
            cbxSecondMedicament.Name = "cbxSecondMedicament";
            cbxSecondMedicament.Size = new Size(170, 23);
            cbxSecondMedicament.TabIndex = 6;
            // 
            // cbxPremierMedicament
            // 
            cbxPremierMedicament.FormattingEnabled = true;
            cbxPremierMedicament.Location = new Point(3, 28);
            cbxPremierMedicament.Name = "cbxPremierMedicament";
            cbxPremierMedicament.Size = new Size(166, 23);
            cbxPremierMedicament.TabIndex = 5;
            // 
            // msgSecondMedicament
            // 
            msgSecondMedicament.AutoSize = true;
            msgSecondMedicament.Location = new Point(199, 10);
            msgSecondMedicament.Name = "msgSecondMedicament";
            msgSecondMedicament.Size = new Size(162, 15);
            msgSecondMedicament.TabIndex = 4;
            msgSecondMedicament.Text = "Second médicament proposé";
            // 
            // msgPremierMedicament
            // 
            msgPremierMedicament.AutoSize = true;
            msgPremierMedicament.Location = new Point(3, 10);
            msgPremierMedicament.Name = "msgPremierMedicament";
            msgPremierMedicament.Size = new Size(166, 15);
            msgPremierMedicament.TabIndex = 3;
            msgPremierMedicament.Text = "Premier médicament présenté";
            // 
            // msgBilan
            // 
            msgBilan.AutoSize = true;
            msgBilan.Location = new Point(122, 84);
            msgBilan.Name = "msgBilan";
            msgBilan.Size = new Size(91, 15);
            msgBilan.TabIndex = 2;
            msgBilan.Text = "Bilan de la visite";
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.BackColor = Color.Red;
            btnEnregistrer.Location = new Point(101, 176);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(170, 34);
            btnEnregistrer.TabIndex = 1;
            btnEnregistrer.Text = "Enregistrer la fiche visite";
            btnEnregistrer.UseVisualStyleBackColor = false;
            // 
            // txtBilan
            // 
            txtBilan.AcceptsReturn = true;
            txtBilan.Location = new Point(79, 113);
            txtBilan.Multiline = true;
            txtBilan.Name = "txtBilan";
            txtBilan.Size = new Size(210, 23);
            txtBilan.TabIndex = 0;
            // 
            // FrmVisiteBilan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelCentral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            Name = "FrmVisiteBilan";
            Text = "FrmVisiteBilan";
            Load += FrmVisiteBilan_Load;
            Resize += FrmVisiteBilan_Resize;
            Controls.SetChildIndex(lblTitre, 0);
            Controls.SetChildIndex(panelCentral, 0);
            panelCentral.ResumeLayout(false);
            panelHaut.ResumeLayout(false);
            panelHaut.PerformLayout();
            cbxEchantillon.ResumeLayout(false);
            cbxEchantillon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEchantillon).EndInit();
            ((System.ComponentModel.ISupportInitialize)cptQuantite).EndInit();
            panelGauche.ResumeLayout(false);
            panelGauche.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCentral;
        private Panel panelHaut;
        private Panel cbxEchantillon;
        private Panel panelGauche;
        private TextBox txtBilan;
        private Button btnEnregistrer;
        private Label msgPremierMedicament;
        private Label msgBilan;
        private Label msgSecondMedicament;
        private ComboBox cbxPremierMedicament;
        private ComboBox cbxSecondMedicament;
        private Label label1;
        private Button btnSuivant;
        private Button btnPrecedent;
        private Label lblPraticien;
        private Label label2;
        private Label lblDate;
        private Label label3;
        private ComboBox comboBox1;
        private Label label5;
        private Label label4;
        private NumericUpDown cptQuantite;
        private Label label6;
        private Button btnAjouter;
        private DataGridView dgvEchantillon;
    }
}