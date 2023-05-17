using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace ProyectoProgramacion
{
    public partial class Adivina : Form
    {
        public static string nombrePregunta;
        public static string caractPersonaje;
        public static string pregunta;
        public static List<Personaje> listaPersonajes;
        private string tipoPregunta;
        private PreguntaGeneral preguntasGenerales;
        private PreguntaConcreta preguntasConcretas;
        public Adivina()
        {
            tipoPregunta = "general";
            preguntasGenerales = new PreguntaGeneral();
            preguntasConcretas = new PreguntaConcreta();
            listaPersonajes = new List<Personaje>();
            listaPersonajes.AddRange(Menu.listaPersonajes);
            InitializeComponent();
            PreguntarUsuario();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void Adivina_Load(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tipoPregunta == "general")
                DescartarPregunta(true);
            else
                Adivinar(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tipoPregunta == "general")
                DescartarPregunta(false);
            else
                Adivinar(false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PreguntarUsuario();
        }
        private void PreguntarUsuario()
        {
            ComprobarPersonajes();
            if (listaPersonajes.Count > 10 && (preguntasGenerales.Preguntas.Count - 1) > 0)
            {
                tipoPregunta = "general";
                preguntasGenerales.HacerPregunta();
                label1.Text = pregunta;
            }

            else if ((listaPersonajes.Count > 0 && listaPersonajes.Count < 10) && (preguntasConcretas.Preguntas.Count) > 0)
            {
                tipoPregunta = "concreta";
                preguntasConcretas.HacerPregunta();
                label1.Text = pregunta;
            }
            else
            {
                tipoPregunta = "general";
                preguntasConcretas = new PreguntaConcreta();
                preguntasGenerales = new PreguntaGeneral();
                preguntasGenerales.HacerPregunta();
                label1.Text = pregunta;
            }
        }
        private void ComprobarPersonajes()
        {
            if (listaPersonajes.Count == 1)
                PantallaFinal(listaPersonajes[0]);
            else if (listaPersonajes.Count < 1)
                listaPersonajes.AddRange(Menu.listaPersonajes);
        }
        private void DescartarPregunta(bool respuesta)
        {
            if (nombrePregunta == "humano")
            {
                if (respuesta)
                    pregunta = "humano";
                else if (!respuesta)
                    pregunta = "no humano";
            }
            foreach (Personaje a in listaPersonajes.ToList())
            {
                string caracteristica = SeleccionCaracteristicar(a, nombrePregunta);
                if (respuesta)
                    DescartarPersonajeTrue(caracteristica, a);

                else if (!respuesta)
                    DescartarPersonajeFalse(caracteristica, a);
            }
            PreguntarUsuario();
        }
        private void DescartarPersonajeTrue(string caracteristica, Personaje personaje)
        {
            if (nombrePregunta != "posicionPrimaria" && nombrePregunta != "posicionSecundaria")
            {
                if (caracteristica != caractPersonaje)
                    listaPersonajes.Remove(personaje);
            }
            else
            {
                if (SeleccionCaracteristicar(personaje, "posicionPrimaria") != caractPersonaje &&
                        SeleccionCaracteristicar(personaje, "posicionSecundaria") != caractPersonaje)
                    listaPersonajes.Remove(personaje);
            }
        }
        private void DescartarPersonajeFalse(string caracteristica, Personaje personaje)
        {
            if (nombrePregunta != "posicionPrimaria" && nombrePregunta != "posicionSecundaria")
            {
                if (caracteristica == caractPersonaje)
                    listaPersonajes.Remove(personaje);
            }
            else
            {
                if (SeleccionCaracteristicar(personaje, "posicionPrimaria") == caractPersonaje ||
                        SeleccionCaracteristicar(personaje, "posicionSecundaria") == caractPersonaje)
                    listaPersonajes.Remove(personaje);
            }
        }
        private void Adivinar(bool respuesta)
        {
            Personaje personaje = null;
            int contador = 0;
            while(contador < listaPersonajes.Count-1 && personaje == null)
            {
                string caracteristica = SeleccionCaracteristicar(listaPersonajes[contador], nombrePregunta);
                if (respuesta)
                    personaje = AdivinarPersonajes(caracteristica, listaPersonajes[contador]);
                else if(!(respuesta))
                    DescartarPersonajeFalse(caracteristica, listaPersonajes[contador]);
                contador++;
            }
            if (personaje != null)
                PantallaFinal(personaje);
            else
                PreguntarUsuario();
        }
        private Personaje AdivinarPersonajes(string caracteristica, Personaje personaje)
        {
            Personaje seleccionado = null;
            if (caracteristica == caractPersonaje)
                seleccionado = personaje;
            else
                listaPersonajes.Remove(personaje);
            return seleccionado;
        }
        public static string SeleccionCaracteristicar(Personaje a, string pregunta)
        {
            string caracteristica = "";
            switch (pregunta)
            {
                case "clase":
                    caracteristica = a.Clase;
                    break;
                case "genero":
                    caracteristica = a.Genero;
                    break;
                case "posicionPrimaria":
                    caracteristica = a.PosicionPrimaria;
                    break;
                case "posicionSecundaria":
                    caracteristica = a.PosicionSecundaria;
                    break;
                case "tipo":
                    caracteristica = a.Tipo;
                    break;
                case "tamaño":
                    caracteristica = a.Tamaño;
                    break;
                case "humano":
                    if (a.Humano)
                        caracteristica = "humano";
                    else
                        caracteristica = "no humano";
                    break;
                case "distancia":
                    caracteristica = a.DistanciaAtaque;
                    break;
                case "aspecto":
                    caracteristica = a.Aspecto;
                    break;
                case "caracteristicas":
                    caracteristica = a.Caracteristicas;
                    break;
                case "habilidad":
                    caracteristica = a.Habilidad;
                    break;
            }
            return caracteristica;
        }
        private void PantallaFinal(Personaje p)
        {
            AdivinarPersonaje.personaje = p;
            this.Hide();
            AdivinarPersonaje a = new AdivinarPersonaje();
            a.Show();
        }
    }
}