using Metier;
using Donnee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySqlConnector;

namespace Interface
{
    public partial class FrmPraticienAjout : FrmBase
    {
        public FrmPraticienAjout(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }

        // -------------------------------------------------------
        // Chargement du formulaire
        // -------------------------------------------------------
        private void FrmPraticienAjout_Load(object sender, EventArgs e)
        {
            this.lblTitre.Text = "Ajouter un nouveau praticien";
            parametrerComposants();
        }

        // -------------------------------------------------------
        // Paramétrage des zones de liste et de l'autocomplétion
        // -------------------------------------------------------
        private void parametrerComposants()
        {
            // --- ComboBox Type ---
            cbxType.DataSource = session!.LesTypesPraticien;
            cbxType.DisplayMember = "Libelle";
            cbxType.SelectedIndex = -1;

            // --- ComboBox Spécialité ---
            cbxSpecialite.DataSource = session!.LesSpecialites;
            cbxSpecialite.DisplayMember = "Libelle";
            cbxSpecialite.SelectedIndex = -1;

            // --- Autocomplétion sur la ville ---
            txtVille.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtVille.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var source = new AutoCompleteStringCollection();
            foreach (Ville ville in session!.MesVilles)
            {
                source.Add(ville.Nom);
            }
            txtVille.AutoCompleteCustomSource = source;

            // Masquer tous les labels d'erreur au départ
            messageNom.Visible = false;
            messagePrenom.Visible = false;
            messageRue.Visible = false;
            messageVille.Visible = false;
            messageEmail.Visible = false;
            messageTelephone.Visible = false;
            messageType.Visible = false;
        }

        // -------------------------------------------------------
        // Contrôle générique : champ de texte non vide
        // -------------------------------------------------------
        private bool controlerChamp(TextBox txt, Label lblMessage, string message)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                lblMessage.Text = message;
                lblMessage.Visible = true;
                return false;
            }
            lblMessage.Text = "";
            lblMessage.Visible = false;
            return true;
        }

        // -------------------------------------------------------
        // Contrôle : ville existante dans la collection session
        // -------------------------------------------------------
        private bool controlerVille()
        {
            if (string.IsNullOrWhiteSpace(txtVille.Text))
            {
                messageVille.Text = "La ville du praticien doit être précisée.";
                messageVille.Visible = true;
                return false;
            }
            Ville? laVille = session!.MesVilles.Find(x => x.Nom == txtVille.Text);
            if (laVille == null)
            {
                messageVille.Text = "Cette ville ne fait pas partie des villes gérées.";
                messageVille.Visible = true;
                return false;
            }
            messageVille.Text = "";
            messageVille.Visible = false;
            return true;
        }

        // -------------------------------------------------------
        // Contrôle : téléphone (MaskedTextBox entièrement rempli)
        // -------------------------------------------------------
        private bool controlerTelephone()
        {
            if (!mtbTelephone.MaskFull)
            {
                messageTelephone.Text = "Le téléphone du praticien doit être précisé.";
                messageTelephone.Visible = true;
                return false;
            }
            messageTelephone.Visible = false;
            return true;
        }

        // -------------------------------------------------------
        // Contrôle : email via expression régulière
        // -------------------------------------------------------
        private bool controlerEmail()
        {
            if (txtEmail.Text == string.Empty)
            {
                messageEmail.Text = "L'adresse mail du praticien doit être précisée.";
                messageEmail.Visible = true;
                return false;
            }
            Regex uneExpression = new Regex(@"^[A-Za-z0-9._%+\-]+@[A-Za-z0-9.\-]+\.[A-Za-z]{2,}$");
            if (!uneExpression.IsMatch(txtEmail.Text))
            {
                messageEmail.Text = "L'adresse mail n'est pas valide.";
                messageEmail.Visible = true;
                return false;
            }
            messageEmail.Text = "";
            messageEmail.Visible = false;
            return true;
        }

        // -------------------------------------------------------
        // Contrôle : type de praticien sélectionné
        // -------------------------------------------------------
        private bool controlerType()
        {
            if (cbxType.SelectedIndex == -1)
            {
                messageType.Text = "Veuillez sélectionner le type de praticien.";
                messageType.Visible = true;
                return false;
            }
            messageType.Text = "";
            messageType.Visible = false;
            return true;
        }

        // -------------------------------------------------------
        // Centralise tous les contrôles avant d'appeler ajouter()
        // -------------------------------------------------------
        private void ajout()
        {
            // Les zones de liste (spécialité) peuvent rester vides → pas de contrôle
            bool nomOk = controlerChamp(txtNom, messageNom, "Le nom du praticien doit être précisé.");
            bool prenomOk = controlerChamp(txtPrenom, messagePrenom, "Le prénom du praticien doit être précisé.");
            bool rueOk = controlerChamp(txtRue, messageRue, "La rue du praticien doit être précisée.");
            bool villeOk = controlerVille();
            bool emailOk = controlerEmail();
            bool telephoneOk = controlerTelephone();
            bool typeOk = controlerType();

            if (nomOk && prenomOk && rueOk && villeOk && emailOk && telephoneOk && typeOk)
            {
                ajouter();
            }
        }

        // -------------------------------------------------------
        // Effectue l'ajout en base et met à jour la session
        // -------------------------------------------------------
        private void ajouter()
        {
            try
            {
                // Récupération du code postal depuis la ville saisie
                Ville laVille = session!.MesVilles.Find(x => x.Nom == txtVille.Text)!;
                string codePostal = laVille.Code;

                // Récupération de l'id du type
                string idType = ((TypePraticien)cbxType.SelectedItem!).Id;

                // Récupération de l'id de la spécialité (null si non renseignée)
                string? idSpecialite = null;
                if (cbxSpecialite.SelectedIndex != -1)
                {
                    idSpecialite = ((Specialite)cbxSpecialite.SelectedItem!).Id;
                }

                // Appel de la méthode Passerelle
                int newId = Passerelle.ajouterPraticien(
                    txtNom.Text.Trim(),
                    txtPrenom.Text.Trim(),
                    txtRue.Text.Trim(),
                    codePostal,
                    txtVille.Text.Trim(),
                    mtbTelephone.Text,
                    txtEmail.Text.Trim(),
                    idType,
                    idSpecialite!
                );

                // Récupération des objets TypePraticien et Specialite pour construire le Praticien
                TypePraticien leType = session!.LesTypesPraticien.Find(x => x.Id == idType)!;
                Specialite? laSpecialite = idSpecialite != null
                    ? session!.LesSpecialites.Find(x => x.Id == idSpecialite)
                    : null;

                // Création de l'objet Praticien et ajout dans la collection session
                Praticien nouveauPraticien = new Praticien(
                    newId,
                    txtNom.Text.Trim(),
                    txtPrenom.Text.Trim(),
                    txtRue.Text.Trim(),
                    codePostal,
                    txtVille.Text.Trim(),
                    txtEmail.Text.Trim(),
                    mtbTelephone.Text,
                    leType,
                    laSpecialite
                );

                session!.MesPraticiens.Add(nouveauPraticien);
                session!.MesPraticiens.Sort();

                // Remise à zéro de l'interface
                viderChamps();
                MessageBox.Show(
                    $"Le praticien {nouveauPraticien.NomPrenom} a été ajouté avec succès (id : {newId}).",
                    "Ajout réussi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    "Erreur SQL lors de l'ajout du praticien :\n" + ex.Message,
                    "Erreur base de données",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // -------------------------------------------------------
        // Vide tous les champs de saisie après un ajout réussi
        // -------------------------------------------------------
        private void viderChamps()
        {
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtRue.Text = string.Empty;
            txtVille.Text = string.Empty;
            txtEmail.Text = string.Empty;
            mtbTelephone.Text = string.Empty;
            cbxType.SelectedIndex = -1;
            cbxSpecialite.SelectedIndex = -1;
        }

        // -------------------------------------------------------
        // Événement : clic sur le bouton Ajouter
        // -------------------------------------------------------
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ajout();
        }
    }
}