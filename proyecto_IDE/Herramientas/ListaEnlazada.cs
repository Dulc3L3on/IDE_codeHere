using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE
{
    class ListaEnlazada<T>
    {
        private Nodo<T> primerNodo;//posee el primero objeto puesto que así se sabe de donde partir
        private Nodo<T> ultimoNodo;//obtiene el último elemento, el cual de forma directa ayuda a saber si tiene o no elementos
        private String nombreLista;//podría tener nombre,, solo debes pensar como se lo asignarás
        private int tamanioLista;
        private int tamanioFinal;//Esta var será útil para las propiedades, pues esta contiene el número de elementos totales que contiene un grupo, en este caso almacenado en una lista
        T contenidoELiminado;

        public ListaEnlazada()
        {
            primerNodo = ultimoNodo = null;
        }

        public void anadirAlFinal(T contenidoNuevo)
        {
            if (primerNodo == null)
            {
                primerNodo = ultimoNodo = new Nodo<T>(contenidoNuevo, null);
            }
            else
            {
                Nodo<T> nodoAuxiliar = primerNodo;

                while (nodoAuxiliar.nodoSiguiente != null)
                {
                    nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
                }

                Nodo<T> nuevoNodo = new Nodo<T>(contenidoNuevo, null);
                nodoAuxiliar.establecerSiguiente(nuevoNodo);
                ultimoNodo = nuevoNodo;
            }

            tamanioLista++;
        }

        public Nodo<T> obtnerPrimerNodo()
        {
            return primerNodo;
        }

        public Boolean estaVacia()
        {
            return (primerNodo == null);
        }

        public void limpiarLista()
        {
            primerNodo = ultimoNodo = null;
            tamanioLista = 0;
        }

        public int darTamanio()
        {
            return tamanioLista;
        }

    }
}
