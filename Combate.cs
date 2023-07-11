using System;
using Espacio.Personajes;

namespace Espacio.Combates{
    public class Combate{
        public List<Personaje> Combatir(List<Personaje> ListaDePersonajes, Personaje Usuario){
            int action = 1, dano;
            Random random = new Random();
            bool x;
            while((ListaDePersonajes[0].Salud > 0) && (Usuario.Salud > 0)){
                Console.WriteLine($"{Usuario.Apodo} vs {ListaDePersonajes[0].Nombre}");
                Console.WriteLine($"{Usuario.Salud} PS  {ListaDePersonajes[0].Salud}");
                Console.WriteLine("╔═══════════════════════════════════════════╗");
                Console.WriteLine("║                                           ║");
                Console.WriteLine("║1-Combatir    2-Usar Objeto    3-Habilidad ║");
                Console.WriteLine("║                                           ║");
                Console.WriteLine("╚═══════════════════════════════════════════╝");
                x = int.TryParse(Console.ReadLine(), out action);
                switch(action){
                    case 1:
                        if(Usuario.Velocidad > ListaDePersonajes[0].Velocidad){
                            dano = ((Usuario.Destreza * Usuario.Fuerza * Usuario.Nivel * random.Next(1,101)) - (ListaDePersonajes[0].Velocidad * ListaDePersonajes[0].Armadura)) / 500;
                            Console.WriteLine($"{ListaDePersonajes[0].Nombre} Recibe {dano} de daño");
                            ListaDePersonajes[0].Salud -= dano;
                            Console.WriteLine($"Salud restante {ListaDePersonajes[0].Salud}");
                            if(ListaDePersonajes[0].Salud <= 0){
                                Console.WriteLine($"{ListaDePersonajes[0].Apodo} Ha sido eliminado");
                                Usuario.Habilidad();
                                ListaDePersonajes.RemoveAt(0);
                                Console.ReadLine();
                                break;
                            }
                            dano = ((ListaDePersonajes[0].Destreza * ListaDePersonajes[0].Fuerza * ListaDePersonajes[0].Nivel * random.Next(1,101)) - (Usuario.Velocidad * Usuario.Armadura)) / 500;
                            Console.Write($"{Usuario.Apodo} Recibe {dano} de daño\n");
                            Usuario.Salud -= dano;
                            Console.WriteLine($"Salud restante {Usuario.Salud}");
                            if(ListaDePersonajes[0].Salud <= 0){
                                Console.WriteLine($"{ListaDePersonajes[0].Apodo} Ha sido eliminado");
                                Console.WriteLine($"GAME OVER");
                                Console.ReadLine();
                                break;
                            }
                            Console.ReadLine();
                        }
                        break;
                }
            }
            return ListaDePersonajes;
        }
    }
}