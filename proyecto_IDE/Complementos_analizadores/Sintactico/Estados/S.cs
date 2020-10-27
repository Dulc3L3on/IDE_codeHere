using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class S : Estado
    {
        Produccion produccion1;
        Produccion produccion2;

        public S() {
            producciones = new Produccion[2];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            produccion1.agregarTerminal(")");
            produccion1.agregarNoTerminal("X");
            produccion1.agregarTerminal("(");

            produccion2.agregarNoTerminal("J");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
        }

    }
}
