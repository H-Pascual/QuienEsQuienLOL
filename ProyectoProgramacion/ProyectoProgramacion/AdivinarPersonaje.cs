using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoProgramacion
{
    public partial class AdivinarPersonaje : Form
    {
        public static Personaje personaje;
        public AdivinarPersonaje()
        {
            InitializeComponent();
            label1.Text = personaje.Nombre;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adivina a = new Adivina();
            a.Show();
        }
    }
}
