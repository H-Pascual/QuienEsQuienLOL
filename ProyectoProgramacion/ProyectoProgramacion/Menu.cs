using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ProyectoProgramacion
{
    public partial class Menu : Form
    {
        public static List<Personaje> listaPersonajes;
        public Menu()
        {
            listaPersonajes = LeerDatos("personajes.txt");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adivina adivinaJuego = new Adivina();
            adivinaJuego.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuienEsQuien quienJuego = new QuienEsQuien();
            quienJuego.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ayuda ayuda = new Ayuda();
            ayuda.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private List<Personaje> LeerDatos(string fichero)
        {
            List<Personaje> personajes = new List<Personaje>();
            try
            {
                string[] texto = File.ReadAllLines(fichero);
                bool humano;
                foreach (string a in texto)
                {
                    string[] datos = a.Split(';');
                    if (Boolean.TryParse(datos[7], out humano))
                    {
                        Personaje personaje = new Personaje(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6], humano,
                            datos[8], datos[9], datos[10], datos[11], datos[12]);
                        personajes.Add(personaje);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return personajes;
        }
        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
