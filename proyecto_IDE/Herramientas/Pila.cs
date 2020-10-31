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
            tamanio = indiceTope + elementos.Length;//no le resto el 1 porque el indice tope posee valores a partir del 0, entonces es como si estuviera eliminando la posición que ocupa el NT que será reemplazado [no tendrás problemas cuando llegue a -1 por el hecho de ya no tener elementos, porque media ve llegue a ese valor, ya no se continuará con el análisis, porque es un indicador de que el proceso ya terminó, sea que se halla terminado bien o no...

            pila = new T[tamanio];//puesto que se comienza a apilar a partir del último...

            for (int ubicacion = 0; ubicacion < indiceTope; ubicacion++) {//No colo "<=" proque así se puede obviar el NT, para que parezca un reemplazo...
                pila[ubicacion] = pilaAuxiliar[ubicacion];
            }

            int ubicacionElemento = 0;
            for (int ubicacion = indiceTope; ubicacion < pila.Length; ubicacion++) {              
                pila[ubicacion] = elementos[ubicacionElemento];//como la cantidad de estos ya está incluida, entonces sin pena puede procesderse a hacer esto, puesto que eso en este punto es lo único que hace falta agregar...

                ubicacionElemento++;
            }
            indiceTope = (pila.Length - 1);                                           
        }

        public T inspeccionarTope()                
        {
            if (esVacia()) {
                return default(T);//es decir null xD, pero nunca debería llegar aquí puesto que al vaciarse,se para todo el proceso xd
            }    
            return pila [indiceTope];
        }

        public int darIndiceTope() {
            return indiceTope;
        }

    }
}
