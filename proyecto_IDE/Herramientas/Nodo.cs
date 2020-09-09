using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Herramientas
{
    class Nodo<E>
    {
        public E contenido;
        public Nodo<E> nodoSiguiente;
        private int numeroElementosEnNodo;//esta vriable será útil para el proceso en el cual se almacenan las propiedades, por el hecho de saber el número de elementos que debe
                                          //poseer del grupo para comenzar a construir y saber que tan rico es

        /**
         *ctrctor para 1er elemento es decir, cabeza
         * @param elemento
         */
        public Nodo(E elemento) : this(elemento, null)//aquí es donde se hace la llamada al 2do constructor...
        {
        }

        /**
         *ctrctor para nodos addi a la cabeza
         * @param elemento
         * @param siguiente 
         */
        public Nodo(E elemento, Nodo<E> siguiente)
        {//a ver si no te da problema el nodo por no estar especigicando su tipo... puesto que esta clase es genérica y aquí estas creando uno sin saber, asi que creo que debería de  especificarselo
            contenido = elemento;
            nodoSiguiente = siguiente;
        }

        public void reestablecerContenido(E contenidoNuevo)
        {
            contenido = contenidoNuevo;
        }

        public void reestablecerNodoSiguiente(E contenido)
        {
            Nodo<E> nodoAuxiliar = nodoSiguiente;

            nodoSiguiente = new Nodo<E>(contenido, nodoAuxiliar);//y aspi preservo todo lo que ese nodo antiguo sigueinte acarrea xD
        }//este es para reestablecer teniendo el contenido y el de abajo teniendo de una vez el nodo :v

        public void establecerSiguiente(Nodo<E> siguiente)
        {
            nodoSiguiente = siguiente;
        }

        public E obtenerObjectcEnCasilla()
        {//no será necesario el índice?? para hacer ref a uno específico y obtener sus respect datos??
            return contenido;
        }

        public Nodo<E> obtenerSiguiente()
        {//Aqupi estas refiriendote al nodo, mas no al objeto que dentro de él está contenido
            return nodoSiguiente;
        }

        public void incrementarNumeroElementosNodo()
        {
            numeroElementosEnNodo++;
        }

        public int obtenerNumeroElementosNodo()
        {
            return numeroElementosEnNodo;
        }
    }
}
