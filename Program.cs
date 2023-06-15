using System;
using Espacio.Personaje;

Personaje NuevoPersonaje;
FabricaDePersonajes fp = new FabricaDePersonajes();
NuevoPersonaje = fp.crearPersonaje();
Console.WriteLine(NuevoPersonaje.Nombre);
