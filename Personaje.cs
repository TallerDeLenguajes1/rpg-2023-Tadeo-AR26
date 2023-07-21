using System;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Espacio.Personajes{
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
        public int Edad { get => edad; set => edad = value; }

        public void mostrarPersonaje(){
            Console.WriteLine($"Nombre: {Nombre}");
            Console.WriteLine($"Tipo: {Tipo}");
        }
        public void Habilidad(){
            switch(Tipo){
                case "Clerigo":
                    Console.WriteLine($"{Nombre} ha usado su habilidad");
                    Console.WriteLine($"{Nombre} se ha curado 30 de vida");
                    Salud = Salud + 30;
                    break;
                case "Ladron":
                    Console.WriteLine($"{Nombre} ha usado su habilidad");
                    Console.WriteLine($"{Nombre} ha obtenido +2 de ataque por el resto del combate");
                    Fuerza = Fuerza + 2;
                    break;
                case "Santo":
                    Console.WriteLine($"{Nombre} ha usado su habilidad");
                    Console.WriteLine($"{Nombre} ha obtendio +2 de velocidad por el resto del combate");
                    Velocidad = Velocidad + 2;
                    break;
                case "Mago":
                    Console.WriteLine($"{Nombre} ha usado su habilidad");
                    Console.WriteLine($"{Nombre} ha obtenido +2 de destreza por el resto del combate");
                    Destreza = Destreza + 2;
                    break;
                case "Real":
                    Console.WriteLine($"{Nombre} ha usado su habilidad");
                    Console.WriteLine($"{Nombre} ha obtenido +1 de destreza y +1 de fuerza por el resto del combate");
                    Destreza = Destreza + 1;
                    Fuerza = Fuerza + 1;
                    break;
                case "Caballero":
                    Console.WriteLine($"{Nombre} ha usado su habilidad");
                    Console.WriteLine($"{Nombre} ha obtenido +2 de armadura por el resto del combate");
                    Armadura = Armadura + 2;
                    break;
            }
        }
        public void undoHabilidad(){
            switch(Tipo){
                case "Ladron":
                    Fuerza = Fuerza - 2;
                    break;
                case "Santo":
                    Velocidad = Velocidad - 2;
                    break;
                case "Mago":
                    Destreza = Destreza - 2;
                    break;
                case "Real":
                    Destreza = Destreza - 1;
                    Fuerza = Fuerza - 1;
                    break;
                case "Caballero":
                    Armadura = Armadura - 2;
                    break;
            }
        }
    }


  
}



