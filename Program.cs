using System;
using Espacio.Personaje;

Personaje NuevoPersonaje;
FabricaDePersonajes fp = new FabricaDePersonajes(); //Inicializo las funciones fabrica y pjson.
PersonajesJson pjson = new PersonajesJson();

List<Personaje> ListaPersonaje = new List<Personaje>(); //Creo una lista de personajes

for(int i = 0; i<10; i++){
    NuevoPersonaje = fp.crearPersonaje();
    ListaPersonaje.Add(NuevoPersonaje); //Crear 10 personajes de forma aleatoria y añadirlos a la lista
}
Console.WriteLine(ListaPersonaje[1].Velocidad);

while(ListaPersonaje.Count() != 1){
    Random random = new Random();
    int primero = 0, segundo = 0;
    while(primero == segundo){
        primero = random.Next(0, ListaPersonaje.Count());
        segundo = random.Next(0, ListaPersonaje.Count());
    }
    while((ListaPersonaje[Primero].Salud > 0) && (ListaPersonaje[Primero].Salud > 0)){
        
    }
}
//pjson.GuardarPersonaje("save" ,ListaPersonaje); //guardar personajes