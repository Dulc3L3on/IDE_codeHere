using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class L : Estado
    {
        Produccion hacer;
        Produccion desde;
        Produccion mientras;

        public L()
        {
            producciones = new Produccion[3];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            hacer.agregarTerminal(")");
            hacer.agregarNoTerminal("N");
            hacer.agregarTerminal("(");
            hacer.agregarTerminal("MIENTRAS");
            hacer.agregarNoTerminal("B");
            hacer.agregarTerminal("HACER");

            desde.agregarNoTerminal("B");
            desde.agregarNoTerminal("J");
            desde.agregarTerminal("INCREMENTO");
            desde.agregarNoTerminal("N");
            desde.agregarTerminal("HASTA");
            desde.agregarNoTerminal("J");
            desde.agregarTerminal("igual");
            desde.agregarNoTerminal("J");
            desde.agregarTerminal("DESDE");

            mientras.agregarNoTerminal("B");
            mientras.agregarTerminal(")");
            mientras.agregarNoTerminal("N");
            mientras.agregarTerminal("(");
            mientras.agregarTerminal("MIENTRAS");

            producciones[0] = hacer;
            producciones[1] = desde;
            producciones[2] = mientras;

        }

    }
}
