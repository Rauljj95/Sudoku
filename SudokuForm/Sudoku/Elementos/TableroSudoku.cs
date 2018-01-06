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
        /// Pide al usuario las coordenadas y el v alor de una casilla y devuelve un numero segun los valores introducidos
        /// </summary>
        /// <returns></returns>
       

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

        /// <summary>
        /// Resuelve un tablero de Sudoku mediante algoritmo de marcha atras
        /// </summary>
        public void ResolverTablero()
        {
            int i = 0, j = 0, k = 0;
            
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
                                BuscarCasilla(i, j).Valor = 0;                            
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
                            return;                        
                    }
                }
            }
        }

        /// <summary>
        /// Carga un tablero desde un fichero xml
        /// </summary>
        /// <returns></returns>
        public Boolean CargarTablero(Stream file)
        {
            int fila = 0, columna = 0, valor = 0;
            
            XmlReader reader = XmlReader.Create(file);

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
            this.LimpiarErrores();
            
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

                writer.WriteEndElement();
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
