using Donnee;
using Metier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmConsultation : FrmBase
    {
        public FrmConsultation(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
            this.Resize += (s, e) => centrerFormulaire();
        }

        #region Procédures événementielles

        private void FrmConsultation_Load(object sender, EventArgs e)
        {
            this.lblTitre.Text = "Consultation des visites";
            parametrerComposants();
            remplirDgvVisites();
            centrerFormulaire();
        }

        private void FrmConsultation_Resize(object sender, EventArgs e)
        {
            centrerFormulaire();
        }

        private void dgvVisites_SelectionChanged(object sender, EventArgs e)
        {
            Visite? visite = getVisite();
            if (visite != null)
                afficher(visite);
            else
                viderAffichage();
        }

        #endregion

        #region Procédures

        private void centrerFormulaire()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
        }

        private void parametrerComposants()
        {
            parametrerDgvVisites();
            parametrerDgvEchantillons();
        }

        private void parametrerDgvVisites()
        {
            DataGridView dgv = dgvVisites;
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
            dgv.AutoGenerateColumns = false;

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

            // Colonne 0 : cachée, contient l'objet Visite
            col = new DataGridViewTextBoxColumn();
            col.Name = "Visite";
            col.HeaderText = "";
            col.Width = 0;
            col.Visible = false;
            dgv.Columns.Add(col);

            // Colonne 1 : date programmée (200 px)
            col = new DataGridViewTextBoxColumn();
            col.Name = "Date";
            col.HeaderText = "Programmée le";
            col.Width = 200;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            // Colonne 2 : horaire (50 px)
            col = new DataGridViewTextBoxColumn();
            col.Name = "Horaire";
            col.HeaderText = "à";
            col.Width = 50;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(col);

            // Colonne 3 : lieu (200 px)
            col = new DataGridViewTextBoxColumn();
            col.Name = "Lieu";
            col.HeaderText = "sur";
            col.Width = 200;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            dgv.Width = getLargeur(dgv);
        }

        private void parametrerDgvEchantillons()
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
            dgv.AutoGenerateColumns = false;

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

            
            col = new DataGridViewTextBoxColumn();
            col.Name = "Nom";
            col.HeaderText = "Nom";
            col.Width = 200;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

           
            col = new DataGridViewTextBoxColumn();
            col.Name = "Quantite";
            col.HeaderText = "Quantité";
            col.Width = 100;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(col);

            dgv.Width = getLargeur(dgv);
        }

        private int getLargeur(DataGridView dgv)
        {
            int largeur = 0;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Visible)
                {
                    largeur += col.Width;
                }
            }
            if (dgv.RowHeadersVisible)
            {
                largeur += dgv.RowHeadersWidth;
            }
               
            return largeur + 2; // marge bordure
        }

        private void remplirDgvVisites()
        {
            dgvVisites.Rows.Clear();

            List<Visite> lesVisites = session.MesVisites;

            foreach (Visite visite in lesVisites)
            {
                int index = dgvVisites.Rows.Add();
                DataGridViewRow row = dgvVisites.Rows[index];

                row.Cells["Visite"].Value = visite;
                row.Cells["Date"].Value = visite.DateEtHeure.ToString("dddd d MMMM yyyy",
                                                new CultureInfo("fr-FR"));
                row.Cells["Horaire"].Value = visite.DateEtHeure.ToString("HH:mm");
                row.Cells["Lieu"].Value = visite.LePraticien.Ville;

                // Visites passées affichées en vert
                if (visite.DateEtHeure < DateTime.Now)
                    row.DefaultCellStyle.ForeColor = Color.Green;
            }

            if (dgvVisites.Rows.Count > 0)
                dgvVisites.Rows[0].Selected = true;
        }

        private void afficher(Visite visite)
        {
            Praticien praticien = visite.LePraticien;

            // Infos praticien
            lblPraticien.Text = praticien.NomPrenom;
            lblRue.Text = praticien.Rue;
            lblTelephone.Text = praticien.Telephone;
            lblEmail.Text = praticien.Email;
            lblType.Text = praticien.Type?.Libelle ?? "";        
            lblSpecialite.Text = praticien.Specialite?.Libelle ?? ""; 

            // Motif et bilan
            lblMotif.Text = visite.LeMotif.Libelle ?? "";  
            lblBilan.Text = visite.Bilan ?? "";

            // Échantillons
            dgvEchantillon.Rows.Clear();
            foreach (KeyValuePair<Medicament, int> echantillon in visite) 
            {
                int idx = dgvEchantillon.Rows.Add();
                dgvEchantillon.Rows[idx].Cells["Nom"].Value = echantillon.Key.Nom;     
                dgvEchantillon.Rows[idx].Cells["Quantite"].Value = echantillon.Value;    
            }

            // Médicaments présentés
            lstMedicament.Items.Clear();
            if (visite.PremierMedicament != null)
            {
                lstMedicament.Items.Add(visite.PremierMedicament.Nom);
            }
            if (visite.SecondMedicament != null)
            {
                lstMedicament.Items.Add(visite.SecondMedicament.Nom);
            }
        }
        private void viderAffichage()
        {
            lblPraticien.Text = "";
            lblRue.Text = "";
            lblTelephone.Text = "";
            lblEmail.Text = "";
            lblType.Text = "";
            lblSpecialite.Text = "";
            lblMotif.Text = "";
            lblBilan.Text = "";
            dgvEchantillon.Rows.Clear();
            lstMedicament.Items.Clear();
        }

        private Visite? getVisite()
        {
            if (dgvVisites.SelectedRows.Count == 0) return null;
            return dgvVisites.SelectedRows[0].Cells["Visite"].Value as Visite;
        }

        #endregion
    }
}