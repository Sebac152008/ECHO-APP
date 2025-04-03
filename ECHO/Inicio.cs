using MaterialSkin;
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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Amber700, TextShade.WHITE);
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel5.Visible = false;
        }

        private void materialMaskedTextBox1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void materialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
            if (materialCard1.Visible)
            {
                DateTime dateTime = DateTime.Now;
                materialTextBox2.Text = dateTime.ToString("dd/MM/yy");
                materialTextBox3.Text = dateTime.ToString("hh:mm tt");
            }
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnProgramar_Click(object sender, EventArgs e)
        {
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            materialTextBox2.Text = monthCalendar1.SelectionStart.ToString("dd/MM/yyyy");
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            panel5.Visible = !panel5.Visible;
        }
    }
}
