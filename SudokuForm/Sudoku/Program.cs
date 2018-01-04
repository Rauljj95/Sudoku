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
