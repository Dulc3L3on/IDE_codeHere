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
        public E() {//por el hecho de que no puede tener cuerpo [al menos no directamente] y además no puede saber [de manera directa] el resultado del análisis sintáctico [es decir el conjunto de lexemas...]
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = true;//Esto poara que no tenga oportunidad de ser agregado a la lista enlazada... PERO por la nueva pensada, si debe colocarse la realidad, es decir que es un general, por la revisada que se debe hacer para que el tk y el elemento de la col o producción encajen...donde dicho ele "solo" aparece cuando llega a este general...
            contengoCuerpo = false;
            nombre = "E";
            nombreCompleto = "Condicional";
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            producciones[0] = new Produccion();

            producciones[0].agregarNoTerminal("E'");
            producciones[0].agregarNoTerminal("O");
        }

    }
}
