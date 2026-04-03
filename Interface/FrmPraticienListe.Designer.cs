namespace Interface
{
    partial class FrmPraticienListe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPraticienListe));
            dgvPraticiens = new DataGridView();
            panelCentral = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvPraticiens).BeginInit();
            panelCentral.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.Size = new Size(783, 47);
            // 
            // dgvPraticiens
            // 
            dgvPraticiens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPraticiens.Dock = DockStyle.Fill;
            dgvPraticiens.Location = new Point(0, 0);
            dgvPraticiens.Name = "dgvPraticiens";
            dgvPraticiens.Size = new Size(708, 310);
            dgvPraticiens.TabIndex = 13;
            // 
            // panelCentral
            // 
            panelCentral.Controls.Add(dgvPraticiens);
            panelCentral.Location = new Point(12, 74);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(708, 310);
            panelCentral.TabIndex = 14;
            // 
            // FrmPraticienListe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 450);
            Controls.Add(panelCentral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            Name = "FrmPraticienListe";
            Text = "FrmPraticienListe";
            Load += FrmPraticienListe_Load;
            Controls.SetChildIndex(lblTitre, 0);
            Controls.SetChildIndex(panelCentral, 0);
            ((System.ComponentModel.ISupportInitialize)dgvPraticiens).EndInit();
            panelCentral.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPraticiens;
        private Panel panelCentral;
    }
}