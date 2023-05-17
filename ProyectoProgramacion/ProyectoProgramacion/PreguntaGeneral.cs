using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoProgramacion
{
    internal class PreguntaGeneral : Pregunta
    {
        private Dictionary<string, string> preguntas;

        public Dictionary<string, string> Preguntas { get => preguntas; set => preguntas = value; }

        public PreguntaGeneral()
        {
            preguntas = EstablecerPreguntas();
        }
        public override Dictionary<string, string> EstablecerPreguntas()
        {
            Dictionary<string, string> preguntas = new Dictionary<string, string>() {
                { "clase", "Tu personaje es de tipo "},
                { "genero", "Tu personaje es "},
                { "posicionPrimaria", "Tu personaje juega como "},
                { "posicionSecundaria", "Tu personaje juega como " },
                { "tipo", "Tu personaje utiliza " },
                { "tamaño", "Tu personaje es de tamaño " },
                { "humano", "Tu personaje es " },
                { "distancia", "Tu personaje ataca de " },
            };
            return preguntas;
        }
        public override void HacerPregunta()
        {
            Random rnd = new Random();
            int numPregunta = rnd.Next(0, preguntas.Count - 1);
            Adivina.nombrePregunta = preguntas.ElementAt(numPregunta).Key;
            Adivina.pregunta = preguntas.ElementAt(numPregunta).Value;
            Adivina.caractPersonaje = Adivina.SeleccionCaracteristicar(
                Adivina.listaPersonajes[rnd.Next(0, (Adivina.listaPersonajes.Count - 1))], Adivina.nombrePregunta);
            Adivina.pregunta += Adivina.caractPersonaje;
            preguntas.Remove(Adivina.nombrePregunta);
        }
    }
}
