using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ProyectoProgramacion
{
    internal abstract class Pregunta
    {
        public abstract Dictionary<string, string> EstablecerPreguntas();
        public abstract void HacerPregunta();
    }
}
