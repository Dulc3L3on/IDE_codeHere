using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class E: NoTerminal
    {
        Produccion unica;

        public E() {//por el hecho de que no puede tener cuerpo [al menos no directamente] y además no puede saber [de manera directa] el resultado del análisis sintáctico [es decir el conjunto de lexemas...]
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = false;//Esto poara que no tenga oportunidad de ser agregado a la lista enlazada...
            contengoCuerpo = false;
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            unica.agregarNoTerminal("E'");
            unica.agregarNoTerminal("O");

            producciones[0] = unica;
        }

    }
}
