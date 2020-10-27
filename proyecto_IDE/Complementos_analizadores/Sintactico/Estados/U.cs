using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class U : Estado
    {
        Produccion produccion1;
        Produccion produccion2;

        public U() {
            producciones = new Produccion[2];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();
            produccion1.agregarNoTerminal("S");
            produccion1.agregarTerminal("-");            

            produccion2.agregarNoTerminal("S");

            producciones[0] = produccion1;
            producciones[1] = produccion2;
        }
    }
}
