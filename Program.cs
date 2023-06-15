using System;
using Espacio.Personaje;

Personaje NuevoPersonaje;
FabricaDePersonajes fp = new FabricaDePersonajes();
NuevoPersonaje = fp.crearPersonaje();
Console.WriteLine(NuevoPersonaje.Nombre);
PersonajesJson pjson = new PersonajesJson();

List<Personaje> ListaPersonaje = new List<Personaje>();

for(int i = 0; i<10; i++){
    NuevoPersonaje = fp.crearPersonaje();
    ListaPersonaje.Add(NuevoPersonaje);
}
pjson.GuardarPersonaje("save" ,ListaPersonaje);