using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Herramientas;
using proyecto_IDE.Objetos_Estudio;

namespace proyecto_IDE.Complementos_analizadores.Generales
{
    class TablaDeSimbolos
    {
        ListaEnlazada<Variable> listadoVariables;//en esta se almacenarán las varoables de un bloque correspondiente, el cual estaba pensando, sería bueno que tuviera una lista por tipo... pero eso haría que el tipo de la variable como tal, esté de más...

        public TablaDeSimbolos() {
            listadoVariables = new ListaEnlazada<Variable>();
        }

        public void agregarVariable(String tipo , String nombre, String valor) {
            Variable variable = new Variable(tipo, nombre, valor);
            listadoVariables.anadirAlFinal(variable);
        }

        //no es necesario crear un método para eliminar la variable, puesto que estamos analizando luego de presionar un botón por lo cual si eliminan ni lo notaría porque según ese tipo de proceso, nunca existió...

        //este método será útil para ASIGNACIÓN... es decir será útil 
        //[esto se hará así String var = buscarYDarVariable(variable.darNombre); xD
        //para cambiar el valor... el único atrib de var que debería cb xd
        //el cuál será empleado por el analizador semi SEMÁNTICO xD
        public Variable buscarYDarVariable(String nombreVariable) { 
            Nodo<Variable> nodoAuxiliar = listadoVariables.darPrimerNodo();

            for (int variableActual = 1; variableActual < listadoVariables.darTamanio(); variableActual++) {
                if (nodoAuxiliar.contenido.darNombre().Equals(nombreVariable)) {
                    return nodoAuxiliar.contenido;
                }

                nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
            }
            return null;
        }

    }
}
