using Donnee;
using Interface.Properties;
using Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interface
{
    public partial class FrmVisiteBilan : FrmBase
    {
        private List<Visite> lesVisitesNonCompletees = new();
        private int indexVisiteCourante = 0;

        public FrmVisiteBilan(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
            this.Resize += (s, e) => centrerFormulaire();
        }

        #region Procédures événementielles

        private void FrmVisiteBilan_Load(object sender, EventArgs e)
        {
            this.lblTitre.Text = "Enregistrer le bilan de la visite";
            parametrerComposants();
            chargerLesVisites();
            centrerFormulaire();
        }
        private void FrmVisiteBilan_Resize(object sender, EventArgs e)
        {
            centrerFormulaire();
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            changerVisite(-1);
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            changerVisite(1);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ajouterEchantillon();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            enregistrer();
        }

        private void dgvEchantillon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Clic colonne + (col 3) => augmenter quantité
            if (e.ColumnIndex == 3)
            {
                modifierQuantite(e.RowIndex, 1);
                return;
            }
            // Clic colonne - (col 4) => diminuer quantité
            if (e.ColumnIndex == 4)
            {
                modifierQuantite(e.RowIndex, -1);
                return;
            }
            // Clic colonne x (col 5) => supprimer la ligne
            if (e.ColumnIndex == 5)
            {
                dgvEchantillon.Rows.RemoveAt(e.RowIndex);
            }
        }

        #endregion

        #region Procédures

        private void centrerFormulaire()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
            panelCentral.Top = (this.ClientSize.Height - panelCentral.Height) / 2;
        }

        private void parametrerComposants()
        {
            List<Medicament> lesMedicaments = session.LesMedicaments;

            cbxPremierMedicament.DataSource = new List<Medicament>(lesMedicaments);
            cbxPremierMedicament.DisplayMember = "Nom";
            cbxPremierMedicament.SelectedIndex = -1;

            cbxSecondMedicament.DataSource = new List<Medicament>(lesMedicaments);
            cbxSecondMedicament.DisplayMember = "Nom";
            cbxSecondMedicament.SelectedIndex = -1;

            cbxEchantillon.DataSource = new List<Medicament>(lesMedicaments);
            cbxEchantillon.DisplayMember = "Nom";
            cbxEchantillon.SelectedIndex = -1;

            cptQuantite.Minimum = 1;
            cptQuantite.Maximum = 10;
            cptQuantite.Value = 1;

            msgPremierMedicament.Visible = false;
            msgSecondMedicament.Visible = false;
            msgBilan.Visible = false;

            parametrerDgv();
        }

        private void parametrerDgv()
        {
            DataGridView dgv = dgvEchantillon;
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            dgv.Enabled = true;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.BackgroundColor = Color.White;
            dgv.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Georgia", 11);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToAddRows = false;
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowDrop = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.ColumnHeadersVisible = true;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle style = dgv.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.WhiteSmoke;
            style.ForeColor = Color.Black;
            style.SelectionBackColor = Color.WhiteSmoke;
            style.SelectionForeColor = Color.Black;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Font = new Font("Georgia", 11, FontStyle.Bold);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 30;

            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 28;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            DataGridViewColumn col;

            // Colonne 0 : cachée, contient l'objet Medicament
            col = new DataGridViewTextBoxColumn();
            col.Name = "Medicament";
            col.HeaderText = "";
            col.Visible = false;
            dgv.Columns.Add(col);

            // Colonne 1 : nom du médicament
            col = new DataGridViewTextBoxColumn();
            col.Name = "Nom";
            col.HeaderText = "Médicament";
            col.FillWeight = 100;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            // Colonne 2 : quantité
            col = new DataGridViewTextBoxColumn();
            col.Name = "Quantite";
            col.HeaderText = "Quantité";
            col.FillWeight = 100;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(col);

            // Colonne 3 : image +
            DataGridViewImageColumn colPlus = new DataGridViewImageColumn();
            colPlus.Name = "Plus";
            colPlus.HeaderText = "+";
            colPlus.FillWeight = 40;
            colPlus.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colPlus.DefaultCellStyle.NullValue = null;
            dgv.Columns.Add(colPlus);

            // Colonne 4 : image -
            DataGridViewImageColumn colMoins = new DataGridViewImageColumn();
            colMoins.Name = "Moins";
            colMoins.HeaderText = "-";
            colMoins.FillWeight = 40;
            colMoins.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colMoins.DefaultCellStyle.NullValue = null;
            dgv.Columns.Add(colMoins);

            // Colonne 5 : image x (supprimer)
            DataGridViewImageColumn colSupp = new DataGridViewImageColumn();
            colSupp.Name = "Supprimer";
            colSupp.HeaderText = "x";
            colSupp.FillWeight = 40;
            colSupp.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colSupp.DefaultCellStyle.NullValue = null;
            dgv.Columns.Add(colSupp);

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void chargerLesVisites()
        {
            lesVisitesNonCompletees = session!.MesVisites
                .FindAll(x => x.DateEtHeure <= DateTime.Now && x.Bilan == null);

            if (lesVisitesNonCompletees.Count == 0)
            {
                lblMessage.Text = "Toutes vos fiches sont complétées";
                panelCentral.Visible = false;
                return;
            }

            panelCentral.Visible = true;
            indexVisiteCourante = 0;
            afficherVisite();
            mettreAJourNavigation();
        }

        private void changerVisite(int deplacement)
        {
            int count = lesVisitesNonCompletees.Count;
            if (count == 0) return;

            indexVisiteCourante = (indexVisiteCourante + deplacement + count) % count;
            afficherVisite();
            mettreAJourNavigation();
        }

        private void afficherVisite()
        {
            Visite visite = lesVisitesNonCompletees[indexVisiteCourante];

            lblDate.Text = visite.DateEtHeure.ToString("dddd dd MMMM yyyy à HH:mm");
            lblPraticien.Text = visite.LePraticien.NomPrenom;

            cbxPremierMedicament.SelectedIndex = -1;
            cbxSecondMedicament.SelectedIndex = -1;
            txtBilan.Text = "";
            dgvEchantillon.Rows.Clear();
            cptQuantite.Value = 1;
            cbxEchantillon.SelectedIndex = -1;

            msgPremierMedicament.Visible = false;
            msgSecondMedicament.Visible = false;
            msgBilan.Visible = false;
        }

        private void mettreAJourNavigation()
        {
            int count = lesVisitesNonCompletees.Count;
            btnSuivant.Enabled = count > 1;
            btnPrecedent.Enabled = count > 1;
            lblMessage.Visible = count > 0;

            if (count > 0)
                lblMessage.Text = $"{indexVisiteCourante + 1} / {count}";
            else
                lblMessage.Text = "Toutes vos fiches sont complétées";
        }

        private void ajouterEchantillon()
        {
            if (cbxEchantillon.SelectedIndex < 0)
            {
                MessageBox.Show("Veuillez sélectionner un médicament.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvEchantillon.Rows.Count >= 10)
            {
                MessageBox.Show("Le nombre de médicaments distribués ne peut pas dépasser 10.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Medicament medicament = (Medicament)cbxEchantillon.SelectedItem!;

            // Vérifier si le médicament est déjà dans la liste
            foreach (DataGridViewRow row in dgvEchantillon.Rows)
            {
                if (row.Tag is Medicament m && m.Id == medicament.Id)
                {
                    MessageBox.Show("Ce médicament est déjà dans la liste.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            int rowIndex = dgvEchantillon.Rows.Add(
                "",
                medicament.Nom,
                (int)cptQuantite.Value,
                Resources.plus,
                Resources.moins,
                Resources.supprimer
            );
            dgvEchantillon.Rows[rowIndex].Tag = medicament;
        }

        private void modifierQuantite(int rowIndex, int delta)
        {
            DataGridViewRow row = dgvEchantillon.Rows[rowIndex];
            int quantite = Convert.ToInt32(row.Cells["Quantite"].Value) + delta;

            if (quantite < 1 || quantite > 10) return;

            row.Cells["Quantite"].Value = quantite;
        }

        private bool controlerPremierMedicament()
        {
            if (cbxPremierMedicament.SelectedIndex < 0)
            {
                msgPremierMedicament.Text = "Le premier médicament est obligatoire.";
                msgPremierMedicament.Visible = true;
                return false;
            }
            msgPremierMedicament.Visible = false;
            return true;
        }

        private bool controlerSecondMedicament()
        {
            if (cbxSecondMedicament.SelectedIndex < 0)
            {
                msgSecondMedicament.Visible = false;
                return true;
            }

            Medicament premier = (Medicament)cbxPremierMedicament.SelectedItem!;
            Medicament second = (Medicament)cbxSecondMedicament.SelectedItem!;

            if (premier != null && second.Id == premier.Id)
            {
                msgSecondMedicament.Text = "Le second médicament doit être différent du premier.";
                msgSecondMedicament.Visible = true;
                return false;
            }

            msgSecondMedicament.Visible = false;
            return true;
        }

        private bool controlerBilan()
        {
            if (string.IsNullOrWhiteSpace(txtBilan.Text))
            {
                msgBilan.Text = "Le bilan est obligatoire.";
                msgBilan.Visible = true;
                return false;
            }
            msgBilan.Visible = false;
            return true;
        }

        private void enregistrer()
        {
            bool premierMedicamentOk = controlerPremierMedicament();
            bool secondMedicamentOk = controlerSecondMedicament();
            bool bilanOk = controlerBilan();

            if (premierMedicamentOk && secondMedicamentOk && bilanOk)
            {
                Medicament premierMedicament = (Medicament)cbxPremierMedicament.SelectedItem!;
                Medicament? secondMedicament = (cbxSecondMedicament.SelectedIndex >= 0)
                    ? (Medicament)cbxSecondMedicament.SelectedItem!
                    : null;

                Visite visite = lesVisitesNonCompletees[indexVisiteCourante];

                try
                {
                    // Mise à jour des échantillons dans l'objet visite
                    foreach (DataGridViewRow row in dgvEchantillon.Rows)
                    {
                        Medicament med = (Medicament)row.Tag!;
                        int quantite = Convert.ToInt32(row.Cells["Quantite"].Value);
                        visite.ajouterEchantillon(med, quantite);
                    }

                    // Mise à jour de l'objet Visite en mémoire
                    visite.enregistrerBilan(txtBilan.Text, premierMedicament, secondMedicament);

                    // Enregistrement base de données
                    Passerelle.enregistrerBilan(visite);

                    MessageBox.Show("Votre fiche visite est maintenant archivée", "Bilan enregistré",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Supprimer la visite de la liste
                    lesVisitesNonCompletees.RemoveAt(indexVisiteCourante);

                    if (lesVisitesNonCompletees.Count > 0)
                    {
                        changerVisite(0);
                    }
                    else
                    {
                        lblMessage.Text = "Toutes vos fiches sont complétées";
                        panelCentral.Visible = false;
                        mettreAJourNavigation();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors de l'enregistrement du bilan : " + ex.Message,
                        "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}