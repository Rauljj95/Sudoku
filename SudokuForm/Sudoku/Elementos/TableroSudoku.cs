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
                    this.Insertar(new Casilla(i, j, 0));
                }
            }
        }


        /// <summary>
        /// Borra todas las casillas no estaticas del tablero
        /// </summary>
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

        /// <summary>
        /// Borra todas las casillas incorrectas del tablero
        /// </summary>
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

       

        /// <summary>
        /// Comprueba si hay coincidencias con una casilla en el tablero y es valida
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
                   
                    if (Math.Abs(BuscarCasilla(i, j).Valor) == Math.Abs(BuscarCasilla(fila, columna).Valor) && i != fila && j != columna )
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
        public Boolean ComprobarCasillaValMat(int fila, int columna, int[,] matriz)
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

                    if (Math.Abs(matriz[i, j]) == Math.Abs(matriz[fila, columna]) && i != fila && j != columna)
                        return false;
                }
            }

            //Comprobamos fila

            for (i = 0; i < size; i++)
                if (Math.Abs(matriz[fila, i]) == Math.Abs(matriz[fila, columna]) && i != columna)
                    return false;

            //Comprobamos columna

            for (i = 0; i < size; i++)
                if (Math.Abs(matriz[i, columna]) == Math.Abs(matriz[fila, columna]) && i != fila)
                    return false;

            return true;
        }


        /// <summary>
        /// Comprueba si el tablero esta correctamente resuelto
        /// </summary>
        /// <returns></returns>
        public Boolean ComprobarTablero()
        {
            Nodo<Casilla> aux = primero;
            Boolean fin = true;
            while (aux != null)
            {
                if (ComprobarCasillaVal(aux.GetDato().Fila(), aux.GetDato().Columna()) == false && aux.GetDato().Estatico == false && aux.GetDato().Valor != 0)
                {
                    if (aux.GetDato().Valor > 0)
                        aux.GetDato().Valor *= -1;
                    fin = false;
                }
                else if(ComprobarCasillaVal(aux.GetDato().Fila(), aux.GetDato().Columna()) == false && aux.GetDato().Valor != 0)
                    fin = false;

                aux = aux.GetSiguiente();
            }
            return fin;
        }


        /// <summary>
        /// Comprueba si el tablero esta lleno
        /// </summary>
        /// <returns></returns>
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
        public Boolean TableroLlenoMat(int[,] matriz)
        {
        
            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matriz[i, j] == 0)
                        return false;
                }                 
            }

            return true;
        }


        /// <summary>
        /// Resuelve un tablero de Sudoku mediante algoritmo de marcha atras
        /// </summary>
        public void ResolverTablero(int f, int c)
        {
            int[,] matriz = ObtenerMatriz();

            ResolverTableroRec(f, c, matriz);
            int i = 0, j = 0;
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size; j++)
                {
                   BuscarCasilla(i, j).Valor = matriz[i, j];
                }
            }
        }


        public void ResolverTableroRec(int f, int c, int[,] matriz)
        {
            int k = 1;

            if (f < 9)
            {
                
                if (matriz[f, c] == 0)
                {
                    while (k <= size)
                    {
                        matriz[f, c] = k;
                        if (ComprobarCasillaValMat(f, c, matriz) == true)
                        {
                            ResolverTableroRec(f + ((c + 1) / 9), (c + 1) % 9,  matriz);
                            if (TableroLlenoMat(matriz) == true)
                                return;
                        }
                        k++;
                    }
                    matriz[f, c] = 0;
                    return;
                }
                else
                    ResolverTableroRec(f + ((c + 1) / 9), (c + 1) % 9, matriz);
            }

            return;
        }


        public int[,] ObtenerMatriz()
        {
            int[,] matriz = new int[size, size];

            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j ++)
                {
                    matriz[i, j] = BuscarCasilla(i, j).Valor;
                }
            }

            return matriz;
        }


        /// <summary>
        /// Carga un tablero desde un fichero xml
        /// </summary>
        /// <returns></returns>
        public Boolean CargarTablero(Stream file)
        {
            int fila = 0, columna = 0, valor = 0;
            
            XmlDocument reader = new XmlDocument();
            reader.Load(file);
            XmlNodeList Casillas = reader.GetElementsByTagName("Casilla");

            foreach (XmlElement nodo in Casillas)
            {
               
                fila = int.Parse(nodo.GetAttribute("Fila"));

                columna = int.Parse(nodo.GetAttribute("Columna"));
                valor = int.Parse(nodo.InnerText);

                if (fila >= 0 && fila < size && columna >= 0 && columna < size && valor > -10 && valor < 10)
                {

                    BuscarCasilla(fila, columna).Valor = valor;
                    BuscarCasilla(fila, columna).Estatico = true;
                }

            }
            /*while (reader.ReadToFollowing("Casilla"))
            {

               
               
                fila = int.Parse(reader.GetAttribute("Fila"));


                columna = int.Parse(reader.GetAttribute("Columna"));

          
                valor = int.Parse.(reader.GetAttribute("Valor"));

                if (fila >= 0 && fila < size && columna >= 0 && columna < size && valor > -10 && valor < 10)
                {
                  
                    BuscarCasilla(fila, columna).Valor = valor;
                    BuscarCasilla(fila, columna).Estatico = true;
                }
            }*/

            if (primero == null)
                return false;

            Nodo<Casilla> aux = primero;
            while(aux != null)
            {
                if(ComprobarCasillaVal(aux.GetDato().Fila(), aux.GetDato().Columna()) == false)
                {
                    aux.GetDato().Estatico = false;
                }

                aux = aux.GetSiguiente();
            }


           
            return true;
        }



        /// <summary>
        /// Te genera un tablero aleatorio
        /// </summary>
        /// <param name="dificultad"></param>
        public void GenerarTablero(int dificultad)
        {
            Random rnd = new Random();
            int fila = 0, columna = 0;
            try
            {


                for (int i = 1; i < dificultad; i++)
                {

                    do
                    {
                        fila = rnd.Next(0, 700) % 8;
                        columna = rnd.Next(0, 700) % 8;
                        System.Windows.Forms.Application.DoEvents();
                    } while (BuscarCasilla(fila, columna).Valor != 0);
                    BuscarCasilla(fila, columna).Estatico = true;

                    System.Windows.Forms.Application.DoEvents();

                    do
                    {
                        BuscarCasilla(fila, columna).Valor = rnd.Next(1, 9);
                        System.Windows.Forms.Application.DoEvents();
                    } while (ComprobarCasillaVal(fila, columna) != true);
                }
            }
            catch
            {
                return;
            }
              
            
        }


        /// <summary>
        /// Guarda el tablero en un fichero xml
        /// </summary>
        /// <returns></returns>
        public Boolean GuardarTablero(Stream file)
        {
            
            XmlTextWriter writer;

            Nodo<Casilla> aux = primero;

            if (aux == null)
                return false;
           
            writer = new XmlTextWriter(file, Encoding.UTF8);

            writer.Formatting = Formatting.Indented;
            writer.WriteStartDocument(false);
            this.ComprobarTablero();
            //this.LimpiarErrores();
            
            writer.WriteStartElement("Tablero");
            while(aux != null)
            {
                if (aux.GetDato().Valor != 0)
                {
                    writer.WriteStartElement("Casilla");


                    writer.WriteAttributeString("Fila", XmlConvert.ToString(aux.GetDato().Fila()));
                    writer.WriteAttributeString("Columna", XmlConvert.ToString(aux.GetDato().Columna()));
                    writer.WriteString(aux.GetDato().Valor.ToString());
                    writer.WriteEndElement();
                }
                aux = aux.GetSiguiente();
            }
            
            writer.WriteEndElement();
            writer.Flush();
            writer.WriteEndDocument();
            writer.Close();

            return true;
        }


       
    }
}
