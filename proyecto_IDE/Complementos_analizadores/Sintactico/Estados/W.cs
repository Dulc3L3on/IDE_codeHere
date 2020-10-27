using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class W: Estado
    {
        Produccion unica;

        public W() {
            producciones = new Produccion[1];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            unica.agregarTerminal(";");
            unica.agregarTerminal(")");
            unica.agregarTerminal("F");
            unica.agregarNoTerminal("(");
            unica.agregarTerminal("imprimir");

            producciones[0] = unica;
        }
    }
}
