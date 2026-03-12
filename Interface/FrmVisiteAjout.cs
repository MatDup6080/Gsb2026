using Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using Donnee;

namespace Interface
{
    public partial class FrmVisiteAjout : FrmBase
    {
        public FrmVisiteAjout(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }
        # region procédures événementielles
        private void FrmVisiteAjout_Load(object sender, EventArgs e)
        {
            parametrerComposant();
            remplirDgv();
        }
        private void btnAjouter_click(object sender, EventArgs e)
        {
            ajout();
        }
        #endregion



        private void parametrerComposant()
        {
            lblTitre.Text = "Ajouter une visite";

            //alimentation de la zone de liste des praticiens
            foreach (Praticien unPraticien in session.MesPraticiens)
            {
                cbxPraticien.Items.Add(unPraticien);
            }
            cbxPraticien.DisplayMember = "NomPrenom";
            cbxPraticien.ValueMember = "Id";
            cbxPraticien.SelectedIndex = 0;
            cbxPraticien.DropDownStyle = ComboBoxStyle.DropDownList;

            //alimentation de la zone de liste des motifs
            cbxMotif.DataSource = session.LesMotifs;
            cbxMotif.DisplayMember = "Libelle";
            cbxMotif.ValueMember = "Id";
            cbxMotif.DropDownStyle = ComboBoxStyle.DropDownList;

            //parametrage du DateTimePicker
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd/MM/yyyy HH:mm";

            //paramétrage du datagridview
            parametrerDgv(dgvVisites);
        }
        #region procédures
        private void parametrerDgv(DataGridView dgv)
        {
            // initialisation du datagridview : supprimerRendezVous des colonnes et des lignes ajoutées par défaut dans le composant
            dgv.Columns.Clear();
            dgv.Rows.Clear();

            #region paramètrage concernant le datagridview dans son ensemble

            // Accessibilité (doit être sur true si on veut pouvoir utiliser les barres de défilement)
            dgv.Enabled = true;

            // style de bordure
            dgv.BorderStyle = BorderStyle.FixedSingle;

            // couleur de fond 
            dgv.BackgroundColor = Color.White;

            // couleur de texte  
            dgv.ForeColor = Color.Black;

            // police de caractères par défaut
            dgv.DefaultCellStyle.Font = new Font("Georgia", 11);

            // mode de sélection dans le composant : FullRowSelect, CellSelect ...
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // sélection multiple 
            dgv.MultiSelect = false;

            // l'utilisateur peut-il ajouter ou supprimer des lignes ?
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToAddRows = false;

            // L'utilisateur peut-il modifier le contenu des cellules ou est-elle réservée à la programmation ?
            dgv.EditMode = DataGridViewEditMode.EditProgrammatically;

            // l'utilisateur peut-il redimensionner les colonnes et les lignes ?
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;

            // l'utilisateur peut-il modifier l'ordre des colonnes ?
            dgv.AllowUserToOrderColumns = false;

            // le composant accepte t'il le 'déposer' dans un Glisser - Déposer ?
            dgv.AllowDrop = false;

            // Largeur : à contrôler avec la largeur des colonnes si elle est définie
            dgv.Width = 700;

            // faut-il ajuster automatiquement la taille des colonnes par un ajustement proportionnel à la largeur totale (commenter la ligne si non)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            #endregion

            #region paramètrage concernant la ligne d'entête 

            // visibilité
            dgv.ColumnHeadersVisible = true;

            // bordure
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // style  [à adapter] (ici : noir sur fond transparent sans mise en évidence de la sélection)
            dgv.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle style = dgv.ColumnHeadersDefaultCellStyle;
            style.BackColor = Color.WhiteSmoke;
            style.ForeColor = Color.Black;
            style.SelectionBackColor = Color.WhiteSmoke;    // même couleur que backColor pour ne pas mettre en évidence la colonne sélectionnée
            style.SelectionForeColor = Color.Black;
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Font = new Font("Georgia", 12, FontStyle.Bold);


            // hauteur 
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgv.ColumnHeadersHeight = 40;

            #endregion

            #region paramètrage concernant l'entête de ligne (la colonne d'entête ou le sélecteur)

            // visible 
            dgv.RowHeadersVisible = false;

            // style de bordure  
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;


            #endregion

            #region paramètrage au niveau des lignes

            // Hauteur 
            dgv.RowTemplate.Height = 30;

            #endregion

            #region paramètrage au niveau des cellules

            // style de bordure 
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // couleur de fond, ne pas utiliser transparent car la couleur de la ligne sélectionnée restera après sélection
            dgv.RowsDefaultCellStyle.BackColor = Color.White;

            // Couleur alternative appliquée une ligne sur deux
            // unDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 238, 238, 238);

            #endregion

            #region paramètrage au niveau de la zone sélectionnée

            // couleur de fond mettre la même que les cellules si on ne veut pas mettre la zone en évidence 
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;

            // couleur du texte
            dgv.RowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;

            #endregion

            #region paramètrage des colonnes

            // faut-il ajuster automatiquement la taille des colonnes par un ajustement proportionnel à la largeur totale (commenter la ligne si non)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            // description de chaque colonne  [partie à personnaliser] 
            DataGridViewColumn col;

            // Colonne 0 : La date de la visite
            col = new DataGridViewTextBoxColumn();
            col.Name = "Date";
            col.HeaderText = "Programmée le";
            col.Width = 200;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            // Colonne 1 :  heure du rendez-vous
            col = new DataGridViewTextBoxColumn();
            col.Name = "Heure";
            col.HeaderText = "à";
            col.Width = 50;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(col);

            // Colonne 2 ! ville du rendez-vous
            col = new DataGridViewTextBoxColumn();
            col.Name = "Lieu";
            col.HeaderText = "sur";
            col.Width = 200;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            // Colonne praticien à rencontrer
            col = new DataGridViewTextBoxColumn();
            col.Name = "Praticien";
            col.HeaderText = "chez";
            col.Width = 250;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns.Add(col);

            // faut-il désactiver le tri sur toutes les colonnes ? (commenter les lignes si non)
            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
            #endregion
        private void remplirDgv()
        {
            //vider les lignes avant de les remplir
            dgvVisites.Rows.Clear();
            //parcourir la liste des visites dans l'ordre chronologique et ajouter une ligne pour chaque visite
            foreach (Visite v in session.MesVisites.Where(v => v.Bilan is null).OrderBy(v=>v.DateEtHeure))
            {
                dgvVisites.Rows.Add(v.DateEtHeure.ToLongDateString(), v.DateEtHeure.ToShortTimeString(), v.LePraticien.Ville, v.LePraticien.NomPrenom);

            }
        }
        //enregistrer la visite
        private void ajout()
        {
            //verifier le praticien 
            if (cbxPraticien.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un praticien.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //verifier le motif
            if (cbxMotif.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un motif de visite.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dtpDate.Value < DateTime.Now)
            {
                MessageBox.Show("La date de visite doit être dans le futur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                //récupérer les données saisies

                Praticien p = (Praticien)cbxPraticien.SelectedItem;
                Motif m = (Motif)cbxMotif.SelectedItem;
                DateTime date = dtpDate.Value;

                //enregistrer dans la base de données
                int id = Passerelle.ajouterRendezVous(
                    p.Id,
                    m.Id,
                    date
                    );

                //créer la visite et l'ajouter à la session
                session.MesVisites.Add(new Visite(id, p, m, date));

                //mettre à jour le datagridview
                remplirDgv();
                MessageBox.Show("La visite a été ajoutée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //activer l'option du menu pemrettant la modification de la visite
                modifierRendezVous.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

      
    }
}

    