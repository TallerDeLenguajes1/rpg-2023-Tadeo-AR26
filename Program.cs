using System;
using System.Net;
using System.Text.Json;
using Espacio.Personajes;
using Espacio.Fabrica;
using Espacio.Persistencia;
using Espacio.Combates;
using Espacio.Quotes;

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
NuevoPersonaje = fp.FinalBoss();
ListaPersonaje.RemoveAt(0);
ListaPersonaje.Add(NuevoPersonaje);

var url = $"https://api.adviceslip.com/advice";
var request = (HttpWebRequest)WebRequest.Create(url);
request.Method = "GET";
request.ContentType = "application/json";
request.Accept = "application/json";

try{
    using(WebResponse response = request.GetResponse()){
        using(Stream strReader = response.GetResponseStream()){
            if(strReader == null) return;
            using(StreamReader objReader = new StreamReader(strReader)){
                string ResponseBody = objReader.ReadToEnd();
                Root quote = JsonSerializer.Deserialize<Root>(ResponseBody);
                for(int i = 0; i < quote.slip.advice.Length; i++){
                    Console.Write($"{quote.slip.advice[i]}");
                    Thread.Sleep(70);
                }
                Console.Write("...");
                Thread.Sleep(3000);
            }
        }
    }
}
catch (WebException ex){
    Console.WriteLine("No se ha podido acceder a la API");
}

ListaPersonaje = cb.Combatir(ListaPersonaje, Usuario);