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
    public partial class FrmVisiteBilan : FrmBase
    {
        public FrmVisiteBilan(Session uneSession) : base(uneSession)
        {
            InitializeComponent();
        }
        private void FrmVisiteBilan_Load(object sender, EventArgs e)
        {
            this.lblTitre.Text = "Enregistrer le bilan de la visite";
            centrerFormulaire();
        }

       private void FrmVisiteBilan_Resize(object sender, EventArgs e)
        {
            centrerFormulaire();
        }

        private void centrerFormulaire()
        {
            panelCentral.Left = (this.ClientSize.Width - panelCentral.Width) / 2;
            panelCentral.Top = (this.ClientSize.Height - panelCentral.Height) / 2;
        }
       
    }
}