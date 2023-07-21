using System;
using Espacio.Personajes;
using System.Threading;
namespace Espacio.Combates{
    public class Combate{
        public List<Personaje> Combatir(List<Personaje> ListaDePersonajes, Personaje Usuario){
            int action = 1, dano, habilidadFlag = 0;
            Random random = new Random();
            bool x;
            while((ListaDePersonajes[0].Salud > 0) && (Usuario.Salud > 0)){
                Console.Clear();
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
                                Usuario.Nivel++;
                                Usuario.Fuerza += 1;
                                Usuario.Armadura += 1;
                                Usuario.Velocidad += 1;
                                Usuario.Salud += 20;
                                if(habilidadFlag == 1){
                                    Usuario.undoHabilidad();
                                    habilidadFlag = 0;
                                }
                                if(ListaDePersonajes.Count() > 1){ListaDePersonajes.RemoveAt(0);}
                                else{break;}
                                Console.ReadLine();
                                break;
                            }
                            dano = ((ListaDePersonajes[0].Destreza * ListaDePersonajes[0].Fuerza * ListaDePersonajes[0].Nivel * random.Next(1,101)) - (Usuario.Velocidad * Usuario.Armadura)) / 500;
                            Console.Write($"{Usuario.Apodo} Recibe {dano} de daño\n");
                            Usuario.Salud -= dano;
                            Console.WriteLine($"Salud restante {Usuario.Salud}");
                            if(Usuario.Salud <= 0){
                                Console.WriteLine($"{Usuario.Apodo} Ha sido eliminado");
                                Console.WriteLine($"GAME OVER");
                                Console.ReadLine();
                                break;
                            }
                            Thread.Sleep(3000);
                        }
                        else{
                            dano = ((ListaDePersonajes[0].Destreza * ListaDePersonajes[0].Fuerza * ListaDePersonajes[0].Nivel * random.Next(1, 101)) - (Usuario.Velocidad * Usuario.Armadura)) / 500;
                            Console.WriteLine($"{Usuario.Apodo} Recibe {dano} de daño");
                            Usuario.Salud -= dano;
                            Console.WriteLine($"Salud restante {Usuario.Salud}");
                             if(Usuario.Salud <= 0){
                                Console.WriteLine($"{Usuario.Apodo} Ha sido eliminado");
                                Console.WriteLine($"GAME OVER");
                                Console.ReadLine();
                                break;
                            }
                            dano = ((Usuario.Destreza * Usuario.Fuerza * Usuario.Nivel * random.Next(1,101)) - (ListaDePersonajes[0].Velocidad * ListaDePersonajes[0].Armadura)) / 500;
                            Console.WriteLine($"{ListaDePersonajes[0].Nombre} Recibe {dano} de daño");
                            ListaDePersonajes[0].Salud -= dano;
                            Console.WriteLine($"Salud restante {ListaDePersonajes[0].Salud}");
                            if(ListaDePersonajes[0].Salud <= 0){
                                Console.WriteLine($"{ListaDePersonajes[0].Apodo} Ha sido eliminado");
                                Usuario.Nivel++;
                                Usuario.Fuerza += 1;
                                Usuario.Armadura += 1;
                                Usuario.Velocidad += 1;
                                Usuario.Salud += 20;
                                if(habilidadFlag == 1){
                                    Usuario.undoHabilidad();
                                    habilidadFlag = 0;
                                }
                                if(ListaDePersonajes.Count() > 1){ListaDePersonajes.RemoveAt(0);}
                                else{break;}
                                Console.ReadLine();
                                break;
                            }
                            Thread.Sleep(3000);
                        }
                        break;
                    case 3:
                        if(habilidadFlag == 0){
                            Usuario.Habilidad();
                            habilidadFlag = 1;
                            Thread.Sleep(3000);
                        }
                        else{
                            Console.WriteLine("Solo se puede usar la habilidad una vez por combate");
                            Thread.Sleep(3000);
                            break;
                        }
                        break;
                }
            }
            return ListaDePersonajes;
        }
    }
}