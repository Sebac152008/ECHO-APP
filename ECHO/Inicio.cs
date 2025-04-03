using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        public static class RoundedControl
        {
            public static void SetRoundedShape(Control control, int radius)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                control.Region = new Region(path);
            }
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            monthCalendar1.Visible = false;
            RoundedControl.SetRoundedShape(panel3, 37); // 30 es el radio de las esquinas
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
            if (panel3.Visible)
            {
                DateTime dateTime = DateTime.Now;
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
            monthCalendar1.Visible = !monthCalendar1.Visible;
            if (monthCalendar1.Visible)
            {
                materialTextBox2.Visible = false;
                materialTextBox3.Visible = false;
                pictureBox1.Visible = false;
                materialLabel4.Visible = false;
            }
            else
            {
                materialTextBox2.Visible = true;
                materialTextBox3.Visible = true;
                pictureBox1.Visible = true;
                materialLabel4.Visible = true;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
