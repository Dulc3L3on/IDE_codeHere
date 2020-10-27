using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores.Sintactico
{
    class Produccion
    {       
        ListaEnlazada<String> listadoElementos;

        public Produccion() {
            listadoElementos = new ListaEnlazada<String>();
        }

        public void agregarTerminal(String terminal) {       
            listadoElementos.anadirAlFinal(terminal);
            listadoElementos.darUltimoNodo().establecerNombre("terminal");
        }

        public void agregarNoTerminal(String noTerminal) {
            listadoElementos.anadirAlFinal(noTerminal);
            listadoElementos.darUltimoNodo().establecerNombre("terminal");
        }

        public ListaEnlazada<String> darElementosProduccion() {
            return listadoElementos;
        }

        

    }
}
