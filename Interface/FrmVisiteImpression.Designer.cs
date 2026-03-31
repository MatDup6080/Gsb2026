namespace Interface
{
    partial class FrmVisiteImpression
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisiteImpression));
            panelCentral = new Panel();
            panelSaisie = new Panel();
            dtpFin = new DateTimePicker();
            dptDebut = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            messageIntervale = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            printRendezVous = new System.Drawing.Printing.PrintDocument();
            choixImprimante = new PrintDialog();
            aperçuRendezVous = new PrintPreviewDialog();
            message = new Label();
            panelCentral.SuspendLayout();
            panelSaisie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.Size = new Size(800, 45);
            // 
            // panelCentral
            // 
            panelCentral.Controls.Add(panelSaisie);
            panelCentral.Controls.Add(pictureBox1);
            panelCentral.Location = new Point(0, 91);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(788, 311);
            panelCentral.TabIndex = 14;
            // 
            // panelSaisie
            // 
            panelSaisie.Controls.Add(dtpFin);
            panelSaisie.Controls.Add(dptDebut);
            panelSaisie.Controls.Add(label2);
            panelSaisie.Controls.Add(label1);
            panelSaisie.Controls.Add(messageIntervale);
            panelSaisie.Controls.Add(pictureBox3);
            panelSaisie.Controls.Add(pictureBox2);
            panelSaisie.Location = new Point(426, 22);
            panelSaisie.Name = "panelSaisie";
            panelSaisie.Size = new Size(347, 271);
            panelSaisie.TabIndex = 1;
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(76, 69);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(200, 23);
            dtpFin.TabIndex = 6;
            // 
            // dptDebut
            // 
            dptDebut.Location = new Point(76, 27);
            dptDebut.Name = "dptDebut";
            dptDebut.Size = new Size(200, 23);
            dptDebut.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 69);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 4;
            label2.Text = "Au";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 33);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 3;
            label1.Text = "Du";
            // 
            // messageIntervale
            // 
            messageIntervale.AutoSize = true;
            messageIntervale.BackColor = Color.White;
            messageIntervale.ForeColor = Color.Red;
            messageIntervale.Location = new Point(22, 100);
            messageIntervale.Name = "messageIntervale";
            messageIntervale.Size = new Size(30, 15);
            messageIntervale.TabIndex = 2;
            messageIntervale.Text = "msg";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.apercu;
            pictureBox3.Location = new Point(22, 132);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(152, 123);
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.imprimer;
            pictureBox2.Location = new Point(205, 132);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(128, 123);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.logoGSB;
            pictureBox1.Location = new Point(16, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(387, 242);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // choixImprimante
            // 
            choixImprimante.UseEXDialog = true;
            // 
            // aperçuRendezVous
            // 
            aperçuRendezVous.AutoScrollMargin = new Size(0, 0);
            aperçuRendezVous.AutoScrollMinSize = new Size(0, 0);
            aperçuRendezVous.ClientSize = new Size(400, 300);
            aperçuRendezVous.Enabled = true;
            aperçuRendezVous.Icon = (Icon)resources.GetObject("aperçuRendezVous.Icon");
            aperçuRendezVous.Name = "aperçuRendezVous";
            aperçuRendezVous.Visible = false;
            // 
            // message
            // 
            message.AutoSize = true;
            message.ForeColor = Color.Red;
            message.Location = new Point(0, 73);
            message.Name = "message";
            message.Size = new Size(30, 15);
            message.TabIndex = 15;
            message.Text = "msg";
            // 
            // FrmVisiteImpression
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(message);
            Controls.Add(panelCentral);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Location = new Point(0, 0);
            Name = "FrmVisiteImpression";
            Text = "FrmVisiteImpression";
            Load += FrmVisiteImpression_Load;
            Controls.SetChildIndex(panelCentral, 0);
            Controls.SetChildIndex(lblTitre, 0);
            Controls.SetChildIndex(message, 0);
            panelCentral.ResumeLayout(false);
            panelSaisie.ResumeLayout(false);
            panelSaisie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelCentral;
        private PictureBox pictureBox1;
        private Panel panelSaisie;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private DateTimePicker dptDebut;
        private Label label2;
        private Label label1;
        private Label messageIntervale;
        private DateTimePicker dtpFin;
        private System.Drawing.Printing.PrintDocument printRendezVous;
        private PrintDialog choixImprimante;
        private PrintPreviewDialog aperçuRendezVous;
        private Label message;
    }
}