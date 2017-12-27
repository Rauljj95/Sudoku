using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            if (Directory.Exists(@Directory.GetCurrentDirectory().ToString() + "\\Tableros") == false)
            {
                DirectoryInfo di = Directory.CreateDirectory(@Directory.GetCurrentDirectory().ToString() + "\\Tableros");
            }
            
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();





            Elementos.TableroSudoku miTablero = null;
            Byte opSec = 0;


            
            while (opcion != 3)
            {
                opcion = 0;
                Console.Clear();
                Console.WriteLine("\n  Menu principal del Sudoku.");
                Console.WriteLine("\n  1.- Crear tablero vacio.");
                Console.WriteLine("\n  2.- Cargar tablero.");
                Console.WriteLine("\n  3.- Salir.\n");

                Console.WriteLine("\n  Opcion: \n");
                int.TryParse(Console.ReadLine(), out opcion);




                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\n\n Tablero generado.\n Pulsa una tecla para continuar.");
                        miTablero = new Elementos.TableroSudoku();
                        break;
                    case 2:
                        miTablero = new Elementos.TableroSudoku();
                        
                        if (miTablero.CargarTablero() == true)
                        {
                            miTablero.ResolverTablero();
                            if(miTablero.ComprobarTablero() == true)
                                Console.WriteLine("\n\n Tablero cargado.\n Pulsa una tecla para continuar.");
                            else
                            {
                                Console.WriteLine("\n\n Este tablero no se puede resolver Cargando tablero en blanco.\n Pulsa una tecla para continuar.");
                                miTablero = new Elementos.TableroSudoku();
                            }

                        }
                        else
                        {
                            Console.WriteLine("\n\n No se pudo cargar el tablero. Generando tablero en blanco.\n pulsa una tecla para continuar.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("\n Salir del programa...\n pulsa una tecla para continuar.");
                        break;
                    default:
                        Console.WriteLine("\n Opcion incorrecta.\n pulsa una tecla para continuar.");
                        break;

                }
                Console.ReadKey();
                       
                if (opcion == 1 || opcion == 2)
                    do
                    {
                        opSec = 0;
                        Console.Clear();
                        if(miTablero.TableroLleno() == true )
                        {
                            if(miTablero.ComprobarTablero() == true)
                            {
                                Console.WriteLine("\n Tablero resuelto.");
                                opSec = 4;
                            }
                            else
                            {
                                Console.WriteLine("\n Corregir valores en rojo para completar el tablero.");
                            }    
                                
                        }
                        miTablero.MostrarTablero();

                        if(opSec != 4)
                            opSec = miTablero.IntroducirCasilla();

                        
                        if (opSec == 1)
                        {
                            Console.WriteLine("\n Datos incorrectos...");
                            Console.WriteLine("\n Pulse una tecla para continuar.\n");
                            Console.ReadKey();
                        }                          
                        else if(opSec == 2)
                        {
                            miTablero.LimpiarTablero();
                            miTablero.ResolverTablero();
                            Console.Clear();
                            miTablero.MostrarTablero();
                            Console.ReadKey();
                        }
                        else if(opSec == 3)
                        {
                            Console.WriteLine("\n Guardar tablero: \n");
                            miTablero.GuardarTablero();
                            Console.WriteLine("\n Pulse una tecla para continuar.\n");
                            Console.ReadKey();
                        }
                        else if(opSec == 4)
                        {
                            Console.WriteLine("\n Volver al menu principal...");
                            Console.WriteLine("\n Pulse una tecla para continuar.\n");

                            Console.ReadKey();

                        }
                        else if(opSec == 5)
                        {
                            miTablero.LimpiarTablero();
                        }
                        else if(opSec == 6)
                        {
                            miTablero.LimpiarErrores();
                        }
                    } while (opSec != 4);

            }
            
         






            Console.ReadKey();
        }

        public static void Menu(out int opcion)
        {
            opcion = 0;



        }
    }
}
