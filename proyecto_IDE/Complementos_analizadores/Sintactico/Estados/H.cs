using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class H : Estado
    {
        Produccion produccion1;
        Produccion produccion2;
        Produccion produccion3;


        public H() {
            producciones = new Produccion[3];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            produccion1.agregarNoTerminal("V");

            produccion2.agregarTerminal("e");

            produccion3.agregarTerminal("boolean");
            produccion3.agregarNoTerminal("G");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
            producciones[2] = produccion3;
        }

    }
}
