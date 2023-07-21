using System;
using Espacio.Personajes;
using Espacio.Fabrica;
using Espacio.Persistencia;
using Espacio.Combates;

Personaje NuevoPersonaje, Usuario;
FabricaDePersonajes fp = new FabricaDePersonajes(); //Inicializo las funciones fabrica y pjson.
PersonajesJson pjson = new PersonajesJson();
Combate cb = new Combate();

List<Personaje> ListaPersonaje = new List<Personaje>(); //Creo una lista de personajes

if(pjson.Existe("save.json")){
    ListaPersonaje = pjson.LeerPersonajes("\\save.json");
}
else{
    for(int i = 0; i<10; i++){
        NuevoPersonaje = fp.crearPersonaje();
        ListaPersonaje.Add(NuevoPersonaje); //Crear 10 personajes de forma aleatoria y añadirlos a la lista
    }
    pjson.GuardarPersonaje("save" ,ListaPersonaje); //guardar personajes
}
Usuario = fp.Usuario();
ListaPersonaje = cb.Combatir(ListaPersonaje, Usuario);