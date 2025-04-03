using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ECHO
{
    public partial class Ventana_de_navegacion : Form
    {
        public Ventana_de_navegacion()
        {
            InitializeComponent();
            AbrirFormHija(new Inicio());
        }

        private void AbrirFormHija(object formhija)
        {
            if (this.ConexionVentanas.Controls.Count > 0)
                this.ConexionVentanas.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.ConexionVentanas.Controls.Add(fh);
            this.ConexionVentanas.Tag = fh;
            fh.Show();
        }
    }
}
