using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class O : Estado
    {
        Produccion unica;

        public O() {
            producciones = new Produccion[1];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            unica.agregarNoTerminal("O'");
            unica.agregarNoTerminal("B");
            unica.agregarTerminal(")");
            unica.agregarNoTerminal("N");
            unica.agregarTerminal("(");
            unica.agregarTerminal("SI");

            producciones[0] = unica;
        }

    }
}
