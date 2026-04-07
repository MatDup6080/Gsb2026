using Metier;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmVisiteImpression : FrmBase
    {
        private List<Visite> lesVisites;

        public FrmVisiteImpression(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }

        // -----------------------------------------------------------------------
        // Méthodes utilitaires
        // -----------------------------------------------------------------------

        private void centrerFormulaire()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
        }

        /// <summary>
        /// Fixe MinDate/MaxDate :
        ///   dptDebut : aujourd'hui → aujourd'hui + 53 j
        ///   dtpFin   : aujourd'hui + 7 → aujourd'hui + 60 j
        /// </summary>
        private void parametrerComposant()
        {
            DateTime auj = DateTime.Today;

            dptDebut.MinDate = auj;
            dptDebut.MaxDate = auj.AddDays(53);
            dptDebut.Value = auj;

            dtpFin.MinDate = auj.AddDays(7);
            dtpFin.MaxDate = auj.AddDays(60);
            dtpFin.Value = auj.AddDays(7);
        }

        /// <summary>
        /// Retourne les visites comprises entre dptDebut et dtpFin (bornes incluses).
        /// </summary>
        private List<Visite> getVisitesSurPeriode()
        {
            DateTime debut = dptDebut.Value.Date;
            DateTime fin = dtpFin.Value.Date;

            List<Visite> resultat = new List<Visite>();
            foreach (Visite v in lesVisites)
            {
                if (v.DateEtHeure.Date >= debut && v.DateEtHeure.Date <= fin)
                    resultat.Add(v);
            }
            return resultat;
        }

        // -----------------------------------------------------------------------
        // Événements du formulaire
        // -----------------------------------------------------------------------

        private void FrmVisiteImpression_Load(object sender, EventArgs e)
        {
            this.lblTitre.Text = "Impression des rendez-vous sur une période";
            this.Resize += (s, ev) => centrerFormulaire();

            // Filtrer les visites futures (date >= aujourd'hui) depuis la session
            lesVisites = new List<Visite>();
            foreach (Visite v in session.MesVisites)
            {
                if (v.DateEtHeure >= DateTime.Today)
                    lesVisites.Add(v);
            }

            if (lesVisites.Count == 0)
            {
                message.Text = "Aucun rendez-vous planifié pour le moment.";
                panelSaisie.Visible = false;
            }
            else
            {
                message.Text = string.Empty;
                parametrerComposant();
            }

            centrerFormulaire();
        }

        // -----------------------------------------------------------------------
        // Événements des DateTimePickers
        // -----------------------------------------------------------------------

        private void dtpDebut_ValueChanged(object sender, EventArgs e)
        {
            messageIntervale.Text = string.Empty;
            dtpFin.MinDate = dptDebut.Value.AddDays(7);
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            messageIntervale.Text = string.Empty;
        }

        // -----------------------------------------------------------------------
        // Événements des PictureBox
        // -----------------------------------------------------------------------

        private void imgImprimer_Click(object sender, EventArgs e)
        {
            List<Visite> visitesPeriode = getVisitesSurPeriode();

            if (visitesPeriode.Count == 0)
            {
                messageIntervale.Text = "Aucun rendez-vous planifié sur cette période.";
                return;
            }

            messageIntervale.Text = string.Empty;
            printRendezVous.DocumentName = "Rendez-vous";

            choixImprimante.Document = printRendezVous;
            DialogResult result = choixImprimante.ShowDialog();
            if (result == DialogResult.OK)
                printRendezVous.Print();
        }

        private void imgApercu_Click(object sender, EventArgs e)
        {
            List<Visite> visitesPeriode = getVisitesSurPeriode();

            if (visitesPeriode.Count == 0)
            {
                messageIntervale.Text = "Aucun rendez-vous planifié sur cette période.";
                return;
            }

            messageIntervale.Text = string.Empty;
            printRendezVous.DocumentName = "Rendez-vous";

            aperçuRendezVous.Document = printRendezVous;
            aperçuRendezVous.ShowDialog();
        }

        // -----------------------------------------------------------------------
        // Impression
        // -----------------------------------------------------------------------

        private void printRendezVous_PrintPage(object sender, PrintPageEventArgs e)
        {
            List<Visite> visitesPeriode = getVisitesSurPeriode();

            int margeHaut = e.MarginBounds.Top;
            int largeurPage = e.PageBounds.Width;

            // Calcul anticipé de la largeur totale pour centrer
            int largeurTotale = 160 + 55 + 140 + 100 + 140 + 100;

            int margeGauche = (largeurPage - largeurTotale) / 2;
            int hauteurLigne = 25;

            Font policeEntete = new Font("Arial", 10, FontStyle.Bold);
            Font police = new Font("Arial", 9);
            Font policeTitre = new Font("Arial", 11, FontStyle.Bold);
            Brush brush = Brushes.Black;
            Brush brushEntete = Brushes.White;
            Brush brushFondEntete = new SolidBrush(Color.SteelBlue);

            var lesColonnes = new[]
            {
    new { Titre = "Date",      Largeur = 160, Alignement = StringAlignment.Near   },
    new { Titre = "Heure",     Largeur = 55,  Alignement = StringAlignment.Center },
    new { Titre = "Praticien", Largeur = 140, Alignement = StringAlignment.Near   },
    new { Titre = "Téléphone", Largeur = 100, Alignement = StringAlignment.Near   },
    new { Titre = "Lieu",      Largeur = 140, Alignement = StringAlignment.Near   },
    new { Titre = "Motif",     Largeur = 100, Alignement = StringAlignment.Near   }
};



            // --- Titre centré ---
            string titre = string.Format(
                "Mes rendez-vous entre le {0} et le {1}",
                dptDebut.Value.ToString("dddd d MMMM yyyy"),
                dtpFin.Value.ToString("dddd d MMMM yyyy"));

            e.Graphics.DrawString(titre, policeTitre, brush,
                new RectangleF(margeGauche, margeHaut, largeurTotale, hauteurLigne + 5),
                new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

            // --- En-tête du tableau ---
            int y = margeHaut + hauteurLigne + 10;
            int x = margeGauche;

            e.Graphics.FillRectangle(brushFondEntete, new Rectangle(x, y, largeurTotale, hauteurLigne));

            foreach (var col in lesColonnes)
            {
                e.Graphics.DrawString(col.Titre, policeEntete, brushEntete,
                    new Rectangle(x, y, col.Largeur, hauteurLigne),
                    new StringFormat { Alignment = col.Alignement, LineAlignment = StringAlignment.Center });
                x += col.Largeur;
            }

            // --- Corps du tableau ---
            y += hauteurLigne;
            bool lignePaire = false;

            foreach (Visite v in visitesPeriode)
            {
                x = margeGauche;
                Brush brushFond = lignePaire ? new SolidBrush(Color.AliceBlue) : Brushes.White;
                e.Graphics.FillRectangle(brushFond, new Rectangle(x, y, largeurTotale, hauteurLigne));

                // Lieu = rue + ville du praticien 
                string lieu = v.LePraticien.Rue + " " + v.LePraticien.Ville;

                string[] valeurs =
                {
                    v.DateEtHeure.ToString("dddd d MMMM yyyy"),
                    v.DateEtHeure.ToString("HH:mm"),
                    v.LePraticien.NomPrenom,
                    v.LePraticien.Telephone,
                    lieu,
                    v.LeMotif.Libelle           
                };

                for (int i = 0; i < lesColonnes.Length; i++)
                {
                    e.Graphics.DrawString(valeurs[i], police, brush,
                        new Rectangle(x, y, lesColonnes[i].Largeur, hauteurLigne),
                        new StringFormat { Alignment = lesColonnes[i].Alignement, LineAlignment = StringAlignment.Center });
                    x += lesColonnes[i].Largeur;
                }

                y += hauteurLigne;
                lignePaire = !lignePaire;
            }

            e.HasMorePages = false;
        }
    }
}