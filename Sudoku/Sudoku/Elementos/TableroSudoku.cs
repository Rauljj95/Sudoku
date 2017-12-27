using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace Sudoku.Elementos
{
    class TableroSudoku : Tablero
    {
        public TableroSudoku() : base()
        {
            size = 9;
            int i = 0, j = 0;

            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    this.Insertar(new Casilla(i, j));
                }
            }
        }

        public void LimpiarTablero()
        {
            Nodo<Casilla> aux = primero;

            while(aux != null)
            {
                if (aux.GetDato().Estatico == false)
                    aux.GetDato().Valor = 0;

                aux = aux.GetSiguiente();
            }
        }

        public void LimpiarErrores()
        {
            Nodo<Casilla> aux = primero;

            while (aux != null)
            {
                if (aux.GetDato().Valor < 0)
                    aux.GetDato().Valor = 0;

                aux = aux.GetSiguiente();
            }
        }

        public void MostrarTablero()
        {
            int i = 0, j = 0, k = 0;

            Casilla aux = null;
            Console.Write("\n    ");
            for (i = 0; i < size; i++)
            {
                Console.Write(" " + (i + 1).ToString() + "  ");
            }
            Console.Write("\n    ");
            for (i = 0; i < size * 4 - 1; i++)
            {
                Console.Write("-");
            }
            for (i = 0; i < size; i++)
            {
                Console.Write("\n " + (i + 1).ToString() + " | ");
                for (j = 0; j < size; j++)
                {
                    aux = BuscarCasilla(i, j);
                    if (aux.Valor < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write((-1 * aux.Valor).ToString());
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" | ");
                    }
                    else if (aux.Valor == 0)
                    {
                        Console.Write("  | ");
                    }
                    else
                    {
                        if(aux.Estatico == true)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write((aux.Valor).ToString());
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" | ");
                        }
                        else
                            Console.Write(aux.Valor.ToString() + " | ");
                    }

                }
                Console.Write("\n    ");
                for (k = 0; k < size * 4 - 1; k++)
                {
                    Console.Write("-");
                }
            }


        }

        public Byte IntroducirCasilla()
        {
            int fila = -1, columna = -1, valor = -1;

            Console.WriteLine(" \n ** Para mostrar la solucion introducir: fila: 0, columna: 0, valor: 0");
            Console.WriteLine(" \n ** Para guardar el tablero introducir: fila: 10, columna: 10, valor: 10");
            Console.WriteLine(" \n ** Para volver al menu introducir: fila: 11, columna: 11, valor: 11");
            Console.WriteLine(" \n ** Para limpiar el tablero: fila: 12, columna: 12, valor: 12");
            Console.WriteLine(" \n ** Para limpiar los fallos: fila: 13, columna: 13, valor: 13\n");
            Console.Write("\n Introduce la fila: ");
            int.TryParse(Console.ReadLine(), out fila);

            Console.WriteLine();

            Console.Write("\n Introduce la columna: ");
            int.TryParse(Console.ReadLine(), out columna);

            Console.WriteLine();

            Console.Write("\n Introduce el valor: ");
            int.TryParse(Console.ReadLine(), out valor);

            if (fila == 0 && columna == 0 && valor == 0)
                return 2;

            if (fila == 10 && columna == 10 && valor == 10)
                return 3;

            if (fila == 11 && columna == 11 && valor == 11)
                return 4;

            if (fila == 12 && columna == 12 && valor == 12)
                return 5;

            if (fila == 13 && columna == 13 && valor == 13)
                return 6;

            if (fila < 1 || fila > size || columna < 1 || columna > size || valor < 1 || valor > size)
            {
                return 1;
            }

            if (BuscarCasilla(fila - 1, columna - 1).Estatico == true)
            {
                Console.WriteLine("\n No se puede cambiar esa casilla...");
                return 1;
            }

            BuscarCasilla(fila - 1, columna - 1).Valor = valor;


            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        public Boolean ComprobarCasillaVal(int fila, int columna)
        {
            //Comprobar cuadrante
            int i = 0, j = 0;
            double dSize = size;
            int modulo = (int)Math.Sqrt(Convert.ToDouble(dSize));
            int minFila = fila - (fila % modulo);
            int minCol = columna - (columna % modulo);
           
            for (i = minFila; i < (minFila + modulo); i++)
            {
                for (j = minCol; j < (minCol + modulo); j++)
                {
                   
                    if (Math.Abs(BuscarCasilla(i, j).Valor) == Math.Abs(BuscarCasilla(fila, columna).Valor) && i != fila && j != columna)
                        return false;
                }
            }


            //Comprobamos fila

            for (i = 0; i < size; i++)
                if (Math.Abs(BuscarCasilla(fila, i).Valor) == Math.Abs(BuscarCasilla(fila, columna).Valor) && i != columna)
                    return false;

            //Comprobamos columna

            for (i = 0; i < size; i++)
                if (Math.Abs(BuscarCasilla(i, columna).Valor) == Math.Abs(BuscarCasilla(fila, columna).Valor) && i != fila)
                    return false;



            return true;
        }


        public Boolean ComprobarTablero()
        {
            Nodo<Casilla> aux = primero;
            Boolean fin = true;
            while (aux != null)
            {
                if (ComprobarCasillaVal(aux.GetDato().Fila(), aux.GetDato().Columna()) == false && aux.GetDato().Estatico ==false && aux.GetDato().Valor != 0)
                {
                    aux.GetDato().Valor *= -1;
                    fin = false;
                }
                else if(ComprobarCasillaVal(aux.GetDato().Fila(), aux.GetDato().Columna()) == false && aux.GetDato().Valor != 0)
                    fin = false;

                aux = aux.GetSiguiente();
            }
            return fin;
        }

        public Boolean TableroLleno()
        {

            Nodo<Casilla> aux = primero;

            while (aux != null)
            {
                if (aux.GetDato().Valor == 0)
                    return false;

                aux = aux.GetSiguiente();
            }

            return true;
        }

        public void ResolverTablero()
        {
        
            int i = 0, j = 0, k = 0;
            Console.Clear();
            MostrarTablero();
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                    if (BuscarCasilla(i, j).Valor == 0)
                    {

                        for (k = 1; k <= size && TableroLleno() == false; k++)
                        {
                            BuscarCasilla(i, j).Valor = k;
                            if (ComprobarCasillaVal(i, j) == false)
                                //if (ComprobarTablero() == false)
                            {
                                BuscarCasilla(i, j).Valor = 0;                            
                            }
                            else
                            {
                                ResolverTablero();
                                if (TableroLleno() == true)
                                    return;
                                else
                                    BuscarCasilla(i, j).Valor = 0;
                            }
                        }

                        if (k > size || BuscarCasilla(i, j).Valor == 0)
                        {
                            
                            return;
                        }

                           
                    }
                }
            }
        }

        public Boolean CargarTablero()
        {
            int fila = 0, columna = 0, valor = 0;
            string fichero;
            XmlReader reader;

            DirectoryInfo di = new DirectoryInfo(@Directory.GetCurrentDirectory().ToString() + "\\Tableros");

            if (di.GetFiles().Length == 0)
            {
                Console.WriteLine("\n No existe ningun tablero para cargar. Puedes crear uno con el programa y guardarlo. ");
                return false;
            }

            Console.WriteLine("\n Tablero existentes para cargar:\n");

            foreach (var fi in di.GetFiles("*.xml"))
            {
                Console.WriteLine(fi.Name);
            }


            Console.WriteLine("\n Introduce el nombre del fichero xml (con la extension):");
            fichero = Console.ReadLine();
            reader = new XmlTextReader(@Directory.GetCurrentDirectory().ToString() + "\\Tableros\\" + fichero);

            if (File.Exists(@Directory.GetCurrentDirectory().ToString() + "\\Tableros\\" + fichero) == false)
            {
                Console.WriteLine("\n No existe el fichero.\n");
                reader.Close();
                return false;
            }
            
            while (reader.ReadToFollowing("Casilla"))
            {
                reader.ReadToFollowing("Fila");
                fila = reader.ReadElementContentAsInt();

                reader.ReadToFollowing("Columna");
                columna = reader.ReadElementContentAsInt();

                reader.ReadToFollowing("Valor");
                valor = reader.ReadElementContentAsInt();

                if (fila >= 0 && fila < size && columna >= 0 && columna < size && valor > 0 && valor < 10)
                {
                  
                    BuscarCasilla(fila, columna).Valor = valor;
                    BuscarCasilla(fila, columna).Estatico = true;
                }
            }
            reader.Close();
            if (primero == null)
                return false;
            
           
            return true;
        }

        public Boolean GuardarTablero()
        {
            string nombre;
            XmlTextWriter writer;

            Nodo<Casilla> aux = primero;

            if (aux == null)
                return false;
            DirectoryInfo di = new DirectoryInfo(@Directory.GetCurrentDirectory().ToString() + "\\Tableros");

            if (di.GetFiles().Length > 0)
            {
                Console.WriteLine("\n Tableros existentes (si no quieres sobreescribir selecciona un nombre distinto\n a los existentes\n");

                foreach (var fi in di.GetFiles("*.xml"))
                {
                    Console.WriteLine(fi.Name);
                }

            }
            Console.WriteLine("\n Introduce el nombre del fichero xml para guardar el tablero (con la extension):");
            nombre = Console.ReadLine();
            string ruta = @Directory.GetCurrentDirectory().ToString() + "\\Tableros\\" + nombre;
            writer = new XmlTextWriter(ruta, Encoding.UTF8);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument(false);

            writer.WriteStartElement(nombre);
            writer.WriteStartElement("Tablero");
            while(aux != null)
            {
                writer.WriteStartElement("Casilla");

                writer.WriteStartElement("Fila");
                writer.WriteString(aux.GetDato().Fila().ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Columna");
                writer.WriteString(aux.GetDato().Columna().ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("Valor");
                writer.WriteString(aux.GetDato().Valor.ToString());
                writer.WriteEndElement();

                aux = aux.GetSiguiente();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Flush();
            writer.WriteEndDocument();
            writer.Close();

            return true;
        }


    }
}
