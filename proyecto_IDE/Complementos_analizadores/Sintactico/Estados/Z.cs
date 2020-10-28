using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class Z : NoTerminal
    {
        Produccion produccion1;
        Produccion produccion2;
        Produccion produccion3;

        public Z() {
            producciones = new Produccion[3];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();
            produccion1.agregarTerminal("booleano");

            produccion2.agregarNoTerminal("H");
            produccion2.agregarTerminal("comparacion");
            produccion2.agregarNoTerminal("H");

            produccion2.agregarTerminal("parentesis_Cierre");
            produccion2.agregarNoTerminal("H");
            produccion2.agregarTerminal("comparacion");
            produccion2.agregarNoTerminal("H");
            produccion2.agregarTerminal("parentesis_Apertura");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
            producciones[2] = produccion3;
        }
    }
}
