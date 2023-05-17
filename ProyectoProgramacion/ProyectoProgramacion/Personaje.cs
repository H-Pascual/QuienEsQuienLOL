using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProyectoProgramacion
{
    public class Personaje
    {
        private string nombre, clase, genero, posicionPrimaria, posicionSecundaria, tipo, tamaño, distanciaAtaque, aspecto, caracteristicas, habilidad, img;
        private bool humano;
        public Personaje(string nombre, string clase, string genero, string posicionPrimaria, string posicionSecundaria, string tipo, string tamaño, bool humano, string distanciaAtaque, string aspecto, string caracteristicas, string habilidad, string img)
        {
            this.nombre = nombre;
            this.clase = clase;
            this.genero = genero;
            this.posicionPrimaria = posicionPrimaria;
            this.posicionSecundaria = posicionSecundaria;
            this.tipo = tipo;
            this.tamaño = tamaño;
            this.distanciaAtaque = distanciaAtaque;
            this.aspecto = aspecto;
            this.caracteristicas = caracteristicas;
            this.habilidad = habilidad;
            this.img = "personajes/" + img; //Para que se guarde con la ubicación real
            this.humano = humano;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Clase { get => clase; set => clase = value; }
        public string Genero { get => genero; set => genero = value; }
        public string PosicionPrimaria { get => posicionPrimaria; set => posicionPrimaria = value; }
        public string PosicionSecundaria { get => posicionSecundaria; set => posicionSecundaria = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Tamaño { get => tamaño; set => tamaño = value; }
        public string DistanciaAtaque { get => distanciaAtaque; set => distanciaAtaque = value; }
        public string Aspecto { get => aspecto; set => aspecto = value; }
        public string Caracteristicas { get => caracteristicas; set => caracteristicas = value; }
        public string Habilidad { get => habilidad; set => habilidad = value; }
        public bool Humano { get => humano; set => humano = value; }
        public string Img { get => img; set => img = value; }
    }
}
