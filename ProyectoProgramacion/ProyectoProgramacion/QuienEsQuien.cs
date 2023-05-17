using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoProgramacion
{
    public partial class QuienEsQuien : Form
    {
        public static Jugador jugador1;
        public static Jugador jugador2;
        public QuienEsQuien()
        {
            jugador1 = new Jugador();
            jugador2 = new Jugador();
            InitializeComponent();
        }
        private void SeleccionarPersonaje(string personaje)
        {
            List<Personaje> lista = Menu.listaPersonajes;
            if (jugador1.Elegido == null)
            {
                RecorrerTablero(jugador1, personaje);
                this.button2.BackgroundImage = Image.FromFile("contenido/jugador2.png");
            }
            else
            {
                RecorrerTablero(jugador2, personaje);
                this.Hide();
                TableroQuienEsQuien tablero = new TableroQuienEsQuien();
                tablero.Show();
            }
        }
        private void RecorrerTablero(Jugador jugador, string personaje)
        {
            List<Personaje> lista = Menu.listaPersonajes;
            jugador.Elegido = lista.Where(i => i.Nombre.Equals(personaje)).First();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void QuienEsQuien_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Fizz");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Ezreal");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Miss Fortune");
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Rammus");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Nami");
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Evelynn");
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Jhin");
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Yummi");
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Lux");
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Kayn");
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Morgana");
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Nasus");
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Mordekaiser");
        }
        private void pictureBox23_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Kog'maw");
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Neeko");
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Olaf");
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Illaoi");
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Kai'sa");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Ahri");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Amumu");
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            SeleccionarPersonaje("Wukong");
        }
    }
}
