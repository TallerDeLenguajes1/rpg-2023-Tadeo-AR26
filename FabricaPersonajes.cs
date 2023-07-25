using Espacio.Personajes;

namespace Espacio.Fabrica{
    public class FabricaDePersonajes{
        public string[] Tipos = {"Mago", "Ladron", "Santo", "Clerigo", "Real", "Caballero"};
        public string[] Nombres = {"Orwell", "Aleister", "Crowley", "Carissa", "Elizard", "Kanzaki", "Mathers", "Kingsford", "Sprengel", "Aradia", "Izzard", "Marian", "Thor", "Mjolnir", "Fiamma", "Terra", "Birdway", "Othinus", "Felkin", "Cromwell", "Sigyn", "Bersi", "Wescott"};

        public int obtenerAleatorio(int a, int b){
            Random random = new Random();
            return(random.Next(a,b));
        }
        
        public Personaje crearPersonaje(){
            Personaje NuevoPersonaje = new Personaje();
            NuevoPersonaje.Destreza = obtenerAleatorio(1,6);
            NuevoPersonaje.Nivel = obtenerAleatorio(1,11);
            NuevoPersonaje.Velocidad = obtenerAleatorio(1,11);
            NuevoPersonaje.Fuerza = obtenerAleatorio(1,11);
            NuevoPersonaje.Armadura = obtenerAleatorio(1, 11);
            NuevoPersonaje.Salud = 100;
            NuevoPersonaje.Fecha_Nacimiento = new DateTime(obtenerAleatorio(1700, 2024), obtenerAleatorio(1, 13), obtenerAleatorio(1,28));
            NuevoPersonaje.Edad = DateTime.Now.Subtract(NuevoPersonaje.Fecha_Nacimiento).Days / 365;
            NuevoPersonaje.Tipo = Tipos[obtenerAleatorio(0,6)];
            NuevoPersonaje.Nombre = Nombres[obtenerAleatorio(0,23)];
            return NuevoPersonaje;
        }

        public Personaje Usuario(){
            Personaje PersonajeUsuario = new Personaje();
            Console.WriteLine("CREACIÓN DE PERSONAJE");
            Console.WriteLine("Nombre del personaje:");
            PersonajeUsuario.Nombre = Console.ReadLine();
            Console.WriteLine("Apodo del personaje");
            PersonajeUsuario.Apodo = Console.ReadLine();
            Console.WriteLine("Clase:");
            Console.WriteLine("1- Mago");
            Console.WriteLine("2- Ladrón");
            Console.WriteLine("3- Santo");
            Console.WriteLine("4- Clérigo");
            Console.WriteLine("5- Real");
            Console.WriteLine("6- Caballero");
            int Tipo;
            bool x;
            x = int.TryParse(Console.ReadLine(), out Tipo);
            PersonajeUsuario.Tipo = Tipos[Tipo-1];
            PersonajeUsuario.Destreza = 5;
            PersonajeUsuario.Nivel = 5;
            PersonajeUsuario.Velocidad = 5;
            PersonajeUsuario.Fuerza = 8;
            PersonajeUsuario.Armadura = 8;
            PersonajeUsuario.Salud = 100;
            PersonajeUsuario.Fecha_Nacimiento = new DateTime(obtenerAleatorio(1700, 2024), obtenerAleatorio(1, 13), obtenerAleatorio(1,28));
            PersonajeUsuario.Edad = DateTime.Now.Subtract(PersonajeUsuario.Fecha_Nacimiento).Days / 365;
            return PersonajeUsuario;
        }

        public Personaje FinalBoss(){
            Personaje FinalBoss = new Personaje();
            FinalBoss.Destreza = 10;
            FinalBoss.Nivel = 5;
            FinalBoss.Velocidad = 7;
            FinalBoss.Fuerza = 7;
            FinalBoss.Armadura = 7;
            FinalBoss.Salud = 350;
            FinalBoss.Fecha_Nacimiento = new DateTime(obtenerAleatorio(1700, 2024), obtenerAleatorio(1, 13), obtenerAleatorio(1,28));
            FinalBoss.Edad = DateTime.Now.Subtract(FinalBoss.Fecha_Nacimiento).Days / 365;
            FinalBoss.Tipo = "Boss";
            FinalBoss.Nombre = Nombres[obtenerAleatorio(0,23)];
            return FinalBoss;
        }
    }
}