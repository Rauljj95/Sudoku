using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Elementos
{
    class Casilla
    {
        private int fila;
        private int columna;
        private int valor;

        //Sirve para indicar las casillas que se cargan del fichero y no se pueden modificar
        private Boolean estatico;
      
        public int Valor { get => valor; set => valor = value; }

        public bool Estatico { get => estatico; set => estatico = value; }

        public int Fila()
        {
            return fila;
        }

        public int Columna()
        {
            return columna;
        }

        public Casilla(int fila, int columna)
        {
            this.fila = fila;
            this.columna = columna;
            valor = 0;
            estatico = false;

        }

        public Casilla(int fila, int columna, int valor)
        {
            this.fila = fila;
            this.columna = columna;
            this.valor = valor;
            estatico = false;
        }

        public Casilla(Casilla c)
        {
            if(c != null)
            {
                fila = c.fila;
                columna = c.columna;
                valor = c.valor;
                estatico = c.estatico;
            }
        } 
        
        public Boolean CasillasIguales(Casilla c)
        {
            return fila == c.fila && columna == c.columna;
        }
           


    }
}
