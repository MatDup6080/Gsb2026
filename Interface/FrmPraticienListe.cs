using Metier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmPraticienListe : FrmBase
    {
        public FrmPraticienListe(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }

        private void FrmPraticienListe_Load(object sender, EventArgs e)
        {
            this.lblTitre.Text = "Liste des praticiens";

            InitialiserDataGridView();
            ChargerPraticiens();

        }


        /// <summary>
        /// Configure les colonnes du DataGridView
        /// </summary>
        private void InitialiserDataGridView()
        {
            dgvPraticiens.AutoGenerateColumns = false;
            dgvPraticiens.AllowUserToAddRows = false;
            dgvPraticiens.ReadOnly = true;
            dgvPraticiens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPraticiens.MultiSelect = false;
            dgvPraticiens.RowHeadersVisible = false;
            dgvPraticiens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            // Colonne cachée : objet Praticien
            DataGridViewTextBoxColumn colObjet = new DataGridViewTextBoxColumn();
            colObjet.Name = "colObjet";
            colObjet.HeaderText = "";
            colObjet.Visible = false;
            dgvPraticiens.Columns.Add(colObjet);

            // Nom et prénom
            DataGridViewTextBoxColumn colNom = new DataGridViewTextBoxColumn();
            colNom.Name = "colNom";
            colNom.HeaderText = "Nom et prénom";
            colNom.FillWeight = 20;
            dgvPraticiens.Columns.Add(colNom);

            // Téléphone
            DataGridViewTextBoxColumn colTel = new DataGridViewTextBoxColumn();
            colTel.Name = "colTelephone";
            colTel.HeaderText = "Téléphone";
            colTel.FillWeight = 15;
            dgvPraticiens.Columns.Add(colTel);

            // Email
            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "colEmail";
            colEmail.HeaderText = "Email";
            colEmail.FillWeight = 20;
            dgvPraticiens.Columns.Add(colEmail);

            // Adresse
            DataGridViewTextBoxColumn colAdresse = new DataGridViewTextBoxColumn();
            colAdresse.Name = "colAdresse";
            colAdresse.HeaderText = "Adresse";
            colAdresse.FillWeight = 25;
            dgvPraticiens.Columns.Add(colAdresse);

            // Date dernière visite
            DataGridViewTextBoxColumn colDerniereVisite = new DataGridViewTextBoxColumn();
            colDerniereVisite.Name = "colDerniereVisite";
            colDerniereVisite.HeaderText = "Date dernière visite";
            colDerniereVisite.FillWeight = 20;
            dgvPraticiens.Columns.Add(colDerniereVisite);
        }

        /// <summary>
        /// Charge et affiche la liste des praticiens depuis la session
        /// </summary>
        private void ChargerPraticiens()
        {
            dgvPraticiens.Rows.Clear();

            List<Praticien> lesPraticiens = session.MesPraticiens
                .OrderBy(p => p.Nom)
                .ToList();

            foreach (Praticien unPraticien in lesPraticiens)
            {
                // Rechercher la dernière visite pour ce praticien
                DateTime? dateDerniereVisite = ObtenirDateDerniereVisite(unPraticien);

                string affichageDerniereVisite = dateDerniereVisite.HasValue
                    ? dateDerniereVisite.Value.ToString("dddd d MMMM yyyy",
                        new System.Globalization.CultureInfo("fr-FR"))
                    : "Aucune visite";

                string adresse = $"{unPraticien.Rue}\n{unPraticien.CodePostal} {unPraticien.Ville}";

                int indexLigne = dgvPraticiens.Rows.Add(
                    unPraticien,
                    $"{unPraticien.Nom} {unPraticien.Prenom}",
                    unPraticien.Telephone,
                    unPraticien.Email,
                    adresse,
                    affichageDerniereVisite
                );

                // Colorer la ligne selon les règles du cahier des charges :
                // Rouge si aucune visite OU visite > 6 mois
                DataGridViewRow ligne = dgvPraticiens.Rows[indexLigne];
                if (!dateDerniereVisite.HasValue ||
                    dateDerniereVisite.Value < DateTime.Now.AddMonths(-6))
                {
                    ligne.DefaultCellStyle.BackColor = Color.LightCoral;
                    ligne.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        /// <summary>
        /// Retourne la date de la dernière visite (avec bilan) pour un praticien,
        /// ou null si aucune visite n'a été réalisée
        /// </summary>
        private DateTime? ObtenirDateDerniereVisite(Praticien unPraticien)
        {
            // On cherche dans les visites du visiteur connecté
            // Les visites avec bilan non null correspondent aux visites réalisées
            List<Visite> visitesRealisees = session.MesVisites
                .Where(v => v.LePraticien != null &&
                            v.LePraticien.Id == unPraticien.Id &&
                            v.Bilan != null)
                .ToList();

            if (!visitesRealisees.Any())
                return null;

            return visitesRealisees.Max(v => v.DateEtHeure);
        }
    }
}