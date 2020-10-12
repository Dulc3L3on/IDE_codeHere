using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Herramientas;

namespace proyecto_IDE.Analizadores
{
    class AnalizadorSintactico
    {
        // String[] matrizTrancisiones = new String { };
        Buscador buscador = new Buscador();

        public String[] darSugerencias(String porcion) {            
            ListaEnlazada<String> listadoCoincidentes = buscador.hallarCoincidentes(porcion);
            String[] coincidencias = new String[listadoCoincidentes.darTamanio()];
            Nodo<String> nodoAuxiliar = listadoCoincidentes.darPrimerNodo();

            for (int resultado = 1; resultado < listadoCoincidentes.darTamanio(); resultado++) {
                coincidencias[resultado - 1] = nodoAuxiliar.contenido;

                nodoAuxiliar = nodoAuxiliar.nodoSiguiente;
            }
            return coincidencias;//de esta forma no habrá problemas puesto que si la listaEnlazada no tiene tamaño, entonces esto no se exe... xD :) :3
        }


    }
}
