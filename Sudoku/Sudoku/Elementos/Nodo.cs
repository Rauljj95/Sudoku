using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Elementos
{
    class Nodo<T>
    {
        private Nodo<T> siguiente = null;
        private Nodo<T> anterior = null;
        private T dato;

        public Nodo(T dato)
        {
            this.dato = dato;
        }


        public Nodo(T dato, Nodo<T> siguiente, Nodo<T> anterior)
        {
            this.dato = dato;
            this.siguiente = siguiente;
            this.anterior = anterior;
        }

        public Nodo<T> GetSiguiente()
        {
            return this.siguiente;
        }

        public Nodo<T> GetAnterior()
        {
            return this.anterior;
        }

        public T GetDato()
        {
            return this.dato;
        }

        public void SetSiguiente(Nodo<T> siguiente)
        {
            this.siguiente = siguiente;
        }

        public void SetAnterior(Nodo<T> anterior)
        {
            this.anterior = anterior;
        }
    }
}
