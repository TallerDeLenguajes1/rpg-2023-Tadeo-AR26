using System;
using Espacio.Personaje;

void Combate(int primero, int segundo){
    while((ListaPersonaje[primero] > 0) && (ListaPersonaje[segundo] > 0)){
        int dano = ((ListaPersonaje[primero].Destreza * ListaPersonaje[primero].Fuerza * ListaPersonaje[primero].Nivel) - (ListaPersonaje[segundo].Velocidad * ListaPersonaje[segundo].armadura))/500;
        Console.WriteLine($"{ListaPersonaje[segundo].Apodo}RECIBE {dano} DE DAÑO");
        ListaPersonaje[segundo].Salud -= dano;
        Console.WriteLine($"Salud Restante: {ListaPersonaje[segundo].Salud}");
        int dano = ((ListaPersonaje[segundo].Destreza * ListaPersonaje[segundo].Fuerza * ListaPersonaje[segundo].Nivel) - (ListaPersonaje[primero].Velocidad * ListaPersonaje[primero].armadura))/500;
        Console.WriteLine($"{ListaPersonaje[primero].Apodo}RECIBE {dano} DE DAÑO");
        ListaPersonaje[primero].Salud -= dano;
        Console.WriteLine($"Salud Restante: {ListaPersonaje[primero].Salud}");
    }
    if(ListaPersonaje[primero] <= 0){
        ListaPersonaje.Remove(ListaPersonaje[primero]);
    }
    if(ListaPersonaje[segundo] <= 0){
        ListaPersonaje.Remove(ListaPersonaje[segundo]);
    }
}

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
    Random random = new Random();h
    int primero = 0, segundo = 0;
    while(primero == segundo){
        primero = random.Next(0, ListaPersonaje.Count());
        segundo = random.Next(0, ListaPersonaje.Count());
    }
    if(ListaPersonaje[primero].Velocidad > ListaPersonaje[segundo].Velocidad){
        Combate(primero, segundo);
    }
}
//pjson.GuardarPersonaje("save" ,ListaPersonaje); //guardar personajes