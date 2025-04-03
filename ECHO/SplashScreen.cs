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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void AbrirFormHija(object formhija)
        {
            if (this.panel3.Controls.Count > 0)
                this.panel3.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel3.Controls.Add(fh);
            this.panel3.Tag = fh;
            fh.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Centrar PictureBox cuando la ventana cambie de tamaño
            CentrarPictureBox();
        }

        private void CentrarPictureBox()
        {
            pictureBox1.Location = new Point(
                (this.ClientSize.Width - pictureBox1.Width) / 2,
                (this.ClientSize.Height - pictureBox1.Height) / 2
            );
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 15;
            if (panel2.Width >= 1150)
            {
                timer1.Stop();
                panel2.Visible = false;
                panel1.Visible = false;
                pictureBox1.Visible = false;
                AbrirFormHija(new Ventana_de_navegacion());
            }
        }
    }
}
