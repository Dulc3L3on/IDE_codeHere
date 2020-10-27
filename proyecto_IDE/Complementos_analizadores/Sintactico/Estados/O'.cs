using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class O_: Estado
    {
        Produccion produccion1;
        Produccion produccion2;
        Produccion produccion3;

        public O_() {
            producciones = new Produccion[3];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            produccion1.agregarTerminal("e");

            produccion2.agregarNoTerminal("O'");
            produccion2.agregarNoTerminal("B");
            produccion2.agregarTerminal(")");
            produccion2.agregarNoTerminal("N");
            produccion2.agregarTerminal("(");
            produccion2.agregarTerminal("SI");//tendré que agregarle la alternativa???

            produccion2.agregarNoTerminal("O'");
            produccion2.agregarNoTerminal("B");
            produccion2.agregarTerminal(")");
            produccion2.agregarNoTerminal("N");
            produccion2.agregarTerminal("(");
            produccion2.agregarTerminal("SINO_SI");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
            producciones[2] = produccion3;
        }

    }
}
