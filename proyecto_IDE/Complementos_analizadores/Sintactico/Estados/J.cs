using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class J: Estado
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

            produccion1.agregarTerminal("var_numero");
            produccion2.agregarTerminal("valor_numero");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
        }

    }
}
