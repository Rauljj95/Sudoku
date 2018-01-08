/*
 * Proyecto Sudoku 
 * Autor: Raúl Jiménez Juárez
 * 
 * Descripción: Este programa te permite jugar al sudoku, cargar y guardar tableros existentes,
 * así como reslver un tablero actual mediante algoritmo de marcha atrás.
 * 
 * Todos los metodos han sido realizados por: Raúl Jiménez Juárez
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Directory.Exists(@Directory.GetCurrentDirectory().ToString() + "\\Tableros") == false)
            {
                DirectoryInfo di = Directory.CreateDirectory(@Directory.GetCurrentDirectory().ToString() + "\\Tableros");
            }
       
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
