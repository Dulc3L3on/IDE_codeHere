using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Generales;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos
{
    class B : Estado
    {
        Produccion unica;
        TablaDeSimbolos tablaDeSimbolos;


        public B() {
            producciones = new Produccion[1];
            definirProducciones();
            tablaDeSimbolos = new TablaDeSimbolos();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();
            unica = new Produccion();

            unica.agregarNoTerminal("B'");
            unica.agregarTerminal("{");            

            producciones[0] = unica;
        }

        public void agregarVariable(String tipo , String nombre, String valor) { //creo que sería útil alamacener la fila en la VAR, para saber si ya fue declarada como para permitir du uso... pero eso implicaría ordenar la lista enlazada por número de fila...
            tablaDeSimbolos.agregarVariable(tipo, nombre, valor);        
        }

    }
}
