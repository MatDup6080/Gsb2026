namespace Interface
{
    partial class FrmVisiteModification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisiteModification));
            panelDroit = new Panel();
            panel4 = new Panel();
            btnAjouter = new Button();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            label3 = new Label();
            lblNom = new Label();
            label1 = new Label();
            label2 = new Label();
            panelGauche = new Panel();
            dgvVisites = new DataGridView();
            label4 = new Label();
            panelDroit.SuspendLayout();
            panel4.SuspendLayout();
            panelGauche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisites).BeginInit();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.Size = new Size(800, 74);
            // 
            // panelDroit
            // 
            panelDroit.Controls.Add(panel4);
            panelDroit.Dock = DockStyle.Right;
            panelDroit.Location = new Point(589, 98);
            panelDroit.Name = "panelDroit";
            panelDroit.Size = new Size(211, 307);
            panelDroit.TabIndex = 13;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnAjouter);
            panel4.Controls.Add(lblDate);
            panel4.Controls.Add(dtpDate);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(lblNom);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(6, 15);
            panel4.Name = "panel4";
            panel4.Size = new Size(202, 285);
            panel4.TabIndex = 7;
            // 
            // btnAjouter
            // 
            btnAjouter.BackColor = Color.Red;
            btnAjouter.Location = new Point(114, 238);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(75, 23);
            btnAjouter.TabIndex = 6;
            btnAjouter.Text = "Modifier";
            btnAjouter.UseVisualStyleBackColor = false;
            btnAjouter.Click += btnModifier_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(10, 129);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(162, 15);
            lblDate.TabIndex = 3;
            lblDate.Text = "Date et heure du rendez-vous";
            // 
            // dtpDate
            // 
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.Location = new Point(10, 209);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(172, 23);
            dtpDate.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 182);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 5;
            label3.Text = "est remis au";
            // 
            // lblNom
            // 
            lblNom.AutoSize = true;
            lblNom.Location = new Point(26, 38);
            lblNom.Name = "lblNom";
            lblNom.Size = new Size(100, 15);
            lblNom.TabIndex = 1;
            lblNom.Text = "Nom du praticien";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 14);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 0;
            label1.Text = "Le rendez-vous chez";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 100);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 2;
            label2.Text = "prévu initialement le";
            // 
            // panelGauche
            // 
            panelGauche.Controls.Add(dgvVisites);
            panelGauche.Controls.Add(label4);
            panelGauche.Dock = DockStyle.Fill;
            panelGauche.Location = new Point(0, 98);
            panelGauche.Name = "panelGauche";
            panelGauche.Size = new Size(589, 307);
            panelGauche.TabIndex = 14;
            // 
            // dgvVisites
            // 
            dgvVisites.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVisites.Dock = DockStyle.Fill;
            dgvVisites.Location = new Point(0, 15);
            dgvVisites.Name = "dgvVisites";
            dgvVisites.Size = new Size(589, 292);
            dgvVisites.TabIndex = 1;
            dgvVisites.CellClick += dgvVisites_CellClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(324, 15);
            label4.TabIndex = 0;
            label4.Text = "Sélectionner la visite afin de modifier la date du rendez-vous";
            // 
            // FrmVisiteModification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelGauche);
            Controls.Add(panelDroit);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            Name = "FrmVisiteModification";
            Text = "FrmVisiteModification";
            Load += FrmVisiteModification_Load;
            Controls.SetChildIndex(lblTitre, 0);
            Controls.SetChildIndex(panelDroit, 0);
            Controls.SetChildIndex(panelGauche, 0);
            panelDroit.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panelGauche.ResumeLayout(false);
            panelGauche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVisites).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelDroit;
        private Panel panelGauche;
        private Label label1;
        private Label lblNom;
        private Label label3;
        private DateTimePicker dtpDate;
        private Label lblDate;
        private Label label2;
        private Button btnAjouter;
        private Label label4;
        private DataGridView dgvVisites;
        private Panel panel4;
    }
}