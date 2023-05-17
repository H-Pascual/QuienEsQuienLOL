using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoProgramacion
{
    public partial class Ayuda : Form
    {
        private string[] fondo;
        private int numFondo;
        public Ayuda()
        {
            InitializeComponent();
            numFondo = 0;
            fondo = new string[] { "contenido/background0.png", "contenido/background1.png", 
                "contenido/background2.png", "contenido/background3.png" };
            pictureBox1.BackgroundImage = Image.FromFile(fondo[numFondo]);
        }
        private void CambiarFondo()
        {
            if (numFondo < 0)
                numFondo = 0;
            else if (numFondo > 3)
                numFondo = 3;
            pictureBox1.BackgroundImage = Image.FromFile(fondo[numFondo]);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numFondo++;
            CambiarFondo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numFondo--;
            CambiarFondo();
        }
    }
}
