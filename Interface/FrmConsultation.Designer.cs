namespace Interface
{
    partial class FrmConsultation
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultation));
            panelCentral = new Panel();
            dgvEchantillon = new DataGridView();
            label6 = new Label();
            lstMedicament = new ListBox();
            label5 = new Label();
            lblBilan = new Label();
            label4 = new Label();
            lblMotif = new Label();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            lblSpecialite = new Label();
            lblType = new Label();
            lblEmail = new Label();
            lblTelephone = new Label();
            lblRue = new Label();
            lblPraticien = new Label();
            label1 = new Label();
            dgvVisites = new DataGridView();
            panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEchantillon).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisites).BeginInit();
            SuspendLayout();

            // lblTitre
            lblTitre.Size = new Size(800, 74);

            // panelCentral — largeur = dgvVisites(452) + espacement(20) + zone droite(~480) = ~952
            panelCentral.Controls.Add(dgvEchantillon);
            panelCentral.Controls.Add(label6);
            panelCentral.Controls.Add(lstMedicament);
            panelCentral.Controls.Add(label5);
            panelCentral.Controls.Add(lblBilan);
            panelCentral.Controls.Add(label4);
            panelCentral.Controls.Add(lblMotif);
            panelCentral.Controls.Add(label3);
            panelCentral.Controls.Add(label2);
            panelCentral.Controls.Add(panel2);
            panelCentral.Controls.Add(label1);
            panelCentral.Controls.Add(dgvVisites);
            panelCentral.Location = new Point(12, 91);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(980, 420);  // élargi pour contenir tout le contenu
            panelCentral.TabIndex = 13;

            // dgvVisites — taille corrigée : largeur calculée par le code (452px environ)
            dgvVisites.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVisites.Location = new Point(3, 32);
            dgvVisites.Name = "dgvVisites";
            dgvVisites.Size = new Size(452, 370);  // largeur = 0+200+50+200+2 = 452
            dgvVisites.TabIndex = 0;
            dgvVisites.SelectionChanged += dgvVisites_SelectionChanged;

            // label1 — "Sélectionner la visite pour afficher le détail"
            label1.AutoSize = true;
            label1.Location = new Point(3, 14);
            label1.Name = "label1";
            label1.Size = new Size(229, 15);
            label1.TabIndex = 1;
            label1.Text = "Sélectionner la visite pour afficher le détail";

            // label2 — "Praticien" (titre au-dessus du panel2)
            label2.AutoSize = true;
            label2.Location = new Point(472, 7);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 3;
            label2.Text = "Praticien";

            // panel2 — infos praticien, élargi pour accueillir type + spécialité
            panel2.Controls.Add(lblSpecialite);
            panel2.Controls.Add(lblType);
            panel2.Controls.Add(lblEmail);
            panel2.Controls.Add(lblTelephone);
            panel2.Controls.Add(lblRue);
            panel2.Controls.Add(lblPraticien);
            panel2.Location = new Point(472, 25);
            panel2.Name = "panel2";
            panel2.Size = new Size(490, 110);  // élargi : 490px pour nom+type/spécialité côte à côte
            panel2.TabIndex = 2;

            // lblPraticien
            lblPraticien.Location = new Point(3, 10);
            lblPraticien.Name = "lblPraticien";
            lblPraticien.Size = new Size(220, 23);
            lblPraticien.TabIndex = 0;
            lblPraticien.Text = "";

            // lblRue
            lblRue.Location = new Point(3, 33);
            lblRue.Name = "lblRue";
            lblRue.Size = new Size(220, 23);
            lblRue.TabIndex = 1;
            lblRue.Text = "";

            // lblTelephone
            lblTelephone.Location = new Point(3, 56);
            lblTelephone.Name = "lblTelephone";
            lblTelephone.Size = new Size(220, 23);
            lblTelephone.TabIndex = 2;
            lblTelephone.Text = "";

            // lblEmail
            lblEmail.Location = new Point(3, 79);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(220, 23);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "";

            // lblType (colonne droite du panel2)
            lblType.Location = new Point(240, 10);
            lblType.Name = "lblType";
            lblType.Size = new Size(245, 23);
            lblType.TabIndex = 4;
            lblType.Text = "";

            // lblSpecialite (colonne droite du panel2)
            lblSpecialite.Location = new Point(240, 33);
            lblSpecialite.Name = "lblSpecialite";
            lblSpecialite.Size = new Size(245, 46);
            lblSpecialite.TabIndex = 5;
            lblSpecialite.Text = "";

            // label3 — "Motif"
            label3.AutoSize = true;
            label3.Location = new Point(472, 148);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 4;
            label3.Text = "Motif";

            // lblMotif — AutoSize = false, taille fixe
            lblMotif.AutoSize = false;
            lblMotif.Location = new Point(540, 148);
            lblMotif.Name = "lblMotif";
            lblMotif.Size = new Size(200, 23);
            lblMotif.TabIndex = 5;
            lblMotif.Text = "";

            // label4 — "Bilan de la visite"
            label4.AutoSize = true;
            label4.Location = new Point(472, 185);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 6;
            label4.Text = "Bilan de la visite";

            // lblBilan — AutoSize = false, taille fixe pour afficher texte long
            lblBilan.AutoSize = false;
            lblBilan.Location = new Point(472, 205);
            lblBilan.Name = "lblBilan";
            lblBilan.Size = new Size(490, 50);
            lblBilan.TabIndex = 7;
            lblBilan.Text = "";

            // label5 — "Médicaments présentés"
            label5.AutoSize = true;
            label5.Location = new Point(472, 265);
            label5.Name = "label5";
            label5.Size = new Size(132, 15);
            label5.TabIndex = 8;
            label5.Text = "Médicaments présentés";

            // lstMedicament
            lstMedicament.FormattingEnabled = true;
            lstMedicament.Location = new Point(472, 283);
            lstMedicament.Name = "lstMedicament";
            lstMedicament.Size = new Size(220, 60);
            lstMedicament.TabIndex = 9;

            // label6 — "Echantillons fournis"
            label6.AutoSize = true;
            label6.Location = new Point(720, 148);
            label6.Name = "label6";
            label6.Size = new Size(111, 15);
            label6.TabIndex = 10;
            label6.Text = "Echantillons fournis";

            // dgvEchantillon — largeur = 200+100+2 = 302
            dgvEchantillon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEchantillon.Location = new Point(720, 167);
            dgvEchantillon.Name = "dgvEchantillon";
            dgvEchantillon.Size = new Size(302, 176);
            dgvEchantillon.TabIndex = 11;

            // FrmConsultation
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 600);
            Controls.Add(panelCentral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            Name = "FrmConsultation";
            Text = "FrmConsultation";
            Load += FrmConsultation_Load;
            Resize += FrmConsultation_Resize;
            Controls.SetChildIndex(lblTitre, 0);
            Controls.SetChildIndex(panelCentral, 0);
            panelCentral.ResumeLayout(false);
            panelCentral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEchantillon).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVisites).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCentral;
        private Panel panel2;
        private Label label1;
        private DataGridView dgvVisites;
        private Label label2;
        private Label lblRue;
        private Label lblPraticien;
        private Label lblSpecialite;
        private Label lblType;
        private Label lblEmail;
        private Label lblTelephone;
        private Label label5;
        private Label lblBilan;
        private Label label4;
        private Label lblMotif;
        private Label label3;
        private DataGridView dgvEchantillon;
        private Label label6;
        private ListBox lstMedicament;
    }
}