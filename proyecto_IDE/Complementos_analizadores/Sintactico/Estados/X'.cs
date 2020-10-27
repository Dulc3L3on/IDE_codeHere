using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class X_: Estado
    {
        Produccion produccion1;
        Produccion produccion2;
        Produccion produccion3;

        public X_() {
            producciones = new Produccion[3];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();
            produccion1.agregarNoTerminal("T");
            produccion1.agregarTerminal("+");

            produccion2.agregarNoTerminal("T");
            produccion2.agregarTerminal("-");

            produccion3.agregarTerminal("e");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
            producciones[2] = produccion3;
        }
    }
}
