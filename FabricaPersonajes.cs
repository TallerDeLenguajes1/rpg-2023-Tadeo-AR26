using Espacio.Personajes;

namespace Espacio.Fabrica{
    public class FabricaDePersonajes{
        
        public string[] Tipos = {"Magician", "Esper", "Saint", "Trascendent", "Royal", "Knight"};
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
    }
}