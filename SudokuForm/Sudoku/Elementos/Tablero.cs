using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Elementos
{
    class Tablero
    {
        protected Nodo<Casilla> primero = null;
        protected Nodo<Casilla> ultimo = null;

        //Tamaño del tablero. Ej: 9x9  - tamaño 9
        protected int size;

        public int Size()
        {
            return this.size;
        }
        public Tablero()
        {
            primero = null;
            ultimo = null;
        }

        public Tablero(int size)
        {
            this.size = size;

        }

        public Boolean Insertar(Casilla c)
        {

            if (Existe(c) == true)
                return false;

            if (primero == null)
            {
                primero = new Nodo<Casilla>(c);
            }
            else if (ultimo == null)
            {
                ultimo = new Nodo<Casilla>(c);
                primero.SetSiguiente(ultimo);
                ultimo.SetAnterior(primero);
            }
            else
            {
                Nodo<Casilla> aux = new Nodo<Casilla>(c);
                ultimo.SetSiguiente(aux);
                aux.SetAnterior(ultimo);
                ultimo = aux;
            }
            return true;
        }

        public Boolean Insertar(int fila, int columna, int valor)
        {
            if (Existe(new Casilla(fila, columna)) == true)
                return false;

            if (primero == null)
            {
                primero = new Nodo<Casilla>(new Casilla(fila, columna, valor));
            }
            else if (ultimo == null)
            {             
                ultimo = new Nodo<Casilla>(new Casilla(fila, columna, valor));
                primero.SetSiguiente(ultimo);
                ultimo.SetAnterior(primero);
            }
            else
            {
                Nodo<Casilla> aux = new Nodo<Casilla>(new Casilla(fila, columna, valor));
                ultimo.SetSiguiente(aux);
                aux.SetAnterior(ultimo);
                ultimo = aux;
            }
            
               
            return true;
        }

        /// <summary>
        /// Comprueba si ext
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Boolean Existe(Casilla c)
        {

            Nodo<Casilla> aux = primero;

            while(aux != null)
            {
                if (aux.GetDato().CasillasIguales(c) == true)
                    return true;

                aux = aux.GetSiguiente();
            }
            return false;
        }

        /// <summary>
        /// Devuelve una casilla con las coordenadas indicadas
        /// </summary>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        public Casilla BuscarCasilla(int fila, int columna)
        {
            Casilla miCas = new Casilla(fila, columna);
            Nodo<Casilla> aux = primero;

            while(aux != null)
            {
                if(aux.GetDato().CasillasIguales(miCas) == true)
                {
                    miCas = aux.GetDato();
                    return miCas;
                }

                aux = aux.GetSiguiente();
            }
                

            return null;
        }

        
    }
}
