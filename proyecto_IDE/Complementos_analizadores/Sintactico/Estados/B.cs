using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Generales;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos
{
    class B : NoTerminal//recuerda que este será representado por el nodo de la lista que representar el cuerpo de cada método, por lo cual no es necesario crear una lista cuando se caiga en él porque el general [que engloba a todo lo demás, el de principla] estará representado por el nodo de dicha lista, y las démás veces en que se caiga en B, se creará una lista al caer en el NT que la contiene [como L o E...]
    {        
        TablaDeSimbolos tablaDeSimbolos;
        ListaEnlazada<NoTerminal> NoTerminalesBloque;
        //después miras como le add los 2 atrib que se requieren revisar para saber si se debe agrgear al listado o add y además cb de listado... aunque si recuerdas, como B no es un "elemento" de programación
        //sino que representa al bloque que contendrá a dichos elementos, entonces no tendría porqué agregarse a la lista, sino que este represerntaría que debería agregarse una y nada más xD, en el único punto
        //Donde cambiaría [o cambiará xd, depende cómo lo pienses xD] seía al crear el primer bloque... [el qu eva luego del main]

        public B(Boolean esFuncional) {//ouse este boolean, porque la instancia que se encontrará el arreglo para moverse entre filas, solo es un indicador y no se empleará  "como debería" ser
            producciones = new Produccion[1];

            definirProducciones();

            if (esFuncional) {
                tablaDeSimbolos = new TablaDeSimbolos();
                NoTerminalesBloque = new ListaEnlazada<NoTerminal>();//sip debe instanciarse para que cuando llegue la oportunidad solo sea de agregar, además de esta manera se evitarán errores por el hecho de tener que no todas las listas enlazadas serán credas por el mismo NT, ni en la misma jerarquía...
                soyGeneral = false;
                contengoCuerpo = true;                
            }
            nombre = "B";
            nombreCompleto = "Bloque";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();//unica

            producciones[0].agregarNoTerminal("B'");
            producciones[0].agregarTerminal("inicio_Bloque");            
        }

        public void agregarVariable(String tipo , String nombre, String valor) { //creo que sería útil alamacener la fila en la VAR, para saber si ya fue declarada como para permitir du uso... pero eso implicaría ordenar la lista enlazada por número de fila...
            tablaDeSimbolos.agregarVariable(tipo, nombre, valor);        
        }

        public ListaEnlazada<NoTerminal> darNoTerminales() {
            return NoTerminalesBloque;
        }

    }
}
