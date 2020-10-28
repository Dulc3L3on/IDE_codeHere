using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class F: NoTerminal
    {
        Produccion unica;

        public F() {
            producciones = new Produccion[1];
            definirProducciones();
            soyGeneral = false;
            contengoCuerpo = false;
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            unica.agregarNoTerminal("F'");
            unica.agregarNoTerminal("V");

            producciones[0] = unica;
        }

    }
}
