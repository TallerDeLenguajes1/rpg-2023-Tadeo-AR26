using System;
using Espacio.Personajes;
using Espacio.Fabrica;
using Espacio.Persistencia;

void Combate(List<Personaje> ListaPersonaje, int primero, int segundo)
{
    Random random = new Random();
    while (ListaPersonaje[primero].Salud > 0 && ListaPersonaje[segundo].Salud > 0)
    {
        int dano = ((ListaPersonaje[primero].Destreza * ListaPersonaje[primero].Fuerza * ListaPersonaje[primero].Nivel * random.Next(1,101)) -
                    (ListaPersonaje[segundo].Velocidad) * (ListaPersonaje[segundo].Armadura)) / 500;
        Console.WriteLine($"{ListaPersonaje[segundo].Nombre} RECIBE {dano} DE DAÑO");
        ListaPersonaje[segundo].Salud -= dano;
        Console.WriteLine($"Salud Restante: {ListaPersonaje[segundo].Salud}");

        if (ListaPersonaje[segundo].Salud <= 0)
        {
            Console.WriteLine($"{ListaPersonaje[segundo].Nombre} HA SIDO ELIMINADO");
            ListaPersonaje[primero].Habilidad();
            ListaPersonaje.RemoveAt(segundo);
            break;
        }

        dano = ((ListaPersonaje[segundo].Destreza * ListaPersonaje[segundo].Fuerza * ListaPersonaje[segundo].Nivel * random.Next(1,101)) -
                (ListaPersonaje[primero].Velocidad) * (ListaPersonaje[primero].Armadura)) / 500;
        Console.WriteLine($"{ListaPersonaje[primero].Nombre} RECIBE {dano} DE DAÑO");
        ListaPersonaje[primero].Salud -= dano;
        Console.WriteLine($"Salud Restante: {ListaPersonaje[primero].Salud}");

        if (ListaPersonaje[primero].Salud <= 0)
        {
            Console.WriteLine($"{ListaPersonaje[primero].Nombre} HA SIDO ELIMINADO");
            ListaPersonaje[segundo].Habilidad();
            ListaPersonaje.RemoveAt(primero);
            break;
        }
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
pjson.GuardarPersonaje("save" ,ListaPersonaje); //guardar personajes

while(ListaPersonaje.Count() != 1){
    Console.WriteLine($"Cantidad {ListaPersonaje.Count()}********************");
    Random random = new Random();
    int primero = 0, segundo = 0;
    while(primero == segundo){
        primero = random.Next(0, ListaPersonaje.Count());
        segundo = random.Next(0, (ListaPersonaje.Count())-1);
    }
    Console.WriteLine($"PRIMERO {primero} SEGUNDO {segundo} ************");
    if(ListaPersonaje[primero].Velocidad >= ListaPersonaje[segundo].Velocidad){
        Combate(ListaPersonaje, primero, segundo);
    }
    else{
        Combate(ListaPersonaje, segundo, primero);
    }
    Console.WriteLine("Presione Enter para continuar");
    Console.ReadLine();
}

foreach(Personaje per in ListaPersonaje){
    per.mostrarPersonaje();
}