using Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Interface.Properties;
using Donnee;

namespace Interface
{
    public partial class FrmVisiteModification : FrmBase
    {
        private Visite? visiteSelectionnee;

        public FrmVisiteModification(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }

        #region procédures événementielles

        private void FrmVisiteModification_Load(object sender, EventArgs e)
        {
            lblTitre.Text = "Modifier ou supprimer un rendez-vous";
            parametrerComposants();
            remplirDgv();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            modifier();
        }

        private void dgvVisites_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Clic sur la colonne image (colonne 1) => suppression
            if (e.ColumnIndex == 1)
            {
                supprimer(e.RowIndex);
                return;
            }

            // Sélection d'une ligne => afficher les infos de la visite
            selectionnerVisite(e.RowIndex);
        }

        #endregion

        #region procédures

        private void parametrerComposants()
        {
            // Paramétrage du DateTimePicker (date + heure)
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd/MM/yyyy HH:mm";

            // Désactiver le panneau droit tant qu'aucune visite n'est sélectionnée
            panelDroit.Enabled = false;

            // Paramétrage du datagridview
            parametrerDgv(dgvVisites);
        }

        private void parametrerDgv(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            #region paramétrage du datagridview dans son ensemble

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

            #endregion

            #region paramétrage de la ligne d'entête

            dgv.ColumnHeadersVisible = true;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle style = dgv.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.WhiteSmoke;
            style.ForeColor = Color.Black;
            style.SelectionBackColor = Color.WhiteSmoke;
            style.SelectionForeColor = Color.Black;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Font = new Font("Georgia", 12, FontStyle.Bold);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 40;

            #endregion

            #region paramétrage de l'entête de ligne

            dgv.RowHeadersVisible = false;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            #endregion

            #region paramétrage des lignes

            dgv.RowTemplate.Height = 30;

            #endregion

            #region paramétrage des cellules

            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.RowsDefaultCellStyle.BackColor = Color.White;

            #endregion

            #region paramétrage de la zone sélectionnée

            dgv.RowsDefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            #endregion

            #region paramétrage des colonnes

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewColumn col;

            // Colonne 0 : cachée, contient l'objet Visite
            col = new DataGridViewTextBoxColumn();
            col.Name = "Visite";
            col.HeaderText = "";
            col.Visible = false;
            dgv.Columns.Add(col);

            // Colonne 1 : image de suppression
            DataGridViewImageColumn colImg = new DataGridViewImageColumn();
            colImg.Name = "Supprimer";
            colImg.HeaderText = "";
            colImg.Width = 40;
            colImg.FillWeight = 5;
            colImg.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colImg.DefaultCellStyle.NullValue = null;
            dgv.Columns.Add(colImg);

            // Colonne 2 : Date
            col = new DataGridViewTextBoxColumn();
            col.Name = "Date";
            col.HeaderText = "Programmée le";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            // Colonne 3 : Heure
            col = new DataGridViewTextBoxColumn();
            col.Name = "Heure";
            col.HeaderText = "à";
            col.FillWeight = 20;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(col);

            // Colonne 4 : Ville
            col = new DataGridViewTextBoxColumn();
            col.Name = "Lieu";
            col.HeaderText = "sur";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            // Colonne 5 : Praticien
            col = new DataGridViewTextBoxColumn();
            col.Name = "Praticien";
            col.HeaderText = "chez";
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            // Désactiver le tri sur toutes les colonnes
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            #endregion
        }

        private void remplirDgv()
        {
            dgvVisites.Rows.Clear();

            foreach (Visite v in session.MesVisites
                         .Where(v => v.Bilan is null)
                         .OrderBy(v => v.DateEtHeure))
            {
                int rowIndex = dgvVisites.Rows.Add(
                    "",                                         // col 0 : cachée (vide)
                    Resources.supprimer,                        // col 1 : image suppression
                    v.DateEtHeure.ToLongDateString(),           // col 2 : date
                    v.DateEtHeure.ToShortTimeString(),          // col 3 : heure
                    v.LePraticien.Ville,                        // col 4 : ville
                    v.LePraticien.NomPrenom                     // col 5 : praticien
                );
                // Stocker l'objet Visite dans le Tag de la ligne
                dgvVisites.Rows[rowIndex].Tag = v;
            }
        }

        private void selectionnerVisite(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dgvVisites.Rows.Count) return;

            visiteSelectionnee = dgvVisites.Rows[rowIndex].Tag as Visite;

            if (visiteSelectionnee == null) return;

            // Afficher les infos dans le panneau droit
            lblNom.Text = visiteSelectionnee.LePraticien.NomPrenom;
            lblDate.Text = visiteSelectionnee.DateEtHeure.ToString("dddd dd MMMM yyyy");

            dtpDate.Value = visiteSelectionnee.DateEtHeure;

            panelDroit.Enabled = true;
        }

        private void modifier()
        {
            if (visiteSelectionnee == null)
            {
                MessageBox.Show("Veuillez sélectionner une visite.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Récupérer la nouvelle date+heure depuis le picker unique
            DateTime nouvelleDate = dtpDate.Value;

            // Vérifications métier
            if (nouvelleDate < DateTime.Now.AddHours(1))
            {
                MessageBox.Show("La date de visite doit être dans au moins une heure.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nouvelleDate.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Veuillez sélectionner une date qui n'est pas un dimanche.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nouvelleDate.Hour < 8 || nouvelleDate.Hour >= 19)
            {
                MessageBox.Show("Veuillez sélectionner une heure entre 8h et 19h.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nouvelleDate > DateTime.Today.AddDays(60).AddHours(19))
            {
                MessageBox.Show("Veuillez sélectionner une date dans les 2 mois à venir.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérifier l'écart de 2h avec les autres visites du même visiteur
            bool conflit = session.MesVisites.Any(v =>
                v.Id != visiteSelectionnee.Id &&
                v.Bilan is null &&
                Math.Abs((v.DateEtHeure - nouvelleDate).TotalHours) < 2);

            if (conflit)
            {
                MessageBox.Show("Il doit y avoir au moins 2 heures d'écart avec les autres rendez-vous.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Appel à la passerelle
                Passerelle.modifierRendezVous(visiteSelectionnee.Id, nouvelleDate);

                // Mettre à jour l'objet en session : remplacer la visite par une nouvelle instance
                int idx = session.MesVisites.IndexOf(visiteSelectionnee);
                session.MesVisites[idx] = new Visite(visiteSelectionnee.Id, visiteSelectionnee.LePraticien, visiteSelectionnee.LeMotif, nouvelleDate);

                // Rafraîchir le datagridview
                remplirDgv();
                panelDroit.Enabled = false;
                visiteSelectionnee = null;

                MessageBox.Show("Le rendez-vous a été modifié avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void supprimer(int rowIndex)
        {
            Visite? v = dgvVisites.Rows[rowIndex].Tag as Visite;

            if (v == null) return;

            DialogResult rep = MessageBox.Show(
                $"Voulez-vous vraiment supprimer le rendez-vous du {v.DateEtHeure.ToLongDateString()} chez {v.LePraticien.NomPrenom} ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rep != DialogResult.Yes) return;

            try
            {
                Passerelle.supprimerRendezVous(v.Id);

                session.MesVisites.Remove(v);

                remplirDgv();
                panelDroit.Enabled = false;
                visiteSelectionnee = null;

                MessageBox.Show("Le rendez-vous a été supprimé.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}