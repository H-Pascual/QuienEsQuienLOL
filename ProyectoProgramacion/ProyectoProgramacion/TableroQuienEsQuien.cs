using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoProgramacion
{
    public partial class TableroQuienEsQuien : Form
    {
        private bool borrar, adivinar;
        private string jugadorTurno;
        private Jugador jugador1;
        private Jugador jugador2;
        private Dictionary<string, PictureBox> lista;

        public TableroQuienEsQuien()
        {
            InitializeComponent();
            jugador1 = QuienEsQuien.jugador1;
            jugador2 = QuienEsQuien.jugador2;
            jugadorTurno = "jugador1";
            lista = RellenarLista();
        }
        private Dictionary<string, PictureBox> RellenarLista()
        {
            Dictionary<string, PictureBox> lista = new Dictionary<string, PictureBox>
            {
                { "Ezreal", pictureBox9},
                { "Fizz", pictureBox10},
                { "Miss Fortune", pictureBox15},
                { "Rammus", pictureBox22},
                { "Nami", pictureBox14},
                { "Evelynn", pictureBox21},
                { "Jhin", pictureBox29},
                { "Yummi", pictureBox36},
                { "Lux", pictureBox28},
                { "Kayn", pictureBox27},
                { "Morgana", pictureBox26},
                { "Nasus", pictureBox25},
                { "Mordekaiser", pictureBox24},
                { "Kog'maw", pictureBox23},
                { "Neeko", pictureBox35},
                { "Olaf", pictureBox33},
                { "Illaoi", pictureBox32},
                { "Kai'sa", pictureBox30},
                { "Ahri", pictureBox2},
                { "Amumu", pictureBox11},
                { "Wukong", pictureBox19}
            };
            return lista;
        }
        private void PulsarBoton(string key)
        {  
            if (borrar)
            {
                if(jugadorTurno == "jugador1")
                    BorrarPersonaje(key, jugador1);
                else
                    BorrarPersonaje(key, jugador2);
            }
            else if (adivinar)
            {
                if (jugadorTurno == "jugador1")
                    AdivinarPersonaje(key, jugador2, jugador1);
                else
                    AdivinarPersonaje(key, jugador1, jugador2);
            }
        }
        private void BorrarPersonaje(string key, Jugador jugador)
        {
            lista[key].Visible = false;
            jugador.Personajes.Remove(key);
            ComprobarPersonajes(jugador);
        }
        private void ComprobarPersonajes(Jugador jugador)
        {
            if(jugador.Personajes.Count < 1)
            {
                jugador.Vidas = 1;
                QuitarVida(jugador);
            }
        }
        private void QuitarVida(Jugador jugador)
        {
            switch (jugador.Vidas)
            {
                case 3:
                    pictureBox7.BackgroundImage = Image.FromFile("contenido/vidaeliminada.png");
                    break;
                case 2:
                    pictureBox6.BackgroundImage = Image.FromFile("contenido/vidaeliminada.png");
                    break;
                case 1:
                    pictureBox5.BackgroundImage = Image.FromFile("contenido/vidaeliminada.png");
                    PantallaGanar();
                    break;
            }
            jugador.Vidas--;
        }
        private void AdivinarPersonaje(string personaje, Jugador adivinar, Jugador jugador)
        {
            if (personaje == adivinar.Elegido.Nombre)
                PantallaGanar();
            else
                QuitarVida(jugador);
        }
        private void PantallaGanar()
        {
            pictureBox8.Visible = true;
            pictureBox8.BringToFront();
            button1.BringToFront();
            if (jugadorTurno == "jugador1")
            {
                if(jugador1.Vidas > 1)
                    pictureBox8.BackgroundImage = Image.FromFile("contenido/victoria1.png");
                else
                    pictureBox8.BackgroundImage = Image.FromFile("contenido/victoria2.png");
            }
            else if(jugadorTurno == "jugador2")
            {
                if (jugador2.Vidas > 1)
                    pictureBox8.BackgroundImage = Image.FromFile("contenido/victoria2.png");
                else
                    pictureBox8.BackgroundImage = Image.FromFile("contenido/victoria1.png");
            }
        }
        private void CambiarJugador(Jugador jugador)
        {
            ComprobarPersonajes(jugador);
            ComprobarVidas(jugador);
            ComprobarLista(jugador);
        }
        private void ComprobarLista(Jugador jugador)
        {
            foreach(KeyValuePair<string, PictureBox> a in lista)
            {
                if (jugador.Personajes.Contains(a.Key))
                    a.Value.Visible = true;
                else
                    a.Value.Visible = false;
            }
        }
        private void ComprobarVidas(Jugador jugador)
        {
            switch (jugador.Vidas)
            {
                case 1:
                    pictureBox5.BackgroundImage = Image.FromFile("contenido/vida.png");
                    pictureBox6.BackgroundImage = Image.FromFile("contenido/vidaeliminada.png");
                    pictureBox7.BackgroundImage = Image.FromFile("contenido/vidaeliminada.png");
                    break;
                case 2:
                    pictureBox5.BackgroundImage = Image.FromFile("contenido/vida.png");
                    pictureBox6.BackgroundImage = Image.FromFile("contenido/vida.png");
                    pictureBox7.BackgroundImage = Image.FromFile("contenido/vidaeliminada.png");
                    break;
                case 3:
                    pictureBox5.BackgroundImage = Image.FromFile("contenido/vida.png");
                    pictureBox6.BackgroundImage = Image.FromFile("contenido/vida.png");
                    pictureBox7.BackgroundImage = Image.FromFile("contenido/vida.png");
                    break;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            borrar = false;
            adivinar = false;
            if (jugadorTurno == "jugador1")
            {
                jugadorTurno = "jugador2";
                button2.BackgroundImage = Image.FromFile("contenido/jugador2.png");
                CambiarJugador(jugador2);
            }
            else
            {
                jugadorTurno = "jugador1";
                button2.BackgroundImage = Image.FromFile("contenido/jugador1.png");
                CambiarJugador(jugador1);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            borrar = true;
            adivinar = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            borrar = false;
            adivinar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PulsarBoton("Ezreal");
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            PulsarBoton("Fizz");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            PulsarBoton("Miss Fortune");
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            PulsarBoton("Rammus");
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            PulsarBoton("Nami");
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            PulsarBoton("Evelynn");
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            PulsarBoton("Jhin");
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            PulsarBoton("Yummi");
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            PulsarBoton("Lux");
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            PulsarBoton("Kayn");
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            PulsarBoton("Morgana");
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            PulsarBoton("Nasus");
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            PulsarBoton("Mordekaiser");
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            PulsarBoton("Kog'maw");
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            PulsarBoton("Neeko");
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            PulsarBoton("Olaf");
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            PulsarBoton("Illaoi");
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            PulsarBoton("Kai'sa");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PulsarBoton("Ahri");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            PulsarBoton("Amumu");
        }
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            PulsarBoton("Wukong");
        }
    }
}
