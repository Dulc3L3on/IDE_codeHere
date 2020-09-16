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
        private int tamanioLista=0;
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
        public void establecerNombreNodoCreado(String nombre) {
            ultimoNodo.establecerNombre(nombre);
        }

        public T darUltimaCoincidencia(T contenidoABuscar)
        {
            ListaEnlazada<Nodo<T>> listaDeCoincidencias = hallarCoincidencias(contenidoABuscar);

            return listaDeCoincidencias.darUltimoNodo().contenido.contenido;//se devuelve el tipo de contenido como tal que se tenía almacenado... en este caso 

        }

        public void modificarUltimaCoincidencia(T contenido,T contenidoABuscar) {
            ListaEnlazada<Nodo<T>> listaDeCoincidencias = hallarCoincidencias(contenidoABuscar);
            listaDeCoincidencias.darUltimoNodo().contenido.reestablecerContenido(contenido);//obtnego el nodo último y su contenido que realmente es un nodo para así reasignar su contenido...
        }//Esta bien pero en este momento no quiero reemplazar el nodo que al prinicipo estaba aquí así que...



        public ListaEnlazada<Nodo<T>> hallarCoincidencias(T contenidoABuscar) {
            Nodo<T> nodoAuxiliar = primerNodo;
            ListaEnlazada<Nodo<T>> listaCoincidencias = new ListaEnlazada<Nodo<T>>();//el nodo almacenará nodos :v xD

            for (int numeroNodoActual=0; numeroNodoActual< tamanioLista; numeroNodoActual++) {
                if (nodoAuxiliar.contenido.Equals(contenidoABuscar)) {
                    listaCoincidencias.anadirAlFinal(nodoAuxiliar);
                }

                nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
            }

            return listaCoincidencias;
        }

        public void eliminarUltimoNodo() {
            if (ultimoNodo!=null) {
                if (tamanioLista == 1)
                {
                    primerNodo = ultimoNodo = null;
                }
                else
                {
                    Nodo<T> nodoAuxiliar = primerNodo;

                    for (int nodoActual = 1; nodoActual < (tamanioLista - 1); nodoActual++)//debe ser -1 puesto que quiero quedarme en el penúltimo nodo para así eliminar al último, además por el hehco de tener antes de comenzar con el ciclo el primer nodo, es necesario que considere el valor al que quiero llegar a sabiendas de que ya llevo adelantado un paso...
                    { //Así cabal se queda en el penúltimo nodo...
                        nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
                    }

                    nodoAuxiliar.nodoSiguiente = null;//bye bye xD GRACIAS POR TUS SERVICIOS... XD
                    ultimoNodo = nodoAuxiliar;//Si la lista tiene 1 solo ele cabal 
                }

                tamanioLista--;
            }            
        }

        public Nodo<T> darPrimerNodo()
        {
            return primerNodo;
        }

        public Nodo<T> darUltimoNodo() {
            return ultimoNodo;
        }

        public T darContenidoUltimoNodo() {
            return ultimoNodo.contenido;
        }

        public Boolean estaVacia()
        {
            return (primerNodo == null);
        }

        public void limpiarLista()
        {//no daría error al estar vacía, solo se estaría redundando...
            primerNodo = ultimoNodo = null;
            tamanioLista = 0;
        }

        public int darTamanio()
        {
            return tamanioLista;
        }

    }
}
