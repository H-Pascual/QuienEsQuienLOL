using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace ProyectoProgramacion
{
    public class Jugador
    {
        private Personaje elegido;
        private int vidas;
        private List<string> personajes;
        public Jugador()
        {
            vidas = 3;
            personajes = InsertarPersonajes();
        }
        public Personaje Elegido { get => elegido; set => elegido = value; }
        public int Vidas { get => vidas; set => vidas = value; }
        public List<string> Personajes { get => personajes; set => personajes = value; }
        private List<string> InsertarPersonajes()
        {
            List<string> lista = new List<string>
            {
                { "Ezreal"},
                { "Fizz"},
                { "Miss Fortune"},
                { "Rammus"},
                { "Nami"},
                { "Evelynn"},
                { "Jhin"},
                { "Yummi"},
                { "Lux"},
                { "Kayn"},
                { "Morgana"},
                { "Nasus"},
                { "Mordekaiser"},
                { "Kog'maw"},
                { "Neeko"},
                { "Olaf"},
                { "Illaoi"},
                { "Kai'sa"},
                { "Ahri"},
                { "Amumu"},
                { "Wukong"}
            };
            return lista;
        }
    }
}
