using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Espacio.Personajes;

namespace Espacio.Persistencia{
      public class PersonajesJson{
        public void GuardarPersonaje(string archivo, List<Personaje> personaje){
           string json = JsonSerializer.Serialize(personaje);
           File.WriteAllText(archivo + ".json", json);
        }
        public List<Personaje> LeerPersonajes(string archivo){
            List<Personaje> ListaPersonaje = new List<Personaje>();
            string pathJSON = Directory.GetCurrentDirectory()+archivo;
            string Json = File.ReadAllText(pathJSON);
            ListaPersonaje = JsonSerializer.Deserialize<List<Personaje>>(Json); //
            return ListaPersonaje;
        }
    }
}