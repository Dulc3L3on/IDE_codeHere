using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Herramientas
{
    class Pila<T>
    {
        private int tamanio;
        private T[] pila;
        //private ListaEnlazada<>;
        private int indiceTope;

        public Pila(T[] elementosIniciales)
        {            
            pila = elementosIniciales;
            indiceTope = (elementosIniciales.Length-1);
            tamanio = elementosIniciales.Length;
        }

        public bool esVacia()//En este caso sucederá cuando se legue a un $... que estará al final de tooooodos los tkn devueltos por el léxico...
        {          
            return (indiceTope == -1);
        }

        public T desapilar()//se empleará solo para los terminales...     
        {
            if (!esVacia()) {
                T elementoTope = pila[indiceTope];
                indiceTope--;
                return elementoTope;
            } else {
                throw new Exception("La pila está vacia");
            }
        }

        public void apilar(T[] elementos)            
        {
            T[] pilaAuxiliar = pila;
            tamanio = pilaAuxiliar.Length + elementos.Length-1;

            pila = new T[tamanio];//puesto que se comienza a apilar a partir del último...

            for (int ubicacion = 0; ubicacion < (pilaAuxiliar.Length-1); ubicacion++) {//Así se podrá obviar el último elemento...
                pila[ubicacion] = pilaAuxiliar[ubicacion];
            }

            int ubicacionElemento = 0;
            for (int ubicacion = (pilaAuxiliar.Length-1); ubicacion < pila.Length; ubicacion++) {              
                pila[ubicacion] = elementos[ubicacionElemento];

                ubicacionElemento++;
            }
            indiceTope = (pila.Length - 1);                                           
        }

        public T inspeccionarTope()                
        {
            if (esVacia()) {
                throw new Exception("La pila está vacia");
            }    
            return pila [indiceTope];
        }

    }
}
