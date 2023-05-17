using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoProgramacion
{
    internal class PreguntaConcreta : Pregunta
    {
        private Dictionary<string, string> preguntas;

        public Dictionary<string, string> Preguntas { get => preguntas; set => preguntas = value; }

        public PreguntaConcreta()
        {
            preguntas = EstablecerPreguntas();
        }
        public override Dictionary<string, string> EstablecerPreguntas()
        {
            Dictionary<string, string> preguntas = new Dictionary<string, string>() {
                { "aspecto", "Tu personaje " },
                { "caracteristicas", "Tu personaje " },
                { "habilidad", "Tu personaje " }
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
