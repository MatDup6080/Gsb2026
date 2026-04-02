using Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interface
{
    public partial class FrmVisiteImpression : FrmBase
    {
        private List<Visite> lesVisites;
        public FrmVisiteImpression (Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }

        private void FrmVisiteImpression_Load(object sender, EventArgs e)
        {
            this.lblTitre.Text = "Impression des rendez-vous sur une période";
            this.Resize += (s, e) => centrerFormulaire();
           
        }
        private void centrerFormulaire()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
        }

    }
}
