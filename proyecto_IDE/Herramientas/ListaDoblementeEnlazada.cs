using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Herramientas
{
    class ListaDoblementeEnlazada<T>
    {
        private NodoDoble<T> primerNodo;//posee el primero objeto puesto que así se sabe de donde partir
        private NodoDoble<T> ultimoNodo;//obtiene el último elemento, el cual de forma directa ayuda a saber si tiene o no elementos
        private String nombreLista;//podría tener nombre,, solo debes pensar como se lo asignarás
        private int tamanioLista = 0;
        private int tamanioFinal;//Esta var será útil para las propiedades, pues esta contiene el número de elementos totales que contiene un grupo, en este caso almacenado en una lista
        T contenidoELiminado;

        public ListaDoblementeEnlazada()
        {
            primerNodo = ultimoNodo = null;
        }

        public void anadirAlFinal(T contenidoNuevo)
        {
            if (primerNodo == null)
            {
                primerNodo = ultimoNodo = new NodoDoble<T>(null, contenidoNuevo, null);//puesto que solo hay 1, por ello el último es el primero y por tanto no hay cabida para anterior o siguiente...
                primerNodo.establecerSiguiente(ultimoNodo);
            }
            else
            {
                NodoDoble<T> nodoAuxiliar = ultimoNodo;
                NodoDoble<T> nuevoNodo = new NodoDoble<T>(nodoAuxiliar, contenidoNuevo, null);
                nodoAuxiliar.establecerSiguiente(nuevoNodo);
                ultimoNodo = nuevoNodo;
                //Esta bien, pero por el hehco de no incluir al primer nodo tendría que poner otra condición, que se exe cuando la lista tenga tamaño 1,
                //para que pueda establecerse el ant del primero y por el hecho de manipular el último siempre, entonces "automáticamente" apunte al nodo
                //siguiente, pero actuaizado xd, si es que se llegaran a agrgar más nodos...

                //o hacer que cuando se cree el primer nodo, de una vez apunte al último nodo actual de ese momento y por lo tanto se actualice cuando se agreguen más... pero tendrí aque probar
                //porque no recuerdo si así funciona´ría las refernecias de c#... creo que sí, por el bucle de abajito, al asignar el valor del 1er nodo y cb el último, se da a notar esto...

                //NodoDoble<T> nodoAuxiliar = primerNodo;

                //while (nodoAuxiliar.nodoSiguiente != null)
                //{
                //    nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
                //}

                //NodoDoble<T> nuevoNodo = new NodoDoble<T>(nodoAuxiliar, contenidoNuevo, null);
                //nodoAuxiliar.establecerSiguiente(nuevoNodo);
                //ultimoNodo = nuevoNodo;
            }//si no funciona, solo descomentas esto y borras lo de arribita y la ref del sig cuando se add el 1er nodo...

            tamanioLista++;
        }
        public void establecerNombreNodoCreado(String nombre)
        {
            ultimoNodo.establecerNombre(nombre);
        }

        public T darUltimaCoincidencia(T contenidoABuscar)
        {
            ListaEnlazada<NodoDoble<T>> listaDeCoincidencias = hallarCoincidencias(contenidoABuscar);

            return listaDeCoincidencias.darUltimoNodo().contenido.contenido;//se devuelve el tipo de contenido como tal que se tenía almacenado... en este caso 

        }

        public void modificarUltimaCoincidencia(T contenido, T contenidoABuscar)
        {
            ListaEnlazada<NodoDoble<T>> listaDeCoincidencias = hallarCoincidencias(contenidoABuscar);
            listaDeCoincidencias.darUltimoNodo().contenido.reestablecerContenido(contenido);//obtnego el nodo último y su contenido que realmente es un nodo para así reasignar su contenido...
        }//Esta bien pero en este momento no quiero reemplazar el nodo que al prinicipo estaba aquí así que...



        public ListaEnlazada<NodoDoble<T>> hallarCoincidencias(T contenidoABuscar)
        {
            NodoDoble<T> nodoAuxiliar = primerNodo;
            ListaEnlazada<NodoDoble<T>> listaCoincidencias = new ListaEnlazada<NodoDoble<T>>();//el nodo almacenará nodos :v xD

            for (int numeroNodoActual = 0; numeroNodoActual < tamanioLista; numeroNodoActual++)
            {
                if (nodoAuxiliar.contenido.Equals(contenidoABuscar))
                {
                    listaCoincidencias.anadirAlFinal(nodoAuxiliar);
                }

                nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
            }

            return listaCoincidencias;
        }

        public void eliminarUltimoNodo()
        {
            if (ultimoNodo != null)
            {
                if (tamanioLista == 1)
                {
                    primerNodo = ultimoNodo = null;
                }
                else
                {
                    NodoDoble<T> nodoAuxiliar = primerNodo;

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

        public NodoDoble<T> darPrimerNodo()
        {
            return primerNodo;
        }

        public NodoDoble<T> darUltimoNodo()
        {
            return ultimoNodo;
        }

        public T darContenidoUltimoNodo()
        {
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
