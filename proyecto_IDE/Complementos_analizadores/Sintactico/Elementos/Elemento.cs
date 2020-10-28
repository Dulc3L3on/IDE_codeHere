using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Elementos
{
    class Elemento
    {
        String tipo;
        String contenido;

        public void crearNoTerminal(String elemento) {
            tipo = "NoTerminal";
            contenido = elemento;
        }

        public void crearTerminal(String elemento) {
            tipo = "Terminal";
            contenido = elemento;
        }

        public String darTipo() {
            return tipo;
        }

        public String darContenido() {
            return contenido;
        }
    }
}
