using System;
using Espacio.Personajes;
using System.Threading;
namespace Espacio.Combates{
    public class Combate{
        public List<Personaje> Combatir(List<Personaje> ListaDePersonajes, Personaje Usuario){
            int action = 1, dano, habilidadFlag = 0, item = 0;
            Random random = new Random();
            Random ItemSpawn = new Random();
            bool x;
            int[] objetos = new int[3];
            while((ListaDePersonajes[0].Salud > 0) && (Usuario.Salud > 0)){
                Console.Clear();
                Console.WriteLine($"{Usuario.Apodo} vs {ListaDePersonajes[0].Nombre}");
                Console.WriteLine($"{Usuario.Salud} PS  {ListaDePersonajes[0].Salud}");
                if(ListaDePersonajes[0].Tipo == "Boss"){
                    Console.WriteLine("▒▒▒▒▒▒▒▒▒▒▒▄▄▄▄░▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▒▒▒▒▒▄██████▒▒▒▒▒▄▄▄█▄▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▒▒▒▄██▀░░▀██▄▒▒▒▒████████▄▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▒▒███░░░░░░██▒▒▒▒▒▒█▀▀▀▀▀██▄▄▒▒▒");
                    Console.WriteLine("▒▒▒▒▒▄██▌░░░░░░░██▒▒▒▒▐▌▒▒▒▒▒▒▒▒▀█▄▒");
                    Console.WriteLine("▒▒▒▒▒███░░▐█░█▌░██▒▒▒▒█▌▒▒▒▒▒▒▒▒▒▒▀▌");
                    Console.WriteLine("▒▒▒▒████░▐█▌░▐█▌██▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▐████░▐░░░░░▌██▒▒▒█▌▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒████░░░▄█░░░██▒▒▐█▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒████░░░██░░██▌▒▒█▌▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒████▌░▐█░░███▒▒▒█▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▐████░░▌░███▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒▒▒████░░░███▒▒▒▒█▌▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▒▒██████▌░████▒▒▒██▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒▐████████████▒▒███▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("▒█████████████▄████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("██████████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("██████████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("█████████████████▀▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("█████████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("████████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                    Console.WriteLine("████████████████▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
                }
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
                                item = ItemSpawn.Next(1,11);
                                switch(item){
                                    case 1:
                                        Console.WriteLine("Has obtenido una poción de vida (Restaura 35PS)");
                                        objetos[0]++;
                                        break;
                                    case 2:
                                        Console.WriteLine("Has obtenido una poción de habilidad (Puedes volver a usar tu habilidad)");
                                        objetos[1]++;
                                        break;
                                    case 3:
                                        Console.WriteLine("Has obtenido una poción de fuerza (Otorga 1 de fuerza permanente)");
                                        objetos[2]++;
                                        break;
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
                    case 2:
                        Console.WriteLine("Objetos disponibles");
                        Console.WriteLine($"1- Poción de vida ({objetos[0]}) - Restaura 35 de vida");
                        Console.WriteLine($"2- Poción de habilidad ({objetos[1]} - Permite utilizar tu habilidad de nuevo)");
                        Console.WriteLine($"3- Poción de fuerza ({objetos[2]} - Obtiene 1 de fuerza de forma permanente)");
                        x = int.TryParse(Console.ReadLine(), out action);
                        switch(action){
                            case 1:
                                if(objetos[0] > 0){
                                    Console.WriteLine("Has usado una poción de vida");
                                    Console.WriteLine("Has restaurado 35 de salud");
                                    Usuario.Salud += 35;
                                    objetos[0]--;
                                }
                                else{
                                    Console.WriteLine("No tienes pociones de vida");
                                }
                                Thread.Sleep(3000);
                                break;
                            case 2:
                                if(objetos[1] > 0){
                                    if(habilidadFlag == 1){
                                        Console.WriteLine("Has usado una poción de habilidad");
                                        Console.WriteLine("Puedes utilizar tu habilidad nuevamente");
                                        habilidadFlag = 0;
                                        objetos[1]--;
                                    }
                                    else{
                                        Console.WriteLine("Aun no has usado tu habilidad en este combate");
                                    }
                                }
                                else{
                                    Console.WriteLine("No tienes pociones de habilidad");
                                }
                                Thread.Sleep(3000);
                                break;
                            case 3:
                                if(objetos[2] > 0){
                                        Console.WriteLine("Has usado una poción de fuerza");
                                        Console.WriteLine("Has obtenido fuerza permanentemente");
                                        Usuario.Fuerza++;
                                        objetos[2]--;
                                }
                                    else{
                                        Console.WriteLine("No tienes pociones de fuerza");
                                    } 
                                Thread.Sleep(3000);
                                break;
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