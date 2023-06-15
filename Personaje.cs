using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Espacio.Personaje{
    public class Personaje{
        private int velocidad;
        private int destreza;
        private int fuerza;
        private int nivel;
        private int armadura;
        private int salud;

        private string? tipo;
        private string? nombre;
        private string? apodo;
        private DateTime fecha_nacimiento;
        private int edad;
        public int Destreza { get => destreza; set => destreza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Velocidad { get => velocidad; set => velocidad = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Armadura { get => armadura; set => armadura = value; }
        public string? Tipo { get => tipo; set => tipo = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Apodo { get => apodo; set => apodo = value; }
        public DateTime Fecha_Nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Edad { get => salud; set => salud = value; }
    }

    public class FabricaDePersonajes{
        Personaje NuevoPersonaje = new Personaje();
        public string[] Tipos = {"Ogro", "Mago", "Caballero", "Duende"};
        public string[] Nombres = {"Tadeo", "Andrea", "Sergio"};

        public int obtenerAleatorio(int a, int b){
            Random random = new Random();
            return(random.Next(a,b));
        }
        public int obtenerEdad(){
            return((DateTime.Now.Subtract(NuevoPersonaje.Fecha_Nacimiento).Days) / 365);
        }
        public Personaje crearPersonaje(){
            NuevoPersonaje.Destreza = obtenerAleatorio(1,6);
            NuevoPersonaje.Nivel = obtenerAleatorio(1,11);
            NuevoPersonaje.Velocidad = obtenerAleatorio(1,11);
            NuevoPersonaje.Fuerza = obtenerAleatorio(1,11);
            NuevoPersonaje.Armadura = obtenerAleatorio(1, 11);
            NuevoPersonaje.Salud = 100;
            NuevoPersonaje.Fecha_Nacimiento = new DateTime(obtenerAleatorio(1700, 2024), obtenerAleatorio(1, 13), obtenerAleatorio(1,31));
            NuevoPersonaje.Edad = obtenerEdad();
            NuevoPersonaje.Tipo = Tipos[obtenerAleatorio(0,4)];
            NuevoPersonaje.Nombre = Nombres[obtenerAleatorio(0,3)];
            return NuevoPersonaje;
        }
    }

    public class PersonajesJson{
        public void GuardarPersonaje(string archivo, List<Personaje> personaje){
           string json = JsonSerializer.Serialize(personaje);
           File.WriteAllText(archivo + ".json", json);
        }

        //public List<Personaje> LeerPersonajes(string nombre, Personaje personaje){

        //}
        //public bool Existe(string nombre){

        //}
    }
}



