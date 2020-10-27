using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proyecto_IDE.Complementos_analizadores.Sintactico.Simbolos;

namespace proyecto_IDE.Complementos_analizadores.Sintactico.Estados
{
    class R: Estado
    {
        Produccion unica;

        public R() {
            producciones = new Produccion[1];
            definirProducciones();
        }

        public override void definirProducciones()
        {
            base.definirProducciones();

            unica.agregarTerminal(";");
            unica.agregarTerminal(")");
            unica.agregarTerminal("var");
            unica.agregarTerminal("(");            
            unica.agregarTerminal("leer");

            producciones[0] = unica;
        }

    }
}
