using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class F_: Estado
    {

        Produccion produccion1;
        Produccion produccion2;

        public F_() {
            producciones = new Produccion[2];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            produccion1.agregarNoTerminal("F'");
            produccion1.agregarNoTerminal("V");
            produccion1.agregarNoTerminal("+");

            produccion2.agregarTerminal("e");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
        }
    }
}
