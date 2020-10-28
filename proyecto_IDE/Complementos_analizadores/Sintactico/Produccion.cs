using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Elementos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico
{
    class Produccion
    {
        // ListaEnlazada<String> listadoElementos;
        ListaEnlazada<Elemento> listadoElementos;


        public Produccion() {
            listadoElementos = new ListaEnlazada<Elemento>();
        }

        public void agregarTerminal(String terminal) {
            Elemento elemento = new Elemento();
            elemento.crearTerminal(terminal);

            listadoElementos.anadirAlFinal(elemento);

            /*listadoElementos.anadirAlFinal(terminal);
            listadoElementos.darUltimoNodo().establecerNombre("Terminal");*/
        }

        public void agregarNoTerminal(String noTerminal) {
            Elemento elemento = new Elemento();
            elemento.crearNoTerminal(noTerminal);

            listadoElementos.anadirAlFinal(elemento);

            /*listadoElementos.anadirAlFinal(noTerminal);
            listadoElementos.darUltimoNodo().establecerNombre("Noterminal");¨*/
        }

        public ListaEnlazada<Elemento> darElementosProduccion() {
            return listadoElementos;
        }

        

    }
}
