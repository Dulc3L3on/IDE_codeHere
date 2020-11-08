using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.ArbolDerivaciones;
using proyecto_IDE.Complementos_analizadores.Sintactico.Elementos;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Complementos_analizadores.Sintactico
{
    class ArbolDeDerivaciones
    {
        private ListaDoblementeEnlazada<Padre> listadoPadres = new ListaDoblementeEnlazada<Padre>();
        private int numeroNodosEnElArbol;
        private bool seguirAnadiendo = true;
        private graph grafo = new graph();

        public ArbolDeDerivaciones(String padreRaiz) {            
            anadirPadre(padreRaiz, 0);
            numeroNodosEnElArbol = 1;//pues el conteo inicia desde 0 [y este ya es el valor para el sigueinte xD], por los requerimientos de graphviz... creo xD
        }

        private Padre darPadreNoEstudiado() { //da el nombre del nodo de la lista que corresponde a aquel nodo al que le corresponda agregar sus producciones [es decir al más reciente para atender...]
            NodoDoble<Padre> nodoAuxiliar = listadoPadres.darUltimoNodo();

            for (int numeroNodo = listadoPadres.darTamanio(); numeroNodo >=1; numeroNodo--) { //recorrerá la lista de atrás para aedlante
                if (!nodoAuxiliar.contenido.darEstadoEstudio()) {
                    return nodoAuxiliar.contenido;
                }

                nodoAuxiliar = nodoAuxiliar.nodoAnterior;
            }

            seguirAnadiendo = false;
            return null;//cuando devuelva esto es porque se terminó el análisis... xd... por eso creo que nunca debería devolver esto, porque el autómata se encargaría de cerrar el árbol [añadir el nodo de cierre] cuando termine su proceso... es decri cuando al reducir llegue al símbolo de fin xD
            //CORRIGIENDO el comentario de la línea de arriba...NUNCA debe llegar a esto pues solo se exe este métod al existir reemplazos, y como el $ no aparece por un reemplazo, entonces cabal se add los ele de la prod del último NT y ya no se debería asomar por aquí ... entonces JAMÁS debería devolver un null
        }

        private String darIdentificadorPadreReferencia() {//es decir el numero de nodo que corresponde al NT [padre] que será reemplazado en la pila por sus respectivas producciones
            Padre padreReferencia = darPadreNoEstudiado();            

            if (padreReferencia !=null) {
                return Convert.ToString(padreReferencia.darNumeroCreacion()) +"-"+ padreReferencia.darNombre();
            }            
            return "";//aunque jamás nunca debería devolver esto, pues el $ no surge por una producción... y además no se add al árbol...
        }

        public void anadirNodos(Elemento[] elementos) {
            if (seguirAnadiendo) {
                String identificador = darIdentificadorPadreReferencia();

                for (int numeroNodo = 0; numeroNodo < elementos.Length; numeroNodo++)
                {
                    if (elementos[numeroNodo].darTipo().Equals("NoTerminal")) {
                        anadirPadre(elementos[numeroNodo].darContenido(), numeroNodosEnElArbol);
                    }

                    //y aquí el codigo [dentro del método o directo] que graph solicita... donde mandaré el nodo del que partírán los elementos que le voy a enviar...
                    grafo.agregarHijo(identificador, Convert.ToString(numeroNodosEnElArbol) + "-"+ Convert.ToString(elementos[numeroNodo].darContenido()));                   

                    numeroNodosEnElArbol++;
                }
            }            
        }

        private void anadirPadre(String nombrePadre, int numeroCreacion) {
            Padre padre = new Padre(nombrePadre, numeroCreacion);
            listadoPadres.anadirAlFinal(padre);            
        }

        public void terminarArbol() {
            grafo.terminarArbol();
        }

        public void dejarDeAnadir() {
            seguirAnadiendo = false;
        }

        //aqupi el método para llegar a al último NT general no estudiado.. que al parecer siempre será B'...
        public ListaDoblementeEnlazada<Padre> darListaPadres() {
            return listadoPadres;
        }

        public graph darGrafo() {
            return grafo;
        }
    }
}
